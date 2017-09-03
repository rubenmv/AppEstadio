using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;


namespace AppEstadioGen_MVP.code
{
    public class PresenterDetallePedido
    {
        private IVistaDetallePedido vista;
        private Service servicio = null;

        public PresenterDetallePedido(IVistaDetallePedido vista, int idPedido)
        {
            this.vista = vista;
            servicio = new Service();

			ObtenerLineasPedido(idPedido);
        }

		public void ObtenerLineasPedido(int pedido)
		{
			this.vista.Lineas = servicio.getLineasPedido(pedido);
		}
    }
}