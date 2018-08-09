using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.ValueObjects;

namespace EstoqueMangas.Domain.Entities
{
    public class Autor : Entity
    {
        #region Propriedades 
        public Nome NomeAutor { get; private set; }
        public IList<AutorManga> Mangas { get; private set; }
        #endregion

        #region Construtores
        public Autor(Nome nomeAutor) : base()
        {
            this.NomeAutor = nomeAutor;
            this.Mangas = new List<AutorManga>();

            AddNotifications(this.NomeAutor);
        }
        #endregion 
    }
}
