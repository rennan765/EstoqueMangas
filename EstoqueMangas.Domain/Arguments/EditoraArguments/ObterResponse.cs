using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;

namespace EstoqueMangas.Domain.Arguments.EditoraArguments
{
    public class ObterResponse : Response
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

        #region Métodos
        public static explicit operator ObterResponse(Editora entidade)
        {
            return new ObterResponse()
            {
                Nome = entidade.Nome,
                EnderecoLogradouro = !(entidade.Endereco is null) ? entidade.Endereco.Logradouro : "",
                EnderecoNumero = !(entidade.Endereco is null) ? entidade.Endereco.Numero : "",
                EnderecoComplemento = !(entidade.Endereco is null) ? entidade.Endereco.Complemento : "",
                EnderecoBairro = !(entidade.Endereco is null) ? entidade.Endereco.Bairro : "",
                EnderecoCidade = !(entidade.Endereco is null) ? entidade.Endereco.Cidade : "",
                EnderecoEstado = !(entidade.Endereco is null) ? entidade.Endereco.Estado : "",
                EnderecoCep = !(entidade.Endereco is null) ? entidade.Endereco.Cep : "",
                TelefoneDdd = !(entidade.Telefone is null) ? entidade.Telefone.Ddd : "",
                TelefoneNumero = !(entidade.Telefone is null) ? entidade.Telefone.Numero : ""
            };
        }
        #endregion 
    }
}
