﻿using prmToolkit.NotificationPattern;
using System;

namespace EstoqueMangas.Domain.Entities.Base
{
    public abstract class Entity : Notifiable
    {
        #region Propriedades
        public Guid Id { get; private set; }
        #endregion

        #region Construtores
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        #endregion 

    }
}
