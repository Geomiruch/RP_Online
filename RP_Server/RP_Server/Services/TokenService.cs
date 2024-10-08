﻿using Microsoft.IdentityModel.Tokens;
using RP_Server.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RP_Server.Services
{
    public class TokenService
    {
        private const int ExpirationMinutes = 30;
        private readonly ILogger<TokenService> _logger;

        public TokenService(ILogger<TokenService> logger)
        {
            _logger = logger;
        }

        public string CreateToken(ApplicationUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            _logger.LogInformation("JWT Token created");

            return tokenHandler.WriteToken(token);

        }
        public string UpdateToken(string oldToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(oldToken);
            var claims = jwtToken.Claims.ToList();
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            var newToken = CreateJwtToken(claims, CreateSigningCredentials(), expiration);

            _logger.LogInformation("JWT Token updated");

            return tokenHandler.WriteToken(newToken);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration) =>
            new(
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private List<Claim> CreateClaims(ApplicationUser user)
        {
            var jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];

            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }

        public string GetUserRoleFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);

            return roleClaim?.Value;
        }

        public string GetUserNameFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var nameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);

            return nameClaim?.Value;
        }
        public string GetUserEmailFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);

            return emailClaim?.Value;
        }
    }
}
