
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
public partial class AbonoCAD : BasicCAD, IAbonoCAD
{
public AbonoCAD() : base ()
{
}

public AbonoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AbonoEN ReadOIDDefault (int id)
{
        AbonoEN abonoEN = null;

        try
        {
                SessionInitializeTransaction ();
                abonoEN = (AbonoEN)session.Get (typeof(AbonoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return abonoEN;
}


public int New_ (AbonoEN abono)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (abono);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return abono.Id;
}

public void Modify (AbonoEN abono)
{
        try
        {
                SessionInitializeTransaction ();
                AbonoEN abonoEN = (AbonoEN)session.Load (typeof(AbonoEN), abono.Id);

                abonoEN.Nombre = abono.Nombre;


                abonoEN.Descripcion = abono.Descripcion;


                abonoEN.Foto = abono.Foto;


                abonoEN.Precio = abono.Precio;


                abonoEN.Stock = abono.Stock;


                abonoEN.Categoria = abono.Categoria;


                abonoEN.Tipo = abono.Tipo;


                abonoEN.Temporada = abono.Temporada;


                abonoEN.Grada = abono.Grada;

                session.Update (abonoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
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
                AbonoEN abonoEN = (AbonoEN)session.Load (typeof(AbonoEN), id);
                session.Delete (abonoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public AbonoEN ReadOID (int id)
{
        AbonoEN abonoEN = null;

        try
        {
                SessionInitializeTransaction ();
                abonoEN = (AbonoEN)session.Get (typeof(AbonoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return abonoEN;
}

public System.Collections.Generic.IList<AbonoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AbonoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AbonoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AbonoEN>();
                else
                        result = session.CreateCriteria (typeof(AbonoEN)).List<AbonoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.AbonoEN> GetAbonos ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.AbonoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AbonoEN self where FROM AbonoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AbonoENgetAbonosHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.AbonoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in AbonoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
