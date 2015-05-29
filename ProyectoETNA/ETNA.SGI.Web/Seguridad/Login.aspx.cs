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
using ETNA.BusinessEntity.Seguridad;

namespace ETNA.Seguridad
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session[Comun.StatusLogin] = "NomLogeado";
            if (!Page.IsPostBack)
            {
                string _Out = Comun.QueryString("OUT");
                if (_Out != null)
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("../Default.aspx");
                }
            }

            this.lblError.Text = "";
        }

        protected void ibtnIngresar_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {
                    
                    BEUsuario _BEUsuario = new BEUsuario();

                    _BEUsuario.IdUsuario = txtIdUsuario.Text;
                    _BEUsuario.Nombre = "Administrador";
                    _BEUsuario.Correo = "admin@etna.com.pe";

                    Session["BEUsuario"] = _BEUsuario;
                    Session[Comun.StatusLogin] = "Logeado";

                    
                    FormsAuthentication.RedirectFromLoginPage(this.txtIdUsuario.Text, false);

                    //if (_WSSeguridad.AutenticaUsuario(this.txtIdUsuario.Text, this.txtClave.Text, Comun.IdApplication, out _Mensaje))
                    //{
                    //    BLUsuario _BLUsuario = new BLUsuario();

                    //    Session["BEUsuario"] = _BLUsuario.GetDatos(this.txtIdUsuario.Text, Comun.IdApplication);
                    //    Session[Comun.StatusLogin] = "Logeado";

                    //    _BLUsuario = null;

                    //    FormsAuthentication.RedirectFromLoginPage(this.txtIdUsuario.Text, false);
                    //}
                    //else
                    //{
                    //    this.lblError.Text = _Mensaje;
                    //}
                }
                catch (Exception ex)
                {
                    this.lblError.Text = ex.Message;
                }

            }
        }

    }
}
