using ETNA.BusinessEntity.Logistica;
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
    public partial class frmGeneracionMovimiento : System.Web.UI.Page
    {
        #region Métodos

        private void mtDetalleDocumentoPendiente_Listar(int paramIdDocPendiente)
        {
            try
            {
                //Cargamos la cabecera del documento pendiente
                List<DocumentoPendienteBE> objDocumentoPendienteBE = new DocumentoPendienteBL().Listar(-1, paramIdDocPendiente);
                if (objDocumentoPendienteBE.Count > 0)
                {
                    lblTipoDocumento.Text = objDocumentoPendienteBE[0].descripcionDocumentoPendiente.ToString();
                    lblNumeroDocumento.Text = objDocumentoPendienteBE[0].numeroDocPendiente.ToString();
                    hdnidDocPendiente.Value = objDocumentoPendienteBE[0].idDocPendiente.ToString();
                    lblFechaMovimiento.Text = DateTime.Now.ToShortDateString();
                    lblOrigen.Text = objDocumentoPendienteBE[0].origen.ToString();
                    lblCentroCosto.Text = objDocumentoPendienteBE[0].centrocosto.ToString();
                    
                    //Cargamos el Detalle del documento pendiente
                    List<DetalleDocumentoPendienteBE> objListado = new DetalleDocumentoPendienteBL().Listar(paramIdDocPendiente);
                    if (objListado.Count > 0)
                    {
                        gvListado.DataSource = objListado;
                        gvListado.DataBind();
                        if (objDocumentoPendienteBE[0].tipoDocumentoPendiente == 30) //Control de Calidad
                        {
                            gvListado.Columns[7].Visible = true;
                        }
                        else
                        {
                            gvListado.Columns[7].Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mtMovimientos_Listar(int paramCorrelativo)
        {
            try
            {
                List<DocumentoAlmacenBE> objDocumentoAlmacenBE = new DocumentoAlmacenBL().Listar(-1, paramCorrelativo);

                if (objDocumentoAlmacenBE.Count > 0)
                {
                    lblTipoDocumento.Text = objDocumentoAlmacenBE[0].descripcionDocumentoPendiente.ToString();
                    lblNumeroDocumento.Text = objDocumentoAlmacenBE[0].numeroDocPendiente.ToString();                    
                    lblFechaMovimiento.Text = objDocumentoAlmacenBE[0].fechaDocumento.ToShortDateString();
                    lblOrigen.Text = objDocumentoAlmacenBE[0].Origen.ToString();
                    lblCentroCosto.Text = objDocumentoAlmacenBE[0].centrocosto.ToString();
                    rbTipoMovimiento.SelectedValue = objDocumentoAlmacenBE[0].tipoMovimiento.ToString();
                    ddlAlmacen.SelectedValue = objDocumentoAlmacenBE[0].idAlmacen.ToString();

                    btnGenerar.Visible = false;
                    ddlAlmacen.Enabled = false;
                    gvListado.Enabled = false;
                    rbTipoMovimiento.Enabled = false;
                    lblCaptionTipoDocAtender.Text = "Tipo Documento relacionado";
                    lblCaptionNumeroDocAtender.Text = "Número Documento relacionado";
                    lblCaptionNumeroMovimiento.Text = "Numero Movimiento";
                    lblNumeroMovimiento.Text = objDocumentoAlmacenBE[0].numeroDocAlmacen;

                    //Cargamos el Detalle del documento pendiente
                    List<DetalleDocumentoPendienteBE> objListado = new DetalleDocumentoAlmacenBL().Listar(paramCorrelativo);
                    if (objListado.Count > 0)
                    {
                        gvListado.DataSource = objListado;
                        gvListado.DataBind();

                        gvListado.Columns[7].Visible = false;

                        //if (lblTipoDocumento.Text == "CONTROL DE CALIDAD")
                        //{
                        //    gvListado.Columns[7].Visible = true;
                        //}
                        //else
                        //{
                        //    gvListado.Columns[7].Visible = false;
                        //}                        

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        private bool mtValidarDatos(ref string Mensaje)
        {
            bool ValidacionExitosa = true;

            TextBox txtcantidad = null;
            int cantidadSolicitada = 0;            

            if (rbTipoMovimiento.SelectedValue == "")
            {
                Mensaje = "Ingrese el tipo de Movimiento";
                return false;
            }

            StockBL objStockBL = new StockBL();

            foreach (GridViewRow item in gvListado.Rows)
            {
                
                txtcantidad = (TextBox)gvListado.Rows[item.RowIndex].FindControl("txtCantidadAtendida");
                cantidadSolicitada = Convert.ToInt32(item.Cells[5].Text);

                if (txtcantidad.Text.ToString().Trim() ==string.Empty)
                {
                    Mensaje = "Debe ingresar la cantidad Atendida";
                    return false;
                }

                if (Convert.ToInt32(txtcantidad.Text) == 0)
                {                    
                    Mensaje = "La cantidad Atendida debe ser mayor a Cero (0)";
                    return false;
                }

                if (Convert.ToInt32(txtcantidad.Text) > cantidadSolicitada)
                {                    
                    Mensaje = "La cantidad Atendida debe ser menor a la Cantidad Pendiente de Atención";
                    return false;
                }

                if (Convert.ToInt32(rbTipoMovimiento.SelectedValue) == 23) // Salida
                {
                    StockBE objStockBE = objStockBL.Consultar(Convert.ToInt32(ddlAlmacen.SelectedValue), Convert.ToInt32(gvListado.DataKeys[item.RowIndex].Value.ToString()));
                    if (objStockBE != null)
                    {
                        if ((objStockBE.cantidad - objStockBE.cantidadReservada) < cantidadSolicitada)
                        {
                            Mensaje = "No Existe stock para el producto: " + item.Cells[1].Text;
                            return false;
                        }
                    }
                    else
                    {
                        Mensaje = "El lote del  producto: " + item.Cells[1].Text + " se encuentra bloqueado por Calidad.";
                        return false;
                    }
                }

                

            }

            return ValidacionExitosa;
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                int IdAccion = Convert.ToInt32(Request.QueryString["IdAccion"].ToString()); //1 = Registrar , 2 = Consultar

                mtCargarAlmacen();

                if (IdAccion == 1)
                {
                    int idDocPendiente = Convert.ToInt32(Request.QueryString["idDocPendiente"].ToString());
                    mtDetalleDocumentoPendiente_Listar(idDocPendiente);
                }
                else
                {
                    //Cargamos la consulta de DOcumento Generado
                    int correlativo = Convert.ToInt32(Request.QueryString["correlativo"].ToString());
                    mtMovimientos_Listar(correlativo);
                }
                
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Logistica/frmMovimientosAlmacen.aspx");
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string MensajeValidacion = string.Empty;

                if (mtValidarDatos(ref MensajeValidacion))
                {
                    DocumentoAlmacenBE objDocumentoAlmacenBE = new DocumentoAlmacenBE();
                    objDocumentoAlmacenBE.correlativo = 0;
                    objDocumentoAlmacenBE.idDocPendiente = Convert.ToInt32(hdnidDocPendiente.Value);
                    objDocumentoAlmacenBE.tipoMovimiento = Convert.ToInt32(rbTipoMovimiento.SelectedValue);
                    objDocumentoAlmacenBE.fechaDocumento = Convert.ToDateTime(lblFechaMovimiento.Text);
                    objDocumentoAlmacenBE.idAlmacen = Convert.ToInt32(ddlAlmacen.SelectedValue);
                    objDocumentoAlmacenBE.idUsuario = 1;

                    List<DetalleDocumentoAlmacenBE> objDetalleDocumentoAlmacenBE = new List<DetalleDocumentoAlmacenBE>();


                    TextBox txtcantidad = null;
                    int indice = 0;
                    int situacionAtencion = 0;
                    int cantidadSolicitada = 0;
                    bool indicadorAtendido = true;                    

                    foreach (GridViewRow item in gvListado.Rows)
                    {
                        indice++;
                        txtcantidad = (TextBox)gvListado.Rows[item.RowIndex].FindControl("txtCantidadAtendida");
                        cantidadSolicitada = Convert.ToInt32(item.Cells[5].Text);

                        if (Convert.ToInt32(txtcantidad.Text) != cantidadSolicitada)
                        {
                            indicadorAtendido = false;
                        }

                        DetalleDocumentoAlmacenBE objEntidad = new DetalleDocumentoAlmacenBE();
                        objEntidad.correlativo = 0;
                        objEntidad.idDetalleDocAlmacen = indice;
                        objEntidad.idProducto = Convert.ToInt32(gvListado.DataKeys[item.RowIndex].Value.ToString());
                        objEntidad.cantidad = Convert.ToInt32(txtcantidad.Text);
                        objEntidad.idDocPendiente = objDocumentoAlmacenBE.idDocPendiente;
                        if (lblTipoDocumento.Text == "CONTROL DE CALIDAD")
                        {
                            objEntidad.idLote = Convert.ToInt32(((DropDownList)gvListado.Rows[item.RowIndex].FindControl("ddlLote")).SelectedValue.ToString());
                            objEntidad.cantidad = cantidadSolicitada;
                            indicadorAtendido = true;
                        }
                            

                        objDetalleDocumentoAlmacenBE.Add(objEntidad);

                    }

                    DocumentoAlmacenBL objDocumentoAlmacenBL = new DocumentoAlmacenBL();
                    bool OperacionExitosa = objDocumentoAlmacenBL.Insertar(objDocumentoAlmacenBE, objDetalleDocumentoAlmacenBE);
                    if (OperacionExitosa)
                    {
                        //Actualizamos el estado del documento Pendiente
                        DocumentoPendienteBL objDocumentoPendienteBL = new DocumentoPendienteBL();
                        situacionAtencion = indicadorAtendido == true ? 2 : 1;
                        objDocumentoPendienteBL.ActualizaSituacion(objDocumentoAlmacenBE.idDocPendiente, situacionAtencion);

                        //Actualizamos el Stock
                        if (lblTipoDocumento.Text != "CONTROL DE CALIDAD")
                        {
                            StockBL objStockBL = new StockBL();
                            objStockBL.Actualizar(objDocumentoAlmacenBE.idAlmacen, objDetalleDocumentoAlmacenBE, objDocumentoAlmacenBE.tipoMovimiento);
                        }
                        

                        //Si el documento es control de calidad, se bloquea el Lote del producto
                        if (lblTipoDocumento.Text == "CONTROL DE CALIDAD")
                        {
                            foreach (var itemLote in objDetalleDocumentoAlmacenBE)
                            {
                                LoteBL objLoteBL = new LoteBL();
                                objLoteBL.Actualizar(itemLote.idLote, 1);
                            }
                        }

                        lblMensaje.Text = "Movimiento generado satisfactoriamente";
                        btnGenerar.Visible = false;
                        ddlAlmacen.Enabled = false;
                        gvListado.Enabled = false;
                        rbTipoMovimiento.Enabled = false;
                    }  
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

        #endregion

        #region Propiedades
        #endregion
    }
}