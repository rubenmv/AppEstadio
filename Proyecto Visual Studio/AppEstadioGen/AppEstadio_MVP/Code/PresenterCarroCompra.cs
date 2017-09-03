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
    public class PresenterCarroCompra
    {
        private IVistaCarroCompra vista = null;
        private Service servicio = null;
		private SessionManager sessionManager = null;

        public PresenterCarroCompra(IVistaCarroCompra vista)
        {
            this.vista = vista;
            servicio = new Service();
			sessionManager = SessionManager.Instance;

            this.ObtenerItemsCarro();
        }

        public void ObtenerItemsCarro()
        {
            this.vista.ItemsCarro = sessionManager.cart.getItemsCarro();
        }

		// Elimina una lista de items seleccionado
		public void eliminarSeleccion(IList<int> seleccion)
		{
			sessionManager.cart.removeItems(seleccion);
		}

		// Limpia el carro de la compra
		public void VaciarCarroCompra()
		{
			sessionManager.cart.vaciarCarro();
			this.ObtenerItemsCarro();
		}

		public float getPrecioTotal()
		{
			return sessionManager.cart.getPrecioTotal();
		}
    }
}