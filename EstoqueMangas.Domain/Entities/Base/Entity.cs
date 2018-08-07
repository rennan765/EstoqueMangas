using System;
using prmToolkit.NotificationPattern;

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
            this.Id = Guid.NewGuid();
        }
        #endregion 

    }
}
