using System;
using EstoqueMangas.Core.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.Entities
{
    public class Edicao : Notifiable
    {
        #region Atributos
        public Guid Id { get; private set; }
        public Guid MangaId { get; private set; }
        public Manga Manga { get; private set; }
        public Guid EditoraId { get; private set; }
        public Editora Editora { get; private set; }
        public string EdicaoManga { get; private set; }
        public int Numero { get; private set; }
        #endregion

        #region Construtores
        public Edicao(Guid id, Guid mangaId, Manga manga, Guid editoraId, Editora editora, string edicaoManga, int numero)
        {
            this.Id = id;
            this.MangaId = mangaId;
            this.Manga = manga;
            this.EditoraId = editoraId;
            this.Editora = editora;
            this.EdicaoManga = edicaoManga;
            this.Numero = numero;

            new AddNotifications<Edicao>(this)
                .IfNull(e => e.Manga, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Mangá"))
                .IfNull(e => e.Editora, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Editora"))
                .IfNullOrEmpty(e => e.EdicaoManga, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Edição do Mangá"))
                .IfNull(e => e.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número da Edição"))
                .IfLowerThan(e => e.Numero, 1, Message.CAMPO_X0_INVALIDO_FAVOR_INSERIR_NUMERO_MAIOR_QUE_X1.ToFormat("Mangá", 0));
        }
        #endregion 
    }
}
