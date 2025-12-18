namespace AulaDB.Repository;

using AulaDB.Models;
using AulaDB.Context;
using System.Collections.Generic;

public class BookRepository : IBookRepository
{
    protected readonly IBookStoreContext _context;

    public BookRepository(IBookStoreContext context)
    {
        _context = context;
    }
    public Book AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public void DeleteBook(int bookId)
    {
        var myBook = _context.Books.Find(bookId);
        if (myBook != null)
        {
            _context.Books.Remove(myBook);
            _context.SaveChanges();

        }
    }

    public IEnumerable<Book> GetBooks()
    {
        return _context.Books;
    }

    public Book UpdateBook(int bookId, Book book)
    {
        var myBook = _context.Books.Find(bookId);
        if (myBook != null)
        {
            myBook.Title = book.Title;
            _context.SaveChanges();

        }
        return myBook!;
    }
}