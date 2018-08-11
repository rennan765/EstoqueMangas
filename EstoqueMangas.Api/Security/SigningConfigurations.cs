using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EstoqueMangas.Api.Security
{
    public class SigningConfigurations
    {
        #region Atributos
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));
        #endregion

        #region Constantes
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";
        #endregion

        #region Propriedades
        public SigningCredentials SigningCredentials { get; }
        #endregion

        #region Construtores
        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256); ;
        }
        #endregion 
    }
}
