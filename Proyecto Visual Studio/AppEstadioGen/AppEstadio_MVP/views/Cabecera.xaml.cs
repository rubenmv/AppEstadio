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
using AppEstadioGen_MVP.code;

namespace AppEstadioGen_MVP.views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Cabecera : Page, IVistaCabecera
    {
		PresenterCabecera presenter = null;
		SessionManager sessionManager = null;

        public Cabecera()
        {
            presenter = new PresenterCabecera(this);
            InitializeComponent();

			sessionManager = SessionManager.Instance;

			actualizaCarro();
			setUsuario();
			setLoginPerfil();
        }

        public string Usuario {
            set{
                usuario.Content = value;
            }
        }

		public void setUsuario()
		{
			if (sessionManager.usuario == null)
			{
				Usuario = "No ha accedido como usuario";
				salir.Visibility = System.Windows.Visibility.Hidden;
			}
			else
			{
				Usuario = "Usuario: " + sessionManager.usuario.Nif;
				salir.Visibility = System.Windows.Visibility.Visible;
			}
		}

		public void setLoginPerfil()
		{
			if (sessionManager.usuario == null)
			{
				perfil.Visibility = System.Windows.Visibility.Hidden;
				login.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				perfil.Visibility = System.Windows.Visibility.Visible;
				login.Visibility = System.Windows.Visibility.Hidden;
			}
		}



		public void actualizaCarro()
		{
			carro.Content = "Tiene " + SessionManager.Instance.cart.getNumItems() + " productos en el carro";
		}

        private void irInicio(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("inicio");
        }

        private void irTienda(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("tienda");
        }

        private void irMisCompras(object sender, RoutedEventArgs e)
        {
			if (sessionManager.usuario == null)
			{
				MessageBox.Show("Debe acceder como usuario para ver sus compras");
				((MainWindow)Application.Current.MainWindow).irPagina("login");
			}
			else
			{
				((MainWindow)Application.Current.MainWindow).irPagina("compras");
			}
        }

        private void irPerfil(object sender, RoutedEventArgs e)
        {
			if (SessionManager.Instance.usuario != null)
			{
				((MainWindow)Application.Current.MainWindow).irPagina("perfil");
			}
			else
			{
				((MainWindow)Application.Current.MainWindow).irPagina("login");
			}
        }

		private void irLogin(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).irPagina("login");

		}

		private void logout(object sender, RoutedEventArgs e)
		{
			if (sessionManager.cart.getNumItems() > 0)
			{
				if (MessageBox.Show("Va a finalizar la sesion y quedan elementos en el carro de la compra, ¿desea vaciarlo?",
									"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					sessionManager.cart.vaciarCarro();
				}
			}

			sessionManager.usuario = null;
			((MainWindow)Application.Current.MainWindow).actualizaCabecera();
			((MainWindow)Application.Current.MainWindow).irPagina("login");
		}

		private void irCarroCompra(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).irPagina("carro");
		}
    }
}
