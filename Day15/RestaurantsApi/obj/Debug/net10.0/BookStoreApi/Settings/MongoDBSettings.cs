namespace BookStoreApi.Settings;

public class MongoDBSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string BooksCollectionName { get; set; }
}