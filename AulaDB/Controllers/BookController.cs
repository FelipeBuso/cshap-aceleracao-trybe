namespace AulaDB.Controller;

using AulaDB.Repository;
using AulaDB.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    protected readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        return Created("", _repository.AddBook(book));
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(_repository.GetBooks());
    }

    [HttpPut("{bookId}")]
    public IActionResult UpdateBook(int bookId, [FromBody] Book book)
    {
        return Ok(_repository.UpdateBook(bookId, book));
    }

    [HttpDelete("{bookId}")]
    public IActionResult DeleteBook(int bookId)
    {
        _repository.DeleteBook(bookId);
        return NoContent();
    }
}