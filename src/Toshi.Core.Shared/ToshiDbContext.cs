using Microsoft.EntityFrameworkCore;

namespace Toshi.Core.Shared;

public class ToshiDbContext : DbContext
{
    private readonly string _defaultSchema = default!;

    public ToshiDbContext()
    {
    }

    public ToshiDbContext(DbContextOptions optionsBuilder, string defaultSchema)
        : base(optionsBuilder)
    {
        _defaultSchema = defaultSchema;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_defaultSchema);
        modelBuilder.HasPostgresExtension("postgis");

        base.OnModelCreating(modelBuilder);
    }
}
