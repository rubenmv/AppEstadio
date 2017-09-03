
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IEntradaCAD
{
EntradaEN ReadOIDDefault (int id);

int New_ (EntradaEN entrada);

void Modify (EntradaEN entrada);


void Destroy (int id);


EntradaEN ReadOID (int id);


System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.EntradaEN> GetEntradas ();
}
}
