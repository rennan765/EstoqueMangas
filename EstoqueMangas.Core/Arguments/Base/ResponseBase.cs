using System;
using EstoqueMangas.Core.Interfaces.Arguments;

namespace EstoqueMangas.Core.Arguments.Base
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
            this.Mensagem = (validacao ? "Operação realizada com sucesso." : "Falha ao realizar a operação.");
        }
        #endregion 
    }
}
