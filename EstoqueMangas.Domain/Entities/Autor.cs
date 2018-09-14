using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.ValueObjects;
using System.Collections.Generic;

namespace EstoqueMangas.Domain.Entities
{
    public class Autor : Entity
    {
        #region Propriedades 
        public Nome NomeAutor { get; private set; }
        public IList<AutorManga> Mangas { get; private set; }
        #endregion

        #region Construtores
        public Autor()
        {

        }

        public Autor(Nome nomeAutor)
        {
            NomeAutor = nomeAutor;
            Mangas = new List<AutorManga>();

            AddNotifications(NomeAutor);
        }
        #endregion

        #region Métodos
        public void IncluirMangas(IList<AutorManga> mangas)
        {
            Mangas = mangas;
        }
        #endregion 
    }
}
