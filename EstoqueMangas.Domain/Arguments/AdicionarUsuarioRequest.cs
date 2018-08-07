using EstoqueMangas.Domain.Interfaces.Arguments;

namespace EstoqueMangas.Domain.Arguments
{
    public class AdicionarUsuarioRequest : IRequest
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
        #endregion

        #region Construtores
        public AdicionarUsuarioRequest()
        {

        }
        #endregion 
    }
}
