
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
public partial class VariosCAD : BasicCAD, IVariosCAD
{
public VariosCAD() : base ()
{
}

public VariosCAD(ISession sessionAux) : base (sessionAux)
{
}



public VariosEN ReadOIDDefault (int id)
{
        VariosEN variosEN = null;

        try
        {
                SessionInitializeTransaction ();
                variosEN = (VariosEN)session.Get (typeof(VariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return variosEN;
}


public int New_ (VariosEN varios)
{
        try
        {
                SessionInitializeTransaction ();
                if (varios.Producto != null) {
                        varios.Producto = (AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN), varios.Producto.Id);

                        varios.Producto.Articulo.Add (varios);
                }
                if (varios.Tamano != null) {
                        for (int i = 0; i < varios.Tamano.Count; i++) {
                                varios.Tamano [i] = (AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN), varios.Tamano [i].Tam);
                                varios.Tamano [i].Varios.Add (varios);
                        }
                }

                session.Save (varios);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return varios.Id;
}

public void Modify (VariosEN varios)
{
        try
        {
                SessionInitializeTransaction ();
                VariosEN variosEN = (VariosEN)session.Load (typeof(VariosEN), varios.Id);

                variosEN.Modelo = varios.Modelo;

                session.Update (variosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
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
                VariosEN variosEN = (VariosEN)session.Load (typeof(VariosEN), id);
                session.Delete (variosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public VariosEN ReadOID (int id)
{
        VariosEN variosEN = null;

        try
        {
                SessionInitializeTransaction ();
                variosEN = (VariosEN)session.Get (typeof(VariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return variosEN;
}

public System.Collections.Generic.IList<VariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VariosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VariosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VariosEN>();
                else
                        result = session.CreateCriteria (typeof(VariosEN)).List<VariosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> GetVarios ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VariosEN self where FROM VariosEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VariosENgetVariosHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in VariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
