﻿using System;
using EstoqueMangas.Core.Enuns;
using EstoqueMangas.Core.ValueObjects;

namespace EstoqueMangas.Core.Entities.Build
{
    public class UsuarioBuild : IDisposable
    {

        #region Propriedades
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string DddFixo { get; private set; }
        public string TelefoneFixo { get; private set; }
        public string DddCelular { get; private set; }
        public string TelefoneCelular { get; private set; }
        public string Senha { get; private set; }
        public StatusUsuario Status { get; private set; }
        #endregion

        #region Construtores
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
                telefoneFixo = new Telefone(Convert.ToInt32(this.DddFixo), this.TelefoneFixo, TipoTelefone.Fixo);
            }

            if (!string.IsNullOrEmpty(this.TelefoneFixo))
            {
                telefoneCelular = new Telefone(Convert.ToInt32(this.DddCelular), this.TelefoneCelular, TipoTelefone.Celular);
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
