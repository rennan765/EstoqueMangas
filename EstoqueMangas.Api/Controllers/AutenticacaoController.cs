using EstoqueMangas.Api.Controllers.Base;
using EstoqueMangas.Api.Security;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EstoqueMangas.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller para autenticação e criação de usuários
    /// </summary>
    public class AutenticacaoController : BaseController
    {
        #region Propriedades
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IHttpContextAccessor _httpContextAcessor;
        #endregion

        #region Construtores
        /// <inheritdoc />
        /// <summary>
        /// Construtor do controller.
        /// </summary>
        public AutenticacaoController(IServiceUsuario serviceUsuario, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
            _httpContextAcessor = httpContextAccessor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Rota para autenticação do usuário.
        /// </summary>
        [Route("api/v1/Autenticacao/Autenticar"), HttpPost, AllowAnonymous]
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

                _httpContextAcessor.HttpContext.User.AddIdentity(identity);

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

        /// <summary>
        /// Rota de alterção de senha
        /// </summary>
        [Route("api/v1/Autenticacao/AlterarSenha"), HttpPost, AllowAnonymous]
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

        /// <summary>
        /// Rota de criação de usuário
        /// </summary>
        [Route("api/v1/Usuario/Adicionar"), HttpPost, AllowAnonymous]
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
