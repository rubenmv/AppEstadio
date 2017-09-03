using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterAdminNuevoProducto
    {
		private IVistaAdminNuevoProducto vista;
        private Service servicio = null;

		public PresenterAdminNuevoProducto(IVistaAdminNuevoProducto vista)
        {
            this.vista = vista;
            servicio = new Service();
        }
        
		public bool crearProducto(string nombre, string descripcion, float precio, string color, int tipo, int stock, string foto)
		{
			// Intenta crear el producto
			if ( servicio.crearProducto(nombre, descripcion, precio, color, tipo, stock, foto) == false )
			{
				return false;
			}

			return true;
		}

		public bool crearEntrada(string nombre, string descripcion, float precio, string tipo, int stock, string foto, DateTime? fecha, string grada)
		{
			// Intenta crear el producto
			if (servicio.crearEntrada(nombre, descripcion, precio, tipo, stock, foto, fecha, grada) == false)
			{
				return false;
			}

			return true;
		}

		public bool crearAbono(string nombre, string descripcion, float precio, string tipo, int stock, string foto, string grada)
		{
			// Intenta crear el producto
			if (servicio.crearAbono(nombre, descripcion, precio, tipo, stock, foto, grada) == false)
			{
				return false;
			}

			return true;
		}
    }
}