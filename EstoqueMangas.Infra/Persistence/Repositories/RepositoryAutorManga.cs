using System;
using System.Linq;
using System.Linq.Expressions;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryAutorManga : Repository<AutorManga, Guid>, IRepositoryAutorManga
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryAutorManga(EstoqueMangasContext context) : base(context)
        {
            this._context = context;
        }
        #endregion

        #region Métodos
        public AutorManga ObterPorId(Guid autorId, Guid mangaId, params Expression<Func<Entity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entity> ObterPorAutorId(Guid autorId, params Expression<Func<Entity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entity> ObterPorMangaId(Guid mangaId, params Expression<Func<Entity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
