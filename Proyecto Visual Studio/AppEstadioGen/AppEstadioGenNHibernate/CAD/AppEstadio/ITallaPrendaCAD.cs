
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ITallaPrendaCAD
{
TallaPrendaEN ReadOIDDefault (string talla);

string New_ (TallaPrendaEN tallaPrenda);

void Modify (TallaPrendaEN tallaPrenda);


void Destroy (string talla);


TallaPrendaEN ReadOID (string talla);


System.Collections.Generic.IList<TallaPrendaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaPrendaEN> GetTallasPrenda ();
}
}
