namespace Guia_3.DTOs
{
    internal class UsuarioConPaisDto
    {
        public UsuarioConPaisDto(UsuarioDto usuario, string nombrePais)
        {
            NombrePais = nombrePais;
            Id= usuario.Id;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombrePais { get; set; }
    }
}
