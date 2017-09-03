
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class LineaPedidoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private int unidades;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto;

/**
 *
 */

private AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido;

/**
 *
 */

private float precio;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual int Unidades {
        get { return unidades; } set { unidades = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}


public virtual AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}


public virtual float Precio {
        get { return precio; } set { precio = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, int unidades, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido, float precio)
{
        this.init (id, unidades, producto, pedido, precio);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (lineaPedido.Id, lineaPedido.Unidades, lineaPedido.Producto, lineaPedido.Pedido, lineaPedido.Precio);
}

private void init (int id, int unidades, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN pedido, float precio)
{
        this.Id = id;


        this.Unidades = unidades;

        this.Producto = producto;

        this.Pedido = pedido;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
