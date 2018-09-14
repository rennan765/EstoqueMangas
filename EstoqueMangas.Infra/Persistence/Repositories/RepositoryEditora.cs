using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryEditora : Repository<Editora, Guid>, IRepositoryEditora
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryEditora(EstoqueMangasContext context) : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
