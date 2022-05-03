using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        public TokenManager(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> GenerateToken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UserNotFoundException($"User with {userName} username was not found");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenSection = _configuration.GetSection("Tokens").GetSection("JwtToken");

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = GetJwtToken(
                user.Id,
                jwtTokenSection["Token"],
                jwtTokenSection["Issuer"],
                jwtTokenSection["Audience"],
                TimeSpan.FromMinutes(Convert.ToInt32(jwtTokenSection["TokenTimeoutMinutes"])),
                claims.ToArray());
            return tokenHandler.WriteToken(token);
        }
        public static JwtSecurityToken GetJwtToken(
       string username,
       string signingKey,
       string issuer,
       string audience,
       TimeSpan expiration,
       Claim[] additionalClaims = null)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub,username),
            // this guarantees the token is unique
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            if (additionalClaims is not null)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.Add(expiration),
                claims: claims,
                signingCredentials: creds
            );
        }
    }
}