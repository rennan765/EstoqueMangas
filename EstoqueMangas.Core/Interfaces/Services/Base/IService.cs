using System;
using EstoqueMangas.Core.Interfaces.Arguments;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.Interfaces.Services.Base
{
    public interface IService : INotifiable, IDisposable
    {
        IResponse Adicionar(IRequest request);
        IResponse Editar(IRequest request);
        IResponse Excluir(Guid id);
    }
}
