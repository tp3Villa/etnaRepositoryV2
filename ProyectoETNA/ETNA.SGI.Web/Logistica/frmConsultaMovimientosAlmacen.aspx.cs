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
    public partial class frmConsultaMovimientosAlmacen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mtMovimientos_Listar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            mtMovimientos_Listar();
        }

        #region Métodos

        private void mtMovimientos_Listar()
        {
            try
            {
                int paramTipoMovimiento = Convert.ToInt32(ddlTipoMovimiento.SelectedValue);
                List<DocumentoAlmacenBE> objListado = new DocumentoAlmacenBL().Listar(paramTipoMovimiento);
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
    }
}