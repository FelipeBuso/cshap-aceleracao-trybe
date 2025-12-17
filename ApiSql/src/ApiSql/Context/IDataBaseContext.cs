namespace ApiSql.Context;

using Microsoft.EntityFrameworkCore;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public interface IDataBaseContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Publisher> Publishers { get; set; }
    int SaveChanges();

    EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
    EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
    EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
}