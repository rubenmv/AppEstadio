using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;

namespace AppEstadioGen_MVP.code
{
    public class PresenterEntradas
    {
        private IVistaEntradas vista;
        private Service servicio = null;

        public PresenterEntradas(IVistaEntradas vista)
        {
            this.vista = vista;
            servicio = new Service();

            this.ObtenerEntradasTienda();
        }

        public void ObtenerEntradasTienda()
        {
            vista.TiendaEntradas = servicio.getEntradasTienda();
        }

        public void eliminarSeleccionTienda(IList<int> seleccion)
        {
            servicio.eliminarProductos(seleccion);
        }
    }
}