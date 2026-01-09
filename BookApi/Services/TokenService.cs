namespace BookApi.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookApi.Constants;
using BookApi.Models;
using Microsoft.IdentityModel.Tokens;


public class TokenService
{
    public string Generate(User user)
    {


        var tokenHandler = new JwtSecurityTokenHandler();
        var userName = new Claim(ClaimTypes.Name, user.Name);
        var userRole = new Claim(ClaimTypes.Role, user.Role.ToString());
        var claims = new ClaimsIdentity();
        claims.AddClaim(userName);
        claims.AddClaim(userRole);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstant.Secret)),
            SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.Now.AddDays(1),
            Subject = claims,
            Audience = "http://meufront.com",
            Issuer = "Notbook"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}