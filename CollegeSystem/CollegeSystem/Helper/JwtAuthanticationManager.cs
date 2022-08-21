using CollegeSystem.Reporisatry;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollegeSystem.Helper
{
    public class JwtAuthanticationManager
    {
        private readonly string key;
        SearchRepo search = new SearchRepo();
        public JwtAuthanticationManager(string key)
        {
            this.key = key;
        }
        public string Authanticate(string email, string password)
        {
            if (search.IsUserExits(email, password) == null) return null;
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
