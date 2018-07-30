using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Repositores;

namespace EstoqueMangas.Core.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public Usuario Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
