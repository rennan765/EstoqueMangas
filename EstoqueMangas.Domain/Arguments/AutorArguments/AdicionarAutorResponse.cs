using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class AdicionarAutorResponse : Response, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        #endregion

        #region Métodos
        public static explicit operator AdicionarAutorResponse(Autor entidade)
        {
            return new AdicionarAutorResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.NomeAutor.ToString(),
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
        #endregion 
    }
}
