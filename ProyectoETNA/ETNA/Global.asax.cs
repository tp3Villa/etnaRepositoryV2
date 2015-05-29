using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ETNA
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Comun.LastError = Server.GetLastError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                Session[Comun.StatusLogin] = null;
                FormsAuthentication.SignOut(); 
            }
        }

    }
}