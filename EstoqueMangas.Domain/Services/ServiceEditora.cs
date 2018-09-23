using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Arguments.EditoraArguments;
using EstoqueMangas.Domain.Entities.Build;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.Services
{
    public class ServiceEditora : Notifiable, IServiceEditora
    {
        #region Atributos
        private readonly IRepositoryEditora _repository;
        #endregion

        #region Construtores
        public ServiceEditora(IRepositoryEditora repository)
        {
            _repository = repository;
        }
        #endregion

        #region Métodos
        public IResponse Adicionar(IRequest request)
        {
            if (!(request is null))
            {
                AdicionarRequest adicionarRequest = (AdicionarRequest)request;

                var editora = new EditoraBuild()
                    .AdicionarNome(adicionarRequest.Nome)
                    .AdicionarEndereco(adicionarRequest.EnderecoLogradouro, adicionarRequest.EnderecoNumero, adicionarRequest.EnderecoComplemento, adicionarRequest.EnderecoBairro, adicionarRequest.EnderecoCidade, adicionarRequest.EnderecoEstado, adicionarRequest.EnderecoCep)
                    .AdicionarTelefone(adicionarRequest.TelefoneDdd, adicionarRequest.TelefoneNumero)
                    .BuildAdicionar();

                AddNotifications(editora);

                if (IsValid())
                {
                    if (!_repository.Existe(e => e.Nome == editora.Nome))
                    {
                        editora = _repository.Adicionar(editora);
                        return (AdicionarResponse)editora;
                    }
                    else
                    {
                        AddNotification("Editora", Message.X0_JA_CADASTRADA.ToFormat("Editora"));
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
                EditarRequest editarRequest = (EditarRequest)request;

                var editora = _repository.ObterPorId(editarRequest.Id);

                if (!(editora is null))
                {
                    editora.Editar(editarRequest);
                    AddNotifications(editora);

                    if (IsValid())
                    {
                        _repository.Editar(editora);
                        return (EditarResponse)editora;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    AddNotification("Editora", Message.X0_NAO_ENCONTRADA.ToFormat("Editora"));
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
            var editora = _repository.ObterPorId(id);

            if (!(editora is null))
            {
                _repository.Remover(editora);
                return new Response(true);
            }
            else
            {
                AddNotification("Editora", Message.X0_NAO_ENCONTRADA.ToFormat("Editora"));
                return null;
            }
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.Listar().ToList().Select(editora => (ObterResponse)editora).ToList();
        }

        public IResponse ObterPorId(Guid id)
        {
            var editora = _repository.ObterPorId(id);

            if (!(editora is null))
            {
                return (ObterResponse)editora;
            }
            else
            {
                AddNotification("Editora", Message.X0_NAO_ENCONTRADA.ToFormat("Editora"));
                return null;
            }
        }

        private void NotificarRequestNulo()
        {
            AddNotification("Request", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Request"));
        }
        #endregion
    }
}
