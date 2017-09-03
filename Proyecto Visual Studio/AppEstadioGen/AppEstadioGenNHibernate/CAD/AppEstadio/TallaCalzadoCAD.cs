
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
public partial class TallaCalzadoCAD : BasicCAD, ITallaCalzadoCAD
{
public TallaCalzadoCAD() : base ()
{
}

public TallaCalzadoCAD(ISession sessionAux) : base (sessionAux)
{
}



public TallaCalzadoEN ReadOIDDefault (int talla)
{
        TallaCalzadoEN tallaCalzadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaCalzadoEN = (TallaCalzadoEN)session.Get (typeof(TallaCalzadoEN), talla);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaCalzadoEN;
}


public int New_ (TallaCalzadoEN tallaCalzado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tallaCalzado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaCalzado.Talla;
}

public void Modify (TallaCalzadoEN tallaCalzado)
{
        try
        {
                SessionInitializeTransaction ();
                TallaCalzadoEN tallaCalzadoEN = (TallaCalzadoEN)session.Load (typeof(TallaCalzadoEN), tallaCalzado.Talla);
                session.Update (tallaCalzadoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int talla)
{
        try
        {
                SessionInitializeTransaction ();
                TallaCalzadoEN tallaCalzadoEN = (TallaCalzadoEN)session.Load (typeof(TallaCalzadoEN), talla);
                session.Delete (tallaCalzadoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public TallaCalzadoEN ReadOID (int talla)
{
        TallaCalzadoEN tallaCalzadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaCalzadoEN = (TallaCalzadoEN)session.Get (typeof(TallaCalzadoEN), talla);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaCalzadoEN;
}

public System.Collections.Generic.IList<TallaCalzadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaCalzadoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TallaCalzadoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TallaCalzadoEN>();
                else
                        result = session.CreateCriteria (typeof(TallaCalzadoEN)).List<TallaCalzadoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> GetTallasCalzado ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TallaCalzadoEN self where FROM TallaCalzadoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TallaCalzadoENgetTallasCalzadoHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
