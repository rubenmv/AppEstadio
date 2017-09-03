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
	public partial class AdminNuevaEntrada : Page, IVistaAdminNuevoProducto
    {
        PresenterAdminNuevoProducto presenter = null;
        SessionManager sessionManager = null;

        public AdminNuevaEntrada()
        {
            InitializeComponent();
			presenter = new PresenterAdminNuevoProducto(this);
            sessionManager = SessionManager.Instance;
			
			// Debemos inicializar el tipo con el enum de CategoriaTienda
        }

		private void botonCrear(object sender, RoutedEventArgs e)
		{
			// Validacion de campos
			bool correcto = true;

			// Nombre
			if (textBoxNombre.Text.Length == 0)
			{
				label5.Content = "Debe indicar un nombre descriptivo para el producto";
				correcto = false;
			}
			else { label5.Content = ""; }

			// Descripcion. Optativo
			if (textBoxDesc.Text.Length == 0)
				textBoxDesc.Text = "";

			// Precio
			if (textBoxPrecio.Text.Length == 0)
			{
				label1.Content = "Debe indicar un precio. Ej: 10.95";
				correcto = false;
			}
			else { label1.Content = ""; }

			

			// Tipo
			if (textBoxTipo.Text.Length == 0)
			{
				label9.Content = "Debe seleccionar el tipo correcto para este producto";
				correcto = false;
			}
			else { label9.Content = ""; }

			// Stock
			if (textBoxStock.Text.Length == 0)
			{
				label7.Content = "Debe indicar el stock";
				correcto = false;
			}
			else { label7.Content = ""; }

			// Foto. Optativo
			if (textBoxFoto.Text.Length == 0)
				textBoxFoto.Text = "";

            // Stock
            if (TextBoxGrada.Text.Length == 0)
            {
                label8.Content = "Debe indicar la grada";
                correcto = false;
            }

            if (fecha.SelectedDate == null)
            {
                correcto = false;
                label6.Content = "Debe indicar la fecha del encuentro";
            }


			if (correcto)
			{
				// Convertimos el precio y el tipo
				float precio = Convert.ToSingle(textBoxPrecio.Text);
				//int tipo = Convert.ToInt32(textBoxTipo.Text);
				int stock = Convert.ToInt32(textBoxStock.Text);

				//espera.Visibility = System.Windows.Visibility.Visible;
				formulario.Visibility = System.Windows.Visibility.Hidden;

                if (presenter.crearEntrada(textBoxNombre.Text, textBoxDesc.Text, precio, textBoxTipo.Text, stock, textBoxFoto.Text, fecha.SelectedDate, TextBoxGrada.Text))
				{
					// Todo correcto, el usuario se ha registrado
					((MainWindow)Application.Current.MainWindow).irPagina("entradas");
				}
				else // El usuario ya existe
				{
					formulario.Visibility = System.Windows.Visibility.Visible;
					//espera.Visibility = System.Windows.Visibility.Hidden;
					resultadoCrear.Content = "Hubo un problema creando el producto";
				}
			}
		}

    }
}
