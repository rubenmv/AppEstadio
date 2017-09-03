using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

/// </summary>
/// ShoppingCart
namespace AppEstadioGen_MVP.code
{
    public class ShoppingCart
    {
        // Lista de productos en el carro
        private IList<ShoppingCartItem> items;
		private float precioTotal;

        public ShoppingCart()
        {
            items = new List<ShoppingCartItem>();
			precioTotal = 0;
        }

        public IList<ShoppingCartItem> getItemsCarro()
        {
            return items;
        }

		public float getPrecioTotal()
		{
			return precioTotal;
		}

		public int getNumItems()
		{
			return this.items.Count;
		}

		public void updatePrecioTotal()
		{
			this.precioTotal = 0;

			if (items.Count > 0)
			{
				for (int i = 0; i < items.Count; i++)
				{
					this.precioTotal += items[i].PrecioTotal;
				}
			}

		}

        public void addItem(ProductoEN producto, int cantidad)
        {
			bool encontrado = false;

			// Comprobamos si ya existe en la lista
			if (items.Count > 0)
			{
				for (int i = 0; i < items.Count && !encontrado; i++)
				{
					if (items[i].Id == producto.Id)
					{
						items[i].agregarUnidades(cantidad); // Agrega las unidades
						encontrado = true;
					}
				}
			}
			// El item es nuevo
			if (!encontrado)
			{
				ShoppingCartItem itemCarro = new ShoppingCartItem(producto, cantidad);
				items.Add(itemCarro);
			}

			updatePrecioTotal();
            
        }

		// Comprueba si un producto (por ID) esta en el carro
		// devuelve la posicion en este, -1 si no esta
		public int isInCart(int id)
		{
			int posicion = -1;
			bool encontrado = false;

			for (int i = 0; i < this.items.Count && !encontrado; i++)
			{
				if (this.items[i].Id == id)
				{
					posicion = i;
					encontrado = true;
				}
			}

			return posicion;
		}

		// Elimina los items indicados segun su ID
        public void removeItems(IList<int> listaIDs)
        {
			for (int i = 0; items.Count > 0 && i < listaIDs.Count; i++)
			{
				int posicion = isInCart(listaIDs[i]);
				if (posicion > -1)
				{
					items.RemoveAt(posicion);
				}
			}

			updatePrecioTotal();
        }

		public void vaciarCarro()
		{
			items.Clear();
			updatePrecioTotal();
		}
    }
}