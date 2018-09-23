using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.EditoraArguments
{
    public class AdicionarResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Métodos
        public static explicit operator AdicionarResponse(Editora entidade)
        {
            return new AdicionarResponse()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
        #endregion 
    }
}
