using System;
using System.Collections.Generic;
using EstoqueMangas.Core.Arguments;
using EstoqueMangas.Core.Arguments.Base;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Entities.Build;
using EstoqueMangas.Core.Interfaces.Arguments;
using EstoqueMangas.Core.Interfaces.Repositores;
using EstoqueMangas.Core.Interfaces.Repositores.Base;
using EstoqueMangas.Core.Interfaces.Services;
using prmToolkit.NotificationPattern;


namespace EstoqueMangas.Core.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        #region Atributos
        private readonly IRepositoryUsuario _repository;
        #endregion

        #region Construtores
        public ServiceUsuario(IRepository repository)
        {
            this._repository = (IRepositoryUsuario)repository;
        }
        #endregion

        #region Métodos
        public IResponse Autenticar(IRequest request)
        {
            AutenticarUsuarioRequest autenticarUsuarioRequest = (AutenticarUsuarioRequest)request;
            Usuario usuario = null;

            using (var usuarioBuild = new UsuarioBuild(autenticarUsuarioRequest.Email, autenticarUsuarioRequest.Senha))
            {
                usuario = usuarioBuild.BuildAutenticar();
            }

            AddNotifications(usuario);

            if (!IsInvalid())
            {
                usuario = _repository.Autenticar(usuario.Email.EnderecoEmail, usuario.Senha);

                if (!(usuario is null))
                {
                    return (AutenticarUsuarioResponse)usuario;
                }
                else
                {
                    return new ResponseBase(false);
                }
            }
            else
            {
                return new ResponseBase(false);
            }
        }

        public IResponse Adicionar(IRequest request)
        {
            throw new NotImplementedException();
        }

        public IResponse Editar(IRequest request)
        {
            throw new NotImplementedException();
        }

        public IResponse Excluir(Guid id)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
