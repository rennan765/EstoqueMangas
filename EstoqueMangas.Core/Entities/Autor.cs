using System;
using System.Collections.Generic;
using EstoqueMangas.Core.Entities.Join;
using EstoqueMangas.Core.ValueObjects;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.Entities
{
    public class Autor : Notifiable
    {
        #region Atributos 
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
