namespace EstoqueMangas.Infra.SecurityConfigurations
{
    public class TokenConfigurations
    {
        #region Propriedades
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        #endregion 
    }
}
