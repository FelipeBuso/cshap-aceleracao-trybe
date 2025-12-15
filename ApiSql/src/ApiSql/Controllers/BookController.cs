namespace ApiSql.Controller;

using Microsoft.AspNetCore.Mvc;
using ApiSql.Models;
using ApiSql.Repository;
using ApiSql.Cache;
using System.Reflection;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookCashingStore _bookRepository;
    public BookController(BookCashingStore repository)
    {
        _bookRepository = repository;
    }

    [HttpPost]
    public IActionResult AddBook()
    {
        _bookRepository.CacheAddBook();

        return Ok(new { message = "livro criado" });
    }

    [HttpGet("{id}")]

    public IActionResult GetBookById(int id)
    {
        Console.WriteLine($"Livro id: {id}");
        var book = _bookRepository.CacheGetBookById(id);
        // Console.WriteLine(book.ToString());
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}