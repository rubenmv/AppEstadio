

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
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int New_ (Nullable<DateTime> p_fecha, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum p_estado, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> p_lineaPedido, string p_cliente, float p_precio)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

        pedidoEN.Estado = p_estado;

        pedidoEN.LineaPedido = p_lineaPedido;


        if (p_cliente != null) {
                pedidoEN.Cliente = new AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN ();
                pedidoEN.Cliente.Nif = p_cliente;
        }

        pedidoEN.Precio = p_precio;

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, Nullable<DateTime> p_fecha, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum p_estado, float p_precio)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Estado = p_estado;
        pedidoEN.Precio = p_precio;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id)
{
        _IPedidoCAD.Destroy (id);
}

public PedidoEN ReadOID (int id)
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.ReadAll (first, size);
        return list;
}
public void AnyadirLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        //Call to PedidoCAD

        _IPedidoCAD.AnyadirLinea (p_Pedido_OID, p_lineaPedido_OIDs);
}
public void QuitarLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        //Call to PedidoCAD

        _IPedidoCAD.QuitarLinea (p_Pedido_OID, p_lineaPedido_OIDs);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorCliente (string p_nif)
{
        return _IPedidoCAD.GetPedidosPorCliente (p_nif);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosEntreFechas (Nullable<DateTime> p_min, Nullable<DateTime> p_max)
{
        return _IPedidoCAD.GetPedidosEntreFechas (p_min, p_max);
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorEstado (int p_estado)
{
        return _IPedidoCAD.GetPedidosPorEstado (p_estado);
}
}
}
