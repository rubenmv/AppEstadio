

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
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Nombre = p_nombre;

        productoEN.Descripcion = p_descripcion;

        productoEN.Foto = p_foto;

        productoEN.Precio = p_precio;

        productoEN.Stock = p_stock;

        productoEN.Categoria = p_categoria;

        //Call to ProductoCAD

        oid = _IProductoCAD.New_ (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Descripcion = p_descripcion;
        productoEN.Foto = p_foto;
        productoEN.Precio = p_precio;
        productoEN.Stock = p_stock;
        productoEN.Categoria = p_categoria;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int id)
{
        _IProductoCAD.Destroy (id);
}

public ProductoEN ReadOID (int id)
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorNombre (string p_termino)
{
        return _IProductoCAD.GetProductosPorNombre (p_termino);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorRangoPrecio (float p_min, float p_max)
{
        return _IProductoCAD.GetProductosPorRangoPrecio (p_min, p_max);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosPorDescripcion (string p_termino)
{
        return _IProductoCAD.GetProductosPorDescripcion (p_termino);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductos ()
{
        return _IProductoCAD.GetProductos ();
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN> GetProductosTienda ()
{
        return _IProductoCAD.GetProductosTienda ();
}
}
}
