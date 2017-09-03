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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class AdminEntradas : Page, IVistaEntradas // Implementa el mismo presenter que la tienda
    {
        PresenterEntradas presenter = null;

        public AdminEntradas()
        {
            InitializeComponent();

            presenter = new PresenterEntradas(this);

            // Agregamos el manejador para la caja de busqueda, asi podemos borrarla al clic
          //  search_box.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(limpiarBusqueda), true);
        }

        public IList<EntradaEN> TiendaEntradas
        {
            set
            {
                this.DataContext = value;
            }
        }

       /* private void busqueda(object sender, EventArgs e)
        {
            presenter.BuscarProductosTienda(search_box.Text);
        }*/

        private void limpiarBusqueda(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.Text = "";
        }

        // Abre la vista con el formulario para crear un nuevo producto
        private void botonAgregarNuevo(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("adminNuevaEntrada");
        }

        // Actualiza el grid y precio total
        private void onGridChange()
        {
            dataGridProductos.Items.Refresh();
        }


        private void BotonEliminarSeleccion(object sender, RoutedEventArgs e)
        {
            int n = dataGridProductos.SelectedItems.Count;

            if (n > 0)
            {
                if (MessageBox.Show("Va a eliminar " + n + " productos ¿Está seguro?",
                                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Obtenemos las IDs
                    IList<int> listaID = new List<int>();

                    foreach (EntradaEN row in dataGridProductos.SelectedItems)
                    {
                        listaID.Add(row.Id);
                    }

                    presenter.eliminarSeleccionTienda(listaID);

                    // Por algun motivo este dataGrid no quiere actualizarse solo
                    onGridChange();
                }
            }
        }


    }
}
