using System;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Repositores;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        #region Construtores
        public RepositoryUsuario()
        {

        }
        #endregion 

        #region Métodos
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
        #endregion 
    }
}
