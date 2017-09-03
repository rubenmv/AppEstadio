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
    public class ProductoCP : BasicCP
    {

        public ProductoCP() : base() { }

        public ProductoCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

      	 public void eliminarArticulosDeProducto(int idProducto)
		{

        	try
            {
                SessionInitializeTransaction();

                ProductoCAD productoCAD = new ProductoCAD(session);
				ProductoEN productoEN = productoCAD.ReadOIDDefault(idProducto);

				ArticuloCAD articuloCAD = new ArticuloCAD(session);
				ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
				IList<ArticuloEN> listaArticulos = new List<ArticuloEN>();

				for (int i = 0; i < productoEN.Articulo.Count; i++)
				{
					articuloCEN.Destroy(productoEN.Articulo[i].Id);
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
        }

	}
}
