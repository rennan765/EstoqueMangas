using System;
using System.Threading.Tasks;
using EstoqueMangas.Api.Controllers.Base;
using EstoqueMangas.Domain.Arguments.AutorArguments;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstoqueMangas.Api.Controllers
{
    /// <summary>
    /// Controller para manipulação de autores
    /// </summary>
    public class AutorController : BaseController
    {
        #region Atributos
        private readonly IServiceAutor _serviceAutor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AutenticarUsuarioResponse _usuarioLogado;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor do controller.
        /// </summary>
        public AutorController(IServiceAutor serviceAutor, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceAutor = serviceAutor;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Rota de criação do autor.
        /// </summary>
        [Route("api/v1/Autor/Adicionar"), HttpPost]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarAutorRequest request)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.Adicionar(request), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota da alteração do autor.
        /// </summary>
        [Route("api/v1/Autor/Editar"), HttpPut]
        public async Task<IActionResult> Editar([FromBody]EditarAutorRequest request)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.Editar(request), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota da exclusão do autor.
        /// </summary>
        [Route("api/v1/Autor/Remover/{idAutor}"), HttpDelete]
        public async Task<IActionResult> Remover(Guid idAutor)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.Excluir(idAutor), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo ID.
        /// </summary>
        [Route("api/v1/Autor/ObterPorId/{idAutor}"), HttpGet]
        public async Task<IActionResult> ObterPorId(Guid idAutor)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ObterPorId(idAutor), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo ID, com os mangás de sua autoria
        /// </summary>
        [Route("api/v1/Autor/ObterPorIdComMangas/{idAutor}"), HttpGet]
        public async Task<IActionResult> ObterPorIdComMangas(Guid idAutor)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ObterPorIdComMangas(idAutor), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para listar todos os autores
        /// </summary>
        [Route("api/v1/Autor/Listar"), HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.Listar(), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para listar todos os autores e os mangás de sua autoria.
        /// </summary>
        [Route("api/v1/Autor/ListarComMangas"), HttpGet]
        public async Task<IActionResult> ListarComMangas()
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ListarComMangas(), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo ID de um mangá de sua autoria.
        /// </summary>
        [Route("api/v1/Autor/ListarPorManga/{idManga}"), HttpGet]
        public async Task<IActionResult> ListarPorManga(Guid idManga)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ListarPorManga(idManga), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo ID de um mangá de sua autoria, com os mangás de sua autoria.
        /// </summary>
        [Route("api/v1/Autor/ListarPorMangaComMangas/{idManga}"), HttpGet]
        public async Task<IActionResult> ListarPorMangaComMangas(Guid idManga)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ListarPorMangaComMangas(idManga), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo nome.
        /// </summary>
        [Route("api/v1/Autor/ObterPorNome/{primeiroNome}/{segundoNome}"), HttpGet]
        public async Task<IActionResult> ObterPorNome(string primeiroNome, string segundoNome)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ObterPorNome(primeiroNome, segundoNome), _serviceAutor);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        /// <summary>
        /// Rota para obter um autor pelo ID, com os mangás de sua autoria
        /// </summary>
        [Route("api/v1/Autor/ObterPorNomeComMangas/{primeiroNome}/{segundoNome}"), HttpGet]
        public async Task<IActionResult> ObterPorNomeComMangas(string primeiroNome, string segundoNome)
        {
            try
            {
                AtualizarUsuarioLogado();

                return await ResponseAsync(_serviceAutor.ObterPorNomeComMangas(primeiroNome, segundoNome), _serviceAutor);
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
