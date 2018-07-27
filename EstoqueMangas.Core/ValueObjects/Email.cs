using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.ValueObjects
{
    public class Email : Notifiable
    {
        #region Atributos
        public string EnderecoEmail { get; private set; }
        #endregion

        #region Construtores
        public Email(string enderecoEmail)
        {
            this.EnderecoEmail = enderecoEmail;

            new AddNotifications<Email>(this)
                .IfNotEmail(e => e.EnderecoEmail);
        }
        #endregion 
    }
}
