using System;
using EstoqueMangas.Core.Interfaces.Arguments;
using EstoqueMangas.Core.Interfaces.Services.Base;

namespace EstoqueMangas.Core.Interfaces.Services
{
    public interface IServiceUsuario : IService
    {
        IResponse Autenticar(IRequest request);
    }
}
