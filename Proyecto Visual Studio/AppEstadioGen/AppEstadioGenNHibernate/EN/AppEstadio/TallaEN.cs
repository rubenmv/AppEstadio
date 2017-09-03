
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class TallaEN
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

private AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo;

/**
 *
 */

private string medidas;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN> tienda;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}


public virtual string Medidas {
        get { return medidas; } set { medidas = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN> Tienda {
        get { return tienda; } set { tienda = value;  }
}





public TallaEN()
{
        tienda = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN>();
}



public TallaEN(int id, string nombre, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo, string medidas, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN> tienda)
{
        this.init (id, nombre, tipo, medidas, tienda);
}


public TallaEN(TallaEN talla)
{
        this.init (talla.Id, talla.Nombre, talla.Tipo, talla.Medidas, talla.Tienda);
}

private void init (int id, string nombre, AppEstadioGenNHibernate.Enumerated.AppEstadio.CategoriaTiendaEnum tipo, string medidas, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TiendaEN> tienda)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Tipo = tipo;

        this.Medidas = medidas;

        this.Tienda = tienda;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TallaEN t = obj as TallaEN;
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
