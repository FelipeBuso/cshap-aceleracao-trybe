using ApiSql.Context;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class BookTestContext : DbContext, IDataBaseContext
{
    public virtual DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

        //Criando um instãncia de bd em memória
        optionsBuilder
        .UseInMemoryDatabase("Books")
        .UseInternalServiceProvider(serviceProvider);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.BookId);

        modelBuilder.Entity<Book>()
        .HasOne(b => b.Author)
        .WithMany(a => a.Books)
        .HasForeignKey(b => b.AuthorId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>()
        .HasOne(b => b.Publisher)
        .WithMany(p => p.Books)
        .HasForeignKey(b => b.PublisherId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>()
        .Property(b => b.Title)
        .IsRequired()
        .HasMaxLength(100);
    }


}