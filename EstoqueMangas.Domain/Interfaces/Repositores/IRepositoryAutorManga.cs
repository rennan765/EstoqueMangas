using System;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;

namespace EstoqueMangas.Domain.Interfaces.Repositores
{
    public interface IRepositoryAutorManga : IRepository<AutorManga, Guid>
    {
        
    }
}
