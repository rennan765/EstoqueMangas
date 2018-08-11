namespace EstoqueMangas.Shared
{
    public static class Settings
    {
        #region Métodos
        public static string MySQLConnectionString()
        {
            return "Server=localhost;User Id=root;Password=root;Database=EstoqueMangas";
        }

        public static string SQLServerConnectionString()
        {
            return "Data Source=localhost;Initial Catalog=EstoqueMangas;Integrated Security=True;";
        }
        #endregion 
    }
}
