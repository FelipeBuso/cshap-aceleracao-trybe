
namespace ApiSql.Cache;

using ApiSql.Models;
using ApiSql.Repository;
using Microsoft.Extensions.Caching.Memory;


public class BookCashingStore
{
    private readonly IMemoryCache _memoryCache;
    private readonly BookRepository _bookRepository;


    public BookCashingStore(IMemoryCache memoryCache, BookRepository bookRepository)
    {
        _memoryCache = memoryCache;
        _bookRepository = bookRepository;
    }

    private static string GetKey(string key)
    {
        return $"{typeof(Book).Name}:{key}";
    }

    public Book? CacheGetBookById(int bookId)
    {
        var key = GetKey(bookId.ToString());
        var item = _memoryCache.Get<Book>(key);
        if (item == null)
        {
            item = _bookRepository.GetBookById(bookId);
            if (item != null)
            {
                _memoryCache.Set(key, item);
            }
        }
        return item;
    }

    public void CacheAddBook()
    {
        var book = new Book
        {
            Title = "The Divine Comedy",
            Description = "A journey through the infinite torment of Hell",
            Year = 2013,
            Pages = 811,
            Genre = "Drama",
            Author = new Author
            {
                Name = "Dante Alighieri",
                Email = "mail@mail.com"
            },
            Publisher = new Publisher
            {
                Name = "Paradise Publisher"
            }
        };

        _bookRepository.Add(book);
    }
}