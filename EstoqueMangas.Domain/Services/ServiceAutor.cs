using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Arguments.AutorArguments;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Build;
using EstoqueMangas.Domain.Entities.Factory;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.Services
{
    public class ServiceAutor : Notifiable, IServiceAutor
    {
        #region Atributos
        private readonly IRepositoryAutor _repositoryAutor;
        private readonly IRepositoryAutorManga _repositoryAutorManga;
        private readonly IRepositoryManga _repositoryManga;
        #endregion

        #region Construtores
        public ServiceAutor(IRepositoryAutor repositoryAutor, IRepositoryAutorManga repositoryAutorManga, IRepositoryManga repositoryManga)
        {
            _repositoryAutor = repositoryAutor;
            _repositoryAutorManga = repositoryAutorManga;
            _repositoryManga = repositoryManga;
        }
        #endregion

        #region Métodos
        public IResponse Adicionar(IRequest request)
        {
            if (!(request is null))
            {
                AdicionarAutorRequest adicionarAutorRequest = (AdicionarAutorRequest)request;

                var autor = new AutorBuild()
                    .AdicionarNome(adicionarAutorRequest.PrimeiroNome, adicionarAutorRequest.UltimoNome)
                    .BuildAdicionar();

                AddNotifications(autor);

                if (IsValid())
                {
                    if (!_repositoryAutor.Existe(a => a.NomeAutor.ToString() == autor.NomeAutor.ToString()))
                    {
                        _repositoryAutor.Adicionar(autor);

                        return (AdicionarAutorResponse)autor;
                    }
                    else
                    {
                        AddNotification("Autor", Message.X0_JA_CADASTRADO.ToFormat("Autor"));

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
                EditarAutorRequest editarAutorRequest = (EditarAutorRequest)request;

                var autor = _repositoryAutor.ObterPorId(editarAutorRequest.Id);

                if (!(autor is null))
                {
                    autor.Editar(editarAutorRequest);

                    AddNotifications(autor);

                    if (IsValid())
                    {
                        if (!_repositoryAutor.Existe(a => a.Id != autor.Id && a.NomeAutor.ToString() == autor.NomeAutor.ToString()))
                        {
                            _repositoryAutor.Editar(autor);

                            return (EditarAutorResponse)autor;
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
            var autor = _repositoryAutor.ObterPorId(id);

            if (!(autor is null))
            {
                RemoverMangasDoAutor(autor);

                _repositoryAutor.Remover(autor);

                return new Response(true);
            }
            else
            {
                AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

                return null;
            }
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repositoryAutor.Listar().ToList().Select(a => (ObterAutorResponse)a).ToList();
        }

        public IEnumerable<IResponse> ListarComMangas()
        {
            var response = TratarAutoresComMangas(_repositoryAutor.ListarPor(a => a.Mangas.Count <= 0).ToList(), 
                                                  _repositoryAutor.ListarPor(a => a.Mangas.Count > 0).ToList());

            if (response is null)
            {
                NotificarAutorInexistente();
            }

            return response;
        }

        public IResponse ObterPorId(Guid id)
        {
            var autor = _repositoryAutor.ObterPorId(id);

            if (!(autor is null))
            {
                return (ObterAutorResponse)autor;
            }
            else
            {
                AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

                return null;
            }
        }

        public IResponse ObterPorIdComMangas(Guid id)
        {
            var autor = _repositoryAutor.ObterPorId(id);

            if (!(autor is null))
            {
                autor.IncluirMangas(_repositoryAutorManga.ListarPor(am => am.AutorId == id, am => am.Manga).ToList());

                return (ObterAutorResponse)autor;
            }
            else
            {
                AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

                return null;
            }
        }

        public IEnumerable<IResponse> ListarPorManga(Guid mangaId)
        {
            return _repositoryAutorManga.ListarPor(am => am.MangaId == mangaId, am => am.Autor)
                                        .ToList()
                                        .Select(am => (ObterAutorResponse)am.Autor)
                                        .ToList();
        }

        public IEnumerable<IResponse> ListarPorMangaComMangas(Guid mangaId)
        {
            var autores = _repositoryAutorManga
                .ListarPor(am => am.MangaId == mangaId, am => am.Autor)
                .AsQueryable()
                .Select(am => am.Autor)
                .ToList();

            if (!(autores is null) || autores.Count > 0)
            {
                var mangas = _repositoryAutorManga
                .ListarPor(am => autores.Any(a => a.Id == am.AutorId), am => am.Manga)
                .ToList();

                return !(mangas is null) || mangas.Count > 0
                    ? new AutorFactory()
                        .AdicionarMangasEmAutores(mangas)
                        .ListarAutores()
                        .Select(a => (ObterAutorResponse)a)
                        .ToList()
                    : autores.Select(a => (ObterAutorResponse)a).ToList();
            }
            else
            {
                NotificarAutorInexistente();

                return null;
            }
        }

        public IResponse ObterPorNome(string primeiroNome, string ultimoNome)
        {
            if (!string.IsNullOrEmpty(primeiroNome) || !string.IsNullOrEmpty(ultimoNome))
            {
                var autor = !string.IsNullOrEmpty(primeiroNome) && !string.IsNullOrEmpty(ultimoNome)
                               ? _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == primeiroNome && a.NomeAutor.UltimoNome == ultimoNome)
                               : !string.IsNullOrEmpty(primeiroNome) && string.IsNullOrEmpty(ultimoNome)
                                    ? _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == primeiroNome)
                                    : _repositoryAutor.ObterPor(a => a.NomeAutor.UltimoNome == ultimoNome);

                if (!(autor is null))
                {
                    return (ObterAutorResponse)autor;
                }
                else
                {
                    AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

                    return null;
                }
            }
            else
            {
                AddNotification("Nome do autor", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Primeiro Nome"));
                AddNotification("Nome do autor", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Último Nome"));

                return null;
            }
        }

        public IResponse ObterPorNomeComMangas(string primeiroNome, string ultimoNome)
        {
            if (!string.IsNullOrEmpty(primeiroNome) || !string.IsNullOrEmpty(ultimoNome))
            {
                var autor = !string.IsNullOrEmpty(primeiroNome) && !string.IsNullOrEmpty(ultimoNome)
                               ? _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == primeiroNome && a.NomeAutor.UltimoNome == ultimoNome)
                               : !string.IsNullOrEmpty(primeiroNome) && string.IsNullOrEmpty(ultimoNome)
                                    ? _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == primeiroNome)
                                    : _repositoryAutor.ObterPor(a => a.NomeAutor.UltimoNome == ultimoNome);

                if (!(autor is null))
                {
                    var mangas = _repositoryAutorManga
                        .ListarPor(am => am.AutorId == autor.Id, am => am.Manga)
                        .ToList();

                    return !(mangas is null) && mangas.Count > 0
                        ? (ObterAutorResponse)new AutorFactory().AdicionarMangasEmAutor(mangas).ObterAutor()
                        : (ObterAutorResponse)autor;
                }
                else
                {
                    AddNotification("Nome do autor", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Primeiro Nome"));
                    AddNotification("Nome do autor", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Último Nome"));

                    return null;
                }
            }
            else
            {
                NotificarRequestNulo();

                return null;
            }
        }

        private void NotificarRequestNulo()
        {
            AddNotification("Request", Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Request"));
        }

        private void NotificarAutorInexistente()
        {
            AddNotification("Autor", Message.NENHUM_X0_ENCONTRADO.ToFormat("Autor"));
        }

        private void RemoverMangasDoAutor(Autor autor)
        {
            var autoresMangas = _repositoryAutorManga.ListarPor(am => am.AutorId == autor.Id, am => am.Manga).ToList();

            if (!(autoresMangas is null) && autoresMangas.Count > 0)
            {
                foreach (var autorManga in autoresMangas)
                {
                    if (!_repositoryAutorManga.Existe(am => am.MangaId == autorManga.MangaId && am.AutorId != autorManga.AutorId))
                    {
                        _repositoryAutorManga.Remover(autorManga);
                        _repositoryManga.Remover(autorManga.Manga);
                    }
                }
            }
        }

        private IEnumerable<IResponse> TratarAutoresComMangas(IList<Autor> autoresSemMangas, IList<Autor> autoresComMangas)
        {
            var response = new List<ObterAutorResponse>();

            if (!(autoresSemMangas is null))
            {
                response = autoresSemMangas.Select(a => (ObterAutorResponse)a).ToList();
            }

            if (!(autoresComMangas is null))
            {
                foreach (var autor in autoresComMangas)
                {
                    response.Add((ObterAutorResponse)new AutorFactory()
                                 .AdicionarMangasEmAutor(autor.Mangas)
                                 .ObterAutor());
                }
            }

            return response.Count > 0 ? response : null;
        }
        #endregion
    }
}