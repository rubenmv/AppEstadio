using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

/// </summary>
/// SessionManager
namespace AppEstadioGen_MVP.code
{
    public sealed class SessionManager
    {
        static SessionManager instance = null;
        static readonly object padlock = new object();

        public UsuarioEN usuario = null;
        public ShoppingCart cart = null;

        Service servicio = null;

        public SessionManager()
        {
            cart = new ShoppingCart(); // El carro siempre se inicializa la primera vez
            servicio = new Service();
        }

        public static SessionManager Instance
        {
            get
            {	// Doble locking
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SessionManager();
                    }
                    return instance;
                }
            }
        }
        
        public void setUsuario(string nif)
        {
            // Recoger el UsuarioEN
            this.usuario = servicio.getUsuario(nif);
        }

		public float getPrecioTotal()
		{
			return cart.getPrecioTotal();
		}
    }
}