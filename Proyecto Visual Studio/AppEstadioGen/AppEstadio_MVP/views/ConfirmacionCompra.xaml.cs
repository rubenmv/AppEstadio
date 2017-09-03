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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class ConfirmacionCompra : Page, IVistaConfirmacionCompra
    {
		PresenterConfirmacionCompra presenter = null;

        public ConfirmacionCompra()
        {
            InitializeComponent();

			presenter = new PresenterConfirmacionCompra(this);
        }

		public UsuarioEN Usuario
		{
			set
			{
				this.DataContext = value;
			}
		}

		// Finalizar la compra
		private void botonFinalizar(object sender, RoutedEventArgs e)
		{

			if (SessionManager.Instance.usuario.Direccion.Length == 0)
			{
				MessageBox.Show("Debe establecer una dirección en su perfil para el envío del pedido.");
			}
			else
			{
				bool correcto = true;

				if (NumTarjeta.Text.Length != 16)
				{

					correcto = false;
				}

				if (Codigo.Text.Length != 3)
				{

					correcto = false;
				}


				if (caducidad.SelectedDate == null)
				{
					correcto = false;
				}

				DateTime fechaactual = DateTime.Now;

				if (caducidad.SelectedDate < fechaactual)
				{
					correcto = false;
				}


				// NumTarjeta.Text, Codigo.Text, Mes.Text, Anyo.Text

				if (correcto == true)
				{

					if (presenter.finalizarCompra())
					{
						// Redirigimos a pantalla compra realizada
						((MainWindow)Application.Current.MainWindow).irPagina("finCompra");
					}


					else
					{
						MessageBox.Show("Hubo un error, revise sus datos personales y los de la tarjeta.");
					}
				}
				else
				{
					MessageBox.Show("Hubo un error, revise sus datos personales y los de la tarjeta.");
				}
			}
		}


    }
}
