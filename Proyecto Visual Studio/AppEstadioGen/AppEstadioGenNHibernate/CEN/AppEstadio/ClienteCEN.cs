

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using AppEstadioGenNHibernate.EN.AppEstadio;
using AppEstadioGenNHibernate.CAD.AppEstadio;

namespace AppEstadioGenNHibernate.CEN.AppEstadio
{
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public string New_ (string p_nif, String p_password, string p_nombre, string p_apellidos, string p_email, string p_numCuenta, Nullable<DateTime> p_fechaNac, string p_foto, string p_telefono)
{
        ClienteEN clienteEN = null;
        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Nif = p_nif;

        clienteEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        clienteEN.Nombre = p_nombre;

        clienteEN.Apellidos = p_apellidos;

        clienteEN.Email = p_email;

        clienteEN.NumCuenta = p_numCuenta;

        clienteEN.FechaNac = p_fechaNac;

        clienteEN.Foto = p_foto;

        clienteEN.Telefono = p_telefono;

        //Call to ClienteCAD

        oid = _IClienteCAD.New_ (clienteEN);
        return oid;
}

public void Modify (string p_Cliente_OID, String p_password, string p_nombre, string p_apellidos, string p_email, string p_numCuenta, Nullable<DateTime> p_fechaNac, string p_foto, string p_telefono)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Nif = p_Cliente_OID;
        clienteEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        clienteEN.Nombre = p_nombre;
        clienteEN.Apellidos = p_apellidos;
        clienteEN.Email = p_email;
        clienteEN.NumCuenta = p_numCuenta;
        clienteEN.FechaNac = p_fechaNac;
        clienteEN.Foto = p_foto;
        clienteEN.Telefono = p_telefono;
        //Call to ClienteCAD

        _IClienteCAD.Modify (clienteEN);
}

public void Destroy (string nif)
{
        _IClienteCAD.Destroy (nif);
}

public ClienteEN ReadOID (string nif)
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.ReadOID (nif);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.ReadAll (first, size);
        return list;
}
}
}
