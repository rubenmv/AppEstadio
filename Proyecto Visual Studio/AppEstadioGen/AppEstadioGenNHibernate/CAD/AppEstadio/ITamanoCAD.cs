
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ITamanoCAD
{
TamanoEN ReadOIDDefault (string tam);

string New_ (TamanoEN tamano);

void Modify (TamanoEN tamano);


void Destroy (string tam);


TamanoEN ReadOID (string tam);


System.Collections.Generic.IList<TamanoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TamanoEN> GetTamanos ();
}
}
