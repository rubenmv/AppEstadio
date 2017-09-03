

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
public partial class TallaCEN
{
private ITallaCAD _ITallaCAD;

public TallaCEN()
{
        this._ITallaCAD = new TallaCAD ();
}

public TallaCEN(ITallaCAD _ITallaCAD)
{
        this._ITallaCAD = _ITallaCAD;
}

public ITallaCAD get_ITallaCAD ()
{
        return this._ITallaCAD;
}

public int New_ (string p_nombre, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum p_tipo, string p_medidas)
{
        TallaEN tallaEN = null;
        int oid;

        //Initialized TallaEN
        tallaEN = new TallaEN ();
        tallaEN.Nombre = p_nombre;

        tallaEN.Tipo = p_tipo;

        tallaEN.Medidas = p_medidas;

        //Call to TallaCAD

        oid = _ITallaCAD.New_ (tallaEN);
        return oid;
}

public void Modify (int p_Talla_OID, string p_nombre, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum p_tipo, string p_medidas)
{
        TallaEN tallaEN = null;

        //Initialized TallaEN
        tallaEN = new TallaEN ();
        tallaEN.Id = p_Talla_OID;
        tallaEN.Nombre = p_nombre;
        tallaEN.Tipo = p_tipo;
        tallaEN.Medidas = p_medidas;
        //Call to TallaCAD

        _ITallaCAD.Modify (tallaEN);
}

public void Destroy (int id)
{
        _ITallaCAD.Destroy (id);
}

public TallaEN ReadOID (int id)
{
        TallaEN tallaEN = null;

        tallaEN = _ITallaCAD.ReadOID (id);
        return tallaEN;
}

public System.Collections.Generic.IList<TallaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaEN> list = null;

        list = _ITallaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> GetTallasPorTipo (int p_tipo)
{
        return _ITallaCAD.GetTallasPorTipo (p_tipo);
}
}
}
