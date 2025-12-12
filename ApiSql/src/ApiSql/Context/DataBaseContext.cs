
namespace ApiSql.Context;

using ApiSql.Models;
using Microsoft.EntityFrameworkCore;


public class DataBaseContext : DbContext, IDataBaseContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=api_sql_db;User=sa;" + "Password=SqlServer123!;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
        .HasOne(book => book.Author)
        .WithMany(author => author.Books)
        .HasForeignKey(book => book.AuthorId);

        modelBuilder.Entity<Book>()
        .HasOne(book => book.Publisher)
        .WithMany(publisher => publisher.Books)
        .HasForeignKey(book => book.PublisherId);
    }
}