using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

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
        public Manga() : base()
        {
            this.Autores = new List<AutorManga>();
            this.Edicoes = new List<Edicao>();
        }

        public Manga(string titulo, IList<AutorManga> autores, int anoLancamento, Guid editoraId, Editora editora, IList<Edicao> edicoes) : base()
        {
            this.Titulo = titulo;
            this.Autores = autores;
            this.AnoLancamento = anoLancamento;
            this.EditoraId = editoraId;
            this.Editora = editora;
            this.Edicoes = edicoes;

            new AddNotifications<Manga>(this)
                .IfNullOrWhiteSpace(m => m.Titulo)
                .IfNull(e => e.Editora, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Editora"));

            AddNotifications(this.Editora);
        }
        #endregion

        #region Métodos
        public void IncluirAutores(IList<AutorManga> autores)
        {
            this.Autores = autores;
        }
        #endregion 
    }
}
