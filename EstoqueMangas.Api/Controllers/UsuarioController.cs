using System;
using System.Threading.Tasks;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueMangas.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        #region Atributos
        private readonly IServiceUsuario _serviceUsuario;
        #endregion

        #region Construtores
        public UsuarioController(IServiceUsuario serviceUsuario, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }
        #endregion

        #region Métodos
        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Usuario/ObterPorId/{idUsuario}")]
        public async Task<IActionResult> ObterPorId(Guid idUsuario)
        {
            try
            {
                return await ResponseAsync(_serviceUsuario.ObterPorId(idUsuario), _serviceUsuario);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }
        #endregion 
    }
}
