
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
public bool Login (string p_oid, string password)
{
        /*PROTECTED REGION ID(AppEstadioGenNHibernate.CEN.AppEstadio_Usuario_login) ENABLED START*/

        bool result = false;

        try
        {
                UsuarioEN usuario = _IUsuarioCAD.ReadOID (p_oid);

                if (usuario.Password.Equals (Utils.Util.GetEncondeMD5 (password)))
                        result = true;
        }

        catch (Exception ex)
        {
                result = false;
        }
        return result;

        /*PROTECTED REGION END*/
}
}
}
