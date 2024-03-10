using System.Data.SqlClient;

namespace Guia_3.DTOs
{
    internal class PaisDto
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; }

        public PaisDto(SqlDataReader reader)
        {
            PaisId = reader.GetInt32(0);
            NombrePais = reader.GetString(1);
        }
    }
}
