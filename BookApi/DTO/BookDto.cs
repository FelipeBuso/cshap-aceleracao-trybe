namespace BookApi.DTO;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookDto
{

    public int BookId { get; set; }
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }

    public string? AuthorName { get; set; }
}