using EstoqueMangas.Core.Enuns;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Core.ValueObjects
{
    public class Telefone : Notifiable
    {
        #region Atributos
        public int Ddd { get; private set; }
        public string Numero { get; private set; }
        public TipoTelefone TipoTelefone { get; private set; }
        #endregion

        #region Construtores
        public Telefone(int ddd, string numero, TipoTelefone tipoTelefone)
        {
            this.Ddd = ddd;
            this.Numero = numero;
            this.TipoTelefone = tipoTelefone;
        }
        #endregion 
    }
}
