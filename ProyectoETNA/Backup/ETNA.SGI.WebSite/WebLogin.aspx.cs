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
using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Entity.Exportacion;




namespace ETNA.SGI.WebSite
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        ELogin ObjEnt = new ELogin();
        BLogin ObjBus = new BLogin();

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
        {
            ObjEnt.Usuario = txtusu.Text.ToUpper();
            ObjEnt.Pasw = txtpas.Text.ToUpper();
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
                try
                {
                    string cod = ObjBus.BLogueo(ObjEnt).Rows[0][2].ToString();
                    Session["usuario"] = cod;
                }
                catch (Exception ex)
                {
                    global::System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                Response.Redirect("~/PaginasWeb/Bienvenida.aspx");
            }
            else
            {
                String sw = "0";
                if ((txtusu.Text == "") && (sw == "0"))
                {
                    global::System.Windows.Forms.MessageBox.Show("Por favor Ingrese Usuario...!");
                    sw = "1";
                }
                if ((txtpas.Text == "") && (sw == "0"))
                {
                    global::System.Windows.Forms.MessageBox.Show("Por favor Ingrese su Password...!");
                    sw = "1";
                }
                else
                {
                    global::System.Windows.Forms.MessageBox.Show("Usuario no existe...!");
                    sw = "1";
                    txtusu.Text = "";
                    txtpas.Text = "";
                    txtusu.Focus();
                }
            }
        }
    }
}