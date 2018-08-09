﻿using System;
using EstoqueMangas.Domain.Entities.Base;

namespace EstoqueMangas.Domain.Entities.Join
{
    public class AutorManga : Entity
    {
        #region Atributos 
        public Guid MangaId { get; private set; }
        public Manga Manga { get; private set; }
        public Guid AutorId { get; private set; }
        public Autor Autor { get; private set; }
        #endregion 
    }
}