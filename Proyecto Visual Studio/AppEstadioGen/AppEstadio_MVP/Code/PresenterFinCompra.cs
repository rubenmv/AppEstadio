using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

/// <summary>
/// Presenter para la vista del carro de la compra
/// con los productos agregados por el usuario
/// </summary>
namespace AppEstadioGen_MVP.code
{
    public class PresenterFinCompra
    {
        private IVistaFinCompra vista = null;
        private Service servicio = null;
		private SessionManager sessionManager = null;

		public PresenterFinCompra(IVistaFinCompra vista)
        {
            this.vista = vista;
            servicio = new Service();
			sessionManager = SessionManager.Instance;
        }

		public void ObtenerUltimoPedido()
        {
			IList<PedidoEN> pedidos = servicio.getPedidosPorUsuario(sessionManager.usuario);

			if (pedidos.Count > 0)
			{
				this.vista.Pedido = pedidos[pedidos.Count - 1];
			}
        }
    }
}