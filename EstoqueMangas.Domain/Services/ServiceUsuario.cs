using System;
using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Build;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Domain.Interfaces.Repositores.Base;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Enuns;

namespace EstoqueMangas.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        #region Atributos
        private readonly IRepositoryUsuario _repository;
        #endregion

        #region Construtores
        public ServiceUsuario(IRepositoryUsuario repository)
        {
            this._repository = repository;
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
                    usuario = _repository.ObterPor(u => u.Email.ToString() == usuario.Email.ToString() && u.Senha == usuario.Senha);

                    if (!(usuario is null))
                    {
                        if (usuario.Status == StatusUsuario.Ativo)
                        {
                            return (AutenticarUsuarioResponse)usuario;
                        }
                        else
                        {
                            AddNotification("Status", $"Não foi possível efetuar o login. Status do usuário: {usuario.ObterStatusUsuario()}.");
                            return null;
                        }

                    }
                    else 
                    {
                        AddNotification("Usuário", "Nome de usuário e/ou senha incorretos.");
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

        public IResponse AlterarSenha(IRequest request)
        {
            if (!(request is null))
            {
                AlterarSenhaRequest alterarSenhaRequest = (AlterarSenhaRequest)request;
                var usuario = _repository.ObterPor(u => u.Email.ToString() == alterarSenhaRequest.Email);

                if (!(usuario is null))
                {
                    usuario.AlterarSenha(alterarSenhaRequest);
                    AddNotifications(usuario);

                    if(IsValid())
                    {
                        _repository.Editar(usuario);
                        return (AlterarSenhaResponse)usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    AddNotification("Usuario", Message.X0_NAO_ENCONTRADO.ToFormat("Usuario"));
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
                    if (!_repository.Existe(u => u.Email.ToString() == usuario.Email.ToString()))
                    {
                        usuario.Adicionar();
                        usuario = _repository.Adicionar(usuario);
                        return (AdicionarUsuarioResponse)usuario;
                    }
                    else
                    {
                        AddNotification("E-mail", Message.X0_JA_CADASTRADO.ToFormat("E-mail"));
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
                    if (!_repository.Existe(u => u.Id.ToString() != editarUsuarioRequest.Id.ToString() && u.Email.ToString() == editarUsuarioRequest.Email.ToString()))
                    {
                        usuario.Editar(editarUsuarioRequest);
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
                        AddNotification("E-mail", Message.X0_JA_CADASTRADO.ToFormat("E-mail"));
                        return null;
                    }
                }
                else
                {
                    AddNotification("Usuario", Message.X0_NAO_ENCONTRADO.ToFormat("Usuario"));
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
            _repository.Remover(_repository.ObterPorId(id));
            return new Response(true);
        } 

        public IResponse ObterPorId(Guid id)
        {
            var usuario = _repository.ObterPorId(id);

            if (!(usuario is null))
            {
                return (ObterUsuarioResponse)usuario;
            }
            else
            {
                AddNotification("Usuario", Message.X0_NAO_ENCONTRADO.ToFormat("Usuario"));
                return null;
            }
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.Listar().ToList().Select(usuario => (ObterUsuarioResponse)usuario).ToList();
        }

        private void NotificarRequestNulo()
        {
            AddNotification("Request", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Request"));
        }
        #endregion
    }
}
