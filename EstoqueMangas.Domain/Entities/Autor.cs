using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Domain.Entities
{
    public class Autor : Notifiable
    {
        #region Propriedades 
        public Guid Id { get; private set; }
        public Nome NomeAutor { get; private set; }
        public IList<AutorManga> Mangas { get; private set; }
        #endregion

        #region Construtores
        public Autor(Guid id, Nome nomeAutor)
        {
            this.Id = id;
            this.NomeAutor = nomeAutor;
            this.Mangas = new List<AutorManga>();
        }
        #endregion 
    }
}
