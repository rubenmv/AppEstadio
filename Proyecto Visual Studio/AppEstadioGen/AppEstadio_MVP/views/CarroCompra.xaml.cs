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
    public partial class CarroCompra : Page, IVistaCarroCompra
    {
        PresenterCarroCompra presenter = null;

        public CarroCompra()
        {
            InitializeComponent();
            presenter = new PresenterCarroCompra(this);
			onGridChange(); // Para mostrar el precio al inicio
        }

        public IList<ShoppingCartItem> ItemsCarro
        {
            set
            {
                this.DataContext = value;
            }

			get
            {
				return this.DataContext as IList<ShoppingCartItem>;
            }

        }

		// Actualiza el grid
		private void onGridChange()
		{
			dataGridItemsCarro.Items.Refresh();

			// Obtener el precio total
			float precio = presenter.getPrecioTotal();
			labelPrecioTotal.Content = precio + " €";
		}

		// Elimina los productos seleccionados
		private void BotonEliminarSeleccion(object sender, RoutedEventArgs e)
		{
			int n = dataGridItemsCarro.SelectedItems.Count;

			if (n > 0)
			{
				if (MessageBox.Show("Va a eliminar " + n + " productos del carro ¿Está seguro?",
									"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					// Obtenemos las IDs
					IList<int> listaID = new List<int>();

					foreach (ShoppingCartItem row in dataGridItemsCarro.SelectedItems)
					{
						listaID.Add(row.Id);
					}

					presenter.eliminarSeleccion(listaID);
					// Por algun motivo este dataGrid no quiere actualizarse solo
					onGridChange();
					((MainWindow)Application.Current.MainWindow).actualizaCabecera();
				}
			}
		}

		// Elimina  todos los elementos del carro
		private void BotonVaciarCarro(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Se van a eliminar todos los elementos del carrito. ¿Está seguro?", 
			  "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				presenter.VaciarCarroCompra();
				// Por algun motivo este dataGrid no quiere actualizarse solo
				onGridChange();
				((MainWindow)Application.Current.MainWindow).actualizaCabecera();
			}
		}

		private void botonContinuarCompra(object sender, RoutedEventArgs e)
		{
			if (SessionManager.Instance.usuario != null)
			{
				if (ItemsCarro.Count > 0)
				{
					// navega a la pagina de confirmar compra
					((MainWindow)Application.Current.MainWindow).irPagina("confirmarCompra");
				}
				else
				{
					MessageBox.Show("No hay productos en el carro");
				}	
			}
			else
			{
				MessageBox.Show("Antes de continuar debe acceder con su usuario y contraseña");
			}
		}

		
    }
}