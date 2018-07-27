using System;
using System.Collections.Generic;
using EstoqueMangas.Core.ValueObjects;
using prmToolkit.NotificationPattern;

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
        }
        #endregion 
    }
}
