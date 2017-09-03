

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
public partial class AbonoCEN
{
private IAbonoCAD _IAbonoCAD;

public AbonoCEN()
{
        this._IAbonoCAD = new AbonoCAD ();
}

public AbonoCEN(IAbonoCAD _IAbonoCAD)
{
        this._IAbonoCAD = _IAbonoCAD;
}

public IAbonoCAD get_IAbonoCAD ()
{
        return this._IAbonoCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, string p_tipo, int p_temporada, string p_grada)
{
        AbonoEN abonoEN = null;
        int oid;

        //Initialized AbonoEN
        abonoEN = new AbonoEN ();
        abonoEN.Nombre = p_nombre;

        abonoEN.Descripcion = p_descripcion;

        abonoEN.Foto = p_foto;

        abonoEN.Precio = p_precio;

        abonoEN.Stock = p_stock;

        abonoEN.Categoria = p_categoria;

        abonoEN.Tipo = p_tipo;

        abonoEN.Temporada = p_temporada;

        abonoEN.Grada = p_grada;

        //Call to AbonoCAD

        oid = _IAbonoCAD.New_ (abonoEN);
        return oid;
}

public void Modify (int p_Abono_OID, string p_nombre, string p_descripcion, string p_foto, float p_precio, int p_stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum p_categoria, string p_tipo, int p_temporada, string p_grada)
{
        AbonoEN abonoEN = null;

        //Initialized AbonoEN
        abonoEN = new AbonoEN ();
        abonoEN.Id = p_Abono_OID;
        abonoEN.Nombre = p_nombre;
        abonoEN.Descripcion = p_descripcion;
        abonoEN.Foto = p_foto;
        abonoEN.Precio = p_precio;
        abonoEN.Stock = p_stock;
        abonoEN.Categoria = p_categoria;
        abonoEN.Tipo = p_tipo;
        abonoEN.Temporada = p_temporada;
        abonoEN.Grada = p_grada;
        //Call to AbonoCAD

        _IAbonoCAD.Modify (abonoEN);
}

public void Destroy (int id)
{
        _IAbonoCAD.Destroy (id);
}

public AbonoEN ReadOID (int id)
{
        AbonoEN abonoEN = null;

        abonoEN = _IAbonoCAD.ReadOID (id);
        return abonoEN;
}

public System.Collections.Generic.IList<AbonoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AbonoEN> list = null;

        list = _IAbonoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.AbonoEN> GetAbonos ()
{
        return _IAbonoCAD.GetAbonos ();
}
}
}
