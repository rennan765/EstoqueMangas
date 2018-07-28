using System;
using EstoqueMangas.Core.Enuns;
using EstoqueMangas.Core.ValueObjects;

namespace EstoqueMangas.Core.Entities.Build
{
    public class UsuarioBuild
    {

        #region Atributos
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public int DddFixo { get; private set; }
        public string TelefoneFixo { get; private set; }
        public int DddCelular { get; private set; }
        public string TelefoneCelular { get; private set; }
        public string Senha { get; private set; }
        #endregion

        #region Construtores
        public UsuarioBuild(string primeiroNome, string ultimoNome, string email, int dddFixo, string telefoneFixo, int dddCelular, string telefoneCelular, string senha)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;
            this.Email = email;
            this.DddFixo = dddFixo;
            this.TelefoneFixo = telefoneFixo;
            this.DddCelular = dddCelular;
            this.TelefoneCelular = telefoneCelular;
            this.Senha = senha;
        }
        #endregion

        #region Métodos
        public Usuario Build()
        {
            var nome = new Nome(this.PrimeiroNome, this.UltimoNome);
            var email = new Email(this.Email);
            Telefone telefoneFixo = null;
            Telefone telefoneCelular = null;

            if (!string.IsNullOrEmpty(this.TelefoneFixo))
            {
                telefoneFixo = new Telefone(this.DddFixo, this.TelefoneFixo, TipoTelefone.Fixo);
            }

            if (!string.IsNullOrEmpty(this.TelefoneFixo))
            {
                telefoneCelular = new Telefone(this.DddCelular, this.TelefoneCelular, TipoTelefone.Celular);
            }

            return new Usuario(nome, email, telefoneFixo, telefoneCelular, this.Senha);
        }
        #endregion 

    }
}
