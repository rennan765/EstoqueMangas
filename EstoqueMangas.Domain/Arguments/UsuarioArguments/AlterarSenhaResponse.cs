using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class AlterarSenhaResponse : Response, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Email { get; set; }
        #endregion

        #region Construtores 
        public AlterarSenhaResponse()
        {

        }
        #endregion

        #region Métodos
        public static explicit operator AlterarSenhaResponse(Usuario entidade)
        {
            return new AlterarSenhaResponse()
            {
                Id = entidade.Id,
                Email = entidade.Email.ToString(),
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
        #endregion 
    }
}
