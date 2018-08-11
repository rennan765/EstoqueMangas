namespace EstoqueMangas.Domain.Interfaces.Transactions
{
    public interface IUnitOfWork
    {
        void Incializar();
        void Commit();
    }
}
