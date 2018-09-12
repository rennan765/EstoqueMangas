namespace EstoqueMangas.Api.Security
{
    /// <summary>
    /// Token configurations.
    /// </summary>
    public class TokenConfigurations
    {
        #region Propriedades
        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        /// <value>The audience.</value>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>The issuer.</value>
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>The seconds.</value>
        public int Seconds { get; set; }
        #endregion 
    }
}
