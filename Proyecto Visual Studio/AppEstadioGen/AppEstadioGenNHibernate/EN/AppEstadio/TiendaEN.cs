
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class TiendaEN                   :                           AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN


{
/**
 *
 */

private string color;

/**
 *
 */

private AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> talla;





public virtual string Color {
        get { return color; } set { color = value;  }
}


public virtual AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> Talla {
        get { return talla; } set { talla = value;  }
}





public TiendaEN() : base ()
{
        talla = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN>();
}



public TiendaEN(int id, string color, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> talla, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.init (id, color, tipo, talla, nombre, descripcion, foto, precio, lineaPedido, articulo, stock, categoria);
}


public TiendaEN(TiendaEN tienda)
{
        this.init (tienda.Id, tienda.Color, tienda.Tipo, tienda.Talla, tienda.Nombre, tienda.Descripcion, tienda.Foto, tienda.Precio, tienda.LineaPedido, tienda.Articulo, tienda.Stock, tienda.Categoria);
}

private void init (int id, string color, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> talla, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.Id = id;


        this.Color = color;

        this.Tipo = tipo;

        this.Talla = talla;

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
        TiendaEN t = obj as TiendaEN;
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
