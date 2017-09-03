
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id);

int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id);


ProductoEN ReadOID (int id);


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);





System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorNombre (string p_termino);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorRangoPrecio (float p_min, float p_max);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorDescripcion (string p_termino);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductos ();


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosTienda ();
}
}
