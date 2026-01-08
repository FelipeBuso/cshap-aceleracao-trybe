namespace AuthenticationApi.Repository;

using AuthenticationApi.Models;

public interface IUserRepository
{
    User Add(User user);
    User? GetUserByEmail(string email);
}