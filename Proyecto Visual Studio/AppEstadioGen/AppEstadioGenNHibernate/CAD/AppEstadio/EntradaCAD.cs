
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
public partial class EntradaCAD : BasicCAD, IEntradaCAD
{
public EntradaCAD() : base ()
{
}

public EntradaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EntradaEN ReadOIDDefault (int id)
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entradaEN;
}


public int New_ (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (entrada);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entrada.Id;
}

public void Modify (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), entrada.Id);

                entradaEN.Nombre = entrada.Nombre;


                entradaEN.Descripcion = entrada.Descripcion;


                entradaEN.Foto = entrada.Foto;


                entradaEN.Precio = entrada.Precio;


                entradaEN.Stock = entrada.Stock;


                entradaEN.Categoria = entrada.Categoria;


                entradaEN.FechaHora = entrada.FechaHora;


                entradaEN.Tipo = entrada.Tipo;


                entradaEN.Temporada = entrada.Temporada;


                entradaEN.Grada = entrada.Grada;

                session.Update (entradaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
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
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), id);
                session.Delete (entradaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public EntradaEN ReadOID (int id)
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EntradaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EntradaEN>();
                else
                        result = session.CreateCriteria (typeof(EntradaEN)).List<EntradaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.EntradaEN> GetEntradas ()
{
        System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENgetEntradasHQL");

                result = query.List<AppEstadioGenNHibernate.EN.AppEstadio.EntradaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
