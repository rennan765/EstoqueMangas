using System;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.Base
{
    public class ResponseBase : IResponse
    {
        #region Propriedades
        public string Mensagem { get; set; }
        #endregion

        #region Construtores
        public ResponseBase()
        {
        }

        public ResponseBase(Boolean validacao)
        {
            this.Mensagem = (validacao ? Message.OPERACAO_REALIZADA_COM_SUCESSO : Message.FALHA_AO_REALIZAR_A_OPERACAO);
        }
        #endregion 
    }
}
