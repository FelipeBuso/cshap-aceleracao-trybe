namespace AuthenticationApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using AuthenticationApi.Models;
using AuthenticationApi.Repository;
using AuthenticationApi.DTO;
using AuthenticationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly TokenGenerator _tokenGenerator;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
        _tokenGenerator = new TokenGenerator();
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "levelA")]
    public IActionResult Post()
    {
        var tokenClaims = HttpContext.User.Identity as ClaimsIdentity;
        //Mostrar os dados do tokenClaims
        var claimsList = tokenClaims?.Claims.Select(c => new { c.Type, c.Value });
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(claimsList));

        var name = tokenClaims?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
        var email = tokenClaims?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
        return Created("", new { message = "Rota autorizada", name, email });
    }

    [HttpPost("signup")]
    public IActionResult AddUser([FromBody] User user)
    {
        User userCreated = _repository.Add(user);
        var token = _tokenGenerator.Generate(user);
        return Created("", new { token });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTORequest loginDTO)
    {
        User? existingUser = _repository.GetUserByEmail(loginDTO.Email!);
        if (existingUser == null) return Unauthorized(new { message = "Incorrect e-mail or password" });
        if (existingUser.Password != loginDTO.Password) return Unauthorized(new { message = "Incorrect e-mail or password" });

        var token = _tokenGenerator.Generate(existingUser);
        return Ok(new { token });
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "levelB")]
    public IActionResult Delete()
    {
        return Ok(new { message = "Rota autorizada" });
    }

}
