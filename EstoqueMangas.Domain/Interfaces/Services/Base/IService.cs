﻿using System;
using EstoqueMangas.Domain.Interfaces.Arguments;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Domain.Interfaces.Services.Base
{
    public interface IService
    {
        IResponse Adicionar(IRequest request);
        IResponse Editar(IRequest request);
        IResponse Excluir(Guid id);
    }
}