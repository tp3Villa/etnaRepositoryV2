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
    public partial class CalendarioOptional : System.Web.UI.UserControl
    {
        #region Propiedades
            public Nullable<DateTime> SelectedDate
            {
                get
                {
                    return Convert.ToDateTime(txtFecha.Value);
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
                    revFecha.Enabled = value;
                }
            }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            imgFecha.Attributes.Add("onclick", "popUpCalendar(this, " + this.txtFecha.ClientID + ", 'dd/mm/yyyy')");
        }
    }
}