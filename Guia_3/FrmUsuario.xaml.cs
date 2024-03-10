using Guia_3.DAOs;
using Guia_3.DTOs;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            try
            {
                if (ValidarCampos())
                {
                    UsuarioDao daoUsuario = new();
                    PaisDto paisSeleccionado = (PaisDto)txtPais.SelectedItem;
                    int paisId = paisSeleccionado?.PaisId ?? 0;

                    if (this.Id == null)
                        daoUsuario.Agregar(txtNombre.Text, txtApellido.Text, txtEmail.Text, paisId);
                    else
                        daoUsuario.Actualizar(txtNombre.Text, txtApellido.Text, txtEmail.Text, paisId, Id.Value);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, corrige los errores en los campos.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarTexto(txtNombre);
        }

        private void txtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarTexto(txtApellido);
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarEmail(txtEmail.Text);
        }

        private bool ValidarTexto(TextBox txt)
        {
            string regex = "[a-zA-Z]+$"; // Solo letras de la a-z o A-Z

            if (!Regex.IsMatch(txt.Text, regex))
            {
                txt.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                txt.BorderBrush = Brushes.Black;
                return true;
            }
        }

        private bool ValidarEmail(string email)
        {
            string regex = @"^([\w\.\-]+)@([\w\-]+)\.([a-zA-Z]{2,6})$";
            if (!Regex.IsMatch(email, regex))
            {
                txtEmail.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                txtEmail.BorderBrush = Brushes.Black;
                return true;
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;

            if (!ValidarTexto(txtNombre))
                esValido = false;

            if (!ValidarTexto(txtApellido))
                esValido = false;

            if (!ValidarEmail(txtEmail.Text))
                esValido = false;

            return esValido;
        }
    }
}
