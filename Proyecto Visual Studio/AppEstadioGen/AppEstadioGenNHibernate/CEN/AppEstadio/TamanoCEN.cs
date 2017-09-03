

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
public partial class TamanoCEN
{
private ITamanoCAD _ITamanoCAD;

public TamanoCEN()
{
        this._ITamanoCAD = new TamanoCAD ();
}

public TamanoCEN(ITamanoCAD _ITamanoCAD)
{
        this._ITamanoCAD = _ITamanoCAD;
}

public ITamanoCAD get_ITamanoCAD ()
{
        return this._ITamanoCAD;
}

public string New_ (string p_tam)
{
        TamanoEN tamanoEN = null;
        string oid;

        //Initialized TamanoEN
        tamanoEN = new TamanoEN ();
        tamanoEN.Tam = p_tam;

        //Call to TamanoCAD

        oid = _ITamanoCAD.New_ (tamanoEN);
        return oid;
}

public void Modify (string p_Tamano_OID)
{
        TamanoEN tamanoEN = null;

        //Initialized TamanoEN
        tamanoEN = new TamanoEN ();
        tamanoEN.Tam = p_Tamano_OID;
        //Call to TamanoCAD

        _ITamanoCAD.Modify (tamanoEN);
}

public void Destroy (string tam)
{
        _ITamanoCAD.Destroy (tam);
}

public TamanoEN ReadOID (string tam)
{
        TamanoEN tamanoEN = null;

        tamanoEN = _ITamanoCAD.ReadOID (tam);
        return tamanoEN;
}

public System.Collections.Generic.IList<TamanoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TamanoEN> list = null;

        list = _ITamanoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> GetTamanos ()
{
        return _ITamanoCAD.GetTamanos ();
}
}
}
