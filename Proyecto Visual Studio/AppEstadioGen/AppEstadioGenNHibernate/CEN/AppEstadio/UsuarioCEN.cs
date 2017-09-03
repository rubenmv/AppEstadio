

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
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_nif, String p_password, string p_nombre, string p_apellidos, string p_email, Nullable<DateTime> p_fechaNac, string p_direccion, string p_telefono, bool p_esAdmin)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nif = p_nif;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Email = p_email;

        usuarioEN.FechaNac = p_fechaNac;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.EsAdmin = p_esAdmin;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, String p_password, string p_nombre, string p_apellidos, string p_email, Nullable<DateTime> p_fechaNac, string p_direccion, string p_telefono, bool p_esAdmin)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nif = p_Usuario_OID;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Email = p_email;
        usuarioEN.FechaNac = p_fechaNac;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.EsAdmin = p_esAdmin;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string nif)
{
        _IUsuarioCAD.Destroy (nif);
}

public UsuarioEN ReadOID (string nif)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (nif);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AppEstadioGenNHibernate.EN.AppEstadio.UsuarioEN> GetUsuarios ()
{
        return _IUsuarioCAD.GetUsuarios ();
}
}
}
