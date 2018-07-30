using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Repositores.Base;

namespace EstoqueMangas.Core.Interfaces.Repositores
{
    public interface IRepositoryUsuario : IRepository
    {
        Usuario Autenticar(string email, string senha);
        Usuario Adicionar(Usuario usuario);
        void Editar(Usuario usuario);
        void Excluir(Guid id);
        bool ExisteEmail(string email);
    }
}
