using Guia_3.DAOs;
using Guia_3.DTOs;
using System.Windows;

namespace Guia_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new();
            dgUsuarios.ItemsSource = daoUsuario.Obtener();
        }

        private int ObtenerIdSeleccionado()
        {
            var selected = dgUsuarios.SelectedItems;
            foreach (var item in selected)
            {
                var usr = item as UsuarioDto;
                return usr.Id;
            }
            return -1;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuario frm = new ();
            frm.ShowDialog();
            CargarDatos();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var id = ObtenerIdSeleccionado();

            if (id == -1)
                MessageBox.Show("No ha seleccionado registro a editar");
            else
            {
                FrmUsuario frmEditar = new(id);
                frmEditar.ShowDialog();
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var id = ObtenerIdSeleccionado();

            if (id == -1)
                MessageBox.Show("No ha seleccionado registro a eliminar");
            else
            {
                try
                {
                    var result = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Gestión de Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        UsuarioDao daoUsuario = new();
                        daoUsuario.Eliminar(id);
                        MessageBox.Show("Registro eliminado con éxito");
                        CargarDatos();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: "+ex.Message);
                }
            }
        }
    }
}