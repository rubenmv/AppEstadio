using System;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;

namespace AppEstadioGen_MVP.code
{
    public interface IVistaDetalleProducto
    {
        // Producto a mostrar
        ProductoEN Producto { get; set; }
    }
}