﻿using System;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;


namespace AppEstadioGen_MVP.code
{
    public interface IVistaEntradas
    {
        IList<EntradaEN> TiendaEntradas { set; }
    }
}