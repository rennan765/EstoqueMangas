using System;
using EstoqueMangas.Core.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Core.ValueObjects
{
    public class Endereco : Notifiable
    {
        
        #region Atributos
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        #endregion

        #region Construtores
        public Endereco(string logradouro, int numero, string complemento, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            new AddNotifications<Endereco>(this)
                .IfNullOrEmpty(end => end.Logradouro, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Logradouro"))
                .IfNullOrEmpty(end => end.Numero.ToString(), Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Número"))
                .IfLowerThan(end => end.Numero, 1, Message.CAMPO_X0_INVALIDO_FAVOR_INSERIR_NUMERO_MAIOR_QUE_X1.ToFormat("Número"), 1)
                .IfNullOrEmpty(end => end.Complemento, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Complemento"))
                .IfNullOrEmpty(end => end.Cidade, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cidade"))
                .IfNullOrEmpty(end => end.Estado, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Estado"))
                .IfNullOrEmpty(end => end.Cep, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Cep"));
        }
        #endregion 
    }
}
