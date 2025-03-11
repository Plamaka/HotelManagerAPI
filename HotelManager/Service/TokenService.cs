using HotelManager.Interfaces;
using HotelManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<Guest> _userManager;

    public TokenService(IConfiguration config, UserManager<Guest> userManager)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        _userManager = userManager;
    }

    public async Task<string> CreateToken(Guest guest)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, guest.Id.ToString()),
                new Claim(ClaimTypes.Email, guest.Email),
                new Claim(JwtRegisteredClaimNames.Email, guest.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, guest.UserName),
            };

        var userRoles = await _userManager.GetRolesAsync(guest);
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

