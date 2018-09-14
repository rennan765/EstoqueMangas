using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories.Base;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryUsuario: Repository<Usuario, Guid>, IRepositoryUsuario
    {
        #region Propriedades
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public RepositoryUsuario(EstoqueMangasContext context) : base(context) 
        {
            _context = context;
        }
        #endregion 
    }
}
