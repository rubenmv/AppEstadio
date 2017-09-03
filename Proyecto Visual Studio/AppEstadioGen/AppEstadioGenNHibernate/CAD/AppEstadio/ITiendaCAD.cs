
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ITiendaCAD
{
TiendaEN ReadOIDDefault (int id);

int New_ (TiendaEN tienda);

void Modify (TiendaEN tienda);


void Destroy (int id);


TiendaEN ReadOID (int id);


System.Collections.Generic.IList<TiendaEN> ReadAll (int first, int size);


void AgregaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs);

void QuitaTalla (int p_Tienda_OID, System.Collections.Generic.IList<int> p_talla_OIDs);
}
}
