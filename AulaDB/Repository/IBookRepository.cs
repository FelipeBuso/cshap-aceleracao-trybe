namespace AulaDB.Repository;

using AulaDB.Models;

public interface IBookRepository
{
    Book AddBook(Book book);

    IEnumerable<Book> GetBooks();

    Book UpdateBook(int BookId, Book book);

    void DeleteBook(int BookId);
}