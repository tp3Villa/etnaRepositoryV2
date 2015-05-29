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

namespace SGCA.Controles
{
    public partial class TextBoxHora : System.Web.UI.UserControl
    {

        #region Propiedades
        public Nullable<DateTime> SelectedDate
        {
            get
            {
                return Convert.ToDateTime(txtHora.Value);
            }
            set
            {
                if (value.HasValue)
                    txtHora.Value = value.ToString().Substring(0, 10);
                else
                    txtHora.Value = null;
            }
        }

        public bool Enabled
        {
            set
            {                
                txtHora.Disabled = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}