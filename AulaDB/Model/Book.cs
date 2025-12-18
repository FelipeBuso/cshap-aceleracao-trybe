namespace AulaDB.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string? Title { get; set; }

    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }


}