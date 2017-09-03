
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
public partial class TallaPrendaCAD : BasicCAD, ITallaPrendaCAD
{
public TallaPrendaCAD() : base ()
{
}

public TallaPrendaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TallaPrendaEN ReadOIDDefault (string talla)
{
        TallaPrendaEN tallaPrendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaPrendaEN = (TallaPrendaEN)session.Get (typeof(TallaPrendaEN), talla);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaPrendaEN;
}


public string New_ (TallaPrendaEN tallaPrenda)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tallaPrenda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaPrenda.Talla;
}

public void Modify (TallaPrendaEN tallaPrenda)
{
        try
        {
                SessionInitializeTransaction ();
                TallaPrendaEN tallaPrendaEN = (TallaPrendaEN)session.Load (typeof(TallaPrendaEN), tallaPrenda.Talla);
                session.Update (tallaPrendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string talla)
{
        try
        {
                SessionInitializeTransaction ();
                TallaPrendaEN tallaPrendaEN = (TallaPrendaEN)session.Load (typeof(TallaPrendaEN), talla);
                session.Delete (tallaPrendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public TallaPrendaEN ReadOID (string talla)
{
        TallaPrendaEN tallaPrendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaPrendaEN = (TallaPrendaEN)session.Get (typeof(TallaPrendaEN), talla);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaPrendaEN;
}

public System.Collections.Generic.IList<TallaPrendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaPrendaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TallaPrendaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TallaPrendaEN>();
                else
                        result = session.CreateCriteria (typeof(TallaPrendaEN)).List<TallaPrendaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> GetTallasPrenda ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TallaPrendaEN self where FROM TallaPrendaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TallaPrendaENgetTallasPrendaHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaPrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
