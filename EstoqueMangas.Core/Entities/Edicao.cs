using System;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.Entities
{
    public class Edicao : Notifiable
    {
        #region Atributos
        public Guid Id { get; private set; }
        public Guid MangaId { get; private set; }
        public Manga Manga { get; private set; }
        public Editora Editora { get; private set; }
        public string EdicaoManga { get; private set; }
        public int Numero { get; private set; }
        #endregion

        #region Construtores
        public Edicao(Guid id, Guid mangaId, Manga manga, Editora editora, string edicaoManga, int numero)
        {
            this.Id = id;
            this.MangaId = mangaId;
            this.Manga = manga;
            this.Editora = editora;
            this.EdicaoManga = edicaoManga;
            this.Numero = numero;
        }
        #endregion 
    }
}
