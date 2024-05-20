using Cocona;
using Microsoft.EntityFrameworkCore;
using Toshi.Core.CLI.Parameters;
using Toshi.Core.Shared;

namespace Toshi.Core.CLI;

internal static class CreateDatabaseCommand
{
    internal static void AddCreateDatabaseCommand(this CoconaApp app)
    {
        app.AddCommand("create-db", async (CreateDatabaseParameterSet parameters) =>
        {
            string password = InputUtils.InputSecret("database password");

            string connectionString = $@"
                Server={parameters.Hostname};
                Database={parameters.Database};
                User Id={parameters.User};
                Password={password};
                TrustServerCertificate=True;";

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Something went wrong, connection string wasn't created!");

            var optionsBuilder = new DbContextOptionsBuilder<ToshiDbContext>();
            optionsBuilder.UseNpgsql(
                connectionString, options =>
                {
                    options.UseNetTopologySuite();
                });

            using (var context = new ToshiDbContext(optionsBuilder.Options, parameters.Schema))
            {
                await context.Database.EnsureCreatedAsync();

                Console.WriteLine("Running migrations");
                await context.Database.MigrateAsync();
            }

            Console.WriteLine("Toshi DB created successfully!");
        });
    }
}

