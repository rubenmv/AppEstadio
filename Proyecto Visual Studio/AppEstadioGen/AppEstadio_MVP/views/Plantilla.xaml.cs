using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGen_MVP.code;
using System.Collections;

namespace AppEstadioGen_MVP.views
{
    public partial class Plantilla : Page, IVistaPlantilla
    {
    	// Aqui irian los objetos del Presenter y SessionManager
    	// El presenter siempre se pone, el SessionManager solo si se utiliza en esta clase
        PresenterPlantilla presenter = null;
        SessionManager sessionManager = null;

        // Constructor, aqui se inicializan los objetos anteriores
        public Plantilla()
        {
            InitializeComponent();
            presenter = new PresenterPlantilla(this);
            // El SessionManager es una clase con su instancia de tipo estatico
            // llamando al Instance recogemos la instancia que ya existe, con el usuario
            // logado o no logado (a null) y el carro de la compra
            sessionManager = SessionManager.Instance;

            // Asi accedemos al usuario, es de tipo UsuarioEN
            //sessionManager.usuario;
            // Asi accedemos al carro
			//sessionManager.cart;
        }

		// Para realizar el Binding tenemos que implementar el set o get en esta clase
		public IList<ShoppingCartItem> ItemsCarro
		{
			set
			{
				this.DataContext = value;
			}
		}

        // Esto es un metodo que se ejecuta al hacer clic en un boton
        // Lo de (object sender, RoutedEventArgs e) se pone siempre que sea un funcion
        // a la que se llama desde un boton u otro elemento de la interfaz
        public void irSeccion(object sender, RoutedEventArgs e)
        {
        	// El sender es el boton con el que se ha llamado a la funcion
            var button = (Button)sender;
            // El name tiene el nombre de la funcion, que es el de la pagina
            // a la que se quiere ir
            var name = button.Name.ToLower(); // a minuscula por si acaso
            // En MainWindow tenemos un irPagina con un switch-case para cada pagina
            ((MainWindow)Application.Current.MainWindow).irPagina(name);
        }

        // Este es otro ejemplo de metodo, aqui se llama al presenter
        // para comprobar si existe un usuario
        public void botonExisteUsuario(object sender, RoutedEventArgs e)
        {
            // Esto podria recogerse de algun textbox o algo asi
            // pero para el ejemplo lo pongo asi a saco
            string nif = "48333441E";
            // Usamos el presenter de esta clase y que habiamos inicializado en el constructor
            if ( presenter.existeUsuario(nif) )
            {
                // El usuario existe
                MessageBox.Show("El usuario existe");
            }
            else
            {
                // El usuario no existe
                MessageBox.Show("El usuario no existe");
            }
        }

    }
}
