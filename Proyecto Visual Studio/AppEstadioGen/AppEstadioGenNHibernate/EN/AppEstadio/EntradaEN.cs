
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class EntradaEN                  :                           AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN


{
/**
 *
 */

private Nullable<DateTime> fechaHora;

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





public virtual Nullable<DateTime> FechaHora {
        get { return fechaHora; } set { fechaHora = value;  }
}


public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}


public virtual int Temporada {
        get { return temporada; } set { temporada = value;  }
}


public virtual string Grada {
        get { return grada; } set { grada = value;  }
}





public EntradaEN() : base ()
{
}



public EntradaEN(int id, Nullable<DateTime> fechaHora, string tipo, int temporada, string grada, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.init (id, fechaHora, tipo, temporada, grada, nombre, descripcion, foto, precio, lineaPedido, articulo, stock, categoria);
}


public EntradaEN(EntradaEN entrada)
{
        this.init (entrada.Id, entrada.FechaHora, entrada.Tipo, entrada.Temporada, entrada.Grada, entrada.Nombre, entrada.Descripcion, entrada.Foto, entrada.Precio, entrada.LineaPedido, entrada.Articulo, entrada.Stock, entrada.Categoria);
}

private void init (int id, Nullable<DateTime> fechaHora, string tipo, int temporada, string grada, string nombre, string descripcion, string foto, float precio, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> articulo, int stock, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaEnum categoria)
{
        this.Id = id;


        this.FechaHora = fechaHora;

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
        EntradaEN t = obj as EntradaEN;
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
