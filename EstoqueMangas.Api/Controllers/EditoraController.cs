using System;
using System.Threading.Tasks;
using EstoqueMangas.Api.Controllers.Base;
using EstoqueMangas.Domain.Arguments.EditoraArguments;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstoqueMangas.Api.Controllers
{
    public class EditoraController : BaseController
    {
        #region Atributos
        private readonly IServiceEditora _serviceEditora;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AutenticarUsuarioResponse _usuarioLogado;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor do controller.
        /// </summary>
        public EditoraController(IServiceEditora serviceEditora, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceEditora = serviceEditora;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Métodos
        [Route("api/v1/Editora/Adicionar"), HttpPost]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarRequest request)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceEditora.Adicionar(request), _serviceEditora);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Route("api/v1/Editora/Alterar"), HttpPut]
        public async Task<IActionResult> Editar([FromBody]EditarRequest request)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceEditora.Editar(request), _serviceEditora);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Route("api/v1/Editora/Remover/{idEditora}"), HttpDelete]
        public async Task<IActionResult> Remover([FromBody]Guid idEditora)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceEditora.Excluir(idEditora), _serviceEditora);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Route("api/v1/Editora/ObterPorId/{idEditora}"), HttpGet]
        public async Task<IActionResult> ObterPorId([FromBody]Guid idEditora)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceEditora.ObterPorId(idEditora), _serviceEditora);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Route("api/v1/Editora/Listar"), HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceEditora.Listar(), _serviceEditora);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        private void AtualizarUsuarioLogado()
        {
            _usuarioLogado = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(_httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value);
        }
        #endregion 
    }
}
