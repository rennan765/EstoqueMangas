using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;
using System;

namespace EstoqueMangas.Domain.Interfaces.Repositores
{
    public interface IRepositoryAutorManga : IRepository<AutorManga, Guid>
    {
        void Remover(Autor autor);
    }
}
