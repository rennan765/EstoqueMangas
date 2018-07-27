using System;
using prmToolkit.NotificationPattern;

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
                .IfNullOrEmpty(end => end.Logradouro)
                .IfNullOrEmpty(end => end.Numero.ToString())
                .IfNullOrEmpty(end => end.Complemento)
                .IfNullOrEmpty(end => end.Cidade)
                .IfNullOrEmpty(end => end.Estado)
                .IfNullOrEmpty(end => end.Cep);
        }
        #endregion 
    }
}
