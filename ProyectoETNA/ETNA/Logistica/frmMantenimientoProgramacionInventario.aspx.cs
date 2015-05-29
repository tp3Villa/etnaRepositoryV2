using ETNA.BusinessEntity.Comun;
using ETNA.BusinessEntity.Logistica;
using ETNA.BusinessLogic.Comun;
using ETNA.BusinessLogic.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETNA.Logistica
{
    public partial class frmMantenimientoProgramacionInventario : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int IdAccion = Convert.ToInt32(Request.QueryString["IdAccion"].ToString()); //1 = Registrar , 2 = Editar ; 3 = Eliminar
                int idProgInventario = 0;
                mtCargarAlmacen();
                mtCargarPersona();
                lblIdProgramacion.Visible = false;
                lblCaptionIdProgramacion.Visible = false;

                if (IdAccion == 2)
                {
                    btnGrabar.Text = "Actualizar";
                    idProgInventario = Convert.ToInt32(Request.QueryString["idProgInventario"].ToString());
                    mtConsultarProgramacion(idProgInventario);
                    
                }
                else if (IdAccion == 3)
                {
                    btnGrabar.Text = "Eliminar";
                    idProgInventario = Convert.ToInt32(Request.QueryString["idProgInventario"].ToString());
                    mtConsultarProgramacion(idProgInventario);
                    ddlAlmacen.Enabled = false;
                    ddlResponsable.Enabled = false;
                    ddlTipoInventario.Enabled = false;
                    txtFechaProgramada.Enabled = false;

                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string MensajeValidacion = string.Empty;

                if (mtValidarDatos(ref MensajeValidacion))
                {
                    ProgramacionInventarioBE objProgramacionInventarioBE = new ProgramacionInventarioBE();
                    objProgramacionInventarioBE.tipoInventario = Convert.ToInt32(ddlTipoInventario.SelectedValue);
                    objProgramacionInventarioBE.fechaProgramada = Convert.ToDateTime(txtFechaProgramada.Text);
                    objProgramacionInventarioBE.frecuencia = 1;
                    objProgramacionInventarioBE.idAlmacen = Convert.ToInt32(ddlAlmacen.SelectedValue);
                    objProgramacionInventarioBE.idPersona = Convert.ToInt32(ddlResponsable.SelectedValue);
                    objProgramacionInventarioBE.idEstadoInventario = 31;
                    objProgramacionInventarioBE.idUsuario = 1;

                    ProgramacionInventarioBL objProgramacionInventarioBL = new ProgramacionInventarioBL();

                    if (btnGrabar.Text == "Actualizar")
                    {
                        objProgramacionInventarioBE.idProgInventario = Convert.ToInt32(Request.QueryString["idProgInventario"].ToString());
                        objProgramacionInventarioBL.Actualizar(objProgramacionInventarioBE);
                        lblMensaje.Text = "Programación actualizada satisfactoriamente";
                    }
                    else if (btnGrabar.Text == "Grabar")
                    {
                        objProgramacionInventarioBL.Insertar(objProgramacionInventarioBE);
                        lblMensaje.Text = "Programación generada satisfactoriamente";
                    }
                    else
                    {
                        //Eliminamos
                        bool EliminacionCorrecta = objProgramacionInventarioBL.Eliminar(Convert.ToInt32(Request.QueryString["idProgInventario"].ToString()));
                        if (EliminacionCorrecta)
                            lblMensaje.Text = "Programación eliminada satisfactoriamente";
                        else
                            lblMensaje.Text = "No se puede eliminar existe dependencia con Inventario";
                    }

                    btnGrabar.Visible = false;
                    ddlAlmacen.Enabled = false;
                    ddlResponsable.Enabled = false;
                    ddlTipoInventario.Enabled = false;
                    txtFechaProgramada.Enabled = false;
                }
                else
                {
                    lblMensaje.Text = MensajeValidacion;
                }
                

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
                throw ex;
            }
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Logistica/frmProgramacionInventario.aspx");
        }

        #endregion

        #region Métodos

        private void mtCargarAlmacen()
        {
            try
            {
                List<AlmacenBE> objListado = new AlmacenBL().Listar();
                if (objListado.Count > 0)
                {
                    ddlAlmacen.DataSource = objListado;
                    ddlAlmacen.DataTextField = "descripcionAlmacen";
                    ddlAlmacen.DataValueField = "idAlmacen";
                    ddlAlmacen.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mtCargarPersona()
        {
            try
            {
                List<PersonaBE> objListado = new PersonaBL().Listar();
                if (objListado.Count > 0)
                {
                    ddlResponsable.DataSource = objListado;
                    ddlResponsable.DataTextField = "NombreCompleto";
                    ddlResponsable.DataValueField = "idPersona";
                    ddlResponsable.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mtConsultarProgramacion(int paramIdProgramacion)
        {
            List<ProgramacionInventarioBE> objListado = new ProgramacionInventarioBL().Listar(paramIdProgramacion);
            if (objListado.Count > 0)
            {
                lblIdProgramacion.Visible = true;
                lblCaptionIdProgramacion.Visible = true;                

                lblCaptionIdProgramacion.Text = "Código Programación";
                lblIdProgramacion.Text = objListado[0].idProgInventario.ToString();

                txtFechaProgramada.Text = objListado[0].fechaProgramada.ToString();
                ddlTipoInventario.SelectedValue = objListado[0].tipoInventario.ToString();
                ddlAlmacen.SelectedValue = objListado[0].idAlmacen.ToString();
                ddlResponsable.SelectedValue = objListado[0].idPersona.ToString();
                lblEstadoInventario.Text = objListado[0].descripcionEstadoInventario.ToString();
            }
        }

        private bool mtValidarDatos(ref string Mensaje)
        {
            bool ValidacionExitosa = true;

            if (txtFechaProgramada.Text == "")
            {
                Mensaje = "Ingrese la fecha programada";
                return false;
            }

            

            return ValidacionExitosa;
        }

        #endregion
    }
}