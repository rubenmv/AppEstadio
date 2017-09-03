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
    public partial class Login : Page, IVistaUsuario
    {
		PresenterUsuario presenter = null;
        SessionManager sessionManager = null;

        public Login()
        {
            InitializeComponent();
			presenter = new PresenterUsuario(this);
            sessionManager = SessionManager.Instance;
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

        private void botonAcceder(object sender, RoutedEventArgs e)
        {
            if (presenter.login(nif.Text, password.Password))
            {
                // Accede a la aplicacion
				((MainWindow)Application.Current.MainWindow).actualizaCabecera();
                ((MainWindow)Application.Current.MainWindow).irPagina("inicio");
            }
            else
            {
                errorLogin.Content = "USUARIO O CONTRASEÑA INCORRECTOS";
            }
        }

		private void botonRegistrarse(object sender, RoutedEventArgs e)
		{
			// Validacion de campos
			bool correcto = true;

			// Nombre
			if (textBoxNombre.Text.Length == 0)
			{
				errorusuario.Content = "Introduzca su nombre. ";
				correcto = false;
			}
			else { errorusuario.Content = ""; }

			// NIF
			if (textBoxNif.Text.Length == 0)
			{
				label5.Content = "Introduzca el NIF. ";
				correcto = false;
			}
			else { label5.Content = ""; }

			// Password
			if (textBoxPassword.Password.Length == 0)
			{
				label1.Content = "Introduzca una contraseña.";
				correcto = false;
			}
			else { label1.Content = ""; }
			// Repeticion del password
			if (textBoxPassword.Password != textBoxPassword2.Password)
			{
				label4.Content = "Las contraseñas no coinciden.";
				correcto = false;
			}
			else { label4.Content = ""; }


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
			DateTime fecha = new DateTime(1,1,1);
			if (fechaNac.SelectedDate != null)
			{
				DateTime zeroTime = new DateTime(1, 1, 1);
				fecha = fechaNac.SelectedDate.Value.Date;
				DateTime hoy = DateTime.Now;

				TimeSpan span = hoy - fecha;
				int years = (zeroTime + span).Year - 1;

				if (years < 18)
				{
					label2.Content = "Fecha incorrecta, debes ser mayor de 18";
					correcto = false;
				}
				else { label2.Content = ""; }
			}
			else
				label2.Content = "Introduzca la fecha de nacimiento";
			

			if (correcto)
			{
				if ( presenter.registro(textBoxNif.Text, textBoxPassword.Password, textBoxNombre.Text, textBoxEmail.Text, fecha) )
				{
					// Todo correcto, el usuario se ha registrado
					resultadoRegistro.Content = "Usuario registrado. ";
				}
				else // El usuario ya existe
				{
					resultadoRegistro.Content = "Un usuario con ese NIF ya existe";
				}
			}
		}

		private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
    }
}
