using System.Security.Cryptography.X509Certificates;
using ApiSql.Context;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;
using ApiSql.Cache;
using Microsoft.VisualBasic;

namespace ApiSql.Repository;

public class BookRepository
{
    private readonly IDataBaseContext _context;
    public BookRepository(IDataBaseContext context)
    {
        _context = context;
    }

    public List<Book> GetBookList()
    {
        var query = _context.Books.ToList();
        return query;
    }

    public Book GetBookById(int id)
    {
        return _context.Books
        .Where(e => e.BookId == id)
        .Include(e => e.Author)
        .Include(e => e.Publisher).First();
    }

    public Book Add(Book book)
    {
        _context.Add(book);
        _context.SaveChanges();
        return book;
    }

    public virtual void Update(Book book)
    {
        _context.Update(book);
        _context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var book = _context.Books
        .Include(b => b.Author)
        .Include(b => b.Publisher)
        .Single(b => b.BookId == id);

        _context.Remove(book);
        _context.Remove(book.Author);
        _context.Remove(book.Publisher);
        _context.SaveChanges();
    }



}