using System;
using EstoqueMangas.Domain.Enuns;
using EstoqueMangas.Domain.ValueObjects;

namespace EstoqueMangas.Domain.Entities.Build
{
    public class UsuarioBuild
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
        public UsuarioBuild AdicionarNome(string primeiroNome, string ultimoNome)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;

            return this;
        }

        public UsuarioBuild AdicionarEmail(string email)
        {
            this.Email = email;

            return this;
        }

        public UsuarioBuild AdicionarTelefoneFixo(string dddFixo, string numeroFixo)
        {
            this.DddFixo = dddFixo;
            this.TelefoneFixo = numeroFixo;

            return this;
        }

        public UsuarioBuild AdicionarTelefoneCelular(string dddCelular, string numeroCelular)
        {
            this.DddCelular = dddCelular;
            this.TelefoneCelular = numeroCelular;

            return this;
        }

        public UsuarioBuild AdicionarSenha(string senha)
        {
            this.Senha = senha;

            return this;
        }

        public UsuarioBuild AdicionarStatus(StatusUsuario status)
        {
            this.Status = status;

            return this;
        }

        public Usuario BuildCompleto()
        {
            return new Usuario(
                new Nome(this.PrimeiroNome, this.UltimoNome),
                new Email(this.Email),
                new Telefone(this.DddFixo, this.TelefoneFixo),
                new Telefone(this.DddCelular, this.TelefoneCelular), 
                this.Senha, 
                this.Status);
        }

        public Usuario BuildAutenticar()
        {
            return new Usuario(new Email(this.Email), this.Senha);
        }

        public Usuario BuildAdicionar()
        {
            return new Usuario(
                new Nome(this.PrimeiroNome, this.UltimoNome),
                new Email(this.Email),
                new Telefone(this.DddFixo, this.TelefoneFixo),
                new Telefone(this.DddCelular, this.TelefoneCelular), 
                this.Senha);
        }
        #endregion 
    }
}
