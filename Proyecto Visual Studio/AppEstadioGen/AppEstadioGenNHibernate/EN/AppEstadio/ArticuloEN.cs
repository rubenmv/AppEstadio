
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class ArticuloEN
{
/**
 *
 */

private int id;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}





public ArticuloEN()
{
        lineaFactura = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN>();
}



public ArticuloEN(int id, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.init (id, producto, lineaFactura);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (articulo.Id, articulo.Producto, articulo.LineaFactura);
}

private void init (int id, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.Id = id;


        this.Producto = producto;

        this.LineaFactura = lineaFactura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
