

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
public partial class EntradaCEN
{
private IEntradaCAD _IEntradaCAD;

public EntradaCEN()
{
        this._IEntradaCAD = new EntradaCAD ();
}

public EntradaCEN(IEntradaCAD _IEntradaCAD)
{
        this._IEntradaCAD = _IEntradaCAD;
}

public IEntradaCAD get_IEntradaCAD ()
{
        return this._IEntradaCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, Nullable<DateTime> p_fechaHora, string p_tipo, int p_temporada, string p_grada)
{
        EntradaEN entradaEN = null;
        int oid;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Nombre = p_nombre;

        entradaEN.Descripcion = p_descripcion;

        entradaEN.Foto = p_foto;

        entradaEN.Precio = p_precio;

        entradaEN.Stock = p_stock;

        entradaEN.Categoria = p_categoria;

        entradaEN.FechaHora = p_fechaHora;

        entradaEN.Tipo = p_tipo;

        entradaEN.Temporada = p_temporada;

        entradaEN.Grada = p_grada;

        //Call to EntradaCAD

        oid = _IEntradaCAD.New_ (entradaEN);
        return oid;
}

public void Modify (int p_Entrada_OID, string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, Nullable<DateTime> p_fechaHora, string p_tipo, int p_temporada, string p_grada)
{
        EntradaEN entradaEN = null;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Id = p_Entrada_OID;
        entradaEN.Nombre = p_nombre;
        entradaEN.Descripcion = p_descripcion;
        entradaEN.Foto = p_foto;
        entradaEN.Precio = p_precio;
        entradaEN.Stock = p_stock;
        entradaEN.Categoria = p_categoria;
        entradaEN.FechaHora = p_fechaHora;
        entradaEN.Tipo = p_tipo;
        entradaEN.Temporada = p_temporada;
        entradaEN.Grada = p_grada;
        //Call to EntradaCAD

        _IEntradaCAD.Modify (entradaEN);
}

public void Destroy (int id)
{
        _IEntradaCAD.Destroy (id);
}

public EntradaEN ReadOID (int id)
{
        EntradaEN entradaEN = null;

        entradaEN = _IEntradaCAD.ReadOID (id);
        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> list = null;

        list = _IEntradaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.EntradaEN> GetEntradas ()
{
        return _IEntradaCAD.GetEntradas ();
}
}
}
