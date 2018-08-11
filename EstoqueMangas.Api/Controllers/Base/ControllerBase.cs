using System;
using System.Threading.Tasks;
using EstoqueMangas.Domain.Interfaces.Services.Base;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Api.Controllers.Base
{
    public class ControllerBase : Controller
    {
        #region Atributos
        private readonly IUnitOfWork _unit;
        private IService _service;
        #endregion

        #region Construtores
        public ControllerBase(IUnitOfWork unit)
        {
            this._unit = unit;
        }
        #endregion

        #region Métodos
        public async Task<IActionResult> ResponseAsync(object result, IService service)
        {
            this._service = service;

            if (_service.IsValid())
            {
                try
                {
                    _unit.Commit();

                    return Ok(result);
                }
                catch (Exception e)
                {
                    return BadRequest(Message.ERRO_INTERNO.ToFormat(e.Message));
                }
            }
            else
            {
                return BadRequest(new { errors = _service.Notifications });
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (!(_service is null))
            {
                _service.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion 
    }
}
