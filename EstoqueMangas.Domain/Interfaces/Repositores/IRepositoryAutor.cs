using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;

namespace EstoqueMangas.Domain.Interfaces.Repositores
{
    public interface IRepositoryAutor : IRepository<Autor, Guid>
    {
        
    }
}
