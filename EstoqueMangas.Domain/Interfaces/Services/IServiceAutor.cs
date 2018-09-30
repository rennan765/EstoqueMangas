using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Interfaces.Services.Base;

namespace EstoqueMangas.Domain.Interfaces.Services
{
    public interface IServiceAutor : IService
    {
        IResponse ObterPorIdComMangas(Guid id);
        IEnumerable<IResponse> ListarComMangas();
        IEnumerable<IResponse> ListarPorManga(Guid mangaId);
        IEnumerable<IResponse> ListarPorMangaComMangas(Guid mangaId);
        IResponse ObterPorNome(IRequest request);
        IResponse ObterPorNomeComMangas(IRequest request);
    }
}
