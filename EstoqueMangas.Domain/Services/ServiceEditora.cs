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
                AdicionarEditoraRequest adicionarEditoraRequest = (AdicionarEditoraRequest)request;

                var editora = new EditoraBuild()
                    .AdicionarNome(adicionarEditoraRequest.Nome)
                    .AdicionarEndereco(adicionarEditoraRequest.EnderecoLogradouro, adicionarEditoraRequest.EnderecoNumero, adicionarEditoraRequest.EnderecoComplemento, adicionarEditoraRequest.EnderecoBairro, adicionarEditoraRequest.EnderecoCidade, adicionarEditoraRequest.EnderecoEstado, adicionarEditoraRequest.EnderecoCep)
                    .AdicionarTelefone(adicionarEditoraRequest.TelefoneDdd, adicionarEditoraRequest.TelefoneNumero)
                    .BuildAdicionar();

                AddNotifications(editora);

                if (IsValid())
                {
                    if (!_repository.Existe(e => e.Nome == editora.Nome))
                    {
                        editora = _repository.Adicionar(editora);
                        return (AdicionarEditoraResponse)editora;
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
                EditarEditoraRequest editarEditoraRequest = (EditarEditoraRequest)request;

                var editora = _repository.ObterPorId(editarEditoraRequest.Id);

                if (!(editora is null))
                {
                    editora.Editar(editarEditoraRequest);
                    AddNotifications(editora);

                    if (IsValid())
                    {
                        _repository.Editar(editora);
                        return (EditarEditoraResponse)editora;
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
            return _repository.Listar().ToList().Select(editora => (ObterEditoraResponse)editora).ToList();
        }

        public IResponse ObterPorId(Guid id)
        {
            var editora = _repository.ObterPorId(id);

            if (!(editora is null))
            {
                return (ObterEditoraResponse)editora;
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
