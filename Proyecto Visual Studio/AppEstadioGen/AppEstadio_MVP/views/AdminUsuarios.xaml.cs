using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGen_MVP.code;
using System.Collections;

namespace AppEstadioGen_MVP.views
{
    public partial class AdminUsuarios : Page, IVistaUsuarios
    {
        PresenterUsuarios presenter = null;

        public AdminUsuarios()
        {
            InitializeComponent();

            presenter = new PresenterUsuarios(this);

        }

        public IList<UsuarioEN> Usuarios
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void limpiarBusqueda(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.Text = "";
        }

        private void onGridChange()
        {
            dataGridProductos.Items.Refresh();
        }


        private void BotonEliminarSeleccion(object sender, RoutedEventArgs e)
        {
            int n = dataGridProductos.SelectedItems.Count;

            if (n > 0)
            {
                if (MessageBox.Show("Va a eliminar completamente al usuario ¿Está seguro?",
                                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Obtenemos las IDs
                    IList<string> listaID = new List<string>();

                    foreach (UsuarioEN row in dataGridProductos.SelectedItems)
                    {
                        listaID.Add(row.Nif);
                    }

                    presenter.eliminarUsuarios(listaID);

					for (int i = 0; i < listaID.Count; i++)
					{
						if (SessionManager.Instance.usuario.Nif == listaID[i])
						{
							// El usuario eliminado es el logado, limpiamos session
							SessionManager.Instance.usuario = null;
							((MainWindow)Application.Current.MainWindow).actualizaCabecera();
							((MainWindow)Application.Current.MainWindow).irPagina("login");
						}
					}

                    // Por algun motivo este dataGrid no quiere actualizarse solo
                    onGridChange();
                }
            }
        }


    }
}
