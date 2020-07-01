using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RapiSolver.Core.DTOs;
using RapiSolver.Infrastructure.Mediatr.User.Query;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;

        public LoginController(IConfiguration configuration, IMediator mediator)
        {
            this.configuration = configuration;
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioDTO usuario)
        {
            var _userInfo = await AutenticarUsuarioAsync(usuario.UserName, usuario.UserPassword);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo), id = _userInfo.UsuarioId });
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<UsuarioDTO> AutenticarUsuarioAsync(string usuario, string password)
        {
            
            var res = await mediator.Send(new Login(usuario, password));
            if (res.UsuarioId != 0) {
                return res;
            }
            else
            {
                return null;
            }

        }

        private string GenerarTokenJWT(UsuarioDTO usuario)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UsuarioId.ToString()),
                new Claim("nick", usuario.UserName)
            };

            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
