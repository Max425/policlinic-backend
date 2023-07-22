using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Data.BLL.DTO;
using Data.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PolyclinicBackend.Controllers;

[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Login")]
public class AccountController : Controller
{
    private readonly CredentialService _credentialService;

    public AccountController(CredentialService credentialService)
    {
        _credentialService = credentialService;
    }

    [HttpPost("/token")]
    public IActionResult Token(string username, string password)
    {
        var (identity, id) = GetIdentity(username, password);

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(AuthOptions.ISSUER, AuthOptions.AUDIENCE, notBefore: now,
            claims: identity.Claims, expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new { access_token = encodedJwt, username = identity.Name, Id = id };

        return Json(response);
    }


    private (ClaimsIdentity identity, int id) GetIdentity(string username, string password)
    {
        var person = _credentialService.GetCredential(new CredentialDTO { Login = username, Password = password });
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, person.Login),
            new(ClaimsIdentity.DefaultRoleClaimType, person.Role)
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        return (claimsIdentity, person.OperatorId);
    }

}