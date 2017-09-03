

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
public partial class VariosCEN
{
private IVariosCAD _IVariosCAD;

public VariosCEN()
{
        this._IVariosCAD = new VariosCAD ();
}

public VariosCEN(IVariosCAD _IVariosCAD)
{
        this._IVariosCAD = _IVariosCAD;
}

public IVariosCAD get_IVariosCAD ()
{
        return this._IVariosCAD;
}

public int New_ (int p_producto, System.Collections.Generic.IList<string> p_tamano, int p_modelo)
{
        VariosEN variosEN = null;
        int oid;

        //Initialized VariosEN
        variosEN = new VariosEN ();

        if (p_producto != -1) {
                variosEN.Producto = new AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN ();
                variosEN.Producto.Id = p_producto;
        }


        variosEN.Tamano = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN>();
        if (p_tamano != null) {
                foreach (string item in p_tamano) {
                        AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN en = new AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN ();
                        en.Tam = item;
                        variosEN.Tamano.Add (en);
                }
        }

        else{
                variosEN.Tamano = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN>();
        }

        variosEN.Modelo = p_modelo;

        //Call to VariosCAD

        oid = _IVariosCAD.New_ (variosEN);
        return oid;
}

public void Modify (int p_Varios_OID, int p_modelo)
{
        VariosEN variosEN = null;

        //Initialized VariosEN
        variosEN = new VariosEN ();
        variosEN.Id = p_Varios_OID;
        variosEN.Modelo = p_modelo;
        //Call to VariosCAD

        _IVariosCAD.Modify (variosEN);
}

public void Destroy (int id)
{
        _IVariosCAD.Destroy (id);
}

public VariosEN ReadOID (int id)
{
        VariosEN variosEN = null;

        variosEN = _IVariosCAD.ReadOID (id);
        return variosEN;
}

public System.Collections.Generic.IList<VariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VariosEN> list = null;

        list = _IVariosCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> GetVarios ()
{
        return _IVariosCAD.GetVarios ();
}
}
}
