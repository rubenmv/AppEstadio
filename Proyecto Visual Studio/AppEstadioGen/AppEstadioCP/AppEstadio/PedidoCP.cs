using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppEstadioGenNHibernate.CAD.AppEstadio;
using AppEstadioGenNHibernate.CEN.AppEstadio;
using AppEstadioGenNHibernate.EN.AppEstadio;
using NHibernate;

namespace appEstadioCP.AppEstadio
{
    public class PedidoCP : BasicCP
    {

        public PedidoCP() : base() { }

        public PedidoCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public float GetPrecioPedido(System.Collections.Generic.IList<LineaPedidoEN> p_lineas)
		{
        	float total = 0;

            LineaPedidoCP lineaPedidoCP = new LineaPedidoCP();

        	try
            {
                SessionInitializeTransaction();

                foreach(LineaPedidoEN linea in p_lineas) {
                    total += lineaPedidoCP.GetPrecioLinea(linea);
                }

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
            return total;
        }

		// Decrementa el stock, genera factura y devuelve su id
		public int EnviarPedidoGenerarFactura(int idPedido)
		{
			int resul = -1;

			try
			{
				SessionInitializeTransaction();

				bool correcto = true;

				// Recoger el pedido
				PedidoCAD pedidoCAD = new PedidoCAD(session);
				PedidoEN pedidoEN = new PedidoEN();
				pedidoEN = pedidoCAD.ReadOID(idPedido);
				ProductoCAD productoCAD = new ProductoCAD(session);
				ProductoCEN productoCEN = new ProductoCEN(productoCAD);

				IList<LineaFacturaEN> lineasFactura = new List<LineaFacturaEN>();

				foreach (LineaPedidoEN linea in pedidoEN.LineaPedido)
				{
					ProductoEN producto = linea.Producto;
					productoCEN.DecrementarStock(producto.Id, linea.Unidades);
					
					IList<int> idArticulos = new List<int>();

					if (linea.Producto.Stock < linea.Unidades) // No hay stock, no se envia el pedido
					{
						correcto = false;
						break;
					}
					for (int i = 0; correcto && i < linea.Unidades; i++)
					{
						idArticulos.Add(producto.Articulo[i].Id);
					}

					ArticuloCAD aCAD = new ArticuloCAD(session);
					ArticuloCEN aCEN = new ArticuloCEN(aCAD);
					 
					for (int i = 0; i < idArticulos.Count; i++)
					{
						aCEN.Destroy(idArticulos[i]);
					}
					
					
					// Creamos las lineas de factura para esta linea de pedido
					for (int i = 0; i < linea.Unidades; i++)
					{
						LineaFacturaEN lfEN = new LineaFacturaEN();
						lfEN.Articulo = producto.Articulo[i];
						lineasFactura.Add(lfEN); // Luego el new de factura creara las lineas
					}
					
				}
				
				// Generar la factura
				FacturaCAD facturaCAD = new FacturaCAD(session);
				FacturaCEN facturaCEN = new FacturaCEN(facturaCAD);
				FacturaEN facturaEN = new FacturaEN();

				facturaEN.Fecha = DateTime.Now;
				facturaEN.PrecioTotal = pedidoEN.Precio;
				facturaEN.Pedido = pedidoEN;

				facturaEN.Id = facturaCEN.New_(pedidoEN.Id, facturaEN.PrecioTotal, lineasFactura, facturaEN.Fecha);
				

				if (correcto)
				{
					resul = 1;
				}
				
				
				SessionCommit();
			}
			catch (Exception ex)
			{
				SessionRollBack();
				throw ex;
			}
			finally
			{
				SessionClose();
			}

			return resul;
		}

		// Crea un pedido nuevo y devuelve su id
		public int CrearPedido(IList<LineaPedidoEN> p_lineas, UsuarioEN usuario)
		{
			int resul = -1;

			try
			{
				SessionInitializeTransaction();

				PedidoEN pedidoEN = new PedidoEN();
				PedidoCAD pedidoCAD = new PedidoCAD();
				PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

				pedidoEN.Fecha = DateTime.Now;
				pedidoEN.Estado = AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum.pendiente; // Por defecto pendiente de revision por un administrador
				// Precio del pedido
				float precio = this.GetPrecioPedido(p_lineas);
				// CREA EL PEDIDO
				pedidoEN.Id = pedidoCEN.New_(pedidoEN.Fecha, pedidoEN.Estado, p_lineas, usuario.Nif, precio);

				resul = pedidoEN.Id;

				SessionCommit();
			}
			catch (Exception ex)
			{
				SessionRollBack();
				throw ex;
			}
			finally
			{
				SessionClose();
			}

			return resul;
		}

		public IList<LineaPedidoEN> GetLineasPedido(int idPedido)
		{
			IList<LineaPedidoEN> lineas = new List<LineaPedidoEN>();

			try
			{
				SessionInitializeTransaction();

				PedidoEN pedido = null;
				PedidoCAD pedidoCAD = null;
				pedidoCAD = new PedidoCAD(session);

				pedido = pedidoCAD.ReadOID(idPedido);

				for (int i = 0; i < pedido.LineaPedido.Count; i++)
				{
					lineas.Add(pedido.LineaPedido[i]);
				}

				SessionCommit();
			}
			catch (Exception ex)
			{
				SessionRollBack();
				throw ex;
			}
			finally
			{
				SessionClose();
			}

			return lineas;
		}
	}
}
