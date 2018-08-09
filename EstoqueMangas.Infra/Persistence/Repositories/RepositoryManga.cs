using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryManga : Repository<Manga, Guid>, IRepositoryManga
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryManga(EstoqueMangasContext context) : base(context)
        {
            this._context = context;
        }
        #endregion 

    }
}
