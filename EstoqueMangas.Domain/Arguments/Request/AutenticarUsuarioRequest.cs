using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments
{
    public class AutenticarUsuarioRequest : Request, IRequest
    {
        #region Propriedades
        public string Email { get; set; }
        public string Senha { get; set; }
        #endregion

        #region Construtores
        public AutenticarUsuarioRequest()
        {
            
        }

        public AutenticarUsuarioRequest(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;
        }
        #endregion
    }
}
