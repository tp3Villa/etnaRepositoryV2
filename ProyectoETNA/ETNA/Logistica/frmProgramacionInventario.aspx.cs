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
    public partial class frmProgramacionInventario : System.Web.UI.Page
    {
       
        #region Métodos

        private void mtProgramacion_Listar()
        {
            try
            {                
                List<ProgramacionInventarioBE> objListado = new ProgramacionInventarioBL().Listar(0,Convert.ToInt32(ddlTipoInventario.SelectedValue.ToString()));

                gvListado.DataSource = objListado;
                gvListado.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Logistica/frmMantenimientoProgramacionInventario.aspx?IdAccion=1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            mtProgramacion_Listar();
        }

        #endregion
    }
}