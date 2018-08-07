using System;
using EstoqueMangas.Domain.Extensions;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.ValueObjects
{
    public class Endereco : Notifiable
    {
        
        #region Propriedades
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        #endregion

        #region Construtores
        public Endereco(string logradouro, string numero, string complemento, string cidade, string estado, string cep)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Cep = cep;

            new AddNotifications<Endereco>(this)
                .IfNullOrEmpty(end => end.Logradouro, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Logradouro"))
                .IfNullOrEmpty(end => end.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número"))
                .IfNullOrEmpty(end => end.Complemento, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Complemento"))
                .IfNullOrEmpty(end => end.Cidade, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cidade"))
                .IfNullOrEmpty(end => end.Estado, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Estado"))
                .IfNullOrEmpty(end => end.Cep, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cep"));

            if (this.Numero.IsNumeric())
            {
                if (Convert.ToInt64(this.Numero) >= 0)
                {
                    AddNotification("Numero", Message.CAMPO_X0_INVALIDO_FAVOR_INSERIR_NUMERO_MAIOR_QUE_X1.ToFormat("Número", "0"));
                }
            }

        }
        #endregion 
    }
}
