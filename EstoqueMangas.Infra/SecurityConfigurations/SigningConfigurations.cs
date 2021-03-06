﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EstoqueMangas.Infra.SecurityConfigurations
{
    public class SigningConfigurations
    {
        #region Atributos
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        #endregion

        #region Constantes
        private const string SecretKey = "c1f51f42-5727-4d15-b787-c6bbbb645024";
        #endregion

        #region Propriedades
       public SigningCredentials SigningCredentials { get; }
        #endregion

        #region Construtores
        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
        #endregion 
    }
}
