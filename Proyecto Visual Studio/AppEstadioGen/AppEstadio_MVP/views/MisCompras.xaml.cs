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

    public partial class MisCompras : Page, IVistaPedidos
    {
		PresenterPedidos presenter = null;

        public MisCompras()
        {
            InitializeComponent();
			presenter = new PresenterPedidos(this);

			presenter.ObtenerPedidosCliente();
        }

		public IList<PedidoEN> Pedidos
		{
			set
			{
				this.DataContext = value;
			}
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

		private void BotonEliminarSeleccion(object sender, RoutedEventArgs e)
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
						dataGridPedidos.Items.Refresh();
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
