namespace AulaDB.Repository;

using AulaDB.Models;
using AulaDB.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class AuthorRepository : IAuthorRepository
{
    protected readonly IBookStoreContext _context;

    public AuthorRepository(IBookStoreContext context)
    {
        _context = context;
    }
    public Author AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
        return author;
    }

    public void DeleteAuthor(int AuthorId)
    {
        var myAuthor = _context.Authors.Find(AuthorId);
        if (myAuthor != null)
        {
            _context.Authors.Remove(myAuthor);
            _context.SaveChanges();

        }
    }

    public IEnumerable<Author> GetAuthors()
    {
        return _context.Authors.Include(a => a.Books);
    }

    public Author UpdateAuthor(int AuthorId, Author author)
    {
        var myAuthor = _context.Authors.Find(AuthorId);
        if (myAuthor != null)
        {
            myAuthor.Name = author.Name;
            _context.SaveChanges();

        }
        return myAuthor!;
    }
}