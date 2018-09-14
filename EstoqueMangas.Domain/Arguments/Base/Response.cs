using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.Base
{
    public class Response : IResponse
    {
        #region Propriedades
        public string Mensagem { get; set; }
        #endregion

        #region Construtores
        public Response()
        {

        }

        public Response(bool validacao)
        {
            Mensagem = (validacao ? Message.OPERACAO_REALIZADA_COM_SUCESSO : Message.FALHA_AO_REALIZAR_A_OPERACAO);
        }

        public Response(string mensagem)
        {
            Mensagem = mensagem;
        }
        #endregion 
    }
}
