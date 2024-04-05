using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EasyControl.Api.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class TokenService
    {
        #region Construtor e Injeção de Dependência
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration){
            _configuration = configuration;
        }
        #endregion

        public string GenerateToken(Usuario usuario){
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["KeySecret"]);

            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                }),
                
                // Pega a data atual e adiciona mais a quantidades de horas definida
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["HoursExpiredToken"])),                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),                
            };            

            SecurityToken token = tokenHandler.CreateToken(tokenDecriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}