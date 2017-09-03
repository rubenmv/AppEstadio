using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;


namespace AppEstadioGen_MVP.code
{
    public class PresenterTienda
    {
        private IVistaTienda vista;
        private Service servicio = null;

        public PresenterTienda(IVistaTienda vista)
        {
            this.vista = vista;
            servicio = new Service();

            this.ObtenerProductosTienda();
        }

        public void ObtenerProductosTienda()
        {
            vista.TiendaProductos = servicio.getProductosTienda();
        }

        public void BuscarProductosTienda(string termino)
        {
            vista.TiendaProductos = servicio.getProductosPorNombre(termino);
        }

		public void BuscarPorPrecio(float min, float max)
		{
			vista.TiendaProductos = servicio.getProductosPorRangoPrecio(min, max);
		}

		// Elimina una lista de items seleccionado
		public void eliminarSeleccionTienda(IList<int> seleccion)
		{
			servicio.eliminarProductos(seleccion);
		}
    }
}