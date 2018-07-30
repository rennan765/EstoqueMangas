using System;
using EstoqueMangas.Core.Arguments.Base;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Arguments;

namespace EstoqueMangas.Core.Arguments
{
    public class EditarUsuarioResponse : ResponseBase, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        #endregion

        #region Construtores
        public EditarUsuarioResponse()
        {

        }
        #endregion

        #region Métodos
        public static explicit operator EditarUsuarioResponse(Usuario entidade)
        {
            return new EditarUsuarioResponse()
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
