namespace AulaDB.Context;

using Microsoft.EntityFrameworkCore;
using AulaDB.Models;

public interface IBookStoreContext
{

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public int SaveChanges();
}