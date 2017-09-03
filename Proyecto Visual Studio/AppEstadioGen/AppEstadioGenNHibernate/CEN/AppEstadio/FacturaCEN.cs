

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
public partial class FacturaCEN
{
private IFacturaCAD _IFacturaCAD;

public FacturaCEN()
{
        this._IFacturaCAD = new FacturaCAD ();
}

public FacturaCEN(IFacturaCAD _IFacturaCAD)
{
        this._IFacturaCAD = _IFacturaCAD;
}

public IFacturaCAD get_IFacturaCAD ()
{
        return this._IFacturaCAD;
}

public int New_ (int p_pedido, float p_precioTotal, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> p_lineaFactura, Nullable<DateTime> p_fecha)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();

        if (p_pedido != -1) {
                facturaEN.Pedido = new AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN ();
                facturaEN.Pedido.Id = p_pedido;
        }

        facturaEN.PrecioTotal = p_precioTotal;

        facturaEN.LineaFactura = p_lineaFactura;

        facturaEN.Fecha = p_fecha;

        //Call to FacturaCAD

        oid = _IFacturaCAD.New_ (facturaEN);
        return oid;
}

public void Modify (int p_Factura_OID, float p_precioTotal, Nullable<DateTime> p_fecha)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.PrecioTotal = p_precioTotal;
        facturaEN.Fecha = p_fecha;
        //Call to FacturaCAD

        _IFacturaCAD.Modify (facturaEN);
}

public void Destroy (int id)
{
        _IFacturaCAD.Destroy (id);
}

public FacturaEN ReadOID (int id)
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaCAD.ReadOID (id);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaCAD.ReadAll (first, size);
        return list;
}
}
}
