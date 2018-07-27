using System;
using System.Collections.Generic;
using EstoqueMangas.Core.Entities.Join;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.Entities
{
    public class Manga : Notifiable
    {
        
        #region Atributos
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public IList<AutorManga> Autores { get; private set; }
        public int AnoLancamento { get; private set; }
        public IList<Edicao> Edicoes { get; private set; }
        #endregion

        #region Construtores
        public Manga(Guid id, string titulo, IList<AutorManga> autores, int anoLancamento, IList<Edicao> edicoes)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autores = autores;
            this.AnoLancamento = anoLancamento;
            this.Edicoes = edicoes;
        }
        #endregion
    }
}
