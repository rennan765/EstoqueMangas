using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Repositores.Base;

namespace EstoqueMangas.Core.Interfaces.Repositores
{
    public interface IRepositoryUsuario : IRepository
    {
        Usuario Autenticar(string email, string senha);
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        bool Excluir(Guid id);
    }
}
