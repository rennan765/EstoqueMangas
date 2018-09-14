using EstoqueMangas.Domain.Extensions;
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
            Ddd = !string.IsNullOrEmpty(ddd) ? ddd : "";
            Numero = !string.IsNullOrEmpty(numero) ? numero : "";

            //Validações (somente se um dos dois campos estiver preenchido):
            //1- Verifica se o DDD está preenchido sem o número
            //2- Verifica se o número está preenchido sem o DDD
            //3- Verifica se o DDD possui menor ou mais de 2 dígitos
            //4- Verifica se o número possui mais de 9 dígitos
            //5- Verifica se o DDD e o número são informações não numéricas

            if (!string.IsNullOrEmpty(Ddd) || !string.IsNullOrEmpty(Numero))
            {
                new AddNotifications<Telefone>(this)
                    .IfNullOrEmpty(tel => tel.Ddd, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Ddd"))
                    .IfNullOrEmpty(tel => tel.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número de Telefone"))
                    .IfLengthNoEqual(tel => tel.Ddd, 2, Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Ddd"))
                    .IfNullOrInvalidLength(tel => tel.Numero, 8, 9, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Número de Telefone", "8", "9"));

                if (!Ddd.IsNumeric())
                {
                    AddNotification("Ddd", Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Ddd"));
                }

                if (!Numero.IsNumeric())
                {
                    AddNotification("Telefone", Message.O_CAMPO_X0_E_INVALIDO.ToFormat("Número de telefone"));
                }
            }
        }
        #endregion

        #region Atributos
        public override string ToString()
        {
            return $"({Ddd}) {Numero}";
        }
        #endregion 
    }
}
