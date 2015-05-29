using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ETNA.MasterPage
{
    public partial class Seguridad : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Solucion al problema "Pagina Caducada" al pulsar el boton "atras" del navegador
                //Response.CacheControl = "Private";                    

                if ((Session[Comun.StatusLogin] != null) || (Comun.BEUsuario != null))
                {
                    Session[Comun.StatusLogin] = "Logeado";
                    this.lblNombreUsuario.Text = string.Format("Bienvenido (a) {0}, {1}",
                                                               Comun.BEUsuario.Nombre, Comun.ddMMyyyy);
                    
                }
                else
                {
                    Session[Comun.StatusLogin] = "NomLogeado";
                    Response.Redirect("../Seguridad/Login.aspx?OUT=SI");
                }
            }
        }

    }
}
