namespace BookApi.Controller;

using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("authors")]
public class AuthorController : Controller
{

    protected readonly IBookRepository _repository;

    public AuthorController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Admin only")]
    public IActionResult Add([FromBody] Author author)
    {
        return Created("", _repository.AddAuthor(author));
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.GetAuthors());
    }
}