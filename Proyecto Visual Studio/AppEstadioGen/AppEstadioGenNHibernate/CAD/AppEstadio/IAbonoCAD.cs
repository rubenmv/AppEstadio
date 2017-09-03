
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IAbonoCAD
{
AbonoEN ReadOIDDefault (int id);

int New_ (AbonoEN abono);

void Modify (AbonoEN abono);


void Destroy (int id);


AbonoEN ReadOID (int id);


System.Collections.Generic.IList<AbonoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.AbonoEN> GetAbonos ();
}
}
