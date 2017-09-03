
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
public partial class TiendaCAD : BasicCAD, ITiendaCAD
{
public TiendaCAD() : base ()
{
}

public TiendaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TiendaEN ReadOIDDefault (int id)
{
        TiendaEN tiendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tiendaEN = (TiendaEN)session.Get (typeof(TiendaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tiendaEN;
}


public int New_ (TiendaEN tienda)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tienda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tienda.Id;
}

public void Modify (TiendaEN tienda)
{
        try
        {
                SessionInitializeTransaction ();
                TiendaEN tiendaEN = (TiendaEN)session.Load (typeof(TiendaEN), tienda.Id);

                tiendaEN.Nombre = tienda.Nombre;


                tiendaEN.Descripcion = tienda.Descripcion;


                tiendaEN.Foto = tienda.Foto;


                tiendaEN.Precio = tienda.Precio;


                tiendaEN.Stock = tienda.Stock;


                tiendaEN.Categoria = tienda.Categoria;


                tiendaEN.Color = tienda.Color;


                tiendaEN.Tipo = tienda.Tipo;

                session.Update (tiendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
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
                TiendaEN tiendaEN = (TiendaEN)session.Load (typeof(TiendaEN), id);
                session.Delete (tiendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public TiendaEN ReadOID (int id)
{
        TiendaEN tiendaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tiendaEN = (TiendaEN)session.Get (typeof(TiendaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tiendaEN;
}

public System.Collections.Generic.IList<TiendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TiendaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TiendaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TiendaEN>();
                else
                        result = session.CreateCriteria (typeof(TiendaEN)).List<TiendaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AgregaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs)
{
        AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN tiendaEN = null;
        try
        {
                SessionInitializeTransaction ();
                tiendaEN = (TiendaEN)session.Load (typeof(TiendaEN), p_Tienda_OID);
                AppEstadioGenNHibernate.EN.AppEstadio.TallaEN tallaENAux = null;
                if (tiendaEN.Talla == null) {
                        tiendaEN.Talla = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN>();
                }

                foreach (int item in p_talla_OIDs) {
                        tallaENAux = new AppEstadioGenNHibernate.EN.AppEstadio.TallaEN ();
                        tallaENAux = (AppEstadioGenNHibernate.EN.AppEstadio.TallaEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.TallaEN), item);
                        tallaENAux.Tienda.Add (tiendaEN);

                        tiendaEN.Talla.Add (tallaENAux);
                }


                session.Update (tiendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN tiendaEN = null;
                tiendaEN = (TiendaEN)session.Load (typeof(TiendaEN), p_Tienda_OID);

                AppEstadioGenNHibernate.EN.AppEstadio.TallaEN tallaENAux = null;
                if (tiendaEN.Talla != null) {
                        foreach (int item in p_talla_OIDs) {
                                tallaENAux = (AppEstadioGenNHibernate.EN.AppEstadio.TallaEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.TallaEN), item);
                                if (tiendaEN.Talla.Contains (tallaENAux) == true) {
                                        tiendaEN.Talla.Remove (tallaENAux);
                                        tallaENAux.Tienda.Remove (tiendaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_talla_OIDs you are trying to unrelationer, doesn't exist in TiendaEN");
                        }
                }

                session.Update (tiendaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in TiendaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
