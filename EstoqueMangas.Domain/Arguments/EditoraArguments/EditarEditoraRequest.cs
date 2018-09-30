using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments.EditoraArguments
{
    public class EditarEditoraRequest : Request, IRequest
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoCep { get; set; }
        public string TelefoneDdd { get; set; }
        public string TelefoneNumero { get; set; }
        #endregion 
    }
}
