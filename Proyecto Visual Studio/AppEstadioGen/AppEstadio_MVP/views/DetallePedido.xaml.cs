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

    public partial class DetallePedido : Page, IVistaDetallePedido
    {
		PresenterDetallePedido presenter = null;

        public DetallePedido(int idPedido)
        {
            InitializeComponent();
			presenter = new PresenterDetallePedido(this, idPedido);
        }

		public IList<LineaPedidoEN> Lineas
		{
			set
			{
				this.DataContext = value;
			}
			get
			{
				return this.DataContext as IList<LineaPedidoEN>;
			}
		}
    }
}
