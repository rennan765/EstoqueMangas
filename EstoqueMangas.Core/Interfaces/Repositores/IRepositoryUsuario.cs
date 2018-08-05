using System;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;

namespace EstoqueMangas.Domain.Interfaces.Repositores
{
    public interface IRepositoryUsuario : IRepository
    {
        Usuario ObterPorId(Guid id);
        Usuario Autenticar(string email, string senha);
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        void Excluir(Guid id);
        bool EmailDisponivel(string email);
    }
}
