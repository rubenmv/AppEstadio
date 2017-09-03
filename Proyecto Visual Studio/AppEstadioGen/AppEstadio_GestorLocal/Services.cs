using System;
using System.Runtime.Serialization;
using NHibernate;
using System.Collections;
using System.Collections.Generic;
using AppEstadioGenNHibernate.CAD.AppEstadio;
using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.CEN.AppEstadio;
using appEstadioCP.AppEstadio;

namespace AppEstadioGen_GestorLocal
{
public class Service
{
/*PROTECTED REGION ID(AppEstadioGen_GestorLocal_Other_Operations) ENABLED START*/


public bool crearProducto(string nombre, string descripcion, float precio, string color, int tipo, int stock, string foto)
{
	bool resul = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			TiendaEN productoEN = new TiendaEN();
			ArticuloCAD articuloCAD = new ArticuloCAD();
			ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
			TiendaCAD tiendaCAD = new TiendaCAD();
			TiendaCEN tiendaCEN = new TiendaCEN(tiendaCAD);

			productoEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.tienda;
			productoEN.Tipo = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum.calzado;
			productoEN.Nombre = nombre;
			productoEN.Descripcion = descripcion;
			productoEN.Precio = precio;
			productoEN.Stock = stock;
			productoEN.Foto = foto;
			productoEN.Color = color;

			productoEN.Id = tiendaCEN.New_(productoEN.Nombre, productoEN.Descripcion, productoEN.Foto,
					productoEN.Precio, productoEN.Stock, productoEN.Categoria,
					productoEN.Color, productoEN.Tipo);

			// Recogemos las tallas de la categoria de ropa
			IList<TallaEN> listaTallas = getTallasPorTipo(tipo);
			IList<int> listaTallasId = new List<int>();

			if (listaTallas.Count > 0)
			{
				for (int i = 0; i < listaTallas.Count; i++)
				{
					listaTallasId.Add(listaTallas[i].Id);
				}
		 
			}

			tiendaCEN.AgregaTalla(productoEN.Id, listaTallasId);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < productoEN.Stock; i++)
			{
				ArticuloEN aProductoEN = new ArticuloEN();
				aProductoEN.Producto = productoEN;         // Lo asociamos con su producto

				articuloCEN.New_(aProductoEN.Producto.Id);
			}

			resul = true;
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return resul;
}

public bool crearEntrada(string nombre, string descripcion, float precio, string tipo, int stock, string foto, DateTime? fecha, string grada)
{
	bool resul = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			EntradaEN entradaEN = new EntradaEN();
			ArticuloCAD articuloCAD = new ArticuloCAD();
			ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
			EntradaCAD entradaCAD = new EntradaCAD();
			EntradaCEN entradaCEN = new EntradaCEN(entradaCAD);



			entradaEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.entrada;
			entradaEN.Nombre = nombre;
			entradaEN.Stock = stock;
			entradaEN.FechaHora = fecha;
			entradaEN.Grada = grada;
			entradaEN.Temporada = DateTime.Now.Year;
			entradaEN.Tipo = tipo;
			entradaEN.Precio = precio;
			entradaEN.Descripcion = descripcion;
			entradaEN.Foto = foto;

			entradaEN.Id = entradaCEN.New_(entradaEN.Nombre, entradaEN.Descripcion, entradaEN.Foto, entradaEN.Precio, entradaEN.Stock, entradaEN.Categoria, entradaEN.FechaHora, entradaEN.Tipo, entradaEN.Temporada, entradaEN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < entradaEN.Stock; i++)
			{
				ArticuloEN aEntradaEN = new ArticuloEN();
				aEntradaEN.Producto = entradaEN;         // Lo asociamos con su producto

				articuloCEN.New_(aEntradaEN.Producto.Id);
			}

			resul = true;
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return resul;
}


public bool crearAbono(string nombre, string descripcion, float precio, string tipo, int stock, string foto, string grada)
{
	bool resul = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			AbonoEN abonoEN = new AbonoEN();
			ArticuloCAD articuloCAD = new ArticuloCAD();
			ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
			AbonoCAD abonoCAD = new AbonoCAD();
			AbonoCEN abonoCEN = new AbonoCEN(abonoCAD);



			abonoEN.Categoria = AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum.abono;
			abonoEN.Nombre = nombre;
			abonoEN.Stock = stock;

			abonoEN.Grada = grada;
			abonoEN.Temporada = DateTime.Now.Year;
			abonoEN.Tipo = tipo;
			abonoEN.Precio = precio;
			abonoEN.Descripcion = descripcion;
			abonoEN.Foto = foto;

			abonoEN.Id = abonoCEN.New_(abonoEN.Nombre, abonoEN.Descripcion, abonoEN.Foto, abonoEN.Precio, abonoEN.Stock, abonoEN.Categoria, abonoEN.Tipo, abonoEN.Temporada, abonoEN.Grada);

			// ARTICULOS ASOCIADOS, TANTOS COMO STOCK
			for (int i = 0; i < abonoEN.Stock; i++)
			{
				ArticuloEN aEntradaEN = new ArticuloEN();
				aEntradaEN.Producto = abonoEN;         // Lo asociamos con su producto

				articuloCEN.New_(aEntradaEN.Producto.Id);
			}

			resul = true;
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return resul;
}


// Elimina una lista de productos por id
public void eliminarProductos(IList<int> lista)
{
	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			if (lista.Count > 0)
			{
				ProductoCAD productoCAD = new ProductoCAD(session);
				ProductoCEN productoCEN = new ProductoCEN(productoCAD);
				ProductoCP productoCP = new ProductoCP(session);

				for (int i = 0; i < lista.Count; i++)
				{
					productoCP.eliminarArticulosDeProducto(lista[i]);
					productoCEN.Destroy(lista[i]);
					
				}
			}
			

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}
}

// Obtiene un producto por ID
public IList<TallaEN> getTallasPorTipo(int tipo)
{
	IList<TallaEN> lista = new List<TallaEN>();

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			TallaCAD tallaCAD = new TallaCAD(session);
			lista = tallaCAD.GetTallasPorTipo(tipo);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return lista;
}


// Obtiene un producto por ID
public ProductoEN getProductoPorId(int idProducto)
{
    ProductoEN producto = null;
    ProductoCAD productoCAD = null;

    try
    {
        using (ISession session = NHibernateHelper.OpenSession())
        using (ITransaction tr = session.BeginTransaction())
        {
            productoCAD = new ProductoCAD(session);
            producto = productoCAD.ReadOID(idProducto);
            tr.Commit();
        }
    }

    catch (Exception ex)
    {
        throw ex;
    }

    return producto;
}

// Obtiene un abono por ID
public AbonoEN getAbonoPorId(int idAbono)
{
	AbonoEN abono = null;
	AbonoCAD abonoCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			abonoCAD = new AbonoCAD(session);
			abono = abonoCAD.ReadOID(idAbono);
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return abono;
}

// Obtiene una entrada por ID
public EntradaEN getEntradaPorId(int idEntrada)
{
	EntradaEN entrada = null;
	EntradaCAD entradaCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			entradaCAD = new EntradaCAD(session);
			entrada = entradaCAD.ReadOID(idEntrada);
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return entrada;
}


// Obtiene un producto por ID
public IList<LineaPedidoEN> getLineasPedido(int id)
{
	IList<LineaPedidoEN> lineas = new List<LineaPedidoEN>();

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoCP pedidoCP = new PedidoCP(session);

			lineas = pedidoCP.GetLineasPedido(id);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return lineas;
}


public System.Collections.Generic.IList<ProductoEN> getProductosTienda()
{
    System.Collections.Generic.IList<ProductoEN> en = null;
    ProductoCAD productoCAD = null;

    try
    {
        using (ISession session = NHibernateHelper.OpenSession())
        using (ITransaction tr = session.BeginTransaction())
        {
            productoCAD = new ProductoCAD(session);
            en = productoCAD.GetProductosTienda();
            tr.Commit();
        }
    }

    catch (Exception ex)
    {
        throw ex;
    }

    return en;
}

public System.Collections.Generic.IList<EntradaEN> getEntradasTienda()
{
	System.Collections.Generic.IList<EntradaEN> en = null;
	EntradaCAD entradaCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			entradaCAD = new EntradaCAD(session);
			en = entradaCAD.GetEntradas();
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return en;
}

public System.Collections.Generic.IList<AbonoEN> getAbonosTienda()
{
	System.Collections.Generic.IList<AbonoEN> en = null;
	AbonoCAD abonoCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			abonoCAD = new AbonoCAD(session);
			en = abonoCAD.GetAbonos();
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return en;
}

public System.Collections.Generic.IList<ProductoEN> getProductosPorNombre(string nombre)
{
    System.Collections.Generic.IList<ProductoEN> en = null;
    ProductoCAD productoCAD = null;

    try
    {
        using (ISession session = NHibernateHelper.OpenSession())
        using (ITransaction tr = session.BeginTransaction())
        {
            productoCAD = new ProductoCAD(session);
            en = productoCAD.GetProductosPorNombre(nombre);
            tr.Commit();
        }
    }

    catch (Exception ex)
    {
        throw ex;
    }

    return en;
}

public System.Collections.Generic.IList<ProductoEN> getProductosPorRangoPrecio(float min, float max)
{
	System.Collections.Generic.IList<ProductoEN> en = null;
	ProductoCAD productoCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			productoCAD = new ProductoCAD(session);
			en = productoCAD.GetProductosPorRangoPrecio(min, max);
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return en;
}

// Obtiene los pedidos de un usuario
public IList<PedidoEN> getPedidosPorUsuario(UsuarioEN usuario)
{
	IList<PedidoEN> pedido = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoCAD pedidoCAD = new PedidoCAD(session);
			pedido = pedidoCAD.GetPedidosPorCliente(usuario.Nif);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return pedido;
}

//devuelve una lista de pedidoEN de los que estan en pendiente
public IList<PedidoEN> getPedidosPorEstado(AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado)
{
	IList<PedidoEN> lista = new List<PedidoEN>();

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoCAD pedidoCAD = new PedidoCAD(session);
			PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);
			int es = Convert.ToInt32(estado);
			lista = pedidoCAD.GetPedidosPorEstado(es);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return lista;
}

public bool checkLogin(string nif, string password)
{
    UsuarioCEN usuarioCEN = null;
    UsuarioCAD usuarioCAD = null;

    bool resul = false;

    try
    {
        using (ISession session = NHibernateHelper.OpenSession())
        using (ITransaction tr = session.BeginTransaction())
        {
            usuarioCAD = new UsuarioCAD(session);
            usuarioCEN = new UsuarioCEN(usuarioCAD);
            // Login correcto
            if (usuarioCEN.Login(nif, password))
            {
                resul = true;
            }
            

            tr.Commit();
        }
    }

    catch (Exception ex)
    {
        throw ex;
    }

    return resul;
}

public UsuarioEN getUsuario(string nif)
{
    UsuarioEN usuarioEN = null;
    UsuarioCAD usuarioCAD = null;

    try
    {
        using (ISession session = NHibernateHelper.OpenSession())
        using (ITransaction tr = session.BeginTransaction())
        {
            usuarioCAD = new UsuarioCAD(session);

            usuarioEN = usuarioCAD.ReadOID(nif);

            
            tr.Commit();
        }
    }

    catch (Exception ex)
    {
        throw ex;
    }

    return usuarioEN;
}

// Devuelve todos los usuario
public System.Collections.Generic.IList<UsuarioEN> getUsuarios()
{
	System.Collections.Generic.IList<UsuarioEN> en = null;
	UsuarioCAD usuarioCAD = null;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			usuarioCAD = new UsuarioCAD(session);
			en = usuarioCAD.GetUsuarios();
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return en;
}

// Realiza el registro de un nuevo usuario si este no existe
public bool registro(String nif, string pass, string nombre, string email, DateTime fecha)
{
	bool registrado = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			// AQUI COMPROBAMOS QUE EL USUARIO NO EXISTE YA.
			// USO UNA FUNCION QUE YA HICE EN ESTA MISMA CLASE QUE RECOGE UN USUARIO POR ID

			// Si el usuario no existe ya, registramos uno nuevo
			if (getUsuario(nif) == null)
			{
				// AHORA YA SE CREA EL USUARIO COMO HACIAMOS EN EL CREATEDB
				UsuarioEN usuarioEN = new UsuarioEN();
				UsuarioCAD usuarioCAD = new UsuarioCAD(session);
				UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

				// Los campos que se envian en el registro
				usuarioEN.Nif = nif;
				usuarioEN.Password = pass;
				usuarioEN.Nombre = nombre;
				usuarioEN.Email = email;

				// Ahora los no obligatorios en el registro, los inicializamos a vacio
				usuarioEN.Apellidos = "";
				usuarioEN.FechaNac = fecha;
				usuarioEN.Direccion = "";
				usuarioEN.Telefono = "";
				usuarioEN.EsAdmin = false; // Por defecto no son admins

				usuarioCEN.New_(usuarioEN.Nif, usuarioEN.Password, usuarioEN.Nombre,
						usuarioEN.Apellidos, usuarioEN.Email, usuarioEN.FechaNac,
						usuarioEN.Direccion, usuarioEN.Telefono, usuarioEN.EsAdmin);

				registrado = true;

				tr.Commit(); // El commit se hace aqui dentro, porque hay cosas que escribir en la BD
			}
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return registrado;
}

// Modifica los datos de un usuario registrado
public bool modificarUsuario(UsuarioEN usuario)
{
	bool modificado = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{

			UsuarioCAD usuarioCAD = new UsuarioCAD(session);
			UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

			usuarioCEN.Modify(usuario.Nif,usuario.Password, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.FechaNac, usuario.Direccion, usuario.Telefono, usuario.EsAdmin);

			modificado = true;

			tr.Commit(); // El commit se hace aqui dentro, porque hay cosas que escribir en la BD
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return modificado;
}

// Realiza el registro de un nuevo usuario si este no existe
public bool bajaUsuario(String nif)
{
	bool baja = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			// AQUI COMPROBAMOS QUE EL USUARIO EXISTE.
			// USO UNA FUNCION QUE YA HICE EN ESTA MISMA CLASE QUE RECOGE UN USUARIO POR ID

			// Si el usuario existe ya, lo eliminamos
			if (getUsuario(nif) != null)
			{
				// AHORA YA SE CREA EL USUARIO COMO HACIAMOS EN EL CREATEDB
				UsuarioCAD usuarioCAD = new UsuarioCAD(session);
				UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

				//ELIMINAMOS
				usuarioCEN.Destroy(nif);

				baja = true;

				tr.Commit(); // El commit se hace aqui dentro, porque hay cosas que escribir en la BD
			}
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return baja;
}

// Realiza el registro de un nuevo usuario si este no existe
public bool eliminarUsuarios(IList<string> usuarios)
{
	bool baja = false;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			// AQUI COMPROBAMOS QUE EL USUARIO EXISTE.
			// USO UNA FUNCION QUE YA HICE EN ESTA MISMA CLASE QUE RECOGE UN USUARIO POR ID

			for (int i = 0; i < usuarios.Count; i++)
			{
				baja = bajaUsuario(usuarios[i]);
				if (!baja)
				{
					break;
				}
			}
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return baja;
}

// Crear el pedido y lo deja pendiente de revision por un administrador
public bool finalizarCompra(IList<LineaPedidoEN> lineasPedido, UsuarioEN usuario)
{
	bool resul = false;
	int idPedido = -1;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoCP pedidoCP = new PedidoCP(session);

			idPedido = pedidoCP.CrearPedido(lineasPedido, usuario);
			if (idPedido >= 0)
			{
					resul = true;

			}
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return resul;
}

// Decrementa el stock y genera la factura
public int enviarPedido(int idPedido)
{
	int resul = -1;

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoCP pedidoCP = new PedidoCP(session);

			resul = pedidoCP.EnviarPedidoGenerarFactura(idPedido);


			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return resul;
}



// Obtiene las tallas relacionadas con un tipo producto de tienda, si las tiene
public IList<TallaEN> getTallasProducto(int id)
{
	IList<TallaEN> tallas = new List<TallaEN>();

	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			TiendaCP tiendaCP = new TiendaCP(session);

			tallas = tiendaCP.GetTallasPorProducto(id);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

	return tallas;
}

// Cancelar pedido
public void modificarEstadoPedido(int idPedido, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado)
{
	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			PedidoEN pedidoEN = new PedidoEN();
			PedidoCAD pedidoCAD = new PedidoCAD();
			PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

			pedidoEN = pedidoCAD.ReadOID(idPedido);

			pedidoCEN.Modify(pedidoEN.Id, pedidoEN.Fecha, estado, pedidoEN.Precio);

			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}
}

// Metodo de plantilla
public void plantilla()
{
	try
	{
		using (ISession session = NHibernateHelper.OpenSession())
		using (ITransaction tr = session.BeginTransaction())
		{
			/* AQUI VA EL CODIGO */
			/* EL COMMIT SOLO LO HACEMOS SI TODO HA IDO BIEN Y HAY ALGO QUE ESCRIBIR EN LA BASE DE DATOS */
			tr.Commit();
		}
	}

	catch (Exception ex)
	{
		throw ex;
	}

}

/*PROTECTED REGION END*/

}
}
