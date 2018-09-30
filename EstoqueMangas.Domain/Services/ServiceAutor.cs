using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Arguments.AutorArguments;
using EstoqueMangas.Domain.Arguments.Base;
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
        #endregion

        #region Construtores
        public ServiceAutor(IRepositoryAutor repositoryAutor, IRepositoryAutorManga repositoryAutorManga)
        {
            _repositoryAutor = repositoryAutor;
            _repositoryAutorManga = repositoryAutorManga;
        }
        #endregion

        #region Métodos
        public IResponse Adicionar(IRequest request)
        {
            if (!(request is null))
            {
                AdicionarRequest adicionarRequest = (AdicionarRequest)request;

                var autor = new AutorBuild()
                    .AdicionarNome(adicionarRequest.PrimeiroNome, adicionarRequest.UltimoNome)
                    .BuildAdicionar();

                AddNotifications(autor);

                if (IsValid())
                {
                    if (!_repositoryAutor.Existe(a => a.NomeAutor.ToString() == autor.NomeAutor.ToString()))
                    {
                        _repositoryAutor.Adicionar(autor);

                        return (AdicionarResponse)autor;
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
                EditarRequest editarRequest = (EditarRequest)request;

                var autor = _repositoryAutor.ObterPorId(editarRequest.Id);

                if (!(autor is null))
                {
                    autor.Editar(editarRequest);

                    AddNotifications(autor);

                    if (IsValid())
                    {
                        if (!_repositoryAutor.Existe(a => a.Id != autor.Id && a.NomeAutor.ToString() == autor.NomeAutor.ToString()))
                        {
                            _repositoryAutor.Editar(autor);

                            return (EditarResponse)autor;
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
                var autoresMangas = _repositoryAutorManga.ListarPor(am => am.AutorId == autor.Id).ToList();

                if (!(autoresMangas is null) && autoresMangas.Count > 0)
                {
                    foreach (var autorManga in autoresMangas)
                    {
                        _repositoryAutorManga.Remover(autorManga);
                    }
                }

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
            return _repositoryAutor.Listar().ToList().Select(a => (ObterResponse)a).ToList();
        }

        public IEnumerable<IResponse> ListarComMangas()
        {
            var autoresMangas = _repositoryAutorManga.ListarOrdenandoPor(am => am.Autor.NomeAutor, true, am => am.Autor, am => am.Manga).ToList();

            if (!(autoresMangas is null) || autoresMangas.Count > 0)
            {
                return new AutorFactory()
                    .AdicionarMangasEmAutores(autoresMangas)
                    .ListarAutores()
                    .Select(a => (ObterResponse)a)
                    .ToList();
            }
            else
            {
                NotificarAutorInexistente();

                return null;
            }
        }

        public IResponse ObterPorId(Guid id)
        {
            var autor = _repositoryAutor.ObterPorId(id);

            if (!(autor is null))
            {
                return (ObterResponse)autor;
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

                return (ObterResponse)autor;
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
                                        .Select(am => (ObterResponse)am.Autor)
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
                        .Select(a => (ObterResponse)a)
                        .ToList()
                    : autores.Select(a => (ObterResponse)a).ToList();
            }
            else
            {
                NotificarAutorInexistente();

                return null;
            }
        }

        public IResponse ObterPorNome(IRequest request)
        {
            if (!(request is null))
            {
                ObterRequest obterRequest = (ObterRequest)request;

                var autor = _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == obterRequest.PrimeiroNome 
                                                      && a.NomeAutor.UltimoNome == obterRequest.UltimoNome);

                if (!(autor is null))
                {
                    return (ObterResponse)autor;
                }
                else
                {
                    AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

                    return null;
                }
            }
            else
            {
                NotificarRequestNulo();

                return null;
            }
        }

        public IResponse ObterPorNomeComMangas(IRequest request)
        {
            if (!(request is null))
            {
                ObterRequest obterRequest = (ObterRequest)request;

                var autor = _repositoryAutor.ObterPor(a => a.NomeAutor.PrimeiroNome == obterRequest.PrimeiroNome 
                                                      && a.NomeAutor.UltimoNome == obterRequest.UltimoNome);

                if (!(autor is null))
                {
                    var mangas = _repositoryAutorManga
                        .ListarPor(am => am.AutorId == autor.Id, am => am.Manga)
                        .ToList();

                    return !(mangas is null) || mangas.Count > 0
                        ? (ObterResponse)new AutorFactory().AdicionarMangasEmAutor(mangas).ObterAutor()
                        : (ObterResponse)autor;
                }
                else
                {
                    AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));

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
            //Nenhum.
            AddNotification("Autor", Message.X0_NAO_ENCONTRADO.ToFormat("Autor"));
        }
        #endregion
    }
}