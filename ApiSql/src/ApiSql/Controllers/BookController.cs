namespace ApiSql.Controller;

using Microsoft.AspNetCore.Mvc;
using ApiSql.Models;
using ApiSql.Repository;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookRepository _bookRespository;
    public BookController(BookRepository repository)
    {
        _bookRespository = repository;
    }

    [HttpPost]
    public IActionResult AddBook()
    {
        var book = new Book
        {
            Title = "The Divine Comedy",
            Description = "A journey through the infinite torment of Hell",
            Year = 2013,
            Pages = 811,
            Genre = "Drama",
            Author = new Author
            {
                Name = "Dante Alighieri",
                Email = "mail@mail.com"
            },
            Publisher = new Publisher
            {
                Name = "Paradise Publisher"
            }
        };

        _bookRespository.Add(book);

        return Ok(new { message = "livro criado" });
    }
}