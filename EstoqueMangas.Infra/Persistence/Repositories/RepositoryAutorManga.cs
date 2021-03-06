﻿using System;
using System.Linq;
using System.Linq.Expressions;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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
            _context = context;
        }
        #endregion

        #region Métodos
        public AutorManga ObterPorId(Guid autorId, Guid mangaId, params Expression<Func<Entity, object>>[] propriedades)
        {
            var query = _context.AutoresMangas;

            if (propriedades.Any())
            {
                foreach (var propriedade in propriedades)
                {
                    query.Include(propriedade);
                }
            }

            return query
                .FirstOrDefault(am => am.AutorId.ToString() == autorId.ToString() && am.MangaId.ToString() == mangaId.ToString());
        }

        public IQueryable<Entity> ObterPorAutorId(Guid autorId, params Expression<Func<Entity, object>>[] propriedades)
        {
            var query = _context.AutoresMangas.AsQueryable();

            if (propriedades.Any())
            {
                foreach (var propriedade in propriedades)
                {
                    query.Include(propriedade);
                }
            }

            return query.Where(am => am.AutorId.ToString() == autorId.ToString());
        }

        public IQueryable<Entity> ObterPorMangaId(Guid mangaId, params Expression<Func<Entity, object>>[] propriedades)
        {
            var query = _context.AutoresMangas.AsQueryable();

            if (propriedades.Any())
            {
                foreach (var propriedade in propriedades)
                {
                    query.Include(propriedade);
                }
            }

            return query.Where(am => am.MangaId.ToString() == mangaId.ToString());
        }

        public void Remover(Autor autor)
        {
            _context.AutoresMangas.RemoveRange(_context.AutoresMangas.Where(am => am.AutorId == autor.Id).ToList());
        }
        #endregion
    }
}
