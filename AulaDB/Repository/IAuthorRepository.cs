namespace AulaDB.Repository;

using AulaDB.Models;

public interface IAuthorRepository
{
    Author AddAuthor(Author author);

    IEnumerable<Author> GetAuthors();

    Author UpdateAuthor(int AuthorId, Author author);

    void DeleteAuthor(int AuthorId);
}