using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using System;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class ObterUsuarioResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string PrimeiroNone { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string TelefoneFixo { get; set; }
        public string DddTelefoneFixo { get; set; }
        public string NumeroTelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public string DddTelefoneCelular { get; set; }
        public string NumeroTelefoneCelular { get; set; }
        public int Status { get; set; }
        #endregion
        
        #region Métodos
        public static explicit operator ObterUsuarioResponse(Usuario entidade)
        {
            return new ObterUsuarioResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
                PrimeiroNone = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Email = entidade.Email.ToString(),
                TelefoneFixo = entidade.TelefoneFixo.ToString(),
                DddTelefoneFixo = entidade.TelefoneFixo.Ddd,
                NumeroTelefoneFixo = entidade.TelefoneFixo.Numero,
                TelefoneCelular = entidade.TelefoneCelular.ToString(),
                DddTelefoneCelular = entidade.TelefoneCelular.Ddd,
                NumeroTelefoneCelular = entidade.TelefoneCelular.Numero,
                Status = (int)entidade.Status
            };
        }
        #endregion 
    }
}
