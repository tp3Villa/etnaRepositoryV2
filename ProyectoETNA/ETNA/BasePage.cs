using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ETNA
{
    public class BasePage : System.Web.UI.Page
    {
        public string Columna
        {
            get
            {
                if (ViewState["Columna"] == null) { ViewState["Columna"] = String.Empty; }
                return (string)ViewState["Columna"];
            }
            set { ViewState["Columna"] = value; }
        }

        public SortDirection Orden
        {
            get
            {
                if (ViewState["Orden"] == null) { ViewState["Orden"] = SortDirection.Ascending; }
                return (SortDirection)ViewState["Orden"];
            }
            set { ViewState["Orden"] = value; }
        }

        public SortDirection mObtenerOrden()
        {
            if (((SortDirection)Orden) == SortDirection.Ascending) { Orden = SortDirection.Descending; }
            else { Orden = SortDirection.Ascending; }
            return Orden;
        }

        public BasePage()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
    }
}
