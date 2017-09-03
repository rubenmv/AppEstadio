
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class UsuarioEN
{
/**
 *
 */

private string nif;

/**
 *
 */

private String password;

/**
 *
 */

private string nombre;

/**
 *
 */

private string apellidos;

/**
 *
 */

private string email;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido;

/**
 *
 */

private Nullable<DateTime> fechaNac;

/**
 *
 */

private string direccion;

/**
 *
 */

private string telefono;

/**
 *
 */

private bool esAdmin;





public virtual string Nif {
        get { return nif; } set { nif = value;  }
}


public virtual String Password {
        get { return password; } set { password = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}


public virtual Nullable<DateTime> FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}


public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}


public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}


public virtual bool EsAdmin {
        get { return esAdmin; } set { esAdmin = value;  }
}





public UsuarioEN()
{
        pedido = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN>();
}



public UsuarioEN(string nif, String password, string nombre, string apellidos, string email, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido, Nullable<DateTime> fechaNac, string direccion, string telefono, bool esAdmin)
{
        this.init (nif, password, nombre, apellidos, email, pedido, fechaNac, direccion, telefono, esAdmin);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Nif, usuario.Password, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.Pedido, usuario.FechaNac, usuario.Direccion, usuario.Telefono, usuario.EsAdmin);
}

private void init (string nif, String password, string nombre, string apellidos, string email, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido, Nullable<DateTime> fechaNac, string direccion, string telefono, bool esAdmin)
{
        this.Nif = nif;


        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;

        this.Pedido = pedido;

        this.FechaNac = fechaNac;

        this.Direccion = direccion;

        this.Telefono = telefono;

        this.EsAdmin = esAdmin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Nif.Equals (t.Nif))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nif.GetHashCode ();
        return hash;
}
}
}
