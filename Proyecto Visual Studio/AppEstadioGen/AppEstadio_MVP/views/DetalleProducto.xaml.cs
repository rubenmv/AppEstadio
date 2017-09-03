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
    public partial class DetalleProducto : Page, IVistaDetalleProducto
    {
        PresenterDetalleProducto presenter = null;
		IList<TallaEN> tallas = null;

        public DetalleProducto(int idProducto)
        {
            InitializeComponent();
            presenter = new PresenterDetalleProducto(this, idProducto);

			initTallas();
			compruebaStock();
        }

        public ProductoEN Producto
        {
            set
            {
                this.DataContext = value;
            }

            get
            {
                return this.DataContext as ProductoEN;
            }
        }

        private void irTienda(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("tienda");
        }

        // Agrega las unidades seleccionadas del producto actual al carrito
        private void agregarProductoCarro(object sender, RoutedEventArgs e)
        {
			int cantidad = Convert.ToInt32(sliderUnidades.Value);

			if (MessageBox.Show("Va a agregar " + cantidad + " unidades de este producto al carro ¿Está seguro?",
			  "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				presenter.AgregarProductoCarro(cantidad);
				compruebaStock();
				((MainWindow)Application.Current.MainWindow).actualizaCabecera();
			}
        }

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var slider = sender as Slider;
			double value = slider.Value;

			labelNumUnidades.Content = value;
		}

		public void initTallas()
		{
			tallas = presenter.getNombreTallasProducto(Producto.Id);

			if (tallas.Count > 0)
			{
				comboTam.Visibility = System.Windows.Visibility.Visible;
				lTalla.Visibility = System.Windows.Visibility.Visible;

				for (int i = 0; i < tallas.Count; i++)
				{
					comboTam.Items.Add(tallas[i].Nombre);
				}

				comboTam.SelectedIndex = 0;
				medidas.Content = tallas[0].Medidas;
			}
			else
			{
				comboTam.Visibility = System.Windows.Visibility.Hidden;
				lTalla.Visibility = System.Windows.Visibility.Hidden;
			}
		}

		public void compruebaStock()
		{
			if (presenter.compruebaStock())
			{
				labelStock.Content = "¡Tenemos en stock!";
			}
			else
			{
				labelStock.Content = "No queda stock de este producto";
			}
		}

		private void comboTam_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			medidas.Content = tallas[comboTam.SelectedIndex].Medidas;
		}
    }
}