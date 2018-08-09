using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryAutor : Repository<Autor, Guid>, IRepositoryAutor
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryAutor(EstoqueMangasContext context) : base(context)
        {
            this._context = context;
        }
        #endregion 

    }
}
