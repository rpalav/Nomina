

using DatosNomina.Dtos;
using DatosNomina.Repositorio.Usuario;
using DatosNomina.Seguridad;
using DominioNomina.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NegocioNomina.Servicios.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUsuarioRepositorio usuarioRepositorio, JwtSettings jwtSettings)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthResult> Login(CredencialesDTO credenciales)
        {
            var usuario = await _usuarioRepositorio.Login(credenciales);
            if (usuario != null)
            {
                return GenerarTokenJwt(usuario);
            }
            else
            {
                return new AuthResult { IsLogin = false };
            }
        }

        private AuthResult GenerarTokenJwt(Usuarios user)
        {
            var claims = new[]
            {
                new Claim("id_user", user.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var expiration = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var expirationUnix = ((DateTimeOffset)expiration).ToUnixTimeSeconds();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new AuthResult
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireIn = expirationUnix.ToString(),
                IsLogin = true
            };
        }
    }
}
