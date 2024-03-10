using System.Data.SqlClient;

namespace Guia_3
{
    internal class DBConnection
    {
        private string ConnectionString =
            "Data Source= DESKTOP-44P1TME;" +
            "Initial Catalog=GestionUsuarios;" +
            "User=sa;" +
            "Password=Admin123!";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            return connection;
        }
    }
}
