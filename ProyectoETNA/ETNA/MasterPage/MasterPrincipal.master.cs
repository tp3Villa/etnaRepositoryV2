using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;
namespace ETNA.MasterPage
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lblFecha.Text = DateTime.Now.ToLongDateString();

                    if ((Session[Comun.StatusLogin] != null) || (Comun.BEUsuario != null))
                    {
                        Session[Comun.StatusLogin] = "Logeado";


                        lblUsuario.Text = "Bienvenido (a) " + Comun.BEUsuario.Nombre;
                        ShowMenu();
                    }
                    else
                    {
                        Session[Comun.StatusLogin] = "NomLogeado";
                        Response.Redirect("../Seguridad/Login.aspx?OUT=SI");
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
           

        }


        private void ShowMenu()
        {

            //BLMenu _BLMenu = new BLMenu();
            //XmlDocument xxx = _BLMenu.XmlMenu(Comun.IdApplication, Comun.BEUsuario.IdUsuario, Comun.BEUsuario.IdPerfil);
            
            //_BLMenu = null;
        }   



    }
}