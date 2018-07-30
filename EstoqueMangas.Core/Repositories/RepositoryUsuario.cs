using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Repositores;

namespace EstoqueMangas.Core.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool EmailDisponivel(string email)
        {
            throw new NotImplementedException();
        }
    }
}
