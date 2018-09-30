using EstoqueMangas.Domain.Arguments.AutorArguments;
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
        protected Autor()
        {
            Mangas = new List<AutorManga>();
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

        public void AdicionarManga(Manga manga)
        {
            Mangas.Add(new AutorManga(manga));
        }

        public void AdicionarMangas(IList<Manga> mangas)
        {
            foreach (var manga in mangas)
            {
                Mangas.Add(new AutorManga(manga));
            }
        }

        public void AdicionarMangas(IList<AutorManga> autoresMangas)
        {
            foreach (var autorManga in autoresMangas)
            {
                Mangas.Add(autorManga);
            }
        }

        public void Editar(EditarAutorRequest request)
        {
            NomeAutor = new Nome(request.PrimeiroNome, request.UltimoNome);

            AddNotifications(NomeAutor);
        }
        #endregion 
    }
}
