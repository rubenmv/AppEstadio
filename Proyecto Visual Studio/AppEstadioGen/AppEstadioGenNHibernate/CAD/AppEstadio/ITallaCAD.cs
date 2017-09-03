
using System;
using AppEstadioGenNHibernate.EN.AppEstadio;

namespace AppEstadioGenNHibernate.CAD.AppEstadio
{
public partial interface ITallaCAD
{
TallaEN ReadOIDDefault (int id);

int New_ (TallaEN talla);

void Modify (TallaEN talla);


void Destroy (int id);


TallaEN ReadOID (int id);


System.Collections.Generic.IList<TallaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.TallaEN> GetTallasPorTipo (int p_tipo);
}
}
