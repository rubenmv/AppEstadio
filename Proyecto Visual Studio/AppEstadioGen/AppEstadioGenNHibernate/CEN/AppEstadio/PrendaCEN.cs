

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
public partial class PrendaCEN
{
private IPrendaCAD _IPrendaCAD;

public PrendaCEN()
{
        this._IPrendaCAD = new PrendaCAD ();
}

public PrendaCEN(IPrendaCAD _IPrendaCAD)
{
        this._IPrendaCAD = _IPrendaCAD;
}

public IPrendaCAD get_IPrendaCAD ()
{
        return this._IPrendaCAD;
}

public int New_ (int p_producto, string p_sexo, System.Collections.Generic.IList<string> p_talla, int p_modelo, string p_color)
{
        PrendaEN prendaEN = null;
        int oid;

        //Initialized PrendaEN
        prendaEN = new PrendaEN ();

        if (p_producto != -1) {
                prendaEN.Producto = new AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN ();
                prendaEN.Producto.Id = p_producto;
        }

        prendaEN.Sexo = p_sexo;


        prendaEN.Talla = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN>();
        if (p_talla != null) {
                foreach (string item in p_talla) {
                        AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN en = new AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN ();
                        en.Talla = item;
                        prendaEN.Talla.Add (en);
                }
        }

        else{
                prendaEN.Talla = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN>();
        }

        prendaEN.Modelo = p_modelo;

        prendaEN.Color = p_color;

        //Call to PrendaCAD

        oid = _IPrendaCAD.New_ (prendaEN);
        return oid;
}

public void Modify (int p_Prenda_OID, string p_sexo, int p_modelo, string p_color)
{
        PrendaEN prendaEN = null;

        //Initialized PrendaEN
        prendaEN = new PrendaEN ();
        prendaEN.Id = p_Prenda_OID;
        prendaEN.Sexo = p_sexo;
        prendaEN.Modelo = p_modelo;
        prendaEN.Color = p_color;
        //Call to PrendaCAD

        _IPrendaCAD.Modify (prendaEN);
}

public void Destroy (int id)
{
        _IPrendaCAD.Destroy (id);
}

public PrendaEN ReadOID (int id)
{
        PrendaEN prendaEN = null;

        prendaEN = _IPrendaCAD.ReadOID (id);
        return prendaEN;
}

public System.Collections.Generic.IList<PrendaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PrendaEN> list = null;

        list = _IPrendaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> GetPrendas ()
{
        return _IPrendaCAD.GetPrendas ();
}
}
}
