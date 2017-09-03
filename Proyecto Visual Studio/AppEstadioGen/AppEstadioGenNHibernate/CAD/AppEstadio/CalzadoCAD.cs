
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
public partial class CalzadoCAD : BasicCAD, ICalzadoCAD
{
public CalzadoCAD() : base ()
{
}

public CalzadoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CalzadoEN ReadOIDDefault (int id)
{
        CalzadoEN calzadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                calzadoEN = (CalzadoEN)session.Get (typeof(CalzadoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return calzadoEN;
}


public int New_ (CalzadoEN calzado)
{
        try
        {
                SessionInitializeTransaction ();
                if (calzado.Producto != null) {
                        calzado.Producto = (AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN), calzado.Producto.Id);

                        calzado.Producto.Articulo.Add (calzado);
                }
                if (calzado.TallaCalzado != null) {
                        for (int i = 0; i < calzado.TallaCalzado.Count; i++) {
                                calzado.TallaCalzado [i] = (AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN), calzado.TallaCalzado [i].Talla);
                                calzado.TallaCalzado [i].Calzado.Add (calzado);
                        }
                }

                session.Save (calzado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return calzado.Id;
}

public void Modify (CalzadoEN calzado)
{
        try
        {
                SessionInitializeTransaction ();
                CalzadoEN calzadoEN = (CalzadoEN)session.Load (typeof(CalzadoEN), calzado.Id);

                calzadoEN.Color = calzado.Color;


                calzadoEN.Modelo = calzado.Modelo;

                session.Update (calzadoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
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
                CalzadoEN calzadoEN = (CalzadoEN)session.Load (typeof(CalzadoEN), id);
                session.Delete (calzadoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public CalzadoEN ReadOID (int id)
{
        CalzadoEN calzadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                calzadoEN = (CalzadoEN)session.Get (typeof(CalzadoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return calzadoEN;
}

public System.Collections.Generic.IList<CalzadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CalzadoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CalzadoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CalzadoEN>();
                else
                        result = session.CreateCriteria (typeof(CalzadoEN)).List<CalzadoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> GetCalzados ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CalzadoEN self where FROM CalzadoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CalzadoENgetCalzadosHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in CalzadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
