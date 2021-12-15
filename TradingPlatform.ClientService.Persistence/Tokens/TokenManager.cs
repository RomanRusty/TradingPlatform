using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.EntityExceptions.User;

namespace TradingPlatform.ClientService.Persistence.Tokens
{
    public class TokenManager : ITokenManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public TokenManager(UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration= configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> GenerateToken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);    
            if(user == null)
            {
                throw new UserNotFoundException($"User with {userName} username was not found");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var configurationSection = _configuration.GetSection("Tokens");
            var key = Encoding.ASCII.GetBytes(configurationSection["AuthToken"]);

            string roles = string.Join(",",await _userManager.GetRolesAsync(user));
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, roles)

            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "http://localhost:5002",
                Audience = "https://localhost:5001",
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}