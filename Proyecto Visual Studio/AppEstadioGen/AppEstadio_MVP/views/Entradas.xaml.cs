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
    public partial class Entradas : Page, IVistaEntradas
    {
    	// Aqui irian los objetos del Presenter y SessionManager
    	// El presenter siempre se pone, el SessionManager solo si se utiliza en esta clase
        PresenterEntradas presenter = null;
        SessionManager sessionManager = null;

        // Constructor, aqui se inicializan los objetos anteriores
        public Entradas()
        {
            InitializeComponent();
            presenter = new PresenterEntradas(this);

            // Agregamos el manejador para la caja de busqueda, asi podemos borrarla al clic
           // search_box.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(limpiarBusqueda), true);

            // Inicializamos los sliders
           // sMinimo.Value = 0;
           // sMaximo.Value = 500;
        }


        public IList<EntradaEN> TiendaEntradas
        {
            set
            {
                this.DataContext = value;
            }
        }

       /* private void busqueda(object sender, EventArgs e)
        {
            presenter.BuscarEntradasTienda(search_box.Text);
        }*/

        // Al hacer clic sobre una fila del datagrid
        private void abrirDetalleEntrada(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                EntradaEN entrada = dataGridProductos.SelectedCells[0].Item as EntradaEN;
                int idEntrada = entrada.Id;
                ((MainWindow)Application.Current.MainWindow).irDetalleEntrada(idEntrada);
            }
        }

        // Aqui se llega desde continuar compra o desde el icono del carrito
        private void botonContinuar_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).irPagina("carro");
        }



        private void limpiarBusqueda(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.Text = "";
        }

       
        }
    }
