using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETNA.SGI.Entity.Exportacion;
using ETNA.SGI.Bussiness.Exportacion;

namespace ETNA.SGI.WebSite
{
    public partial class WebLogin2aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        ELogin ObjEnt = new ELogin();
        BLogin ObjBus = new BLogin();

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Login1.UserName != "")
            {
                lblMensaje.Visible = false;

                ObjEnt.Usuario = Login1.UserName.ToUpper().Trim();
                ObjEnt.Pasw = Login1.Password.ToUpper().Trim();

                int nroUsuario = 0;
                try
                {
                    nroUsuario = ObjBus.BLogueo(ObjEnt).Rows.Count;
                }
                catch (Exception ex)
                {
                    global::System.Windows.Forms.MessageBox.Show(ex.Message);
                }


                if (nroUsuario > 0)
                {
                    Session["Usuario"] = ObjBus.BLogueo(ObjEnt).Rows[0]["Codigo"].ToString();
                    Session["NombreUsu"] = ObjBus.BLogueo(ObjEnt).Rows[0]["Razon_Social"].ToString();
                    Response.Redirect("~/PaginasWeb/webMenuPrincipal.aspx");
                    //Response.Redirect("~/WebMenuPrincipal.aspx");
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Usuario no tiene Acceso";
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ingrese Usuario y Contraseña";
            }
        }
    }
}