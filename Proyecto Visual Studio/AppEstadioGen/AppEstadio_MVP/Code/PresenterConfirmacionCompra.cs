using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;


namespace AppEstadioGen_MVP.code
{
    public class PresenterConfirmacionCompra
    {
        private IVistaConfirmacionCompra vista = null;
        private Service servicio = null;
		private SessionManager sessionManager = null;

		public PresenterConfirmacionCompra(IVistaConfirmacionCompra vista)
        {
            this.vista = vista;
            servicio = new Service();
			sessionManager = SessionManager.Instance;

            this.ObtenerInfoUsuario();
        }

		public void ObtenerInfoUsuario()
        {
            this.vista.Usuario = sessionManager.usuario;
        }


		public bool finalizarCompra()
		{
			IList<ShoppingCartItem> itemsCarro = sessionManager.cart.getItemsCarro();
			IList<LineaPedidoEN> lineasPedido = new List<LineaPedidoEN>();

			// Creamos las lineas de pedido
			for (int i = 0; i < itemsCarro.Count; i++)
			{
				LineaPedidoEN linea = new LineaPedidoEN();
				linea.Producto = itemsCarro[i].producto; // Asocia un productoEN
				linea.Unidades = itemsCarro[i].Unidades;
				linea.Precio = itemsCarro[i].PrecioTotal;
				// Como es una composicion, no es necesario hacer el new, ya lo hara pedido
				// creamos la lista de pedidos que Pedido debera crear y asociar.
				lineasPedido.Add(linea);
			}

			if (servicio.finalizarCompra(lineasPedido, sessionManager.usuario))
			{
				// Limpiamos el carro
				sessionManager.cart.vaciarCarro();
				return true;
			}

			return false;
		}

    }
}