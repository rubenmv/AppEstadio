using System;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;

namespace AppEstadioGen_MVP.code
{
    public interface IVistaTienda
    {
        // Lista de abonos
        IList<ProductoEN> TiendaProductos { set; }
    }
}