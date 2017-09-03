using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

/// </summary>
/// ShoppingCartItem
namespace AppEstadioGen_MVP.code
{
    public class ShoppingCartItem
    {
		public ProductoEN producto; // Esto nos sirve para finalizar la compra
		// Estos nos sirven para hacer el binding
        public int Id  {get; set;}
        public string Nombre{ get; set; }
        public int Stock { get; set; }
        public int Unidades { get; set; }
        public float PrecioUnitario { get; set; }
        public float PrecioTotal { get; set; }

        public ShoppingCartItem(ProductoEN producto, int cantidad)
        {
			this.producto = producto;
            this.Id = producto.Id;
            this.Nombre = producto.Nombre;
            this.Stock = producto.Stock;
            this.PrecioUnitario = producto.Precio;
            this.Unidades = cantidad;
            this.PrecioTotal = producto.Precio * cantidad;
        }

		// Actualiza las unidades y el precio total
		public void agregarUnidades(int cantidad)
		{
			this.Unidades += cantidad;
			this.PrecioTotal = this.PrecioUnitario * this.Unidades;
		}
    }
}