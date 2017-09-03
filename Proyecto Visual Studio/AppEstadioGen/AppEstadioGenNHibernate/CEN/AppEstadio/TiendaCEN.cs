

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
public partial class TiendaCEN
{
private ITiendaCAD _ITiendaCAD;

public TiendaCEN()
{
        this._ITiendaCAD = new TiendaCAD ();
}

public TiendaCEN(ITiendaCAD _ITiendaCAD)
{
        this._ITiendaCAD = _ITiendaCAD;
}

public ITiendaCAD get_ITiendaCAD ()
{
        return this._ITiendaCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, string p_color, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum p_tipo)
{
        TiendaEN tiendaEN = null;
        int oid;

        //Initialized TiendaEN
        tiendaEN = new TiendaEN ();
        tiendaEN.Nombre = p_nombre;

        tiendaEN.Descripcion = p_descripcion;

        tiendaEN.Foto = p_foto;

        tiendaEN.Precio = p_precio;

        tiendaEN.Stock = p_stock;

        tiendaEN.Categoria = p_categoria;

        tiendaEN.Color = p_color;

        tiendaEN.Tipo = p_tipo;

        //Call to TiendaCAD

        oid = _ITiendaCAD.New_ (tiendaEN);
        return oid;
}

public void Modify (int p_Tienda_OID, string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, string p_color, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum p_tipo)
{
        TiendaEN tiendaEN = null;

        //Initialized TiendaEN
        tiendaEN = new TiendaEN ();
        tiendaEN.Id = p_Tienda_OID;
        tiendaEN.Nombre = p_nombre;
        tiendaEN.Descripcion = p_descripcion;
        tiendaEN.Foto = p_foto;
        tiendaEN.Precio = p_precio;
        tiendaEN.Stock = p_stock;
        tiendaEN.Categoria = p_categoria;
        tiendaEN.Color = p_color;
        tiendaEN.Tipo = p_tipo;
        //Call to TiendaCAD

        _ITiendaCAD.Modify (tiendaEN);
}

public void Destroy (int id)
{
        _ITiendaCAD.Destroy (id);
}

public TiendaEN ReadOID (int id)
{
        TiendaEN tiendaEN = null;

        tiendaEN = _ITiendaCAD.ReadOID (id);
        return tiendaEN;
}

public System.Collections.Generic.IList<TiendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TiendaEN> list = null;

        list = _ITiendaCAD.ReadAll (first, size);
        return list;
}
public void AgregaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs)
{
        //Call to TiendaCAD

        _ITiendaCAD.AgregaTalla (p_Tienda_OID, p_talla_OIDs);
}
public void QuitaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs)
{
        //Call to TiendaCAD

        _ITiendaCAD.QuitaTalla (p_Tienda_OID, p_talla_OIDs);
}
}
}
