using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace EstoqueMangas.Domain.Entities
{
    public class Edicao : Entity
    {
        #region Propriedades
        public Guid MangaId { get; private set; }
        public Manga Manga { get; private set; }
        public int Numero { get; private set; }
        #endregion

        #region Construtores
        public Edicao()
        {

        }

        public Edicao(Guid mangaId, Manga manga, int numero)
        {
            MangaId = mangaId;
            Manga = manga;
            Numero = numero;

            new AddNotifications<Edicao>(this)
                .IfNull(e => e.Manga, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Mangá"))
                .IfNull(e => e.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número da Edição"))
                .IfLowerThan(e => e.Numero, 1, Message.CAMPO_X0_INVALIDO_FAVOR_INSERIR_NUMERO_MAIOR_QUE_X1.ToFormat("Número da Edição", 0));
        }
        #endregion 
    }
}
