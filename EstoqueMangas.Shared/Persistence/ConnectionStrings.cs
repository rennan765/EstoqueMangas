namespace EstoqueMangas.Shared.Persistence
{
    public static class ConnectionStrings
    {
        #region Métodos
        public static string MySQL()
        {
            return "Server=localhost;User Id=root;Password=root;Database=EstoqueMangas";
        }

        public static string SQLServer()
        {
            return "Data Source=localhost;Initial Catalog=EstoqueMangas;Integrated Security=True;";
        }
        #endregion 
    }
}
