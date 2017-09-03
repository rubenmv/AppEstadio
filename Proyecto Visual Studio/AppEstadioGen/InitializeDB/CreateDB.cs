
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.CEN.AppEstadio;
using AppEstadioGenNHibernate.CAD.AppEstadio;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
			/***************** CAD **********************/
			IProductoCAD _IProductoCAD = new ProductoCAD();
			IUsuarioCAD _IUsuarioCAD = new UsuarioCAD();
			IEntradaCAD _IEntradaCAD = new EntradaCAD();
			IAbonoCAD _IAbonoCAD = new AbonoCAD();
			ITiendaCAD _ITiendaCAD = new TiendaCAD();
			IPedidoCAD _IPedidoCAD = new PedidoCAD();
			ILineaPedidoCAD _ILineaPedidoCAD = new LineaPedidoCAD();
			IFacturaCAD _IFacturaCAD = new FacturaCAD();
			ILineaFacturaCAD _ILineaFacturaCAD = new LineaFacturaCAD();
			IArticuloCAD _IArticuloCAD = new ArticuloCAD();
			ITallaCAD _ITallaCAD = new TallaCAD();

			/***************** CEN **********************/
			UsuarioCEN usuarioCEN = new UsuarioCEN(_IUsuarioCAD);
			// CEN de producto
			ProductoCEN productoCEN = new ProductoCEN(_IProductoCAD);
			// CEN de entradas y abonos
			EntradaCEN entradaCEN = new EntradaCEN(_IEntradaCAD);
			AbonoCEN abonoCEN = new AbonoCEN(_IAbonoCAD);
			// CEN de Tallas
			TallaCEN tallaCEN = new TallaCEN(_ITallaCAD);
			// CEN de Tienda
			TiendaCEN tiendaCEN = new TiendaCEN(_ITiendaCAD);
			// CEN de articulos
			ArticuloCEN articuloCEN = new ArticuloCEN(_IArticuloCAD);
			// CEN de los pedidos y lineas de pedido
			PedidoCEN pedidoCEN = new PedidoCEN(_IPedidoCAD);
			LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(_ILineaPedidoCAD);
			// CEN de las facturas y lineas de factura
			FacturaCEN facturaCEN = new FacturaCEN(_IFacturaCAD);
			LineaFacturaCEN lineaFacturaCEN = new LineaFacturaCEN(_ILineaFacturaCAD);


			/***************** USUARIOS *****************/
			// CLIENTE
			UsuarioEN clienteEN = new UsuarioEN();

			clienteEN.Nif = "12345678A";
			clienteEN.Password = "1234";
			clienteEN.Nombre = "Ruben";
			clienteEN.Apellidos = "Martinez";
			clienteEN.FechaNac = new DateTime(1986, 11, 8);
			clienteEN.Direccion = "Alfonso Puchades 19, 8ºB, Benidorm, Alicante";
			clienteEN.Email = "rub3nmv@gmail.com";
			clienteEN.Telefono = "966582521";
			clienteEN.EsAdmin = false;

			usuarioCEN.New_(clienteEN.Nif, clienteEN.Password, clienteEN.Nombre,
					clienteEN.Apellidos, clienteEN.Email, clienteEN.FechaNac,
					clienteEN.Direccion, clienteEN.Telefono, clienteEN.EsAdmin);

			// ADMINISTRADOR
			UsuarioEN administradorEN = new UsuarioEN();

			administradorEN.Nif = "01234567A";
			administradorEN.Password = "0000";
			administradorEN.Nombre = "Pablo";
			administradorEN.Apellidos = "Marzal";
			administradorEN.Email = "oleojake@gmail.com";
			administradorEN.FechaNac = new DateTime(1986, 11, 8);
			administradorEN.Direccion = "";
			administradorEN.Telefono = "";
			administradorEN.EsAdmin = true;

			usuarioCEN.New_(administradorEN.Nif, administradorEN.Password, administradorEN.Nombre,
					administradorEN.Apellidos, administradorEN.Email, administradorEN.FechaNac,
					administradorEN.Direccion, administradorEN.Telefono, administradorEN.EsAdmin);

			// PRUEBAS DE LOGIN
			string[,] loginPass = new string[3, 2]   {
                        { "48333441E", "1234" },                                  // Correcto
                        { "45644521", "54545" },                                  // No encuentra login
                        { "48333441E", "55541" }                                  // El password no coindice
                };

			// String donde escribo cada salidas antes de guardarlas a fichero
			string cadena = "";
			string ruta = "../../pruebas.txt";

			System.IO.File.WriteAllText(ruta, cadena); // La primera vez reemplazamos el fichero
			cadena = "PRUEBA DE LOGIN: El primer resultado debe ser correcto, los otros dos son incorrectos\n";


			for (int i = 0; i < 3; i++)
			{
				if (usuarioCEN.Login(loginPass[i, 0], loginPass[i, 1]))
				{
					cadena += (i + 1) + ". Login correcto\n";
				}
				else
				{
					cadena += (i + 1) + ". Usuario o password incorrecto\n";
				}
			}

			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			/***************** PRODUCTOS: ENTRADAS Y ABONOS *****************/

			//ENTRADA TRIBUNA
			cadena = "\n\nCREANDO ENTRADA...";

			EntradaEN entradaEN = new EntradaEN();
			entradaEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.entrada;
			entradaEN.Nombre = "Entrada TRIBUNA";
			entradaEN.Stock = 100;
			entradaEN.FechaHora = new DateTime(2013, 11, 8, 16, 0, 0);
			entradaEN.Grada = "Tribuna";
			entradaEN.Temporada = 2013;
			entradaEN.Tipo = "Adulto";
			entradaEN.Precio = 49.95F;
			entradaEN.Descripcion = "Entrada normal para el encuentro entre UA Club de Futbol y el UMH Top Stars";
			entradaEN.Foto = @"http://pictures2.todocoleccion.net/tc/2009/12/16/16426460.jpg";

			entradaEN.Id = entradaCEN.New_(entradaEN.Nombre, entradaEN.Descripcion, entradaEN.Foto, entradaEN.Precio, entradaEN.Stock, entradaEN.Categoria, entradaEN.FechaHora, entradaEN.Tipo, entradaEN.Temporada, entradaEN.Grada);

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < entradaEN.Stock; i++)
			{
				ArticuloEN aTazaEN = new ArticuloEN();
				aTazaEN.Producto = entradaEN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(aTazaEN.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			//ENTRADA PREFERENTE
			cadena = "\n\nCREANDO ENTRADA...";

			EntradaEN entrada4EN = new EntradaEN();
			entrada4EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.entrada;
			entrada4EN.Nombre = "Entrada PREFERENTE";
			entrada4EN.Stock = 500;
			entrada4EN.FechaHora = new DateTime(2013, 11, 8, 16, 0, 0);
			entrada4EN.Grada = "Preferente";
			entrada4EN.Temporada = 2013;
			entrada4EN.Tipo = "Adulto";
			entrada4EN.Precio = 29.95F;
			entrada4EN.Descripcion = "Entrada normal para el encuentro entre UA Club de Futbol y el UMH Top Stars";
			entrada4EN.Foto = @"http://pictures2.todocoleccion.net/tc/2009/12/16/16426460.jpg";

			entrada4EN.Id = entradaCEN.New_(entrada4EN.Nombre, entrada4EN.Descripcion, entrada4EN.Foto, entrada4EN.Precio, entrada4EN.Stock, entrada4EN.Categoria, entrada4EN.FechaHora, entrada4EN.Tipo, entrada4EN.Temporada, entrada4EN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < entrada4EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = entrada4EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);


			//ENTRADA FONDO NORTE
			cadena = "\n\nCREANDO ENTRADA...";

			EntradaEN entrada2EN = new EntradaEN();
			entrada2EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.entrada;
			entrada2EN.Nombre = "Entrada FONDO NORTE";
			entrada2EN.Stock = 200;
			entrada2EN.FechaHora = new DateTime(2013, 11, 8, 16, 0, 0);
			entrada2EN.Grada = "Fondo Norte";
			entrada2EN.Temporada = 2013;
			entrada2EN.Tipo = "Adulto";
			entrada2EN.Precio = 19.95F;
			entrada2EN.Descripcion = "Entrada normal para el encuentro entre UA Club de Futbol y el UMH Top Stars";
			entrada2EN.Foto = @"http://pictures2.todocoleccion.net/tc/2009/12/16/16426460.jpg";

			entrada2EN.Id = entradaCEN.New_(entrada2EN.Nombre, entrada2EN.Descripcion, entrada2EN.Foto, entrada2EN.Precio, entrada2EN.Stock, entrada2EN.Categoria, entrada2EN.FechaHora, entrada2EN.Tipo, entrada2EN.Temporada, entrada2EN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < entrada2EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = entrada2EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			//ENTRADA FONDO SUR
			cadena = "\n\nCREANDO ENTRADA...";

			EntradaEN entrada3EN = new EntradaEN();
			entrada3EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.entrada;
			entrada3EN.Nombre = "Entrada FONDO SUR";
			entrada3EN.Stock = 200;
			entrada3EN.FechaHora = new DateTime(2013, 11, 8, 16, 0, 0);
			entrada3EN.Grada = "Fondo Sur";
			entrada3EN.Temporada = 2013;
			entrada3EN.Tipo = "Adulto";
			entrada3EN.Precio = 19.95F;
			entrada3EN.Descripcion = "Entrada normal para el encuentro entre UA Club de Futbol y el UMH Top Stars";
			entrada3EN.Foto = @"http://pictures2.todocoleccion.net/tc/2009/12/16/16426460.jpg";

			entrada3EN.Id = entradaCEN.New_(entrada3EN.Nombre, entrada3EN.Descripcion, entrada3EN.Foto, entrada3EN.Precio, entrada3EN.Stock, entrada3EN.Categoria, entrada3EN.FechaHora, entrada3EN.Tipo, entrada3EN.Temporada, entrada3EN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < entrada3EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = entrada3EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			//ABONO ADULTO
			cadena = "\n\nCREANDO ABONO...";

			AbonoEN abonoEN = new AbonoEN();
			abonoEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.abono;
			abonoEN.Precio = 124.99F;
			abonoEN.Descripcion = "Abono de media temporada valido para 8 encuentros";
			abonoEN.Nombre = "Abono Adulto Tribuna";
			abonoEN.Stock = 10;
			abonoEN.Tipo = "Adulto";
			abonoEN.Temporada = 2014;
			abonoEN.Grada = "Tribuna";
			abonoEN.Foto = "http://www.antiguosalumnosdepenalba.org/wp-content/uploads/2008/11/carnet_socio.jpg";

			abonoEN.Id = abonoCEN.New_(abonoEN.Nombre, abonoEN.Descripcion, abonoEN.Foto, abonoEN.Precio, abonoEN.Stock, abonoEN.Categoria, abonoEN.Tipo, abonoEN.Temporada, abonoEN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < abonoEN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = abonoEN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			//ABONO JOVEN
			cadena = "\n\nCREANDO ABONO...";

			AbonoEN abono2EN = new AbonoEN();
			abono2EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.abono;
			abono2EN.Precio = 54.99F;
			abono2EN.Descripcion = "Abono de media temporada valido para 8 encuentros";
			abono2EN.Nombre = "Abono Joven Fondo Norte";
			abono2EN.Stock = 10;
			abono2EN.Tipo = "Joven";
			abono2EN.Temporada = 2014;
			abono2EN.Grada = "Fondo Norte";
			abono2EN.Foto = "http://www.antiguosalumnosdepenalba.org/wp-content/uploads/2008/11/carnet_socio.jpg";

			abono2EN.Id = abonoCEN.New_(abono2EN.Nombre, abono2EN.Descripcion, abono2EN.Foto, abono2EN.Precio, abono2EN.Stock, abono2EN.Categoria, abono2EN.Tipo, abono2EN.Temporada, abono2EN.Grada);

			for (int i = 0; i < abono2EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = abono2EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			//ABONO INFANTIL
			cadena = "\n\nCREANDO ABONO...";

			AbonoEN abono3EN = new AbonoEN();
			abono3EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.abono;
			abono3EN.Precio = 34.99F;
			abono3EN.Descripcion = "Abono de media temporada valido para 8 encuentros";
			abono3EN.Nombre = "Abono Infantil Fondo Sur";
			abono3EN.Stock = 10;
			abono3EN.Tipo = "Infantil";
			abono3EN.Temporada = 2014;
			abono3EN.Grada = "Fondo Sur";
			abono3EN.Foto = "http://www.antiguosalumnosdepenalba.org/wp-content/uploads/2008/11/carnet_socio.jpg";

			abono3EN.Id = abonoCEN.New_(abono3EN.Nombre, abono3EN.Descripcion, abono3EN.Foto, abono3EN.Precio, abono3EN.Stock, abono3EN.Categoria, abono3EN.Tipo, abono3EN.Temporada, abono3EN.Grada);

			for (int i = 0; i < abono3EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = abono3EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			//ABONO JUBILADO
			cadena = "\n\nCREANDO ABONO...";

			AbonoEN abono4EN = new AbonoEN();
			abono4EN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.abono;
			abono4EN.Precio = 34.99F;
			abono4EN.Descripcion = "Abono de media temporada valido para 8 encuentros";
			abono4EN.Nombre = "Abono Jubilado Preferente";
			abono4EN.Stock = 10;
			abono4EN.Tipo = "Jubilado";
			abono4EN.Temporada = 2014;
			abono4EN.Grada = "Preferente";
			abono4EN.Foto = "http://www.antiguosalumnosdepenalba.org/wp-content/uploads/2008/11/carnet_socio.jpg";

			abono4EN.Id = abonoCEN.New_(abono4EN.Nombre, abono4EN.Descripcion, abono4EN.Foto, abono4EN.Precio, abono4EN.Stock, abono4EN.Categoria, abono4EN.Tipo, abono4EN.Temporada, abono4EN.Grada);

			for (int i = 0; i < abono4EN.Stock; i++)
			{
				ArticuloEN articulo = new ArticuloEN();
				articulo.Producto = abono4EN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(articulo.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			System.IO.File.AppendAllText(ruta, cadena);

			/***************** PRODUCTOS: TIENDA *****************/

			// TALLAS
			TallaEN talla1 = new TallaEN();
			TallaEN talla2 = new TallaEN();
			TallaEN talla3 = new TallaEN();
			TallaEN talla4 = new TallaEN();
			TallaEN talla5 = new TallaEN();
			TallaEN talla6 = new TallaEN();
			TallaEN talla7 = new TallaEN();

			// Unica sin medidas, para varios
			talla1.Nombre = "Unica";
			talla1.Medidas = "10x10 cm";
			talla5.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.varios;

			// Prenda
			talla2.Nombre = "S";
			talla3.Nombre = "M";
			talla4.Nombre = "L";
			talla2.Medidas = "60x15x20 cm";
			talla3.Medidas = "80x25x20 cm";
			talla4.Medidas = "100x50x30 cm";
			talla2.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.prenda;
			talla3.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.prenda;
			talla4.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.prenda;

			// Calzado
			talla5.Nombre = "39";
			talla6.Nombre = "41";
			talla7.Nombre = "44";
			talla5.Medidas = "";
			talla6.Medidas = "";
			talla7.Medidas = "";
			talla5.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.calzado;
			talla6.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.calzado;
			talla7.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.calzado;

			talla1.Id = tallaCEN.New_(talla1.Nombre, talla1.Tipo, talla1.Medidas);
			talla2.Id = tallaCEN.New_(talla2.Nombre, talla2.Tipo, talla2.Medidas);
			talla3.Id = tallaCEN.New_(talla3.Nombre, talla3.Tipo, talla3.Medidas);
			talla4.Id = tallaCEN.New_(talla4.Nombre, talla4.Tipo, talla4.Medidas);
			talla5.Id = tallaCEN.New_(talla5.Nombre, talla5.Tipo, talla5.Medidas);
			talla6.Id = tallaCEN.New_(talla6.Nombre, talla6.Tipo, talla6.Medidas);
			talla7.Id = tallaCEN.New_(talla7.Nombre, talla7.Tipo, talla7.Medidas);

			IList<int> tallasVariosId = new List<int>();
			tallasVariosId.Add(talla1.Id);

			IList<int> tallasPrendasId = new List<int>();
			tallasPrendasId.Add(talla2.Id);
			tallasPrendasId.Add(talla3.Id);
			tallasPrendasId.Add(talla4.Id);

			IList<int> tallasCalzadoId = new List<int>();
			tallasCalzadoId.Add(talla5.Id);
			tallasCalzadoId.Add(talla6.Id);
			tallasCalzadoId.Add(talla7.Id);


			// PRODUCTO Y ARTICULO CAMISETA (CAMISETA)
			cadena = "\n\nCREANDO PRODUCTO CAMISETA...";

			TiendaEN pCamisetaEN = new TiendaEN();
			pCamisetaEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.tienda;
			pCamisetaEN.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.prenda;
			pCamisetaEN.Nombre = "Camiseta UA Club";
			pCamisetaEN.Precio = 55;
			pCamisetaEN.Descripcion = "Camiseta UA Club para los aficionados a este gran equipo de futbol";
			pCamisetaEN.Stock = 50;
			pCamisetaEN.Foto = @"http://dmtienda.com/files/2009/05/15/img1_camiseta-seleccin-de-gana-aos-50_0.jpg";
			pCamisetaEN.Color = "Verde, Amarillo, Rojo";

			pCamisetaEN.Id = tiendaCEN.New_(pCamisetaEN.Nombre, pCamisetaEN.Descripcion, pCamisetaEN.Foto,
					pCamisetaEN.Precio, pCamisetaEN.Stock, pCamisetaEN.Categoria,
					pCamisetaEN.Color, pCamisetaEN.Tipo);

			// Relacionamos con las tallas de calzado
			tiendaCEN.AgregaTalla(pCamisetaEN.Id, tallasPrendasId);

			cadena += " ¡¡EXITO!!";

			cadena += "\n\nCREANDO ARTICULO CAMISETA...";

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < pCamisetaEN.Stock; i++)
			{
				ArticuloEN aCamisetaEN = new ArticuloEN();
				aCamisetaEN.Producto = pCamisetaEN;                         // Lo asociamos con su producto

				articuloCEN.New_(aCamisetaEN.Producto.Id);                       // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// --------------------------------------------------------------

			// PRODUCTO Y ARTICULO TAZA (VARIOS)
			cadena = "\n\nCREANDO PRODUCTO TAZA...";

			TiendaEN pTazaEN = new TiendaEN();
			pTazaEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.tienda;
			pTazaEN.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.varios;
			pTazaEN.Nombre = "Taza UA Club";
			pTazaEN.Precio = 10;
			pTazaEN.Descripcion = "Taza del mejor equipo del mundo para tomarte el Cola Cao";
			pTazaEN.Stock = 25;
			pTazaEN.Foto = @"http://www.doblevela.com/images/medium/TF780_med.png";
			pTazaEN.Color = "Blanco";

			pTazaEN.Id = tiendaCEN.New_(pTazaEN.Nombre, pTazaEN.Descripcion, pTazaEN.Foto,
					pTazaEN.Precio, pTazaEN.Stock, pTazaEN.Categoria,
					pTazaEN.Color, pTazaEN.Tipo);

			// Relacionamos con las tallas de calzado
			tiendaCEN.AgregaTalla(pTazaEN.Id, tallasVariosId);

			cadena += " ¡¡EXITO!!";

			cadena += "\n\nCREANDO ARTICULO TAZA...";

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < pTazaEN.Stock; i++)
			{
				ArticuloEN aTazaEN = new ArticuloEN();
				aTazaEN.Producto = pTazaEN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(aTazaEN.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// --------------------------------------------------------------


			// PRODUCTO Y ARTICULO BUFANDA (VARIOS)
			cadena = "\n\nCREANDO PRODUCTO BUFANDA...";

			TiendaEN pBufandaEN = new TiendaEN();
			pBufandaEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.tienda;
			pBufandaEN.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.varios;
			pBufandaEN.Nombre = "Bufanda UA Club";
			pBufandaEN.Precio = 15;
			pBufandaEN.Descripcion = "Bufanda del mejor equipo del mundo para no pasar frío";
			pBufandaEN.Stock = 80;
			pBufandaEN.Foto = @"http://www.fashion-sport.fr/698-1468-thickbox/echarpe-officielle-espagne-2012-adidas.jpg";
			pBufandaEN.Color = "Rojo";

			pBufandaEN.Id = tiendaCEN.New_(pBufandaEN.Nombre, pBufandaEN.Descripcion, pBufandaEN.Foto,
					pBufandaEN.Precio, pBufandaEN.Stock, pBufandaEN.Categoria,
					pTazaEN.Color, pTazaEN.Tipo);

			// Relacionamos con las tallas de calzado
			tiendaCEN.AgregaTalla(pBufandaEN.Id, tallasVariosId);

			cadena += " ¡¡EXITO!!";
			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			for (int i = 0; i < pBufandaEN.Stock; i++)
			{
				ArticuloEN aBufandaEN = new ArticuloEN();
				aBufandaEN.Producto = pBufandaEN;                                                 // Lo asociamos con su producto

				articuloCEN.New_(aBufandaEN.Producto.Id);                                              // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			// --------------------------------------------------------------

			// PRODUCTO Y ARTICULO BOTAS (CALZADO)
			cadena = "\n\nCREANDO PRODUCTO BOTAS...";

			TiendaEN pBotasEN = new TiendaEN();
			pBotasEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.tienda;
			pBotasEN.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.calzado;
			pBotasEN.Nombre = "Botas UA Club";
			pBotasEN.Precio = 150;
			pBotasEN.Descripcion = "Botas niño Club Futbol UA";
			pBotasEN.Stock = 15;
			pBotasEN.Foto = @"http://www.sabercurioso.es/wp-content/botas_futbol.jpg";
			pBotasEN.Color = "Azul";

			pBotasEN.Id = tiendaCEN.New_(pBotasEN.Nombre, pBotasEN.Descripcion, pBotasEN.Foto,
					pBotasEN.Precio, pBotasEN.Stock, pBotasEN.Categoria,
					pBotasEN.Color, pBotasEN.Tipo);

			// Relacionamos con las tallas de calzado
			tiendaCEN.AgregaTalla(pBotasEN.Id, tallasCalzadoId);

			cadena += " ¡¡EXITO!!";

			cadena += "\n\nCREANDO ARTICULO CALZADO BOTAS...";

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < pBotasEN.Stock; i++)
			{
				ArticuloEN aBotasEN = new ArticuloEN();
				aBotasEN.Producto = pBotasEN;         // Lo asociamos con su producto

				articuloCEN.New_(aBotasEN.Producto.Id);        // Esto devuelve el id, pero da igual no nos hace falta ahora
			}

			cadena += " ¡¡EXITO!!";
			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// --------------------------------------------------------------

			/************** PEDIDOS Y FACTURAS *************/

			//LINEAPEDIDO
			LineaPedidoEN lineaPedidoEN = new LineaPedidoEN();
			lineaPedidoEN.Unidades = 2;
			lineaPedidoEN.Precio = entradaEN.Precio * lineaPedidoEN.Unidades;
			// Asocia un producto
			lineaPedidoEN.Producto = entradaEN;
			// Como es una composicion, no es necesario hacer el new, ya lo hara pedido
			// creamos la lista de pedidos que Pedido debera crear y asociar.
			IList<LineaPedidoEN> listaLineasPedido = new List<LineaPedidoEN>();
			listaLineasPedido.Add(lineaPedidoEN);

			// PEDIDO
			cadena = "\n\nCREANDO PEDIDO PASANDO LINEAPEDIDO... ";

			PedidoEN pedidoEN = new PedidoEN();
			pedidoEN.Fecha = new DateTime(2012, 11, 8);
			pedidoEN.Estado = AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente;
			pedidoEN.Precio = 25.1f;
			pedidoEN.Id = pedidoCEN.New_(pedidoEN.Fecha, pedidoEN.Estado, listaLineasPedido, clienteEN.Nif, pedidoEN.Precio); // Aqui se le debe pasar clienteEN.Nif porque no es autogenerado

			cadena += " ¡¡EXITO!!";
			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);




			/************** PRUEBAS DE CUSTOM *************/
			/*
			 *      // IncrementarStock
			 *      cadena = "\n\nPROBANDO IncrementarStock\n";
			 *      cadena += "\nStock de camisetas inicial = " + pTazaEN.Stock + "\n\n";
			 *      cadena += "Incrementando Stock en 10 unidades...";
			 *
			 *      productoCEN.IncrementarStock (pTazaEN.Id, 10);
			 *      pTazaEN = _IProductoCAD.ReadOID (pTazaEN.Id); // Recogemos el producto modificado
			 *
			 *      cadena += "\n\nStock de camisetas final = " + pTazaEN.Stock;
			 *      cadena += "\n\n--------------------------------------\n\n";
			 *      System.IO.File.AppendAllText (ruta, cadena);
			 *
			 *      // DecrementarStock
			 *      cadena = "\n\nPROBANDO DecrementarStock segun las unidades de lineaPedido\n";
			 *      cadena += "\nStock de camisetas inicial = " + pTazaEN.Stock + "\n\n";
			 *      cadena += "Decrementando Stock en 5 unidades...";
			 *
			 *      productoCEN.DecrementarStock (pTazaEN.Id, 5);
			 *      // Recogemos el producto modificado
			 *      pTazaEN = _IProductoCAD.ReadOID (pTazaEN.Id);
			 *
			 *      cadena += "\n\nStock de camisetas final = " + pTazaEN.Stock;
			 *      cadena += "\n\n--------------------------------------\n\n";
			 *      System.IO.File.AppendAllText (ruta, cadena);
			 *
			 *      // ComprobarStock, indica si hay suficientes unidades de stock con respecto a las que se van a pedir
			 *      cadena = "\n\nPROBANDO ComprobarStock\n\n";
			 *      int decre = 35;
			 *      cadena = "El producto Camiseta tiene " + pTazaEN.Stock + " en stock, pedimos " + decre + " unidades...\n";
			 *      if (productoCEN.ComprobarStock (pTazaEN.Id, decre)) {
			 *                      cadena += "\nSe puede realizar el pedido, aun quedan unidades en stock";
			 *      }
			 *      else {
			 *                      cadena += "\nNo quedan unidades suficientes para realizar el pedido";
			 *      }
			 *
			 *      cadena += "\n\n--------------------------------------\n\n";
			 *      System.IO.File.AppendAllText (ruta, cadena);
			 */

			/************** HQL *************/
			// BUSQUEDA POR NOMBRE
			cadena = "\n\nOBTENIENDO PRODUCTOS POR NOMBRE: 'camiseta'\n\n";
			IList<ProductoEN> resultados = new List<ProductoEN>();
			string termino = "camiseta";
			resultados = productoCEN.GetProductosPorNombre(termino);

			cadena += "\nEncontrados " + resultados.Count + " productos\n\n";

			foreach (ProductoEN r in resultados)
			{
				cadena += "Nombre: " + r.Nombre + "\n" +
						  "Descripcion: " + r.Descripcion + "\n" +
						  "Precio: " + r.Precio + "\n" +
						  "Stock: " + r.Stock + "\n" +
						  "\n";
			}

			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// BUSQUEDA POR DESCRIPCION
			cadena = "\n\nOBTENIENDO PRODUCTOS POR DESCRIPCION: 'UMH Top Stars'\n\n";
			resultados.Clear();
			termino = "UMH Top Stars";
			resultados = productoCEN.GetProductosPorDescripcion(termino);

			cadena += "\nEncontrados " + resultados.Count + " productos\n\n";

			foreach (ProductoEN r in resultados)
			{
				cadena += "Nombre: " + r.Nombre + "\n" +
						  "Descripcion: " + r.Descripcion + "\n" +
						  "Precio: " + r.Precio + "\n" +
						  "Stock: " + r.Stock + "\n" +
						  "\n";
			}

			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// BUSQUEDA POR RANGO DE PRECIO
			cadena = "\n\nOBTENIENDO PRODUCTOS POR RANGO DE PRECIO: min = 5, max = 20\n\n";
			resultados.Clear();
			float min = 5;
			float max = 20;

			resultados = productoCEN.GetProductosPorRangoPrecio(min, max);

			cadena += "\nEncontrados " + resultados.Count + " productos\n\n";

			foreach (ProductoEN r in resultados)
			{
				cadena += "Nombre: " + r.Nombre + "\n" +
						  "Descripcion: " + r.Descripcion + "\n" +
						  "Precio: " + r.Precio + "\n" +
						  "Stock: " + r.Stock + "\n" +
						  "\n";
			}

			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			// OBTENER PEDIDOS ENTRE FECHAS
			cadena = "\n\nOBTENIENDO PEDIDOS POR RANGO DE FECHA\n\n";
			resultados.Clear();
			DateTime fecha_min = new DateTime(2012, 10, 8);
			DateTime fecha_max = new DateTime(2012, 12, 8);
			IList<PedidoEN> resPedidos = new List<PedidoEN>();
			resPedidos = pedidoCEN.GetPedidosEntreFechas(fecha_min, fecha_max);

			cadena += "\nEncontrados " + resPedidos.Count + " pedidos\n\n";

			foreach (PedidoEN r in resPedidos)
			{
				cadena += "Fecha: " + r.Fecha + "\n" +
						  "Estado: " + r.Estado + "\n" +
						  "Cliente: " + r.Cliente.Nif + "\n" +
						  "\n";
			}

			cadena += "\n\n--------------------------------------\n\n";
			System.IO.File.AppendAllText(ruta, cadena);

			System.Console.WriteLine("\n\n\nEL FICHERO PRUEBAS.TXT DENTRO DE LA CARPETA INITIALIZEDB CONTIENE EL RESULTADO DE TODAS LAS PRUEBAS REALIZADAS\n\n");

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
