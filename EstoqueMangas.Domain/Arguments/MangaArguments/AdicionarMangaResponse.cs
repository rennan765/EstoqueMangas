using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.MangaArguments
{
    public class AdicionarMangaResponse : Response, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public static explicit operator AdicionarMangaResponse(Manga entidade)
        {
            return new AdicionarMangaResponse()
            {
                Id = entidade.Id,
                Titulo = entidade.Titulo,
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
        #endregion
    }
}
