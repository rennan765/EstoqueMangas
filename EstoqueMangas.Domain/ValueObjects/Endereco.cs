using EstoqueMangas.Domain.Extensions;
using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace EstoqueMangas.Domain.ValueObjects
{
    public class Endereco : Notifiable
    {
        
        #region Propriedades
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        #endregion

        #region Construtores
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            new AddNotifications<Endereco>(this)
                .IfNullOrEmpty(end => end.Logradouro, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Logradouro"))
                .IfNullOrEmpty(end => end.Numero, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número"))
                .IfNullOrEmpty(end => end.Complemento, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Complemento"))
                .IfNullOrEmpty(end => end.Bairro, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Bairro"))
                .IfNullOrEmpty(end => end.Cidade, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cidade"))
                .IfNullOrEmpty(end => end.Estado, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Estado"))
                .IfNullOrEmpty(end => end.Cep, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cep"));

            if (Numero.IsNumeric())
            {
                if (Convert.ToInt64(Numero) >= 0)
                {
                    AddNotification("Numero", Message.CAMPO_X0_INVALIDO_FAVOR_INSERIR_NUMERO_MAIOR_QUE_X1.ToFormat("Número", "0"));
                }
            }

        }
        #endregion 
    }
}
