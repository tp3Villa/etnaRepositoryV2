using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETNA.BusinessEntity.Logistica;
using ETNA.BusinessLogic.Logistica;

namespace ETNA.Logistica
{
    public partial class frmMovimientosAlmacen : System.Web.UI.Page
    {
        #region Métodos

        private void mtDocumentoPendiente_Listar()
        {
            try
            {
                int situacion = Convert.ToInt32(ddlSituacion.SelectedValue.ToString());
                List<DocumentoPendienteBE> objListado = new DocumentoPendienteBL().Listar(situacion);
                if (objListado.Count > 0)
                {
                    gvListado.DataSource = objListado;
                    gvListado.DataBind();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            mtDocumentoPendiente_Listar();
        }

        protected void btnVerMovimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Logistica/frmConsultaMovimientosAlmacen.aspx");
        }

        #endregion

        #region Propiedades
        #endregion
    }
}