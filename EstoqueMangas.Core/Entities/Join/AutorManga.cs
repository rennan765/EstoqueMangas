using System;
namespace EstoqueMangas.Core.Entities.Join
{
    public class AutorManga
    {
        #region Atributos 
        public Guid IdManga { get; private set; }
        public Manga Manga { get; private set; }
        public Guid IdAutor { get; private set; }
        public Autor Autor { get; private set; }
        #endregion 
    }
}
