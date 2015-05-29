using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Entity.Exportacion;
using ETNA.SGI.Utils;
using System.Globalization;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmNuevoRequerimiento : Form
    {
        public frmNuevoRequerimiento()
        {
            InitializeComponent();
        }


        public string Opcion = "";
        public string CorrReqUPD = "";
        TControlVB oControl = new TControlVB();
        BTablas objBus = new BTablas();
        BTransaccion objtra = new BTransaccion();

        DateTime FechaSis = DateTime.Now;

        eReqCab cabReq = new eReqCab();
        EReqDetalle detReq = new EReqDetalle();

        private void button3_Click(object sender, EventArgs e)
        {
            string fecha;
            FechaSis = DateTime.Now;

            if (txtPai.Text == "") { MessageBox.Show("Seleccionar Pais", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); button1.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtdir.Text == "") { MessageBox.Show("Ingresar Direccion", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); txtdir.Focus(); this.Cursor = Cursors.Default; return; }
            if (dgvDetReq.Rows.Count == 0) { MessageBox.Show("Ingresar Items", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); TxtCodProd.Focus(); this.Cursor = Cursors.Default; return; }

            if (MessageBox.Show("Se Procedera a Grabar Req.", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string corr = "";
                if (CorrReqUPD == "")
                {
                    corr = objBus.BCorrelativo().Rows[0][0].ToString();
                }
                else
                {
                    corr = CorrReqUPD;
                }

                objtra = new BTransaccion();
                int U = objtra.DDeleteCabReq(corr);
                objtra = new BTransaccion();
                int F = objtra.DDeleteDetReq(corr);

                objBus = new BTablas();                
                fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);

                cabReq = new eReqCab();
                cabReq.Cod_Cab_Req = Convert.ToDecimal(corr);
                cabReq.Cli_Cab_Req = Convert.ToDecimal(Program.CodCli);
                cabReq.Pais_Cab_Req = codPais;
                cabReq.Destino_Cab_Req = txtdir.Text.Trim();
                cabReq.IATA_Cab_Req = "";
                cabReq.Fec_Reg_Cab_Req = Convert.ToDecimal(fecha.ToString());
                cabReq.Fec_Esp_Cab_Req = Convert.ToDecimal(dtp1.Value.Year.ToString() + dtp1.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtp1.Value.Day.ToString("00", CultureInfo.InvariantCulture));
                cabReq.Pre_Tot_Cab_Req = txtTotalS;
                cabReq.Est_Cab_Req = "A";
                cabReq.Obs_Cab_Req = richTextBox1.Text.Trim();

                objtra = new BTransaccion();
                int h = objtra.BInsertCabReq(cabReq);


                for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
                {
                    detReq = new EReqDetalle();
                    detReq.Cod_Det_Req = Convert.ToDecimal(corr);
                    detReq.Cantidad = Convert.ToInt32(dgvDetReq["Cantidad", i].Value.ToString());
                    detReq.Precio_Unit = Convert.ToDecimal(dgvDetReq["PrecioS", i].Value.ToString());                    
                    detReq.Cod_Prod_Det_Req = Convert.ToDecimal(dgvDetReq["codProd", i].Value.ToString());
                    detReq.FOB = 0;
                    detReq.CIF = 0;
                    objtra = new BTransaccion();
                    int j = objtra.BInsertDetReq(detReq);
                }

                MessageBox.Show("Requerimiento Ingresado Correctamente ", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmActualizarInfoRequerimiento.Actualiza = true;
                this.Close();


            }

            





        }


        string codPais = "";
        string nomPais = "";
        string codPrd = "";
        string desPrd = "";
        decimal PreProd = 0;
        decimal PesoProd=0;
        string undProd="";


        decimal Cantidad1 = 0;
        decimal txtTotalS = 0;
        decimal SubtotalS = 0;

        private void frmNuevoRequerimiento_Load(object sender, EventArgs e)
        {
            dgvDetReq.GridColor = Color.Red;  
            FormatoGrilla();
            txtCliente.Text = Program.Nombre;

            if (Opcion == "UPD")
            {
                DataTable dt = new DataTable();
                objBus = new BTablas();
                dt = objBus.BRequerimientoCabeceraXCodREQ(CorrReqUPD);
                codPais = dt.Rows[0]["PAIS_CAB_REQ"].ToString();
                nomPais = dt.Rows[0]["nompais"].ToString();
                txtPai.Text = nomPais;
                txtdir.Text = dt.Rows[0]["DESTINO_CAB_REQ"].ToString();
                richTextBox1.Text = dt.Rows[0]["OBS_CAB_REQ"].ToString();

                //COD_CAB_REQ,,,OBS_CAB_REQ,FEC_ESP_CAB_REQ,FEC_REG_CAB_REQ

                objBus = new BTablas();
                dt = objBus.BRequerimientoDetalleXCodREQ(CorrReqUPD);
                

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = tbldetalle.NewRow();
                    dr["codProd"] = dt.Rows[i]["codProd"].ToString();
                    dr["desProd"] = dt.Rows[i]["desProd"].ToString();
                    dr["Cantidad"] = Convert.ToDecimal(dt.Rows[i]["Cantidad"].ToString());
                    dr["Peso"] = Convert.ToDecimal(dt.Rows[i]["Peso"].ToString());
                    dr["PrecioS"] = Convert.ToDecimal(dt.Rows[i]["PrecioS"].ToString());
                    dr["subPrecioS"] = Convert.ToDecimal(dt.Rows[i]["subPrecioS"].ToString());
                    dr["UndMeda"] = dt.Rows[i]["UndMeda"].ToString();
                    tbldetalle.Rows.Add(dr);
                    tbldetalle.AcceptChanges();
                    CalcularTotal();
                }



            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Exportacion.FrmBusquedaGRAL frm = new FrmBusquedaGRAL();
            //OT = Orden de Trabajo
            frm.Busqueda = "PAI";
            frm.ShowDialog();
            codPais = frm.vCodigo;
            nomPais = frm.vDescripcion;
            txtPai.Text = frm.vDescripcion;
            this.Cursor = Cursors.Default;
        }

        private void btnHelpCodProd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Exportacion.FrmBusquedaGRAL frm = new FrmBusquedaGRAL();            
            frm.Busqueda = "PRD";
            frm.ShowDialog();
            codPrd = frm.vCodigo;
            desPrd = frm.vDescripcion;
            PreProd = frm.vPrecio;
            PesoProd = frm.vPeso;
            undProd = frm.vUnidaMed;
            TxtCodProd.Text = codPrd;
            txtDesProd.Text = desPrd;
            txtCantidad.Focus();
            this.Cursor = Cursors.Default;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Cancelar la Transaccion", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void TxtCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (TxtCodProd.Text != "")
                    {
                        objBus = new BTablas();
                        DataTable dtProdBusq = new DataTable();
                        dtProdBusq = objBus.BProductoBusquedaXCodigo(TxtCodProd.Text.Trim());
                        if (dtProdBusq.Rows.Count > 0)
                        {
                            codPrd = dtProdBusq.Rows[0]["Cod_Prod"].ToString();
                            desPrd = dtProdBusq.Rows[0]["Des_Prod"].ToString();
                            PreProd = Convert.ToDecimal(dtProdBusq.Rows[0]["Pre_Prod"].ToString());
                            PesoProd = Convert.ToDecimal(dtProdBusq.Rows[0]["Pes_Prod"].ToString());
                            undProd = dtProdBusq.Rows[0]["Cod_Unidad"].ToString();
                            TxtCodProd.Text = codPrd;
                            txtDesProd.Text = desPrd;
                            txtCantidad.Enabled = true;
                            txtCantidad.Focus();                            
                        }
                        else
                        {
                            TxtCodProd.Text = "";
                            TxtCodProd.Focus();
                            MessageBox.Show("Cod.Prod. No Existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresar Cod.Prod.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    }
                oControl.Numero(e, TxtCodProd);   
            }
            catch { }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Agregar();
                }
            }
            catch { }
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
            oControl.NumeroDec(e, txtCantidad);
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
        }

        DataTable tbldetalle;
        DataRow dr;

        void Agregar()
        {
            CalcularDatarow();
            string cantiText = txtCantidad.Text.Trim();
            string codProd = TxtCodProd.Text.Trim();
            string DesProd = txtDesProd.Text.Trim();
            try
            {
                

                if ((cantiText != "") && (cantiText != "0"))
                {
                    dr = tbldetalle.NewRow();
                    dr["codProd"] = codProd;
                    dr["desProd"] = DesProd;
                    dr["Cantidad"] = cantiText;
                    dr["Peso"] = PesoProd;
                    dr["PrecioS"] = PreProd;
                    dr["subPrecioS"] = SubtotalS;
                    dr["UndMeda"] = undProd;
                    tbldetalle.Rows.Add(dr);
                    tbldetalle.AcceptChanges();
                    LimpiarProd();
                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("Ingrese Cantidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
            catch
            {
                if (MessageBox.Show("El producto ya Existe Desea Actualizar los cambios", "Actualizar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dr = tbldetalle.Rows.Find(TxtCodProd.Text.ToString());
                    dr.BeginEdit();
                    dr["codProd"] = codProd;
                    dr["desProd"] = DesProd;
                    dr["Cantidad"] = cantiText;
                    dr["Peso"] = PesoProd;
                    dr["PrecioS"] = PreProd;
                    dr["subPrecioS"] = SubtotalS;
                    dr["UndMeda"] = undProd;
                    dr.EndEdit();
                    tbldetalle.AcceptChanges();
                    LimpiarProd();
                    CalcularTotal();
                }
            }

            TxtCodProd.Focus();
        }



        void CalcularDatarow()
        {
            if (txtCantidad.Text != "") { Cantidad1 = Convert.ToDecimal(txtCantidad.Text); }
            SubtotalS = Math.Round((Cantidad1 * PreProd), 3);
        }
        private void CalcularTotal()
        {
            try
            {
                string sTotalTS = tbldetalle.Compute("sum(subPrecioS)", "") == null ? "0" : tbldetalle.Compute("sum(subPrecioS)", "").ToString();
                txtTotalS = Convert.ToDecimal(sTotalTS);
            }
            catch { throw; }
        }

        void LimpiarProd()
        {
            TxtCodProd.Text = "";
            txtCantidad.Text = "";
            txtDesProd.Text = "";
            codPrd = "";
            desPrd = "";
            PreProd = 0;
            PesoProd = 0;
            undProd = "";
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }



        private void FormatoGrilla()
        {
            tbldetalle = new DataTable("tabll1");
            tbldetalle.Columns.Add(new DataColumn("codProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("desProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Cantidad", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("PrecioS", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("subPrecioS", typeof(decimal)));  
            tbldetalle.Columns.Add(new DataColumn("UndMeda", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Peso", typeof(decimal)));
            tbldetalle.PrimaryKey = new DataColumn[] { tbldetalle.Columns[0] };
            dgvDetReq.DataSource = tbldetalle;

            dgvDetReq.Columns["codProd"].HeaderText = "Producto";
            dgvDetReq.Columns["desProd"].HeaderText = "Descripcion";
            dgvDetReq.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetReq.Columns["PrecioS"].HeaderText = "Precio S/.";
            dgvDetReq.Columns["subPrecioS"].HeaderText = "Precio S/.";
            dgvDetReq.Columns["UndMeda"].HeaderText = "Unid. Med.";
            dgvDetReq.Columns["Peso"].HeaderText = "Peso";

            

            dgvDetReq.Columns["codProd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["desProd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["PrecioS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["subPrecioS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["UndMeda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["Peso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["codProd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["desProd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["PrecioS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["subPrecioS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["UndMeda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvDetReq.Columns["codProd"].Width = 90;
            dgvDetReq.Columns["desProd"].Width = 200;
            dgvDetReq.Columns["Cantidad"].Width = 100;
            dgvDetReq.Columns["UndMeda"].Width = 100;
            dgvDetReq.Columns["Peso"].Width = 100;

            dgvDetReq.Columns["Peso"].DefaultCellStyle.Format = "0,0.00";

            dgvDetReq.Columns["PrecioS"].Visible = false;
            dgvDetReq.Columns["subPrecioS"].Visible = false;

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetReq.Rows.Count >= 1)
                {
                    if (MessageBox.Show("Desea Eliminar Producto", "Eliminar", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string naza = dgvDetReq[0, dgvDetReq.CurrentCell.RowIndex].Value.ToString();
                        dr = tbldetalle.Rows.Find(Convert.ToString(naza));
                        dr.Delete();
                        tbldetalle.AcceptChanges();
                        CalcularTotal();
                    }
                }
            }
            catch { }
        }








    }
}
