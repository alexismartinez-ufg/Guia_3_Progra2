using Guia_3.DTOs;
using System.Data.SqlClient;

namespace Guia_3.DAOs
{
    internal class PaisDao
    {
        public List<PaisDto> ObtenerPaises()
        {
            DBConnection conn = new DBConnection();
            List<PaisDto> paises = new List<PaisDto>();

            string query = "SELECT * FROM Paises";

            using SqlConnection connection = conn.ObtenerConexion();

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    paises.Add(new PaisDto(reader));

                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }

            return paises;
        }

        public PaisDto ObtenerPaises(int id)
        {
            DBConnection conn = new DBConnection();

            string query = "SELECT * FROM Paises WHERE PaisId=@pais";

            using SqlConnection connection = conn.ObtenerConexion();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("pais", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                var pais = new PaisDto(reader);

                connection.Close();
                reader.Close();

                return pais;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
    }
}
