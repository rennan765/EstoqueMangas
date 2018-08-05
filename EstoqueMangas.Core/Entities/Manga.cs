using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Join;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Domain.Entities
{
    public class Manga : Notifiable
    {
        
        #region Propriedades
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

            new AddNotifications<Manga>(this)
                .IfNullOrWhiteSpace(m => m.Titulo);
        }
        #endregion
    }
}
