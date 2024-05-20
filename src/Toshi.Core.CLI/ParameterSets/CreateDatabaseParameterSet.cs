using Cocona;

namespace Toshi.Core.CLI.Parameters;

internal class CreateDatabaseParameterSet : ICommandParameterSet
{
    [Option("hostname", ['h'], Description = "Database hostname")]
    public string Hostname { get; set; } = default!;

    [Option("port", ['p'], Description = "Database port.")]
    public int Port { get; set; }

    [Option("user", ['u'], Description = "Specifies the user to log in as on the remote host.")]
    public string User { get; set; } = default!;

    [Option("database", ['d'], Description = "Database Toshi will create tables in.")]
    [HasDefaultValue()]
    public string Database { get; set; } = "toshi";

    [Option("schema", ['s'], Description = "Schema name.")]
    [HasDefaultValue()]
    public string Schema { get; set; } = "toshi";
}
