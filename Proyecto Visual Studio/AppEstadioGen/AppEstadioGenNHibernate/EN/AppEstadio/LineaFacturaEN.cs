
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class LineaFacturaEN
{
/**
 *
 */

private int id;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN articulo;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}





public LineaFacturaEN()
{
}



public LineaFacturaEN(int id, AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura, AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN articulo)
{
        this.init (id, factura, articulo);
}


public LineaFacturaEN(LineaFacturaEN lineaFactura)
{
        this.init (lineaFactura.Id, lineaFactura.Factura, lineaFactura.Articulo);
}

private void init (int id, AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura, AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN articulo)
{
        this.Id = id;


        this.Factura = factura;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaFacturaEN t = obj as LineaFacturaEN;
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
