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
    public partial class FinCompra : Page, IVistaFinCompra
    {
		PresenterFinCompra presenter = null;

        public FinCompra()
        {
            InitializeComponent();

			presenter = new PresenterFinCompra(this);

			presenter.ObtenerUltimoPedido();
        }

		public PedidoEN Pedido
		{
			set
			{
				this.DataContext = value;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).irPagina("inicio");
		}

    }
}
