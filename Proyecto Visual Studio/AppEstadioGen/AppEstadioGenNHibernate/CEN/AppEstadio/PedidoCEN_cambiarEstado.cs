
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
public void CambiarEstado (int p_oid, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum p_estadoNuevo)
{
        /*PROTECTED REGION ID(AppEstadioGenNHibernate.CEN.AppEstadio_Pedido_cambiarEstado) ENABLED START*/

        PedidoEN pedido = _IPedidoCAD.ReadOID (p_oid);

        pedido.Estado = p_estadoNuevo;

        /*PROTECTED REGION END*/
}
}
}
