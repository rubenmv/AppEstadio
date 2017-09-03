
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (string nif);

string New_ (ClienteEN cliente);

void Modify (ClienteEN cliente);


void Destroy (string nif);


ClienteEN ReadOID (string nif);


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);
}
}
