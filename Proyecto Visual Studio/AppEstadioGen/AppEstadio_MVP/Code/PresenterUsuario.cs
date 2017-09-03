using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
    public class PresenterUsuario
    {
		private IVistaUsuario vista;
        private Service servicio = null;

        SessionManager sessionManager = null;

        public PresenterUsuario(IVistaUsuario vista)
        {
            this.vista = vista;
            servicio = new Service();
            sessionManager = SessionManager.Instance;

			if (sessionManager.usuario != null)
			{
				this.getUsuario(sessionManager.usuario.Nif);
			}
        }

		// Obtiene la informacion de un usuario
		public void getUsuario(string nif)
		{
			this.vista.Usuario = servicio.getUsuario(nif);
		}
        
        // Llama al login del servicio e indica si ha sido correcto
        public bool login(String nif, String pass)
        {
            if (servicio.checkLogin(nif, pass))
            {
                // Login correcto, guardamos en el sessionManager
                sessionManager.usuario = servicio.getUsuario(nif);
                return true;
            }
            
            return false;
        }

		// Funcion que realiza el registro de usuario, si es posible
		public bool registro(String nif, string pass, string nombre, string email, DateTime fecha)
		{
			// Intenta realizar el registro, si es false, entonces el usuario ya existia
			if ( servicio.registro(nif, pass, nombre, email, fecha) == false )
			{
				return false;
			}

			return true;
		}

		public bool baja()
		{
			if (servicio.bajaUsuario(sessionManager.usuario.Nif))
			{
				sessionManager.usuario = null;
				return true;
			}
			return false;
		}

		public bool modificacion(string password, string nombre, string apellidos, string email, DateTime fechaNac, string direccion, string telefono, bool nuevContra)
		{
			// No hay nueva contraseña y la antigua no es la correcta
			if (!nuevContra && !servicio.checkLogin(sessionManager.usuario.Nif, password))
			{
				return false;
			}

			UsuarioEN usuario = new UsuarioEN();
			usuario.Nif = sessionManager.usuario.Nif;
			usuario.Password = password;
			usuario.Nombre = nombre;
			usuario.Apellidos = apellidos;
			usuario.Email = email;
			usuario.FechaNac = fechaNac;
			usuario.Direccion = direccion;
			usuario.Telefono = telefono;

			if (servicio.modificarUsuario(usuario))
			{
				// Actualizamos el usuario del session manager antes de continuar
				sessionManager.usuario = usuario;
			}
			else
				return false;

			return true;
		}


    }
}