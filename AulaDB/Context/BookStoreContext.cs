namespace AulaDB.Context;

using Microsoft.EntityFrameworkCore;
using AulaDB.Models;

public class BookStoreContext : DbContext, IBookStoreContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;

    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost,1433;Database=Bookstore;User=sa;Password=SqlServer123!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}