namespace BuildingBlocks.EFCore;

public class MySQLOptions
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
    public ushort? Port { get; set; }
}