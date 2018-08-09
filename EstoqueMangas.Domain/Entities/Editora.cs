using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Resources;
using EstoqueMangas.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.Entities
{
    public class Editora : Entity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        public IList<Manga> Mangas { get; private set; }
        #endregion

        #region Editora
        public Editora() : base()
        {
            this.Mangas = new List<Manga>();
        }

        public Editora(string nome, Endereco endereco, Telefone telefone, IList<Manga> mangas) : base()
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Mangas = mangas;

            new AddNotifications<Editora>(this)
                .IfNullOrEmpty(e => e.Nome, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Nome da Editora"));
        }
        #endregion 
    }
}
