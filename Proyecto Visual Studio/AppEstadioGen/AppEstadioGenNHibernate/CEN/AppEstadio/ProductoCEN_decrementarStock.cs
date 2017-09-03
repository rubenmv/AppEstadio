
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
public void DecrementarStock (int p_oid, int p_decremento)
{
        /*PROTECTED REGION ID(AppEstadioGenNHibernate.CEN.AppEstadio_Producto_decrementarStock) ENABLED START*/

        ProductoEN productoEN = _IProductoCAD.ReadOID (p_oid);
        ProductoCEN productoCEN = new ProductoCEN (_IProductoCAD);

        productoEN.Stock -= p_decremento;
        if (productoEN.Stock < 0) {
                productoEN.Stock = 0;
        }

        productoCEN.Modify (productoEN.Id, productoEN.Nombre, productoEN.Descripcion, productoEN.Foto, productoEN.Precio, productoEN.Stock, productoEN.Categoria);

        /*PROTECTED REGION END*/
}
}
}
