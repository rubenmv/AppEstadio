using System;
using System.Data;
using AppEstadioGenNHibernate.EN.AppEstadio;
using System.Collections.Generic;


namespace AppEstadioGen_MVP.code
{
    public interface IVistaCarroCompra
    {
		IList<ShoppingCartItem> ItemsCarro { set; get; }
    }
}