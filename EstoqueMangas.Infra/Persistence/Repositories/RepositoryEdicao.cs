using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryEdicao : Repository<Edicao, Guid>, IRepositoryEdicao
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryEdicao(EstoqueMangasContext context) : base(context) 
        {
            this._context = context;
        }
        #endregion 
    }
}
