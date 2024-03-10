using System.Data.SqlClient;

namespace Guia_3.DTOs
{
    internal class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }

        public UsuarioDto() { }

        public UsuarioDto(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            Nombre = reader.GetString(1);
            Apellido = reader.GetString(2);
            Email = reader.GetString(3);
            Pais = reader.GetString(4);
        }
    }
}
