

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
public partial class TallaPrendaCEN
{
private ITallaPrendaCAD _ITallaPrendaCAD;

public TallaPrendaCEN()
{
        this._ITallaPrendaCAD = new TallaPrendaCAD ();
}

public TallaPrendaCEN(ITallaPrendaCAD _ITallaPrendaCAD)
{
        this._ITallaPrendaCAD = _ITallaPrendaCAD;
}

public ITallaPrendaCAD get_ITallaPrendaCAD ()
{
        return this._ITallaPrendaCAD;
}

public string New_ (string p_talla)
{
        TallaPrendaEN tallaPrendaEN = null;
        string oid;

        //Initialized TallaPrendaEN
        tallaPrendaEN = new TallaPrendaEN ();
        tallaPrendaEN.Talla = p_talla;

        //Call to TallaPrendaCAD

        oid = _ITallaPrendaCAD.New_ (tallaPrendaEN);
        return oid;
}

public void Modify (string p_TallaPrenda_OID)
{
        TallaPrendaEN tallaPrendaEN = null;

        //Initialized TallaPrendaEN
        tallaPrendaEN = new TallaPrendaEN ();
        tallaPrendaEN.Talla = p_TallaPrenda_OID;
        //Call to TallaPrendaCAD

        _ITallaPrendaCAD.Modify (tallaPrendaEN);
}

public void Destroy (string talla)
{
        _ITallaPrendaCAD.Destroy (talla);
}

public TallaPrendaEN ReadOID (string talla)
{
        TallaPrendaEN tallaPrendaEN = null;

        tallaPrendaEN = _ITallaPrendaCAD.ReadOID (talla);
        return tallaPrendaEN;
}

public System.Collections.Generic.IList<TallaPrendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaPrendaEN> list = null;

        list = _ITallaPrendaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> GetTallasPrenda ()
{
        return _ITallaPrendaCAD.GetTallasPrenda ();
}
}
}
