
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ICalzadoCAD
{
CalzadoEN ReadOIDDefault (int id);

int New_ (CalzadoEN calzado);

void Modify (CalzadoEN calzado);


void Destroy (int id);


CalzadoEN ReadOID (int id);


System.Collections.Generic.IList<CalzadoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.CalzadoEN> GetCalzados ();
}
}
