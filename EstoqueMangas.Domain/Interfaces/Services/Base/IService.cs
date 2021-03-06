﻿using EstoqueMangas.Domain.Interfaces.Arguments;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace EstoqueMangas.Domain.Interfaces.Services.Base
{
    public interface IService : INotifiable
    {
        IResponse Adicionar(IRequest request);
        IResponse Editar(IRequest request);
        IResponse Excluir(Guid id);
        IResponse ObterPorId(Guid id);
        IEnumerable<IResponse> Listar();
    }
}
