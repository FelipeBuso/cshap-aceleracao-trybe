
using Xunit;
using ApiSql.Models;
using ApiSql.Repository;
using FluentAssertions;
using System.Linq;

public class TestBook
{

    [Fact]
    public void ShouldCreateABook()
    {
        var _context = new BookTestContext();
        var _repository = new BookRepository(_context);

        var book = new Book
        {
            Title = "A Dance with Dragons",
            Description = "A never end battle",
            Year = 2011,
            Pages = 1016,
            Genre = "Epic Fantasy",
            Author = new Author
            {
                Name = "George R. R. Martin",
                Email = "mail@mail.com"
            },
            Publisher = new Publisher
            {
                Name = "Infinity"
            }
        };

        _repository.Add(book);
        _repository.GetBookList().Count().Should().Be(1);
        _repository.GetBookList().First().Should().Be(book);

    }
}