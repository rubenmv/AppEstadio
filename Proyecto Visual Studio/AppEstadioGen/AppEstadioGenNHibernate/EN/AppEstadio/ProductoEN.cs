
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class ProductoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string nombre;

/**
 *
 */

private string descripcion;

/**
 *
 */

private string foto;

/**
 *
 */

private float precio;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo;

/**
 *
 */

private int stock;

/**
 *
 */

private AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual string Foto {
        get { return foto; } set { foto = value;  }
}


public virtual float Precio {
        get { return precio; } set { precio = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}


public virtual int Stock {
        get { return stock; } set { stock = value;  }
}


public virtual AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}





public ProductoEN()
{
        lineaPedido = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN>();
        articulo = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN>();
}



public ProductoEN(int id, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.init (id, nombre, descripcion, foto, precio, lineaPedido, articulo, stock, categoria);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.Id, producto.Nombre, producto.Descripcion, producto.Foto, producto.Precio, producto.LineaPedido, producto.Articulo, producto.Stock, producto.Categoria);
}

private void init (int id, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Foto = foto;

        this.Precio = precio;

        this.LineaPedido = lineaPedido;

        this.Articulo = articulo;

        this.Stock = stock;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
