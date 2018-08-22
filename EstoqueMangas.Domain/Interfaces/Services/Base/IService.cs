using System;
using EstoqueMangas.Domain.Interfaces.Arguments;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Domain.Interfaces.Services.Base
{
    public interface IService : INotifiable, IDisposable
    {
        IResponse Adicionar(IRequest request);
        IResponse Editar(IRequest request);
        IResponse Excluir(Guid id);
        IResponse ObterPorId(Guid id);
    }
}
