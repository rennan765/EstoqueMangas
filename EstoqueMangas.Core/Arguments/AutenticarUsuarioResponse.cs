using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments
{
    public class AutenticarUsuarioResponse : ResponseBase, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        #endregion

        #region Construtores
        public AutenticarUsuarioResponse()
        {

        }
        #endregion 

        #region Métodos
        public static explicit operator AutenticarUsuarioResponse(Usuario entidade)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
                Mensagem = "Operação realizada com sucesso"
            };
        } 
        #endregion
    }
}
