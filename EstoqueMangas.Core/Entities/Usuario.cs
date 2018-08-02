using System;
using EstoqueMangas.Core.Arguments;
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
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"));

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
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"))
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
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"))
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
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"));

            AddNotifications(this.Email);

            if (IsValid())
            {
                this.Senha = this.Senha.ToHash();
            }
        }
        #endregion

        #region Métodos
        public void Adicionar()
        {
            this.Id = Guid.NewGuid();
            this.Status = StatusUsuario.AguardandoAprovacao;
        }

        public void Editar(EditarUsuarioRequest request, StatusUsuario status)
        {
            this.Nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            this.Email = new Email(request.Email);
            this.Status = status;

            if (!request.DddFixo.IsNumeric())
            {
                AddNotification("TelefoneFixo", Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Ddd do Telefone Fixo"));
            }

            if (!request.DddCelular.IsNumeric())
            {
                AddNotification("TelefoneFixo", Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Ddd do Telefone Celular"));
            }

            if (IsValid())
            {
                this.TelefoneFixo = new Telefone(request.DddFixo.ToInt(), request.TelefoneFixo, TipoTelefone.Fixo);
                this.TelefoneCelular = new Telefone(request.DddCelular.ToInt(), request.TelefoneCelular, TipoTelefone.Celular);   
            }
        }
        #endregion 
    }
}
