
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class AbonoEN                    :                           AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN


{
/**
 *
 */

private string tipo;

/**
 *
 */

private int temporada;

/**
 *
 */

private string grada;





public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}


public virtual int Temporada {
        get { return temporada; } set { temporada = value;  }
}


public virtual string Grada {
        get { return grada; } set { grada = value;  }
}





public AbonoEN() : base ()
{
}



public AbonoEN(int id, string tipo, int temporada, string grada, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.init (id, tipo, temporada, grada, nombre, descripcion, foto, precio, lineaPedido, articulo, stock, categoria);
}


public AbonoEN(AbonoEN abono)
{
        this.init (abono.Id, abono.Tipo, abono.Temporada, abono.Grada, abono.Nombre, abono.Descripcion, abono.Foto, abono.Precio, abono.LineaPedido, abono.Articulo, abono.Stock, abono.Categoria);
}

private void init (int id, string tipo, int temporada, string grada, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Temporada = temporada;

        this.Grada = grada;

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
        AbonoEN t = obj as AbonoEN;
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
