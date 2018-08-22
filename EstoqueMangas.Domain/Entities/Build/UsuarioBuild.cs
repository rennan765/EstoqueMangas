using System;
using EstoqueMangas.Domain.Enuns;
using EstoqueMangas.Domain.ValueObjects;

namespace EstoqueMangas.Domain.Entities.Build
{
    public class UsuarioBuild : IDisposable
    {

        #region Propriedades
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string DddFixo { get; set; }
        public string TelefoneFixo { get; set; }
        public string DddCelular { get; set; }
        public string TelefoneCelular { get; set; }
        public string Senha { get; set; }
        public StatusUsuario Status { get; set; }
        #endregion

        #region Construtores
        public UsuarioBuild()
        {

        }

        public UsuarioBuild(string primeiroNome, string ultimoNome, string email, string dddFixo, string telefoneFixo, string dddCelular, string telefoneCelular, string senha, StatusUsuario statusUsuario)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;
            this.Email = email;
            this.DddFixo = dddFixo;
            this.TelefoneFixo = telefoneFixo;
            this.DddCelular = dddCelular;
            this.TelefoneCelular = telefoneCelular;
            this.Senha = senha;
            this.Status = statusUsuario;
        }

        public UsuarioBuild(string primeiroNome, string ultimoNome, string email, string dddFixo, string telefoneFixo, string dddCelular, string telefoneCelular, string senha)
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

        public UsuarioBuild(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;
        }
        #endregion

        #region Métodos
        public Usuario BuildCompleto()
        {
            var nome = new Nome(this.PrimeiroNome, this.UltimoNome);
            var email = new Email(this.Email);
            Telefone telefoneFixo = null;
            Telefone telefoneCelular = null;

            if (!string.IsNullOrEmpty(this.TelefoneFixo))
            {
                telefoneFixo = new Telefone(this.DddFixo, this.TelefoneFixo);
            }

            if (!string.IsNullOrEmpty(this.TelefoneCelular))
            {
                telefoneCelular = new Telefone(this.DddCelular, this.TelefoneCelular);
            }

            return new Usuario(nome, email, telefoneFixo, telefoneCelular, this.Senha, this.Status);
        }

        public Usuario BuildAutenticar()
        {
            return new Usuario(new Email(this.Email), this.Senha);
        }

        public Usuario BuildAdicionar()
        {
            var nome = new Nome(this.PrimeiroNome, this.UltimoNome);
            var email = new Email(this.Email);
            Telefone telefoneFixo = null;
            Telefone telefoneCelular = null;

            if (!string.IsNullOrEmpty(this.TelefoneFixo))
            {
                telefoneFixo = new Telefone(this.DddFixo, this.TelefoneFixo);
            }

            if (!string.IsNullOrEmpty(this.TelefoneCelular))
            {
                telefoneCelular = new Telefone(this.DddCelular, this.TelefoneCelular);
            }

            return new Usuario(nome, email, telefoneFixo, telefoneCelular, this.Senha);
        }

        private void LimpaCampos()
        {
            this.PrimeiroNome = null;
            this.UltimoNome = null;
            this.Email = null;
            this.DddFixo = null;
            this.TelefoneFixo = null;
            this.DddCelular = null;
            this.TelefoneCelular = null;
            this.Senha = null;
        }

        public void Dispose()
        {
            this.LimpaCampos();
        }
        #endregion 
    }
}
