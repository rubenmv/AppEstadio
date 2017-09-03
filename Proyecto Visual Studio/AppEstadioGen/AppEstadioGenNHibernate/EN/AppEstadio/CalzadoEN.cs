
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class CalzadoEN                  :                           AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN


{
/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> tallaCalzado;

/**
 *
 */

private string color;

/**
 *
 */

private int modelo;





public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> TallaCalzado {
        get { return tallaCalzado; } set { tallaCalzado = value;  }
}


public virtual string Color {
        get { return color; } set { color = value;  }
}


public virtual int Modelo {
        get { return modelo; } set { modelo = value;  }
}





public CalzadoEN() : base ()
{
        tallaCalzado = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN>();
}



public CalzadoEN(int id, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> tallaCalzado, string color, int modelo, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.init (id, tallaCalzado, color, modelo, producto, lineaFactura);
}


public CalzadoEN(CalzadoEN calzado)
{
        this.init (calzado.Id, calzado.TallaCalzado, calzado.Color, calzado.Modelo, calzado.Producto, calzado.LineaFactura);
}

private void init (int id, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> tallaCalzado, string color, int modelo, AppEstadioGenNHibernate.EN.AppEstadio.ProductoEN producto, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.LineaFacturaEN> lineaFactura)
{
        this.Id = id;


        this.TallaCalzado = tallaCalzado;

        this.Color = color;

        this.Modelo = modelo;

        this.Producto = producto;

        this.LineaFactura = lineaFactura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CalzadoEN t = obj as CalzadoEN;
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
