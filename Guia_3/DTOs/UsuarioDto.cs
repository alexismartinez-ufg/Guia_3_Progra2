using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Guia_3.DTOs
{
    internal class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int PaisId { get; set; }

        public UsuarioDto() { }

        public UsuarioDto(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            Nombre = reader.GetString(1);
            Apellido = reader.GetString(2);
            Email = reader.GetString(3);
            PaisId = reader.GetInt32(4);
        }
    }
}
