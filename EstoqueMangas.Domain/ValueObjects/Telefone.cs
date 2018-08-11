using EstoqueMangas.Domain.Enuns;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.ValueObjects
{
    public class Telefone : Notifiable
    {
        #region Propriedades
        public string Ddd { get; private set; }
        public string Numero { get; private set; }
        #endregion

        #region Construtores
        public Telefone(string ddd, string numero)
        {
            this.Ddd = ddd;
            this.Numero = numero;

            new AddNotifications<Telefone>(this)
                .IfNullOrEmpty(tel => tel.Ddd, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Ddd"))
                .IfNullOrEmpty(tel => tel.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número de Telefone"));
        }
        #endregion 
    }
}
