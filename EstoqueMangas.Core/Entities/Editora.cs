using System;
using System.Collections.Generic;
using EstoqueMangas.Domain.Resources;
using EstoqueMangas.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.Entities
{
    public class Editora : Notifiable
    {
        #region Propriedades
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        #endregion

        #region Editora
        public Editora(Guid id, string nome, Endereco endereco, Telefone telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;

            new AddNotifications<Editora>(this)
                .IfNullOrEmpty(e => e.Nome, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Nome da Editora"));
        }
        #endregion 
    }
}
