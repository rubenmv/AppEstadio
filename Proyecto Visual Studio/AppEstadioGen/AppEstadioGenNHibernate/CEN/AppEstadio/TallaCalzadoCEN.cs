

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
public partial class TallaCalzadoCEN
{
private ITallaCalzadoCAD _ITallaCalzadoCAD;

public TallaCalzadoCEN()
{
        this._ITallaCalzadoCAD = new TallaCalzadoCAD ();
}

public TallaCalzadoCEN(ITallaCalzadoCAD _ITallaCalzadoCAD)
{
        this._ITallaCalzadoCAD = _ITallaCalzadoCAD;
}

public ITallaCalzadoCAD get_ITallaCalzadoCAD ()
{
        return this._ITallaCalzadoCAD;
}

public int New_ (int p_talla)
{
        TallaCalzadoEN tallaCalzadoEN = null;
        int oid;

        //Initialized TallaCalzadoEN
        tallaCalzadoEN = new TallaCalzadoEN ();
        tallaCalzadoEN.Talla = p_talla;

        //Call to TallaCalzadoCAD

        oid = _ITallaCalzadoCAD.New_ (tallaCalzadoEN);
        return oid;
}

public void Modify (int p_TallaCalzado_OID)
{
        TallaCalzadoEN tallaCalzadoEN = null;

        //Initialized TallaCalzadoEN
        tallaCalzadoEN = new TallaCalzadoEN ();
        tallaCalzadoEN.Talla = p_TallaCalzado_OID;
        //Call to TallaCalzadoCAD

        _ITallaCalzadoCAD.Modify (tallaCalzadoEN);
}

public void Destroy (int talla)
{
        _ITallaCalzadoCAD.Destroy (talla);
}

public TallaCalzadoEN ReadOID (int talla)
{
        TallaCalzadoEN tallaCalzadoEN = null;

        tallaCalzadoEN = _ITallaCalzadoCAD.ReadOID (talla);
        return tallaCalzadoEN;
}

public System.Collections.Generic.IList<TallaCalzadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaCalzadoEN> list = null;

        list = _ITallaCalzadoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> GetTallasCalzado ()
{
        return _ITallaCalzadoCAD.GetTallasCalzado ();
}
}
}
