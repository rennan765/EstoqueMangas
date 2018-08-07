using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;
using Microsoft.EntityFrameworkCore;

namespace EstoqueMangas.Infra.Persistence.Repositories.Base
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity
        where TId : struct
    {
        #region Atributos
        private readonly DbContext _context;
        #endregion

        #region Constutores

        public Repository(DbContext context)
        {
            this._context = context;
        }
        #endregion

        #region Métodos
        public TEntity Adicionar(TEntity entidade)
        {
            _context.Set<TEntity>().Add(entidade);

            return entidade;
        }

        public IEnumerable<TEntity> AdicionarLista(IEnumerable<TEntity> listaEntidade)
        {
            throw new NotImplementedException();
        }

        public TEntity Editar(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public bool Existe(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public IQueryable<TEntity> Listar(Expression<Func<TEntity, object>>[] propriedades)
        {
            var query = _context.Set<TEntity>();

            if (propriedades.Any())
            {
                foreach (var propriedade in propriedades)
                {
                    query.Include(propriedade);
                }
            }

            return query;
        }

        public IQueryable<TEntity> ListarEOrdenarPor<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool asc = true, params Expression<Func<TEntity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ListarOrdenandoPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool asc = true, params Expression<Func<TEntity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propriedades)
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] propriedades)
        {
            if (propriedades.Any())
            {
                return this.Listar(propriedades).FirstOrDefault(e => e.Id.ToString() == id.ToString());
            }
            else
            {
                return _context.Set<TEntity>().Find(id);
            }
        }

        public void Remover(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
        }
        #endregion
    }
}