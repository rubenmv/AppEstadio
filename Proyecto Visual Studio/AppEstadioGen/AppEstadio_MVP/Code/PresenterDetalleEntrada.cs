using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterDetalleEntrada
    {
        private IVistaDetalleEntrada vista;
        private Service servicio = null;
        private SessionManager sessionManager = null;

        public PresenterDetalleEntrada(IVistaDetalleEntrada vista, int idEntrada)
        {
            this.vista = vista;
            servicio = new Service();
            sessionManager = SessionManager.Instance;

            this.ObtenerInfoEntrada(idEntrada);
        }

        public void ObtenerInfoEntrada(int idEntrada)
        {
            this.vista.Entrada = servicio.getEntradaPorId(idEntrada);
        }

        public void AgregarEntradaCarro(int cantidad)
        {
            sessionManager.cart.addItem(this.vista.Entrada, cantidad);
        }

		public bool compruebaStock()
		{
			// Necesitamos recoger de nuevo la informacion actualizada
			this.ObtenerInfoEntrada(this.vista.Entrada.Id);

			if (this.vista.Entrada.Stock > 0)
				return true;
			else
				return false;
		}
    } 
}