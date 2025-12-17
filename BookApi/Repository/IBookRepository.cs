namespace BookApi.Repository;

using BookApi.DTO;
using BookApi.Models;

public interface IBookRepository
{
    Book AddBook(Book book);
    IEnumerable<BookDto> GetBooks();

    Author AddAuthor(Author author);
    IEnumerable<Author> GetAuthors();
}