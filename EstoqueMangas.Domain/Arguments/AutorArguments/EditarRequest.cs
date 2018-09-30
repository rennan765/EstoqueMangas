using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class EditarRequest : Request, IRequest
    {
        #region Popriedades
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        #endregion 
    }
}
