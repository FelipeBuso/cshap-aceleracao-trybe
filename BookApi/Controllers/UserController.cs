namespace BookApi.Controller;

using BookApi.Models;
using BookApi.Repository;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UserController : Controller
{

    protected readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("signup")]
    public IActionResult Signup([FromBody] User user)
    {
        var createdUser = _repository.SignUp(user);
        if (createdUser == null)
        {
            throw new Exception("User cold not be created");
        }
        UserViewModel userVm = new UserViewModel()
        {
            User = createdUser.Name,
            Token = new TokenService().Generate(user)
        };

        return Created($"/users/{createdUser.UserId}", userVm);
    }




}