namespace BookApi.Repository;

using Microsoft.EntityFrameworkCore;
using BookApi.Models;

public interface IBookContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public int SaveChanges();
}