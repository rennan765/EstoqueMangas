using EstoqueMangas.Domain.Arguments.UsuarioArguments;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Enuns;
using EstoqueMangas.Domain.Extensions;
using EstoqueMangas.Domain.Resources;
using EstoqueMangas.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.Entities
{
    public class Usuario : Entity
    {
        #region Propriedades
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone TelefoneFixo { get; private set; }
        public Telefone TelefoneCelular { get; private set; }
        public string Senha { get; private set; }
        public StatusUsuario Status { get; private set; }
        #endregion

        #region Construtores
        protected Usuario()
        {

        }

        public Usuario(Nome nome, Email email, Telefone telefoneFixo, Telefone telefoneCelular, string senha)
        {
            Nome = nome;
            Email = email;
            TelefoneFixo = telefoneFixo;
            TelefoneCelular = telefoneCelular;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"));

            AddNotifications(Nome, Email);

            if (!(TelefoneFixo is null))
            {
                AddNotifications(TelefoneFixo);
            }

            if (!(TelefoneCelular is null))
            {
                AddNotifications(TelefoneCelular);
            }

            if (IsValid())
            {
                Senha = Senha.ToHash();
            }
        }

        public Usuario(Nome nome, Email email, Telefone telefoneFixo, Telefone telefoneCelular, string senha, StatusUsuario statusUsuario)
        {
            Nome = nome;
            Email = email;
            TelefoneFixo = telefoneFixo;
            TelefoneCelular = telefoneCelular;
            Senha = senha;
            Status = statusUsuario;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("E-mail"))
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"))
                .IfEnumInvalid(u => u.Status, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Status"));

            AddNotifications(Nome, Email);

            if (!(TelefoneFixo is null))
            {
                AddNotifications(TelefoneFixo);
            }

            if (!(TelefoneCelular is null))
            {
                AddNotifications(TelefoneCelular);
            }

            if (IsValid())
            {
                Senha = Senha.ToHash();
            }
        }

        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(u => u.Senha, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Senha"))
                .IfNullOrInvalidLength(u => u.Senha, 8, 32, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"));

            AddNotifications(Email);

            if (IsValid())
            {
                Senha = Senha.ToHash();
            }
        }
        #endregion

        #region Métodos
        public void Adicionar()
        {
            Status = StatusUsuario.AguardandoAprovacao;
        }

        public void Editar(EditarUsuarioRequest request)
        {
            Nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Email = new Email(request.Email);
            Status = (StatusUsuario)request.StatusUsuario;
            TelefoneFixo = new Telefone(request.DddFixo, request.TelefoneFixo);
            TelefoneCelular = new Telefone(request.DddCelular, request.TelefoneCelular);

            new AddNotifications<Usuario>(this)
                .IfEnumInvalid(u => u.Status, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Status"));

            AddNotifications(Nome, Email, TelefoneFixo, TelefoneCelular);
        }

        public void AlterarSenha(AlterarSenhaRequest request)
        {
            if (Email.ToString() != request.Email)
            {
                AddNotification("E-mail", Message.O_CAMPO_X0_E_INVALIDO.ToFormat("E-mail"));
            }

            if (!request.NovaSenha.ValidateLength(8, 32))
            {
                AddNotification("Senha", Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "8", "32"));
            }

            if (IsValid())
            {
                Senha = request.NovaSenha.ToHash();
            }
        }

        public string ObterStatusUsuario()
        {
            string statusUsuario;

            switch (Status)
            {
                case StatusUsuario.AguardandoAprovacao:
                    statusUsuario = "Aguardando aprovação";
                    break;
                case StatusUsuario.Ativo:
                    statusUsuario = "Ativo";
                    break;
                case StatusUsuario.Bloqueado:
                    statusUsuario = "Bloqueado";
                    break;
                default:
                    statusUsuario = "";
                    break;
            }

            return statusUsuario;
        }
        #endregion
    }
}
