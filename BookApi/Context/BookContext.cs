namespace BookApi.Context;

using Microsoft.EntityFrameworkCore;
using BookApi.Models;

public class BookContext : DbContext, IBookContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost,1433;Database=BookStore;User=sa;"
            + "Password=SqlServer123!;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
        .HasOne(b => b.Author)
        .WithMany(a => a.books)
        .HasForeignKey(b => b.AuthorId);
    }
}