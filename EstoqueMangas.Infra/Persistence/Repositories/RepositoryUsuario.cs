using System;
using System.Linq;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Repositores;

namespace EstoqueMangas.Infra.Persistence.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        #region Propriedades
        private readonly EstoqueMangasContext _context;
        #endregion 

        #region Construtores
        public RepositoryUsuario(EstoqueMangasContext context)
        {
            this._context = context;
        }
        #endregion 

        #region Métodos
        public Usuario ObterPorId(Guid id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Autenticar(string email, string senha)
        {
            return _context.Usuarios.Where(u => u.Email.ToString() == email && u.Senha == senha).First();
        }

        public Usuario Editar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public void Excluir(Guid id)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(id));
            _context.SaveChanges();
        }

        public bool EmailDisponivel(string email)
        {
            return !_context.Usuarios.Any(u => u.Email.ToString() == email);
        }
        #endregion 
    }
}
