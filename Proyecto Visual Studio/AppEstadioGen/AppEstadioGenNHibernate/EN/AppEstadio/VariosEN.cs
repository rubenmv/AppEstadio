
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class VariosEN                   :                           AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN


{
/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> tamano;

/**
 *
 */

private int modelo;





public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> Tamano {
        get { return tamano; } set { tamano = value;  }
}


public virtual int Modelo {
        get { return modelo; } set { modelo = value;  }
}





public VariosEN() : base ()
{
        tamano = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN>();
}



public VariosEN(int id, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> tamano, int modelo, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.init (id, tamano, modelo, producto, lineaFactura);
}


public VariosEN(VariosEN varios)
{
        this.init (varios.Id, varios.Tamano, varios.Modelo, varios.Producto, varios.LineaFactura);
}

private void init (int id, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> tamano, int modelo, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.Id = id;


        this.Tamano = tamano;

        this.Modelo = modelo;

        this.Producto = producto;

        this.LineaFactura = lineaFactura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VariosEN t = obj as VariosEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
