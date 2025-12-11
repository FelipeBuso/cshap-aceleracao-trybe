namespace ProjetoSql.Database;

using Microsoft.EntityFrameworkCore;
using ProjetoSql.Model;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public MyContext()
    {
    }

    public DbSet<Student> Students { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Verificamos se o banco de dados já foi configurado
        if (!optionsBuilder.IsConfigured)
        {
            // Buscamos o valor da connection string armazenada nas variáveis de ambiente
            var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");
            Console.WriteLine($"connction-string: {connectionString}");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection string not found in environment variables.");
            }
            // Executamos o método UseSqlServer e passamos a connection string a ele
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}