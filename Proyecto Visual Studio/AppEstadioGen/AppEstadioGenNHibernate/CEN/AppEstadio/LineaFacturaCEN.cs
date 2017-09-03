

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
public partial class LineaFacturaCEN
{
private ILineaFacturaCAD _ILineaFacturaCAD;

public LineaFacturaCEN()
{
        this._ILineaFacturaCAD = new LineaFacturaCAD ();
}

public LineaFacturaCEN(ILineaFacturaCAD _ILineaFacturaCAD)
{
        this._ILineaFacturaCAD = _ILineaFacturaCAD;
}

public ILineaFacturaCAD get_ILineaFacturaCAD ()
{
        return this._ILineaFacturaCAD;
}

public LineaFacturaEN ReadOID (int id)
{
        LineaFacturaEN lineaFacturaEN = null;

        lineaFacturaEN = _ILineaFacturaCAD.ReadOID (id);
        return lineaFacturaEN;
}

public System.Collections.Generic.IList<LineaFacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaFacturaEN> list = null;

        list = _ILineaFacturaCAD.ReadAll (first, size);
        return list;
}
public int New_ (int p_factura)
{
        LineaFacturaEN lineaFacturaEN = null;
        int oid;

        //Initialized LineaFacturaEN
        lineaFacturaEN = new LineaFacturaEN ();

        if (p_factura != -1) {
                lineaFacturaEN.Factura = new AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN ();
                lineaFacturaEN.Factura.Id = p_factura;
        }

        //Call to LineaFacturaCAD

        oid = _ILineaFacturaCAD.New_ (lineaFacturaEN);
        return oid;
}

public void Modify (int p_LineaFactura_OID)
{
        LineaFacturaEN lineaFacturaEN = null;

        //Initialized LineaFacturaEN
        lineaFacturaEN = new LineaFacturaEN ();
        lineaFacturaEN.Id = p_LineaFactura_OID;
        //Call to LineaFacturaCAD

        _ILineaFacturaCAD.Modify (lineaFacturaEN);
}

public void Destroy (int id)
{
        _ILineaFacturaCAD.Destroy (id);
}
}
}
