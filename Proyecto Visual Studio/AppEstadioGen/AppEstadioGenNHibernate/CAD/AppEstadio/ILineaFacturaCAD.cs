
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ILineaFacturaCAD
{
LineaFacturaEN ReadOIDDefault (int id);

LineaFacturaEN ReadOID (int id);


System.Collections.Generic.IList<LineaFacturaEN> ReadAll (int first, int size);


int New_ (LineaFacturaEN lineaFactura);

void Modify (LineaFacturaEN lineaFactura);


void Destroy (int id);
}
}
