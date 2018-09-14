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
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            DddFixo = dddFixo;
            TelefoneFixo = telefoneFixo;
            DddCelular = dddCelular;
            TelefoneCelular = telefoneCelular;
            Senha = senha;
            Status = statusUsuario;
        }

        public UsuarioBuild(string primeiroNome, string ultimoNome, string email, string dddFixo, string telefoneFixo, string dddCelular, string telefoneCelular, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            DddFixo = dddFixo;
            TelefoneFixo = telefoneFixo;
            DddCelular = dddCelular;
            TelefoneCelular = telefoneCelular;
            Senha = senha;
        }

        public UsuarioBuild(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
        #endregion

        #region Métodos
        public UsuarioBuild AdicionarNome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            return this;
        }

        public UsuarioBuild AdicionarEmail(string email)
        {
            Email = email;

            return this;
        }

        public UsuarioBuild AdicionarTelefoneFixo(string dddFixo, string numeroFixo)
        {
            DddFixo = dddFixo;
            TelefoneFixo = numeroFixo;

            return this;
        }

        public UsuarioBuild AdicionarTelefoneCelular(string dddCelular, string numeroCelular)
        {
            DddCelular = dddCelular;
            TelefoneCelular = numeroCelular;

            return this;
        }

        public UsuarioBuild AdicionarSenha(string senha)
        {
            Senha = senha;

            return this;
        }

        public UsuarioBuild AdicionarStatus(StatusUsuario status)
        {
            Status = status;

            return this;
        }

        public Usuario BuildCompleto()
        {
            return new Usuario(
                new Nome(PrimeiroNome, UltimoNome),
                new Email(Email),
                new Telefone(DddFixo, TelefoneFixo),
                new Telefone(DddCelular, TelefoneCelular), 
                Senha, 
                Status);
        }

        public Usuario BuildAutenticar()
        {
            return new Usuario(new Email(Email), Senha);
        }

        public Usuario BuildAdicionar()
        {
            return new Usuario(
                new Nome(PrimeiroNome, UltimoNome),
                new Email(Email),
                new Telefone(DddFixo, TelefoneFixo),
                new Telefone(DddCelular, TelefoneCelular), 
                Senha);
        }
        #endregion 
    }
}
