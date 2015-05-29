using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ETNA.SGI.Bussiness.Exportacion;

namespace ETNA.SGI.WebSite.PaginasWeb
{
    public partial class RequerimientoCliente : System.Web.UI.Page
    {
        BTablas objBus = new BTablas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = objBus.getSELECTLIBRE("select * from Requerimiento");
                GridView1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}