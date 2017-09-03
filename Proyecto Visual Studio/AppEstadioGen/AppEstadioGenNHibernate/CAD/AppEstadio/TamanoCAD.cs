
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
public partial class TamanoCAD : BasicCAD, ITamanoCAD
{
public TamanoCAD() : base ()
{
}

public TamanoCAD(ISession sessionAux) : base (sessionAux)
{
}



public TamanoEN ReadOIDDefault (string tam)
{
        TamanoEN tamanoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tamanoEN = (TamanoEN)session.Get (typeof(TamanoEN), tam);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tamanoEN;
}


public string New_ (TamanoEN tamano)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tamano);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tamano.Tam;
}

public void Modify (TamanoEN tamano)
{
        try
        {
                SessionInitializeTransaction ();
                TamanoEN tamanoEN = (TamanoEN)session.Load (typeof(TamanoEN), tamano.Tam);
                session.Update (tamanoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string tam)
{
        try
        {
                SessionInitializeTransaction ();
                TamanoEN tamanoEN = (TamanoEN)session.Load (typeof(TamanoEN), tam);
                session.Delete (tamanoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public TamanoEN ReadOID (string tam)
{
        TamanoEN tamanoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tamanoEN = (TamanoEN)session.Get (typeof(TamanoEN), tam);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tamanoEN;
}

public System.Collections.Generic.IList<TamanoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TamanoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TamanoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TamanoEN>();
                else
                        result = session.CreateCriteria (typeof(TamanoEN)).List<TamanoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> GetTamanos ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TamanoEN self where FROM TamanoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TamanoENgetTamanosHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TamanoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
