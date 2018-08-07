using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Interfaces.Services.Base;

namespace EstoqueMangas.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IService
    {
        IResponse Autenticar(IRequest request);
    }
}
