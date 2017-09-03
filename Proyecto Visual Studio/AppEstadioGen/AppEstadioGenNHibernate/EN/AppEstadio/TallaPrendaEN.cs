
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class TallaPrendaEN
{
/**
 *
 */

private string talla;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> prenda;





public virtual string Talla {
        get { return talla; } set { talla = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> Prenda {
        get { return prenda; } set { prenda = value;  }
}





public TallaPrendaEN()
{
        prenda = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN>();
}



public TallaPrendaEN(string talla, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> prenda)
{
        this.init (talla, prenda);
}


public TallaPrendaEN(TallaPrendaEN tallaPrenda)
{
        this.init (tallaPrenda.Talla, tallaPrenda.Prenda);
}

private void init (string talla, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> prenda)
{
        this.Talla = talla;


        this.Prenda = prenda;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TallaPrendaEN t = obj as TallaPrendaEN;
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
