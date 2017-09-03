
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class TamanoEN
{
/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> varios;

/**
 *
 */

private string tam;





public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> Varios {
        get { return varios; } set { varios = value;  }
}


public virtual string Tam {
        get { return tam; } set { tam = value;  }
}





public TamanoEN()
{
        varios = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN>();
}



public TamanoEN(string tam, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> varios)
{
        this.init (tam, varios);
}


public TamanoEN(TamanoEN tamano)
{
        this.init (tamano.Tam, tamano.Varios);
}

private void init (string tam, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> varios)
{
        this.Tam = tam;


        this.Varios = varios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TamanoEN t = obj as TamanoEN;
        if (t == null)
                return false;
        if (Tam.Equals (t.Tam))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Tam.GetHashCode ();
        return hash;
}
}
}
