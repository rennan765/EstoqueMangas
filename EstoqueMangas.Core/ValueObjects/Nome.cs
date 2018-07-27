using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.ValueObjects
{
    public class Nome : Notifiable
    {
        #region Atributos
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        #endregion

        #region Construtores
        public Nome(string primeiroNome, string ultimoNome)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;
        }
        #endregion

    }
}
