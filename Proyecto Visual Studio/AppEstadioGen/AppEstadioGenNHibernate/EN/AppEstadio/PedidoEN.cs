
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class PedidoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private Nullable<DateTime> fecha;

/**
 *
 */

private AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN cliente;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura;

/**
 *
 */

private float precio;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


public virtual AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN Cliente {
        get { return cliente; } set { cliente = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}


public virtual float Precio {
        get { return precio; } set { precio = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN>();
}



public PedidoEN(int id, Nullable<DateTime> fecha, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN cliente, AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura, float precio)
{
        this.init (id, fecha, estado, lineaPedido, cliente, factura, precio);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.Id, pedido.Fecha, pedido.Estado, pedido.LineaPedido, pedido.Cliente, pedido.Factura, pedido.Precio);
}

private void init (int id, Nullable<DateTime> fecha, AppEstadioGenNHibernate.Enumerated.AppEstadio.EstadoPedidoEnum estado, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN cliente, AppEstadioGenNHibernate.EN.AppEstadio.FacturaEN factura, float precio)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Estado = estado;

        this.LineaPedido = lineaPedido;

        this.Cliente = cliente;

        this.Factura = factura;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
