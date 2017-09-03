
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IArticuloCAD
{
ArticuloEN ReadOIDDefault (int id);

int New_ (ArticuloEN articulo);

void Modify (ArticuloEN articulo);


void Destroy (int id);


ArticuloEN ReadOID (int id);


System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.ArticuloEN> GetArticulos ();
}
}
