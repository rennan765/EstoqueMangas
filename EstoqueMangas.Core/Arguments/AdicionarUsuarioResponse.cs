using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Arguments;

namespace EstoqueMangas.Core.Arguments.Base
{
    public class AdicionarUsuarioResponse : IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        #endregion

        #region Construtores
        public AdicionarUsuarioResponse()
        {

        }
        #endregion

        #region Métodos
        public static explicit operator AdicionarUsuarioResponse(Usuario entidade)
        {
            return new AdicionarUsuarioResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
                Email = entidade.Email.ToString()
            };
        }
        #endregion
    }
}
