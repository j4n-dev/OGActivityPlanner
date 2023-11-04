using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OGActivityPlannerAPI.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OGActivityPlannerAPI.Services
{
    /// <summary> Service for managing JWT tokens. </summary>
    public class JwtManagement
    {
        private readonly JwtSettings _jwtSettings;

        /// <summary> Initializes a new instance of the <see cref="JwtManagement"/> class. </summary>
        /// <param name="jwtSettings"> The JWT settings. </param>
        public JwtManagement(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        }

        /// <summary> Generates a JWT token for the specified user. </summary>
        /// <param name="user"> The user for whom the token is generated. </param>
        /// <returns> The JWT token as a string. </returns>
        public string GenerateJwtToken(IdentityUser user)
        {
            if (_jwtSettings == null)
            {
                throw new InvalidOperationException("JWT settings are not configured.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key ?? "");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
