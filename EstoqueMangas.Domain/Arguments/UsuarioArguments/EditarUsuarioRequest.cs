using System;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Arguments.Base;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class EditarUsuarioRequest : Request, IRequest
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string DddFixo { get; set; }
        public string TelefoneFixo { get; set; }
        public string DddCelular { get; set; }
        public string TelefoneCelular { get; set; }
        #endregion

        #region Construtores
        public EditarUsuarioRequest()
        {
            
        }
        #endregion 
    }
}
