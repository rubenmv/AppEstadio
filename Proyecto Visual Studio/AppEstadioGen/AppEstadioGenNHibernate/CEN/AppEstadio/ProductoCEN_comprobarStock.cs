
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.CAD.AppEstadio;

namespace AppEstadioGenNHibernate.CEN.AppEstadio
{
public partial class ProductoCEN
{
public bool ComprobarStock (int p_oid, int p_decremento)
{
        /*PROTECTED REGION ID(AppEstadioGenNHibernate.CEN.AppEstadio_Producto_comprobarStock) ENABLED START*/

        ProductoEN producto = _IProductoCAD.ReadOID (p_oid);

        if (producto.Stock - p_decremento >= 0)
                return true;
        else
                return false;

        /*PROTECTED REGION END*/
}
}
}
