using System.Security.Claims;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ApiSolcaClase.Helpers.Functions
{
    public class JwtGenerator
    {

        string SecretKey { get; set; }
        string Name { get; set; }
        string Rol { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        int DurationSec { get; set; }


        public JwtGenerator(string SecretKey, string Name, string Rol, string Issuer, string Audience, int DurationSec)
        {
            this.SecretKey = SecretKey;
            this.Name = Name;
            this.Rol = Rol;
            this.Issuer = Issuer;
            this.Audience = Audience;
            this.DurationSec = DurationSec;
        }

        public string GenerateJwt()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definir los reclamos (Claims) para el JWT
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Role, Rol),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Crear el token
            var token = new JwtSecurityToken(
                issuer: Issuer, // Emisor
                audience: Audience, // Audiencia
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(DurationSec), // Tiempo de expiración del token
                signingCredentials: credentials
            );

            // Retornar el token como una cadena
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        //static void Main(string[] args)
        //{
        //    string secretKey = "mi_clave_secreta_123";  // Usa una clave secreta segura en producción
        //    var token = GenerateJwt(secretKey);
        //    Console.WriteLine("JWT generado: " + token);
        //}
    }
}
