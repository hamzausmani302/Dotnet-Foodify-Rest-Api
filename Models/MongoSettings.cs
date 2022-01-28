namespace Dotnet.Models;

public class MongoSettings
{
    public string? ConnectionString { set; get; }
    public string? DatabaseName { set; get; }

    public string? CollectionName { set; get; }
}