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
using AppEstadioGen_MVP.views;
using AppEstadioGen_MVP.code;

namespace AppEstadioGen_MVP
{
    /// <summary>
    /// Logica de interaccion para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Inicializa el manager de sesion
            SessionManager sessionManager = SessionManager.Instance;
            // Arranca la primera pagina
            frameContenido.NavigationService.Navigate(new Login());
        }

        public void irPagina(string pagina)
        {
			pagina = pagina.ToLower();

            switch (pagina)
            {
				case "login":
					frameContenido.Content = new Login();
                    break;
                case "inicio":
					if (SessionManager.Instance.usuario != null && SessionManager.Instance.usuario.EsAdmin == true)
					{
						frameContenido.Content = new AdminInicio();
					}
					else
					{
						frameContenido.Content = new Inicio();
					}
                    break;
				case "entradas":
					if (SessionManager.Instance.usuario != null && SessionManager.Instance.usuario.EsAdmin == true)
					{
						frameContenido.Content = new AdminEntradas();
					}
					else
					{
						frameContenido.Content = new Entradas();
					}
					break;
				case "abonos":
					if (SessionManager.Instance.usuario != null && SessionManager.Instance.usuario.EsAdmin == true)
					{
						frameContenido.Content = new AdminAbonos();
					}
					else
					{
						frameContenido.Content = new Abonos();
					}
					break;
                case "tienda":
					if (SessionManager.Instance.usuario != null && SessionManager.Instance.usuario.EsAdmin == true)
					{
						frameContenido.Content = new AdminProductos();
					}
					else
					{
						frameContenido.Content = new Tienda();
					}
                    break;
                case "carro":
                    frameContenido.Content = new CarroCompra();
                    break;
				case "confirmarcompra":
                    frameContenido.Content = new ConfirmacionCompra();
                    break;
				case "fincompra":
					frameContenido.Content = new FinCompra();
					break;
				case "compras":
					frameContenido.Content = new MisCompras();
					break;
				case "adminnuevoproducto":
					frameContenido.Content = new AdminNuevoProducto();
					break;
				case "adminnuevaentrada":
					frameContenido.Content = new AdminNuevaEntrada();
					break;
				case "adminnuevoabono":
					frameContenido.Content = new AdminNuevoAbono();
					break;
				case "revisarpedidos":
					frameContenido.Content = new AdminPedidosPendientes();
					break;
				case "perfil":
					frameContenido.Content = new ConfiguracionPerfil();
					break;
				case "eliminarusu":
					if (SessionManager.Instance.usuario != null && SessionManager.Instance.usuario.EsAdmin == true)
					{
						frameContenido.Content = new AdminUsuarios();
					}

					break;
                default:
                    frameContenido.Content = new Inicio();
                    break;
            }
        }

		public void actualizaCabecera()
		{
			frameCabecera.Content = new Cabecera();
		}

        public void irDetalleProducto(int idProducto)
        {
            frameContenido.Content = new DetalleProducto(idProducto);
        }

		public void irDetallePedido(int idPedido)
		{
			frameContenido.Content = new DetallePedido(idPedido);
		}

		public void irDetalleEntrada(int idEntrada)
		{
			frameContenido.Content = new DetalleEntrada(idEntrada);
		}

		public void irDetalleAbono(int idAbono)
		{
			frameContenido.Content = new DetalleAbono(idAbono);
		}
    }
}
