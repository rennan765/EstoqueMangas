using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Entities.Join;

namespace EstoqueMangas.Domain.Entities.Factory
{
    public class AutorFactory
    {
        #region Propriedades
        public Autor Autor { get; set; }
        public IList<Autor> Autores { get; set; }
        #endregion

        #region Construtores
        public AutorFactory()
        {
            Autores = new List<Autor>();
        }
        #endregion 

        #region Métodos
        public AutorFactory AdicionarMangasEmAutores(IList<AutorManga> autoresMangas)
        {
            foreach (var autor in autoresMangas.Select(am => am.Autor).Distinct().ToList())
            {
                autor.AdicionarMangas(autoresMangas.Where(am => am.AutorId == autor.Id).ToList());

                Autores.Add(autor);
            }

            return this;
        }

        public AutorFactory AdicionarMangasEmAutor(IList<AutorManga> autoresMangas)
        {
            Autor = autoresMangas.Select(am => am.Autor).FirstOrDefault();
            Autor.IncluirMangas(autoresMangas);

            return this;
        }

        public IList<Autor> ListarAutores()
        {
            return Autores;
        }

        public Autor ObterAutor()
        {
            return Autor;
        }
        #endregion
    }
}
