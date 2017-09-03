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
	public partial class AdminNuevoProducto : Page, IVistaAdminNuevoProducto
    {
        PresenterAdminNuevoProducto presenter = null;
        SessionManager sessionManager = null;

        public AdminNuevoProducto()
        {
            InitializeComponent();
            presenter = new PresenterAdminNuevoProducto(this);
            sessionManager = SessionManager.Instance;

			comboTipo.Items.Add("Prenda");
			comboTipo.Items.Add("Calzado");
			comboTipo.Items.Add("Varios");
			comboTipo.SelectedIndex = 0;
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
			else { label5.Content = "Nombre descriptivo para el producto"; }

			// Descripcion. Optativo
			if (textBoxDesc.Text.Length == 0)
				textBoxDesc.Text = "";

			// Precio
			// FALTA COMPROBAR QUE SEA NUMERO
			if (textBoxPrecio.Text.Length == 0)
			{
				label1.Content = "Debe indicar un precio. Ej: 10.95";
				correcto = false;
			}
			else { label1.Content = ""; }


			// Color. Optativo
			if (textBoxNombre.Text.Length == 0)
				textBoxNombre.Text = "";
			
			// Stock
			// FALTA COMPROBAR QUE SEA NUMERO
			if (textBoxStock.Text.Length == 0)
			{
				label7.Content = "Debe indicar el stock";
				correcto = false;
			}
			else { label7.Content = ""; }

			// Foto. Optativo
			if (textBoxFoto.Text.Length == 0)
				textBoxFoto.Text = "";

			if (correcto)
			{
				// Convertimos el precio y el tipo
				float precio = Convert.ToSingle(textBoxPrecio.Text);
				int tipo = comboTipo.SelectedIndex+1;
				int stock = Convert.ToInt32(textBoxStock.Text);

				espera.Visibility = System.Windows.Visibility.Visible;
				formulario.Visibility = System.Windows.Visibility.Hidden;

				espera.Visibility = System.Windows.Visibility.Visible;

				if (presenter.crearProducto(textBoxNombre.Text, textBoxDesc.Text, precio, textBoxColor.Text, tipo, stock, textBoxFoto.Text))
				{
					// Todo correcto, el usuario se ha registrado
					((MainWindow)Application.Current.MainWindow).irPagina("tienda");
				}
				else // El usuario ya existe
				{
					formulario.Visibility = System.Windows.Visibility.Visible;
					espera.Visibility = System.Windows.Visibility.Hidden;
					resultadoCrear.Content = "Hubo un problema creando el producto";
				}
			}
		}

    }
}
