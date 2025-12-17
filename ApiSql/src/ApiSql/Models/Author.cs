using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiSql.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }
    public string? Name { get; set; } = null!;
    public string? Email { get; set; }

    [InverseProperty("Author")]
    public ICollection<Book>? Books { get; set; } = null!;
}