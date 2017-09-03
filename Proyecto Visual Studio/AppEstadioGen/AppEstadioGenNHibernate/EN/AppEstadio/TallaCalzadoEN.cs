
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class TallaCalzadoEN
{
/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> calzado;

/**
 *
 */

private int talla;





public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> Calzado {
        get { return calzado; } set { calzado = value;  }
}


public virtual int Talla {
        get { return talla; } set { talla = value;  }
}





public TallaCalzadoEN()
{
        calzado = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN>();
}



public TallaCalzadoEN(int talla, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> calzado)
{
        this.init (talla, calzado);
}


public TallaCalzadoEN(TallaCalzadoEN tallaCalzado)
{
        this.init (tallaCalzado.Talla, tallaCalzado.Calzado);
}

private void init (int talla, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> calzado)
{
        this.Talla = talla;


        this.Calzado = calzado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TallaCalzadoEN t = obj as TallaCalzadoEN;
        if (t == null)
                return false;
        if (Talla.Equals (t.Talla))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Talla.GetHashCode ();
        return hash;
}
}
}
