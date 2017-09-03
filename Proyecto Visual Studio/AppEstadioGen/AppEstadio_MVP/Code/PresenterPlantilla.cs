using System;
using System.Data;
using System.Configuration;
using AppEstadioGen_GestorLocal;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGen_MVP.code
{
	// El presenter es el que tiene los metodos que se comunican con el Service
	// Se podría hacer directamente llamando a los EN y CEN, pero tenerlo todo
	// en el service es mas limpio y nos deja rehusar funciones entre distintos presenters

	// El presenter tiene los metodo y el IVista... tiene las propiedades que se van a "Bindear"
    public class PresenterPlantilla
    {
    	// Tenemos un objeto IVista para este presenter
        private IVistaPlantilla vista;
        // Tambien tenemos el service, aunque no es necesario si no se va utilizar (como este ejemplo)
        // El Service es la clase que hay en el GestorLocal, en Services.cs
        private Service servicio = null;
        // Lo mismo con el SessionManager, si no lo usamos no hace falta, como  ya pasaba en la view
        SessionManager sessionManager = null;

        // Constructos
        public PresenterPlantilla(IVistaPlantilla vista)
        {
        	// Inicializa la vista con la que recibe
            this.vista = vista;
            // Inicializa el servicio y el sessionManager, como ya he dicho esto es solo si se utilizan para algo en esta clase
            servicio = new Service();
            sessionManager = SessionManager.Instance;
        }

        // Aqui tendriamos los metodos que llaman al servicio, por ejemplo este va a
        // pedir un usuario por nif
        public bool existeUsuario(string nif)
        {
        	// Utiliza el metodo que ya existe en el servicio
        	if( servicio.getUsuario(nif) == null )
        	{
        		return false; // El usuario no existe, hace return hacia el view
        	}

        	return true;
        }

    }
}