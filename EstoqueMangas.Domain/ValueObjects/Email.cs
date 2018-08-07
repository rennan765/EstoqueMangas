using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        #region Propriedades
        public string EnderecoEmail { get; private set; }
        #endregion

        #region Construtores
        public Email(string enderecoEmail)
        {
            this.EnderecoEmail = enderecoEmail;

            new AddNotifications<Email>(this)
                .IfNotEmail(e => e.EnderecoEmail, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("E-mail"))
                .IfNotEmail(e => e.EnderecoEmail, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("E-mail"));
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            return this.EnderecoEmail;
        }
        #endregion 
    }
}
