using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace WebAPI_JWT_Authentication_Authorisation.Service
{
    public class LoginCredentials
    {
        private readonly IConfiguration _configuration;
        public LoginCredentials(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string username,string role)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims : claims,
                expires : DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
                signingCredentials : cred

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
