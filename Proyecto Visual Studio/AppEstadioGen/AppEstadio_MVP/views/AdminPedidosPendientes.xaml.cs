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
	public partial class AdminPedidosPendientes : Page, IVistaPedidos
    {
        PresenterPedidos presenter = null;

        public AdminPedidosPendientes()
        {
            InitializeComponent();
			presenter = new PresenterPedidos(this);

			presenter.obtenerPedidosPorEstado(AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente);
        }

        private void abrirDetallePedido(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                if (dataGridPedidos.SelectedCells.Count > 0)
                {
                    PedidoEN pedido = dataGridPedidos.SelectedCells[0].Item as PedidoEN;
                    int idPedido = pedido.Id;
                    ((MainWindow)Application.Current.MainWindow).irDetallePedido(idPedido);
                }
            }
        }

		// Para realizar el Binding tenemos que implementar el set o get en esta clase
		public IList<PedidoEN> Pedidos
		{
			set
			{
				this.DataContext = value;
			}
		}

        public void irSeccion(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var name = button.Name.ToLower(); // a minuscula por si acaso
            ((MainWindow)Application.Current.MainWindow).irPagina(name);
        }

		private void refresh()
		{
			dataGridPedidos.Items.Refresh();
		}

		private void cancelarSeleccion(object sender, RoutedEventArgs e)
		{
			if (dataGridPedidos.SelectedCells.Count > 0)
			{
				PedidoEN pedido = dataGridPedidos.SelectedCells[0].Item as PedidoEN;
				if (pedido.Estado == AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente)
				{
					if (MessageBox.Show("Va a cancelar el pedido seleccionado, ¿Esta seguro?",
										"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					{
						presenter.cancelarPedido(pedido.Id);
						refresh();
					}
				}
				else
				{
					MessageBox.Show("Solo puede cancelar pedidos en estado pendiente.");
				}
			}
		}

		private void confirmarSeleccion(object sender, RoutedEventArgs e)
		{
			if (dataGridPedidos.SelectedCells.Count > 0)
			{
				PedidoEN pedido = dataGridPedidos.SelectedCells[0].Item as PedidoEN;
				if (pedido.Estado == AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente)
				{
					if (MessageBox.Show("Va a confirmar el pedido seleccionado, generar la factura y restar su stock, ¿Esta seguro?",
										"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					{
						if (!presenter.confirmarPedido(pedido.Id))
						{
							MessageBox.Show("No se puede realizar el pedido, revise el stock de los productos");
						}
						
						refresh();
					}
				}
				else
				{
					MessageBox.Show("Solo puede cancelar pedidos en estado pendiente.");
				}
			}
		}

    }
}
