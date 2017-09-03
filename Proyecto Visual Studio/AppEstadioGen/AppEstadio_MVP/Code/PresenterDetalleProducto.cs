using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterDetalleProducto
    {
        private IVistaDetalleProducto vista;
        private Service servicio = null;
        private SessionManager sessionManager = null;

        public PresenterDetalleProducto(IVistaDetalleProducto vista, int idProducto)
        {
            this.vista = vista;
            servicio = new Service();
            sessionManager = SessionManager.Instance;

            this.ObtenerInfoProducto(idProducto);
        }

        public void ObtenerInfoProducto(int idProducto)
        {
            this.vista.Producto = servicio.getProductoPorId(idProducto);
        }

        public void AgregarProductoCarro(int cantidad)
        {
            sessionManager.cart.addItem(this.vista.Producto, cantidad);
        }

		public IList<TallaEN> getNombreTallasProducto(int id)
		{
			return servicio.getTallasProducto(id);
		}

		public bool compruebaStock()
		{
			// Necesitamos recoger de nuevo la informacion actualizada
			this.ObtenerInfoProducto(this.vista.Producto.Id);

			if (this.vista.Producto.Stock > 0)
				return true;
			else
				return false;
		}
    } 
}