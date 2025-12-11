using ProjetoSql.Database;
using ProjetoSql.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new MyContext();
        context.Database.EnsureCreated();
        Console.WriteLine("Insira o nome da pessoa estudante:");
        var name = Console.ReadLine();
        Console.WriteLine("Insira a turma atual da pessoa estudante:");
        var currentClass = Console.ReadLine();
        var student = new Student
        {

            Name = name,
            CurrentClass = currentClass
        };
        context.Students.Add(student);
        context.SaveChanges();
        Console.WriteLine("Pessoa estudante cadastrada com sucesso!");
    }
}
