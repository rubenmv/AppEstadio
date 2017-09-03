

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.CAD.AppEstadio;

namespace AppEstadioGenNHibernate.CEN.AppEstadio
{
public partial class CalzadoCEN
{
private ICalzadoCAD _ICalzadoCAD;

public CalzadoCEN()
{
        this._ICalzadoCAD = new CalzadoCAD ();
}

public CalzadoCEN(ICalzadoCAD _ICalzadoCAD)
{
        this._ICalzadoCAD = _ICalzadoCAD;
}

public ICalzadoCAD get_ICalzadoCAD ()
{
        return this._ICalzadoCAD;
}

public int New_ (int p_producto, System.Collections.Generic.IList<int> p_tallaCalzado, string p_color, int p_Modelo)
{
        CalzadoEN calzadoEN = null;
        int oid;

        //Initialized CalzadoEN
        calzadoEN = new CalzadoEN ();

        if (p_producto != -1) {
                calzadoEN.Producto = new AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN ();
                calzadoEN.Producto.Id = p_producto;
        }


        calzadoEN.TallaCalzado = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN>();
        if (p_tallaCalzado != null) {
                foreach (int item in p_tallaCalzado) {
                        AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN en = new AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN ();
                        en.Talla = item;
                        calzadoEN.TallaCalzado.Add (en);
                }
        }

        else{
                calzadoEN.TallaCalzado = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN>();
        }

        calzadoEN.Color = p_color;

        calzadoEN.Modelo = p_Modelo;

        //Call to CalzadoCAD

        oid = _ICalzadoCAD.New_ (calzadoEN);
        return oid;
}

public void Modify (int p_Calzado_OID, string p_color, int p_Modelo)
{
        CalzadoEN calzadoEN = null;

        //Initialized CalzadoEN
        calzadoEN = new CalzadoEN ();
        calzadoEN.Id = p_Calzado_OID;
        calzadoEN.Color = p_color;
        calzadoEN.Modelo = p_Modelo;
        //Call to CalzadoCAD

        _ICalzadoCAD.Modify (calzadoEN);
}

public void Destroy (int id)
{
        _ICalzadoCAD.Destroy (id);
}

public CalzadoEN ReadOID (int id)
{
        CalzadoEN calzadoEN = null;

        calzadoEN = _ICalzadoCAD.ReadOID (id);
        return calzadoEN;
}

public System.Collections.Generic.IList<CalzadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CalzadoEN> list = null;

        list = _ICalzadoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> GetCalzados ()
{
        return _ICalzadoCAD.GetCalzados ();
}
}
}
