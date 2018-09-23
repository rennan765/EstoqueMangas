using System;
using System.Threading.Tasks;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EstoqueMangas.Api.Controllers
{
    /// <summary>
    /// Controller para manipulação de usuários
    /// </summary>
    public class UsuarioController : BaseController
    {
        #region Atributos
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AutenticarUsuarioResponse _usuarioLogado;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor do controller.
        /// </summary>
        public UsuarioController(IServiceUsuario serviceUsuario, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Rota de edição de usuário.
        /// </summary>
        [Route("api/v1/Usuario/Alterar"), HttpPut]
        public async Task<IActionResult> Editar([FromBody]EditarUsuarioRequest request)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceUsuario.Editar(request), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota de exclusão de usuário.
        /// </summary>
        [Route("api/v1/Usuario/Remover/{idUsuario}"), HttpDelete]
        public async Task<IActionResult> Remover(Guid idUsuario)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceUsuario.Excluir(idUsuario), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um usuário pelo ID.
        /// </summary>
        [Route("api/v1/Usuario/ObterPorId/{idUsuario}"), HttpGet]
        public async Task<IActionResult> ObterPorId(Guid idUsuario)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceUsuario.ObterPorId(idUsuario), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para listar todos os usuários.
        /// </summary>
        [Route("api/v1/Usuario/Listar"), HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceUsuario.Listar(), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        private void AtualizarUsuarioLogado()
        {
            this._usuarioLogado = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(_httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value);
        }
        #endregion 
    }
}
