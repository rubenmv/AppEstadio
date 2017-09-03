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
    public partial class AdminInicio : Page
    {
        public AdminInicio()
        {
            InitializeComponent();
        }

		private void botonEntradas(object sender, RoutedEventArgs e)
		{

		}

		private void botonAbonos(object sender, RoutedEventArgs e)
		{

		}

		public void irSeccion(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			var name = button.Name.ToLower();
			((MainWindow)Application.Current.MainWindow).irPagina(name);
		}

    }
}
