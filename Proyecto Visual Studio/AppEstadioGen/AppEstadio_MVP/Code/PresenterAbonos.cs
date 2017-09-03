using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;

namespace AppEstadioGen_MVP.code
{
    public class PresenterAbonos
    {
         private IVistaAbonos vista;
        private Service servicio = null;

        public PresenterAbonos(IVistaAbonos vista)
        {
            this.vista = vista;
            servicio = new Service();

            this.ObtenerAbonosTienda();
        }

        public void ObtenerAbonosTienda()
        {
            vista.TiendaAbonos = servicio.getAbonosTienda();
        }

        public void eliminarSeleccionTienda(IList<int> seleccion)
        {
            servicio.eliminarProductos(seleccion);
        }
    }
}