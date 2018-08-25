using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class AlterarSenhaRequest : Request, IRequest
    {
        #region Propriedades
        public string Email { get; set; }
        public string NovaSenha { get; set; }
        #endregion

        #region Construtores
        public AlterarSenhaRequest()
        {

        }
        #endregion 
    }
}
