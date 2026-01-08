namespace AuthenticationApi.Services;

using System.Security.Claims;
using System.Text;
using AuthenticationApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;



public class TokenGenerator
{
    public string Generate(User user)
    {
        var Secret = TokenConstants.Secret;
        var ExpiresHours = 4;

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = AddClaims(user),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.Now.AddHours(ExpiresHours)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity AddClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Name!));
        claims.AddClaim(new Claim(ClaimTypes.Role, user.Access!));
        return claims;
    }
}