using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using E_CommenceAPI.Common;

namespace E_CommenceAPI.Helper
{
    public class AuthenticationManager
    {
        private readonly string _key;

        private readonly Dictionary<string, string> _users = new Dictionary<string, string>()
        { { ECommenceConfigurationManager.GetAuthSettings("username"), ECommenceConfigurationManager.GetAuthSettings("password") } };

        public AuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authenicate(string username, string password)
        {
            if (!_users.Any(a => a.Key == username && a.Value == password))
                return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
