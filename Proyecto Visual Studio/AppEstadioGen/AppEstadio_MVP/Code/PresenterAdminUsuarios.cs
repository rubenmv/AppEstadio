using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;

namespace AppEstadioGen_MVP.code
{
    public class PresenterUsuarios
    {
        private IVistaUsuarios vista;
        private Service servicio = null;

        public PresenterUsuarios(IVistaUsuarios vista)
        {
            this.vista = vista;
            servicio = new Service();

            this.ObtenerUsuarios();
        }

        public void ObtenerUsuarios()
        {
            vista.Usuarios = servicio.getUsuarios();
        }

        public void eliminarUsuarios(IList<string> seleccion)
        {
            servicio.eliminarUsuarios(seleccion);
        }

       
    }
}