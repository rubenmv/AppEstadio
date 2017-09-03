
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ITallaCalzadoCAD
{
TallaCalzadoEN ReadOIDDefault (int talla);

int New_ (TallaCalzadoEN tallaCalzado);

void Modify (TallaCalzadoEN tallaCalzado);


void Destroy (int talla);


TallaCalzadoEN ReadOID (int talla);


System.Collections.Generic.IList<TallaCalzadoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaCalzadoEN> GetTallasCalzado ();
}
}
