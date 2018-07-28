﻿using System;
using EstoqueMangas.Core.Extensions;
using EstoqueMangas.Core.Resources;
using EstoqueMangas.Core.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.Entities
{
    public class Usuario : Notifiable
    {
        
        #region Atributos
        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone TelefoneFixo { get; private set; }
        public Telefone TelefoneCelular { get; private set; }
        public string Senha { get; private set; }
        #endregion

        #region Construtores
        public Usuario(Nome nome, Email email, Telefone telefoneFixo, Telefone telefoneCelular, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.TelefoneFixo = telefoneFixo;
            this.TelefoneCelular = telefoneCelular;
            this.Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.A_SENHA_DEVE_TER_ENTRE_X0_E_X1_CARACTERES.ToFormat("8", "32"));

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }
        #endregion 
    }
}
