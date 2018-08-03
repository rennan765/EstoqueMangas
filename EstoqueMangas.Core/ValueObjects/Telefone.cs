using EstoqueMangas.Core.Enuns;
using EstoqueMangas.Core.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.ValueObjects
{
    public class Telefone : Notifiable
    {
        #region Propriedades
        public int Ddd { get; private set; }
        public string Numero { get; private set; }
        #endregion

        #region Construtores
        public Telefone(int ddd, string numero)
        {
            this.Ddd = ddd;
            this.Numero = numero;

            new AddNotifications<Telefone>(this)
                .IfNullOrEmpty(tel => tel.Ddd.ToString(), Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Ddd"))
                .IfNullOrEmpty(tel => tel.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número de Telefone"));
        }
        #endregion 
    }
}
