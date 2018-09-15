using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EstoqueMangas.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Atributos
        private readonly EstoqueMangasContext _context;
        #endregion

        #region Construtores
        public UnitOfWork(EstoqueMangasContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Incializar()
        {
            _context.Database.Migrate();
        }
        #endregion 
    }
}
