using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.ValueObjects;

namespace EstoqueMangas.Domain.Entities.Build
{
    public class AutorBuild
    {
        #region Propriedades
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public IList<AutorManga> Mangas { get; set; }
        #endregion

        #region Métodos
        public AutorBuild AdicionarNome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            return this;
        }

        public AutorBuild AdicionarMangas(IList<AutorManga> mangas)
        {
            Mangas = mangas;

            return this;
        }

        public Autor BuildAdicionar()
        {
            return new Autor(new Nome(PrimeiroNome, UltimoNome));
        }
        #endregion 
    }
}
