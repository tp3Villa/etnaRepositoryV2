using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETNA.SGI.WebSite.MasterPage
{
    public partial class MasterPage2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUsuario.Text = Session["usuario"].ToString();
            //lblFechaHora.Text = DateTime.Today.ToLongDateString();    
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebLogin.aspx");
            Session.Abandon();
        }

    }
}