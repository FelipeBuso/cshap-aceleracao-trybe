namespace AuthenticationApi.Context;

using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

public interface IDatabaseContext
{
    public DbSet<User> Users { get; set; }
    public int SaveChanges();
}