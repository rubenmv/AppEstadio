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
using System.Text.RegularExpressions;

namespace AppEstadioGen_MVP.views
{
    public partial class ConfiguracionPerfil : Page, IVistaUsuario
    {
    	// Aqui irian los objetos del Presenter y SessionManager
    	// El presenter siempre se pone, el SessionManager solo si se utiliza en esta clase
		PresenterUsuario presenter = null;
        SessionManager sessionManager = null;

        // Constructor, aqui se inicializan los objetos anteriores
        public ConfiguracionPerfil()
        {
            InitializeComponent();
			presenter = new PresenterUsuario(this);
            // El SessionManager es una clase con su instancia de tipo estatico
            // llamando al Instance recogemos la instancia que ya existe, con el usuario
            // logado o no logado (a null) y el carro de la compra
            sessionManager = SessionManager.Instance;


			/*
            textBoxNombre.Text = sessionManager.usuario.Nombre;
			textBoxApellidos.Text = sessionManager.usuario.Apellidos;
			textBoxEmail.Text = sessionManager.usuario.Email;
			textBoxDireccion.Text = sessionManager.usuario.Direccion;
			textBoxTelefono.Text = sessionManager.usuario.Telefono;
			fechaNac.SelectedDate = sessionManager.usuario.FechaNac;
			 * */
        }

		public UsuarioEN Usuario
		{
			set
			{
				this.DataContext = value;
			}

			get
			{
				return this.DataContext as UsuarioEN;
			}
		}

        private void botonDarseDeBaja(object sender, RoutedEventArgs e)
		{

			if (MessageBox.Show("Dar de baja. Su usuario se eliminara completamente ¿Está seguro?",
			  "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				if (presenter.baja())
				{
					((MainWindow)Application.Current.MainWindow).actualizaCabecera();
					((MainWindow)Application.Current.MainWindow).irPagina("login");
				}
				else
				{
					resultadoBaja.Content = "Ha habido algún error dando de baja el usuario";
				}
			}

		}

        private void botonModificarPerfil(object sender, RoutedEventArgs e)
		{
			// Validacion de campos
			bool correcto = true;

			// Nombre
			if (textBoxNombre.Text.Length == 0)
			{
				errorusuario.Content = "Introduzca su nombre.";
				correcto = false;
			}
			else { errorusuario.Content = ""; }

			//Comprobacion del email
			if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
			{
				label3.Content = "Introduzca un email correcto.";
				correcto = false;
			}
			else if (Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
			{
				label3.Content = "";

			}

			// Fecha de nacimiento
			DateTime zeroTime = new DateTime(1, 1, 1);
			DateTime fecha = fechaNac.SelectedDate.Value.Date;
			DateTime hoy = DateTime.Now;

			TimeSpan span = hoy - fecha;
			int years = (zeroTime + span).Year - 1;

			if (years < 18)
			{
				label7.Content = "Fecha incorrecta, debes ser mayor de 18";
				correcto = false;
			}
			else { label7.Content = ""; }

			// Telefono
			if (textBoxTelefono.Text.Length != 0 && textBoxTelefono.Text.Length != 9)
			{
				label6.Content = "El telefono deben ser 9 dígitos.";
				correcto = false;
			}
			else { label6.Content = ""; }

			// Contraseñas -------------------------------------------------------
			string contra = "";
			bool nuevaContra = false;

			// Confirmacion de password actual
			if (textBoxPassword.Password.Length == 0)
			{
				correcto = false;
			}
			else
			{
				contra = textBoxPassword.Password;
			}
			// Cambio de contraseña
            if (textBoxNewPassword.Password.Length != 0)
			{
				if (textBoxNewPassword.Password != textBoxNewPassword2.Password)
				{
					label1.Content = "Las nuevas contraseñas no coinciden.";
					correcto = false;
				}
				else {
					label1.Content = "";
					nuevaContra = true;
					contra = textBoxNewPassword.Password;
				}
			}

			// --------------------------------------------------------------------


			if (correcto)
			{
				if (presenter.modificacion(contra, textBoxNombre.Text, textBoxApellidos.Text, textBoxEmail.Text, fechaNac.SelectedDate.Value.Date, textBoxDireccion.Text, textBoxTelefono.Text, nuevaContra))
				{
					resultadoModificacion.Content = "Usuario actualizado. ";
				}
				else // error
				{
					resultadoModificacion.Content = "Ha ocurrido un error, revise los datos. ";
				}
			}
			else
			{
				resultadoModificacion.Content = "Ha ocurrido un error, revise los datos. ";
			}
		}



    }
}
