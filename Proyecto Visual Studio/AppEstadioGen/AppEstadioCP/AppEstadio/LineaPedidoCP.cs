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
    public class LineaPedidoCP : BasicCP
    {

        public LineaPedidoCP() : base() { }

        public LineaPedidoCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public float GetPrecioLinea(LineaPedidoEN p_linea)
        {
            float precio = 0;

            try
            {
                SessionInitializeTransaction();

                precio = p_linea.Unidades * p_linea.Producto.Precio;

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
            return precio;
        }

    }
}
