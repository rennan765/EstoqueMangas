﻿using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;
using System;

namespace EstoqueMangas.Domain.Interfaces.Repositores
{
    public interface IRepositoryUsuario : IRepository<Usuario, Guid>
    {
        
    }
}
