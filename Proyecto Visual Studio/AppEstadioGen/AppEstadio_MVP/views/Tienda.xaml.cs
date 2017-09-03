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
    public partial class Tienda : Page, IVistaTienda
    {
        PresenterTienda presenter = null;

        public Tienda()
        {
            InitializeComponent();
            presenter = new PresenterTienda(this);

			// Agregamos el manejador para la caja de busqueda, asi podemos borrarla al clic
			search_box.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(limpiarBusqueda), true);

			// Inicializamos los sliders
			sMinimo.Value = 0;
			sMaximo.Value = 500;
        }


        public IList<ProductoEN> TiendaProductos
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void busqueda(object sender, EventArgs e)
        {
            presenter.BuscarProductosTienda(search_box.Text);
        }

        // Al hacer clic sobre una fila del datagrid
        private void abrirDetalleProducto(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
				if (dataGridProductos.SelectedCells.Count > 0)
				{
					ProductoEN producto = dataGridProductos.SelectedCells[0].Item as ProductoEN;
					int idProducto = producto.Id;
					((MainWindow)Application.Current.MainWindow).irDetalleProducto(idProducto);
				}
            }
        }

        // Aqui se llega desde continuar compra o desde el icono del carrito
        private void botonContinuar_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("carro");
        }

	

		private void limpiarBusqueda(object sender, MouseButtonEventArgs e)
		{
			TextBox tb = sender as TextBox;

			tb.Text = "";
		}

		// Se modifica alguno de los slider, cambia el valor
		private void sMaximo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Slider slider = sender as Slider;
			lMaximo.Content = slider.Value;
		}

		private void sMinimo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Slider slider = sender as Slider;
			lMinimo.Content = slider.Value;
		}

		private void filtrarPrecio(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
		{
			Slider min = sMinimo;
			Slider max = sMaximo;

			if (min.Value < max.Value)
			{
				errorFiltro.Content = "";
	
				presenter.BuscarPorPrecio(Convert.ToSingle(min.Value), Convert.ToSingle(max.Value));
			}
			else
			{
				errorFiltro.Content = "Rango incorrecto";
			}
		}
    }
}