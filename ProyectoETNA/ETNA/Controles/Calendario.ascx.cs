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
    public partial class Calendario : System.Web.UI.UserControl
    {

        #region Propiedades
            public Nullable<DateTime> SelectedDate
            {
                get 
                {
                    if (string.IsNullOrEmpty(txtFecha.Text))
                        return null;
                    else
                        return Convert.ToDateTime(txtFecha.Text); 
                }
                set 
                {
                    if (value.HasValue)
                        txtFecha.Text = value.ToString().Substring(0, 10);
                    else
                        txtFecha.Text = null;
                }
            }

            public void Text(string texto)
            {
                txtFecha.Text = texto;
            }

            public short TabIndex
            {
                set { txtFecha.TabIndex = value; }
            }

            public bool Enabled
            {
                set
                {
                    imgFecha.Disabled = !value;
                    txtFecha.Enabled= !value;
                    rfvFecha.Enabled = value;
                    revFecha.Enabled = value;
                }
            }

            

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            if (txtFecha.Text.Length == 0)
                txtFecha.Text = DateTime.Today.ToString().Substring(0, 10);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgFecha.Attributes.Add("onclick", "popUpCalendar(this, " + this.txtFecha.ClientID + ", 'dd/mm/yyyy')");
            txtFecha.Attributes.Add("onkeypress", "ingresoFecha(this)");
            txtFecha.Attributes.Add("onblur", "if (valida_fecha(this)==false) {alert('Fecha incorrecta'); this.value=''; this.focus(); }");
          
        }
    }
}