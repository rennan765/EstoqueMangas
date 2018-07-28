using System;
using System.Collections.Generic;
using EstoqueMangas.Core.Resources;
using EstoqueMangas.Core.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.Entities
{
    public class Editora : Notifiable
    {
        
        #region Atributos
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public IList<Telefone> Telefones { get; private set; }
        #endregion

        #region Editora
        public Editora(Guid id, string nome, Endereco endereco, IList<Telefone> telefones)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefones = new List<Telefone>();

            new AddNotifications<Editora>(this)
                .IfNullOrEmpty(e => e.Nome, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Nome da Editora"));
        }
        #endregion 
    }
}
