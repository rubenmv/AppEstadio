
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id);

int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id);


PedidoEN ReadOID (int id);


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);


void AnyadirLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);

void QuitarLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorCliente (string p_nif);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosEntreFechas (Nullable<DateTime> p_min, Nullable<DateTime> p_max);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorEstado (int p_estado);
}
}
