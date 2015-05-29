using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//using LCSA.SGI.WebLogisticaUtiles.Bussness; 

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.MasterPage
{
    public partial class AppMenu : System.Web.UI.MasterPage
    {
        //BTablas objTablas = new BTablas();
        DataTable dtOpcionesPrincipales = new DataTable();
        String SQL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = (string)(Session["NombreUsu"]);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
        }

        protected void MenuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect("~/WebMenuPrincipal.aspx");
        }

        protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebLogin2.aspx");
        }
    }
}
