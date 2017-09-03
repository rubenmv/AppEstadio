using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterPedidos
    {
        private IVistaPedidos vista;
        private Service servicio = null;
        SessionManager sessionManager = null;

        // Constructor
        public PresenterPedidos(IVistaPedidos vista)
        {
            this.vista = vista;
            servicio = new Service();
            sessionManager = SessionManager.Instance;
        }

		public void obtenerPedidosPorEstado(AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado)
		{
			this.vista.Pedidos = servicio.getPedidosPorEstado(AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente);
		}

		public void cancelarPedido(int idPedido)
		{
			servicio.modificarEstadoPedido(idPedido, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.cancelado);
		}

		public bool confirmarPedido(int idPedido)
		{
			int resul = servicio.enviarPedido(idPedido);
			if (resul == -1)
			{
				return false;
			}
			else
			{ 
				servicio.modificarEstadoPedido(idPedido, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.confirmado);
				return true;
			}
		}

		public void ObtenerPedidosCliente()
		{
			this.vista.Pedidos = servicio.getPedidosPorUsuario(SessionManager.Instance.usuario);
		}

    }
}