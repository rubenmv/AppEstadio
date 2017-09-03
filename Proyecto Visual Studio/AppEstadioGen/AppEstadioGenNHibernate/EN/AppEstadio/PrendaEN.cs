
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class PrendaEN                   :                           AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN


{
/**
 *
 */

private string sexo;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> talla;

/**
 *
 */

private int modelo;

/**
 *
 */

private string color;





public virtual string Sexo {
        get { return sexo; } set { sexo = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> Talla {
        get { return talla; } set { talla = value;  }
}


public virtual int Modelo {
        get { return modelo; } set { modelo = value;  }
}


public virtual string Color {
        get { return color; } set { color = value;  }
}





public PrendaEN() : base ()
{
        talla = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN>();
}



public PrendaEN(int id, string sexo, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> talla, int modelo, string color, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.init (id, sexo, talla, modelo, color, producto, lineaFactura);
}


public PrendaEN(PrendaEN prenda)
{
        this.init (prenda.Id, prenda.Sexo, prenda.Talla, prenda.Modelo, prenda.Color, prenda.Producto, prenda.LineaFactura);
}

private void init (int id, string sexo, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> talla, int modelo, string color, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.Id = id;


        this.Sexo = sexo;

        this.Talla = talla;

        this.Modelo = modelo;

        this.Color = color;

        this.Producto = producto;

        this.LineaFactura = lineaFactura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PrendaEN t = obj as PrendaEN;
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
