namespace BookApi.Repository;

using System.Collections.Generic;

using BookApi.Models;
using BookApi.Context;

public class UserRepository : IUserRepository
{
    protected readonly BookContext _context;

    public UserRepository(BookContext context)
    {
        _context = context;
    }

    public User Get(User user)
    {
        throw new NotImplementedException();
    }


    public User SignUp(User user)
    {
        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
}