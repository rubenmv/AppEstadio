using System;
using System.Data;

namespace AppEstadioGen_MVP.code
{
	public class PresenterCabecera
    {
        private IVistaCabecera vista;
		private SessionManager sessionManager = null;

		public PresenterCabecera(IVistaCabecera vista)
        {
            this.vista = vista;
			sessionManager = SessionManager.Instance;
        }
    }
}