
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
public partial class LineaFacturaCAD : BasicCAD, ILineaFacturaCAD
{
public LineaFacturaCAD() : base ()
{
}

public LineaFacturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaFacturaEN ReadOIDDefault (int id)
{
        LineaFacturaEN lineaFacturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaFacturaEN = (LineaFacturaEN)session.Get (typeof(LineaFacturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaEN;
}


public LineaFacturaEN ReadOID (int id)
{
        LineaFacturaEN lineaFacturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaFacturaEN = (LineaFacturaEN)session.Get (typeof(LineaFacturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaEN;
}

public System.Collections.Generic.IList<LineaFacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaFacturaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaFacturaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaFacturaEN>();
                else
                        result = session.CreateCriteria (typeof(LineaFacturaEN)).List<LineaFacturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int New_ (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaFactura.Factura != null) {
                        lineaFactura.Factura = (AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN)session.Load (typeof(AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN), lineaFactura.Factura.Id);

                        lineaFactura.Factura.LineaFactura.Add (lineaFactura);
                }

                session.Save (lineaFactura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFactura.Id;
}

public void Modify (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                LineaFacturaEN lineaFacturaEN = (LineaFacturaEN)session.Load (typeof(LineaFacturaEN), lineaFactura.Id);
                session.Update (lineaFacturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
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
                LineaFacturaEN lineaFacturaEN = (LineaFacturaEN)session.Load (typeof(LineaFacturaEN), id);
                session.Delete (lineaFacturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AppEstadioGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AppEstadioGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
