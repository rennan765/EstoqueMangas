using System;
using EstoqueMangas.Core.Enuns;
using EstoqueMangas.Core.Extensions;
using EstoqueMangas.Core.Resources;
using EstoqueMangas.Core.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.Entities
{
    public class Usuario : Notifiable
    {
        #region Propriedades
        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone TelefoneFixo { get; private set; }
        public Telefone TelefoneCelular { get; private set; }
        public string Senha { get; private set; }
        public StatusUsuario Status { get; private set; }
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

            AddNotifications(this.Nome, this.Email, this.TelefoneFixo, this.TelefoneCelular);

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }

        public Usuario(Nome nome, Email email, Telefone telefoneFixo, Telefone telefoneCelular, string senha, StatusUsuario statusUsuario)
        {
            this.Nome = nome;
            this.Email = email;
            this.TelefoneFixo = telefoneFixo;
            this.TelefoneCelular = telefoneCelular;
            this.Senha = senha;
            this.Status = statusUsuario;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("E-mail"))
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.A_SENHA_DEVE_TER_ENTRE_X0_E_X1_CARACTERES.ToFormat("8", "32"))
                .IfEnumInvalid(u => u.Status, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Status"));

            AddNotifications(this.Nome, this.Email, this.TelefoneFixo, this.TelefoneCelular);

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }

        public Usuario(Guid id, Nome nome, Email email, Telefone telefoneFixo, Telefone telefoneCelular, string senha, StatusUsuario statusUsuario)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.TelefoneFixo = telefoneFixo;
            this.TelefoneCelular = telefoneCelular;
            this.Senha = senha;
            this.Status = statusUsuario;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("E-mail"))
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.A_SENHA_DEVE_TER_ENTRE_X0_E_X1_CARACTERES.ToFormat("8", "32"))
                .IfEnumInvalid(u => u.Status, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Status"));

            AddNotifications(this.Nome, this.Email, this.TelefoneFixo, this.TelefoneCelular);

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }

        public Usuario(Email email, string senha)
        {
            this.Email = email;
            this.Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.A_SENHA_DEVE_TER_ENTRE_X0_E_X1_CARACTERES.ToFormat("8", "32"));

            AddNotifications(this.Email);

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }
        #endregion

        #region Métodos
        public void AdicionarUsuario()
        {
            this.Id = Guid.NewGuid();
            this.Status = StatusUsuario.AguardandoAprovacao;
        }
        #endregion 
    }
}
