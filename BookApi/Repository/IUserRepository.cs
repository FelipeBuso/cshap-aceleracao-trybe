namespace BookApi.Repository;

using BookApi.DTO;
using BookApi.Models;

public interface IUserRepository
{
    User SignUp(User user);
    User Get(User user);
}