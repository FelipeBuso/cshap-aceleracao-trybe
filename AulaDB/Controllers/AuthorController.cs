namespace AulaDB.Controller;

using AulaDB.Repository;
using AulaDB.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthorController : Controller
{
    protected readonly IAuthorRepository _repository;

    public AuthorController(IAuthorRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] Author author)
    {
        return Created("", _repository.AddAuthor(author));
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        return Ok(_repository.GetAuthors());
    }

    [HttpPut("{authorId}")]
    public IActionResult UpdateAuthor(int authorId, [FromBody] Author author)
    {
        return Ok(_repository.UpdateAuthor(authorId, author));
    }

    [HttpDelete("{authorId}")]
    public IActionResult DeleteAuthor(int authorId)
    {
        _repository.DeleteAuthor(authorId);
        return NoContent();
    }
}