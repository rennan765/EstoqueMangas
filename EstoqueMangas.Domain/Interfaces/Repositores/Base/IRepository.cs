using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EstoqueMangas.Domain.Interfaces.Repositores.Base
{
    public interface IRepository <TEntity, TId>
        where TEntity : class
        where TId : struct 
    {
        IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propriedades);

        IQueryable<TEntity> ListarEOrdenarPor<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool asc = true, params Expression<Func<TEntity, object>>[] propriedades);

        TEntity ObterPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propriedades);

        bool Existe(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Listar(Expression<Func<TEntity, object>>[] propriedades);

        IQueryable<TEntity> ListarOrdenandoPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool asc = true, params Expression<Func<TEntity, object>>[] propriedades);

        TEntity ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] propriedades);

        TEntity Adicionar(TEntity entidade);

        TEntity Editar(TEntity entidade);

        void Remover(TEntity entidade);

        IEnumerable<TEntity> AdicionarLista(IEnumerable<TEntity> listaEntidade);
    }
}
