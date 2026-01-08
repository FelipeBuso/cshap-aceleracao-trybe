namespace auth.Test;

using Microsoft.AspNetCore.Hosting;
using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using AuthenticationApi.Repository;
using AuthenticationApi.Controllers;
using AuthenticationApi.Models;
using Xunit;


public class TestAuthorization
{

    [Theory]
    [InlineData("user", "user@betrybe.com", "1234")]
    public void TestAuthenticateSuccess(string name, string email, string password)
    {
        User userMoq = new User
        {
            Name = name,
            Email = email,
            Password = password,
            Access = ""

        };
        // Configuramos o Mock para retornar o usuário quando o e-mail correto for passado
        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(r => r.GetUserByEmail(email)).Returns(userMoq);

        // Criamos o DTO exatamente como o Controller espera receber via [FromBody]
        var loginRequest = new AuthenticationApi.DTO.LoginDTORequest
        {
            Email = email,
            Password = password
        };


        var response = new UserController(mockRepository.Object).Login(loginRequest);
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.ToString().Should().Contain("token");
    }

}