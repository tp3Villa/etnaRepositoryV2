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

namespace SGCA
{
    public partial class CalendarioLibre : System.Web.UI.UserControl
    {
        #region Propiedades

            public Nullable<DateTime> SelectedDate
            {
                get
                {
                    if (txtFecha.Value.Length != 0)
                        return Convert.ToDateTime(txtFecha.Value);
                    else
                        return null;
                }
                set
                {
                    if (value.HasValue)
                        txtFecha.Value = value.ToString().Substring(0, 10);
                    else
                        txtFecha.Value = null;
                }
            }
           
            public bool Enabled
            {
                set
                {
                    imgFecha.Disabled = !value;
                    txtFecha.Disabled = !value;
                }
            }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            this.imgFecha.Attributes.Add("onclick", "popUpCalendar(this, " + this.txtFecha.ClientID + ", 'dd/mm/yyyy')");
            //this.txtFecha.Attributes.Add("onkeypress", "return ingresoNumeroEnteroPositivo();");            
        }
    }
}