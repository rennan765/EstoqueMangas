using System;
namespace EstoqueMangas.Core.Arguments
{
    public class AutenticarUsuarioRequest
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
