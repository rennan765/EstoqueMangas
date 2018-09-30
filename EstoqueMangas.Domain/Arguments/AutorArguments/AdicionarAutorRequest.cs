using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class AdicionarAutorRequest : Request, IRequest
    {
        #region Propriedades
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        #endregion 
    }
}
