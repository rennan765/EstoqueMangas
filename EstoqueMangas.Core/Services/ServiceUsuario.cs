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
using EstoqueMangas.Core.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

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
            if (!(request is null))
            {
                AutenticarUsuarioRequest autenticarUsuarioRequest = (AutenticarUsuarioRequest)request;
                Usuario usuario = null;

                using (var usuarioBuild = new UsuarioBuild(autenticarUsuarioRequest.Email, autenticarUsuarioRequest.Senha))
                {
                    usuario = usuarioBuild.BuildAutenticar();
                }

                AddNotifications(usuario);

                if (IsValid())
                {
                    usuario = _repository.Autenticar(usuario.Email.EnderecoEmail, usuario.Senha);

                    if (!(usuario is null))
                    {
                        return (AutenticarUsuarioResponse)usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                NotificarRequestNulo();
                return null;
            }
        }

        public IResponse Adicionar(IRequest request)
        {
            if (!(request is null))
            {
                AdicionarUsuarioRequest adicionarUsuarioRequest = (AdicionarUsuarioRequest)request;
                Usuario usuario = null;

                using (var usuarioBuild = new UsuarioBuild(adicionarUsuarioRequest.PrimeiroNome, adicionarUsuarioRequest.UltimoNome, adicionarUsuarioRequest.Email, adicionarUsuarioRequest.DddFixo, adicionarUsuarioRequest.TelefoneFixo, adicionarUsuarioRequest.DddCelular, adicionarUsuarioRequest.TelefoneCelular, adicionarUsuarioRequest.Senha))
                {
                    usuario = usuarioBuild.BuildAdicionar();
                }

                AddNotifications(usuario);

                if (IsValid())
                {
                    if (_repository.EmailDisponivel(usuario.Email.ToString()))
                    {
                        usuario.Adicionar();
                        usuario = _repository.Adicionar(usuario);
                        return (AdicionarUsuarioResponse)usuario;
                    }
                    else
                    {
                        AddNotification("E-mail", "E-mail já cadastrado.");
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                NotificarRequestNulo();
                return null;
            }
        }

        public IResponse Editar(IRequest request)
        {
            if (!(request is null))
            {
                EditarUsuarioRequest editarUsuarioRequest = (EditarUsuarioRequest)request;

                Usuario usuario = _repository.ObterPorId(editarUsuarioRequest.Id);

                if (!(usuario is null))
                {
                    if (_repository.EmailDisponivel(editarUsuarioRequest.Email))
                    {
                        usuario.Editar(editarUsuarioRequest, usuario.Status);
                        AddNotifications(usuario);

                        if(IsValid())
                        {
                            usuario = _repository.Editar(usuario);
                            return (EditarUsuarioResponse)usuario;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        AddNotification("E-mail", "E-mail já cadastrado.");
                        return null;
                    }
                }
                else
                {
                    AddNotification("Usuario", "Usuário não encontrado.");
                    return null;
                }
            }
            else
            {
                NotificarRequestNulo();
                return null;
            }
        }

        public IResponse Excluir(Guid id)
        {
            throw new NotImplementedException();
        } 

        private void NotificarRequestNulo()
        {
            AddNotification("Request", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Request"));
        }
        #endregion
    }
}
