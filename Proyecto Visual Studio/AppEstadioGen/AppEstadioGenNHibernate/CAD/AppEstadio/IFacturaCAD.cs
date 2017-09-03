
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IFacturaCAD
{
FacturaEN ReadOIDDefault (int id);

int New_ (FacturaEN factura);

void Modify (FacturaEN factura);


void Destroy (int id);


FacturaEN ReadOID (int id);


System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size);
}
}
