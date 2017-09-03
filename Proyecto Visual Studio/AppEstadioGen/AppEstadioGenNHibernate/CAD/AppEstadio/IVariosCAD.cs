
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface IVariosCAD
{
VariosEN ReadOIDDefault (int id);

int New_ (VariosEN varios);

void Modify (VariosEN varios);


void Destroy (int id);


VariosEN ReadOID (int id);


System.Collections.Generic.IList<VariosEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.VariosEN> GetVarios ();
}
}
