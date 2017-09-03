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
    public class TiendaCP : BasicCP
    {

        public TiendaCP() : base() { }

        public TiendaCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public IList<TallaEN> GetTallasPorProducto(int idProducto)
		{
			IList<TallaEN> tallas = new List<TallaEN>();

        	try
            {
                SessionInitializeTransaction();

				TiendaEN producto = null;
				TiendaCAD productoCAD = null;
				productoCAD = new TiendaCAD(session);

				producto = productoCAD.ReadOID(idProducto);

				for (int i = 0; i < producto.Talla.Count; i++)
				{
					tallas.Add(producto.Talla[i]);
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

            return tallas;
        }
    }
}
