﻿using EstoqueMangas.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EstoqueMangas.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        #region Propriedades
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        #endregion

        #region Construtores
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrEmpty(nom => nom.PrimeiroNome, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Primeiro Nome"))
                .IfNullOrEmpty(nom => nom.UltimoNome, Message.O_CAMPO_X0_E_INFORMACAO_OBRIGATORIA.ToFormat("Último Nome"));
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            return $"{PrimeiroNome} {UltimoNome}";
        }
        #endregion 
    }
}
