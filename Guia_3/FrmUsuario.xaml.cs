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
            this.Id = id;

            if (this.Id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new();
            UsuarioDto usuario = daoUsuario.Obtener(this.Id);

            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            txtPais.Text = usuario.Pais;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDao daoUsuario = new();

            try
            {
                if (this.Id == null)
                    daoUsuario.Agregar(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtPais.Text);
                else
                    daoUsuario.Actualizar(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtPais.Text, Id.Value);

                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
    }
}
