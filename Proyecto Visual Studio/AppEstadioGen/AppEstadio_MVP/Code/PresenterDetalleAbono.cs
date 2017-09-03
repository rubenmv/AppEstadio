using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterDetalleAbono
    {
        private IVistaDetalleAbono vista;
        private Service servicio = null;
        private SessionManager sessionManager = null;

        public PresenterDetalleAbono(IVistaDetalleAbono vista, int idAbono)
        {
            this.vista = vista;
            servicio = new Service();
            sessionManager = SessionManager.Instance;

            this.ObtenerInfoAbono(idAbono);
        }

        public void ObtenerInfoAbono(int idAbono)
        {
            this.vista.Abono = servicio.getAbonoPorId(idAbono);
        }

        public void AgregarAbonoCarro(int cantidad)
        {
            sessionManager.cart.addItem(this.vista.Abono, cantidad);
        }

		public bool compruebaStock()
		{
			// Necesitamos recoger de nuevo la informacion actualizada
			this.ObtenerInfoAbono(this.vista.Abono.Id);

			if (this.vista.Abono.Stock > 0)
				return true;
			else
				return false;
		}
    } 
}