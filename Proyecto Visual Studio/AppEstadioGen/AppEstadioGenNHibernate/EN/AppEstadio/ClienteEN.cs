
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class ClienteEN                  :                           AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN


{
/**
 *
 */

private string numCuenta;

/**
 *
 */

private Nullable<DateTime> fechaNac;

/**
 *
 */

private System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido;

/**
 *
 */

private string foto;

/**
 *
 */

private string telefono;





public virtual string NumCuenta {
        get { return numCuenta; } set { numCuenta = value;  }
}


public virtual Nullable<DateTime> FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}


public virtual System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}


public virtual string Foto {
        get { return foto; } set { foto = value;  }
}


public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}





public ClienteEN() : base ()
{
        pedido = new System.Collections.Generic.List<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN>();
}



public ClienteEN(string nif, string numCuenta, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido, string foto, string telefono, String password, string nombre, string apellidos, string email)
{
        this.init (nif, numCuenta, fechaNac, pedido, foto, telefono, password, nombre, apellidos, email);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (cliente.Nif, cliente.NumCuenta, cliente.FechaNac, cliente.Pedido, cliente.Foto, cliente.Telefono, cliente.Password, cliente.Nombre, cliente.Apellidos, cliente.Email);
}

private void init (string nif, string numCuenta, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PedidoEN> pedido, string foto, string telefono, String password, string nombre, string apellidos, string email)
{
        this.Nif = nif;


        this.NumCuenta = numCuenta;

        this.FechaNac = fechaNac;

        this.Pedido = pedido;

        this.Foto = foto;

        this.Telefono = telefono;

        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
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
