using System;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;


namespace AppEstadioGen_MVP.code
{
    public interface IVistaUsuario
    {
		UsuarioEN Usuario { get; set; }
    }
}