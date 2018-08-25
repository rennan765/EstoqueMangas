using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using EstoqueMangas.Api.Controllers.Base;
using EstoqueMangas.Api.Security;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace EstoqueMangas.Api.Controllers
{
    public class AutenticacaoController : BaseController
    {
        #region Propriedades
        private readonly IServiceUsuario _serviceUsuario;
        #endregion

        #region Construtores
        public AutenticacaoController(IServiceUsuario serviceUsuario, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._serviceUsuario = serviceUsuario;
        }
        #endregion

        #region Métodos
        [Route("api/v1/Autenticacao/Autenticar")]
        [HttpPost]
        [AllowAnonymous]
        public object Autenticar([FromBody]AutenticarUsuarioRequest request, [FromServices]TokenConfigurations tokenConfigurations, [FromServices]SigningConfigurations signingConfigurations)
        {
            AutenticarUsuarioResponse response = (AutenticarUsuarioResponse)_serviceUsuario.Autenticar(request);

            if (!(response is null))
            {
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(response.Id.ToString(), "Id"),
                    new[] 
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("Usuario", JsonConvert.SerializeObject(response))
                    }
                );

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    response.Email
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    _serviceUsuario.Notifications
                };
            }
        }

        [Route("api/v1/Autenticacao/AlterarSenha")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AlterarSenha([FromBody]AlterarSenhaRequest request)
        {
            try
            {
                return await ResponseAsync(_serviceUsuario.AlterarSenha(request), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }

        }

        [Route("api/v1/Usuario/Adicionar")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarUsuarioRequest request)
        {
            try
            {
                return await ResponseAsync(_serviceUsuario.Adicionar(request), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }

        }
        #endregion 
    }
}
