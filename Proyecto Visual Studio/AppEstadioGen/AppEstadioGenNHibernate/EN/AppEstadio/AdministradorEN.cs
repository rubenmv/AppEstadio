
using System;

namespace AppEstadioGenNHibernate.EN.AppEstadio
{
public partial class AdministradorEN                    :                           AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string nif, String password, string nombre, string apellidos, string email)
{
        this.init (nif, password, nombre, apellidos, email);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.Nif, administrador.Password, administrador.Nombre, administrador.Apellidos, administrador.Email);
}

private void init (string nif, String password, string nombre, string apellidos, string email)
{
        this.Nif = nif;


        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
