using BookStoreApi.Models;
using BookStoreApi.Settings;
using MongoDB.Driver;
namespace BookStoreApi.Services;
public class BookService
{
    private readonly IMongoCollection<Book> _books;
    public BookService(MongoDBSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);

        var database = client.GetDatabase(settings.DatabaseName);

        _books = database.GetCollection<Book>(settings.BooksCollectionName);
    }
    public List<Book> Get()
    {
        return _books.Find(book => true).ToList();
    }

    public void Create(Book book)
    {
        _books.InsertOne(book);
    }
}