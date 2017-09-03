
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class FacturaEN
{
/**
 *
 */

private int id;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido;

/**
 *
 */

private float precioTotal;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura;

/**
 *
 */

private Nullable<DateTime> fecha;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}


public virtual float PrecioTotal {
        get { return precioTotal; } set { precioTotal = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}


public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public FacturaEN()
{
        lineaFactura = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN>();
}



public FacturaEN(int id, AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido, float precioTotal, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura, Nullable<DateTime> fecha)
{
        this.init (id, pedido, precioTotal, lineaFactura, fecha);
}


public FacturaEN(FacturaEN factura)
{
        this.init (factura.Id, factura.Pedido, factura.PrecioTotal, factura.LineaFactura, factura.Fecha);
}

private void init (int id, AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido, float precioTotal, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Pedido = pedido;

        this.PrecioTotal = precioTotal;

        this.LineaFactura = lineaFactura;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
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
