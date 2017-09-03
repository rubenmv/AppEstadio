
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IPrendaCAD
{
PrendaEN ReadOIDDefault (int id);

int New_ (PrendaEN prenda);

void Modify (PrendaEN prenda);


void Destroy (int id);


PrendaEN ReadOID (int id);


System.Collections.Generic.IList<PrendaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.PrendaEN> GetPrendas ();
}
}
