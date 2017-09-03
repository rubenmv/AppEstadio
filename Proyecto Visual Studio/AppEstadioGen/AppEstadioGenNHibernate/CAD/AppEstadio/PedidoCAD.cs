
using System;
using System.Text;
using AppEstadioGenNHibernate.CEN.AppEstadio;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.Exceptions;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int id)
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}


public int New_ (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.LineaPedido != null) {
                        foreach (AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN item in pedido.LineaPedido) {
                                item.Pedido = pedido;
                                session.Save (item);
                        }
                }
                if (pedido.Cliente != null) {
                        pedido.Cliente = (AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN), pedido.Cliente.Nif);

                        pedido.Cliente.Pedido.Add (pedido);
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.Estado = pedido.Estado;


                pedidoEN.Precio = pedido.Precio;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), id);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public PedidoEN ReadOID (int id)
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN lineaPedidoENAux = null;
                if (pedidoEN.LineaPedido == null) {
                        pedidoEN.LineaPedido = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN>();
                }

                foreach (int item in p_lineaPedido_OIDs) {
                        lineaPedidoENAux = new AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN ();
                        lineaPedidoENAux = (AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN), item);
                        lineaPedidoENAux.Pedido = pedidoEN;

                        pedidoEN.LineaPedido.Add (lineaPedidoENAux);
                }


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarLinea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedidoEN = null;
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);

                AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN lineaPedidoENAux = null;
                if (pedidoEN.LineaPedido != null) {
                        foreach (int item in p_lineaPedido_OIDs) {
                                lineaPedidoENAux = (AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN), item);
                                if (pedidoEN.LineaPedido.Contains (lineaPedidoENAux) == true) {
                                        pedidoEN.LineaPedido.Remove (lineaPedidoENAux);
                                        lineaPedidoENAux.Pedido = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_lineaPedido_OIDs you are trying to unrelationer, doesn't exist in PedidoEN");
                        }
                }

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorCliente (string p_nif)
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN as p WHERE p.Cliente.Nif = :p_nif";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENgetPedidosPorClienteHQL");
                query.SetParameter ("p_nif", p_nif);

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosEntreFechas (Nullable<DateTime> p_min, Nullable<DateTime> p_max)
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN AS pe WHERE pe.Fecha >= :p_min AND pe.Fecha <= :p_max";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENgetPedidosEntreFechasHQL");
                query.SetParameter ("p_min", p_min);
                query.SetParameter ("p_max", p_max);

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> GetPedidosPorEstado (int p_estado)
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN AS pe WHERE pe.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENgetPedidosPorEstadoHQL");
                query.SetParameter ("p_estado", p_estado);

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
