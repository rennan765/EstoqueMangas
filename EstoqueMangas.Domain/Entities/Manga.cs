using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;

namespace EstoqueMangas.Domain.Entities
{
    public class Manga : Entity
    {

        #region Propriedades
        public string Titulo { get; private set; }
        public IList<AutorManga> Autores { get; private set; }
        public int AnoLancamento { get; private set; }
        public Guid EditoraId { get; private set; }
        public Editora Editora { get; private set; }
        public IList<Edicao> Edicoes { get; private set; }
        #endregion

        #region Construtores
        public Manga()
        {
            Autores = new List<AutorManga>();
            Edicoes = new List<Edicao>();
        }

        public Manga(string titulo, IList<AutorManga> autores, int anoLancamento, Guid editoraId, Editora editora, IList<Edicao> edicoes)
        {
            Titulo = titulo;
            Autores = autores;
            AnoLancamento = anoLancamento;
            EditoraId = editoraId;
            Editora = editora;
            Edicoes = edicoes;

            new AddNotifications<Manga>(this)
                .IfNullOrWhiteSpace(m => m.Titulo)
                .IfNull(e => e.Editora, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Editora"));

            AddNotifications(Editora);
        }
        #endregion

        #region Métodos
        public void IncluirAutores(IList<AutorManga> autores)
        {
            Autores = autores;
        }

        public void IncluirAutor(Autor autor)
        {
            Autores.Add(new AutorManga(autor));
        }
        #endregion 
    }
}
