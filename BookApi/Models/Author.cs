namespace BookApi.Models;

using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    public int AuthorId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Book>? books { get; set; }
}