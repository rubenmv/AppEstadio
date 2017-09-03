
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string nif);

string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string nif);


UsuarioEN ReadOID (string nif);


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);



System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN> GetUsuarios ();
}
}
