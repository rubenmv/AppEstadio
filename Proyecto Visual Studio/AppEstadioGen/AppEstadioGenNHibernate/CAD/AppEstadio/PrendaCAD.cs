
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
public partial class PrendaCAD : BasicCAD, IPrendaCAD
{
public PrendaCAD() : base ()
{
}

public PrendaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PrendaEN ReadOIDDefault (int id)
{
        PrendaEN prendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                prendaEN = (PrendaEN)session.Get (typeof(PrendaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return prendaEN;
}


public int New_ (PrendaEN prenda)
{
        try
        {
                SessionInitializeTransaction ();
                if (prenda.Producto != null) {
                        prenda.Producto = (AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN), prenda.Producto.Id);

                        prenda.Producto.Articulo.Add (prenda);
                }
                if (prenda.Talla != null) {
                        for (int i = 0; i < prenda.Talla.Count; i++) {
                                prenda.Talla [i] = (AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN), prenda.Talla [i].Talla);
                                prenda.Talla [i].Prenda.Add (prenda);
                        }
                }

                session.Save (prenda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return prenda.Id;
}

public void Modify (PrendaEN prenda)
{
        try
        {
                SessionInitializeTransaction ();
                PrendaEN prendaEN = (PrendaEN)session.Load (typeof(PrendaEN), prenda.Id);

                prendaEN.Sexo = prenda.Sexo;


                prendaEN.Modelo = prenda.Modelo;


                prendaEN.Color = prenda.Color;

                session.Update (prendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
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
                PrendaEN prendaEN = (PrendaEN)session.Load (typeof(PrendaEN), id);
                session.Delete (prendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public PrendaEN ReadOID (int id)
{
        PrendaEN prendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                prendaEN = (PrendaEN)session.Get (typeof(PrendaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return prendaEN;
}

public System.Collections.Generic.IList<PrendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PrendaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PrendaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PrendaEN>();
                else
                        result = session.CreateCriteria (typeof(PrendaEN)).List<PrendaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> GetPrendas ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PrendaEN self where FROM PrendaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PrendaENgetPrendasHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in PrendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
