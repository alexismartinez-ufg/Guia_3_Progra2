using Guia_3.DAOs;
using Guia_3.DTOs;
using System.Windows;

namespace Guia_3
{
    /// <summary>
    /// Lógica de interacción para FrmUsuario.xaml
    /// </summary>
    public partial class FrmUsuario : Window
    {
        private int? Id;

        public FrmUsuario(int? id = null)
        {
            InitializeComponent();
            CargarPaises();

            this.Id = id;

            if (this.Id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new();
            PaisDao daoPais = new();
            UsuarioDto usuario = daoUsuario.Obtener(this.Id);
            PaisDto pais = daoPais.ObtenerPaises(usuario.PaisId);

            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            txtPais.Text = pais.NombrePais;
        }

        private void CargarPaises()
        {
            PaisDao paisesDao = new();
            txtPais.ItemsSource = paisesDao.ObtenerPaises();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDao daoUsuario = new();

            try
            {
                PaisDto paisSeleccionado = (PaisDto)txtPais.SelectedItem;
                int paisId = paisSeleccionado?.PaisId ?? 0;

                if (this.Id == null)
                    daoUsuario.Agregar(txtNombre.Text, txtApellido.Text, txtEmail.Text, paisId);
                else
                    daoUsuario.Actualizar(txtNombre.Text, txtApellido.Text, txtEmail.Text, paisId, Id.Value);

                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
    }
}
