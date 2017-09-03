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
    public partial class DetalleAbono : Page, IVistaDetalleAbono
    {
        PresenterDetalleAbono presenter = null;
		
        public DetalleAbono(int idAbono)
        {
            InitializeComponent();
            presenter = new PresenterDetalleAbono(this, idAbono);
       }

        public AbonoEN Abono
        {
            set
            {
                this.DataContext = value;
            }

            get
            {
                return this.DataContext as AbonoEN;
            }
        }

        private void irTienda(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("abonos");
        }

        // Agrega las unidades seleccionadas del producto actual al carrito
        private void agregarAbonoCarro(object sender, RoutedEventArgs e)
        {
			int cantidad = Convert.ToInt32(sliderUnidades.Value);

			if (MessageBox.Show("Va a agregar " + cantidad + " unidades de este producto al carro ¿Está seguro?",
			  "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				presenter.AgregarAbonoCarro(cantidad);
				((MainWindow)Application.Current.MainWindow).actualizaCabecera();
			}
        }

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var slider = sender as Slider;
			double value = slider.Value;

			labelNumUnidades.Content = value;
		}
   }
}