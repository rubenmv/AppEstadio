
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string nif);

string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string nif);


AdministradorEN ReadOID (string nif);


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
