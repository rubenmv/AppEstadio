
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
public partial class TallaCAD : BasicCAD, ITallaCAD
{
public TallaCAD() : base ()
{
}

public TallaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TallaEN ReadOIDDefault (int id)
{
        TallaEN tallaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaEN = (TallaEN)session.Get (typeof(TallaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaEN;
}


public int New_ (TallaEN talla)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (talla);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return talla.Id;
}

public void Modify (TallaEN talla)
{
        try
        {
                SessionInitializeTransaction ();
                TallaEN tallaEN = (TallaEN)session.Load (typeof(TallaEN), talla.Id);

                tallaEN.Nombre = talla.Nombre;


                tallaEN.Tipo = talla.Tipo;


                tallaEN.Medidas = talla.Medidas;

                session.Update (tallaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
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
                TallaEN tallaEN = (TallaEN)session.Load (typeof(TallaEN), id);
                session.Delete (tallaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public TallaEN ReadOID (int id)
{
        TallaEN tallaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaEN = (TallaEN)session.Get (typeof(TallaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaEN;
}

public System.Collections.Generic.IList<TallaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TallaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TallaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TallaEN>();
                else
                        result = session.CreateCriteria (typeof(TallaEN)).List<TallaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> GetTallasPorTipo (int p_tipo)
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TallaEN self where FROM TallaEN AS ta WHERE ta.Tipo = :p_tipo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TallaENgetTallasPorTipoHQL");
                query.SetParameter ("p_tipo", p_tipo);

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TallaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
