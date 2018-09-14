using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EstoqueMangas.Api.Security
{
    /// <summary>
    /// Signing configurations.
    /// </summary>
    public class SigningConfigurations
    {
        #region Atributos
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        #endregion

        #region Constantes
        private const string SecretKey = "c1f51f42-5727-4d15-b787-c6bbbb645024";
        #endregion

        #region Propriedades
        /// <summary>
        /// Gets the signing credentials.
        /// </summary>
        /// <value>The signing credentials.</value>
        public SigningCredentials SigningCredentials { get; }
        #endregion

        #region Construtores
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstoqueMangas.Api.Security.SigningConfigurations"/> class.
        /// </summary>
        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
        #endregion 
    }
}
