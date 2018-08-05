using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments.Base
{
    public class AdicionarUsuarioResponse : ResponseBase, IResponse
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
                Email = entidade.Email.ToString(),
                Mensagem = "Operação realizada com sucesso"
            };
        }
        #endregion
    }
}
