using EstoqueMangas.Domain.ValueObjects;

namespace EstoqueMangas.Domain.Entities.Build
{
    public class EditoraBuild
    {
        #region Propriedades
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

        #region Construtores
        public EditoraBuild()
        {

        }

        public EditoraBuild(string nome, string enderecoLogradouro, string enderecoNumero, string enderecoComplemento, string enderecoBairro, string enderecoCidade, string enderecoEstado, string enderecoCep, string telefoneDdd, string telefoneNumero)
        {
            Nome = nome;
            EnderecoLogradouro = enderecoLogradouro;
            EnderecoNumero = enderecoNumero;
            EnderecoComplemento = enderecoComplemento;
            EnderecoBairro = enderecoBairro;
            EnderecoCidade = enderecoCidade;
            EnderecoEstado = enderecoEstado;
            EnderecoCep = enderecoCep;
            TelefoneDdd = telefoneDdd;
            TelefoneNumero = telefoneNumero;
        }
        #endregion

        #region Métodos
        public EditoraBuild AdicionarNome(string nome)
        {
            Nome = nome;

            return this;
        }

        public EditoraBuild AdicionarEndereco(string enderecoLogradouro, string enderecoNumero, string enderecoComplemento, string enderecoBairro, string enderecoCidade, string enderecoEstado, string enderecoCep)
        {
            EnderecoLogradouro = enderecoLogradouro;
            EnderecoNumero = enderecoNumero;
            EnderecoComplemento = enderecoComplemento;
            EnderecoBairro = enderecoBairro;
            EnderecoCidade = enderecoCidade;
            EnderecoEstado = enderecoEstado;
            EnderecoCep = enderecoCep;

            return this;
        }

        public EditoraBuild AdicionarTelefone(string telefoneDdd, string telefoneNumero)
        {
            TelefoneDdd = telefoneDdd;
            TelefoneNumero = telefoneNumero;

            return this;
        }

        public Editora BuildAdicionar()
        {
            return new Editora(
                Nome,
                new Endereco(EnderecoLogradouro, EnderecoNumero, EnderecoComplemento, EnderecoBairro, EnderecoCidade, EnderecoEstado, EnderecoCep),
                new Telefone(TelefoneDdd, TelefoneNumero));
        }
        #endregion 
    }
}
