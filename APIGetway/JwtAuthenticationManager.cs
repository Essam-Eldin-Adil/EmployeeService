using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HRMS.APIGetway
{
    public class JwtAuthenticationManager
    {
        private readonly string _apiKey;
        private readonly IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"test","123"},
            {"essam","123"},
        };
        public JwtAuthenticationManager(string key)
        {
            _apiKey = key;
        }
        public string Authenticate(string username, string password)
        {
            if (!_users.Any(c => c.Key == username && c.Value == password))
                return String.Empty;

            JwtSecurityTokenHandler tockenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_apiKey);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tockenHandler.CreateToken(securityTokenDescriptor);
            return tockenHandler.WriteToken(token);
        }
    }
}
