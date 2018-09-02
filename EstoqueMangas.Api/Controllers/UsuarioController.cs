using System;
using System.Threading.Tasks;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EstoqueMangas.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        #region Atributos
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AutenticarUsuarioResponse _usuarioLogado;
        #endregion

        #region Construtores
        public UsuarioController(IServiceUsuario serviceUsuario, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._serviceUsuario = serviceUsuario;
            this._httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Métodos
        [HttpPut]
        [Route("api/v1/Usuario/Alterar")]
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

        [HttpDelete]
        [Route("api/v1/Usuario/Remover/{idUsuario}")]
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

        [HttpGet]
        [Route("api/v1/Usuario/ObterPorId/{idUsuario}")]
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

        [HttpGet]
        [Route("api/v1/Usuario/Listar")]
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
