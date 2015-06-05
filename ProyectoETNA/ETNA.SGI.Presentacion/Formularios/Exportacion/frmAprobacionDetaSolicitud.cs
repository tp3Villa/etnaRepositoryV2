using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Utils;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmAprobacionDetaSolicitud : Form
    {
        public frmAprobacionDetaSolicitud()
        {
            InitializeComponent();
        }


        TControlVB oControl = new TControlVB();

        public string Opcion = "";
        public string CorrSOLUPD = "";
        public string CorrREQUPD = "";

        public string codigoReq = "";
        public string Razon = "";
        public string Destino = "";
        public string Direccion = "";

        public string fecha1 = "";
        public string fecha2 = "";
        public string PAIS_CAB_REQ = "";

        DataTable tbldetalle1;
        DataRow dr1;
        DataTable tbldetalle;
        DataRow dr;

        string codIATA = "";
        string desIATA = "";


        DataTable tblDocAdjunto;



        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void frmAprobacionDetaSolicitud_Load(object sender, EventArgs e)
        {
            lblResponsable.Text = Program.Nombre;
            FormatoGrilla();
            dataGridView1.GridColor = Color.Red;

            if (Opcion != "")
            {
                if (Opcion == "VIS")
                {
                    dtFechaEsp.Enabled = false;
                    dtFechaReg.Enabled = false;
                }

                DataTable dt = new DataTable();
                dt = bTablas.getSELECTLIBRE("SELECT             R.idProducto AS codProd,     P.descripcionProducto AS desProd,            cantidad AS cantidad, " +
" P.pre_prod AS PrecioS,            (cantidad*P.pre_prod) AS subPrecioS,   P.tipounidadMedida AS UndMeda, P.peso AS Peso,CIF,FOB FROM Requerimiento_Detalle AS R " +
" LEFT OUTER JOIN  Producto AS P ON (P.idProducto=R.idProducto )             WHERE Cod_Det_Req='" + CorrREQUPD + "'");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = tbldetalle.NewRow();
                    dr["Codigo"] = dt.Rows[i]["codProd"].ToString();
                    dr["producto"] = dt.Rows[i]["desProd"].ToString();
                    dr["cantidad"] = Convert.ToDecimal(dt.Rows[i]["Cantidad"].ToString());
                    dr["precio"] = Convert.ToDecimal(dt.Rows[i]["PrecioS"].ToString());
                    dr["cif"] = Convert.ToDecimal(dt.Rows[i]["CIF"].ToString()); ;
                    dr["fob"] = Convert.ToDecimal(dt.Rows[i]["FOB"].ToString()); ;
                    dr["Medida"] = "Unidad";
                    tbldetalle.Rows.Add(dr);
                    tbldetalle.AcceptChanges();
                }

                //objBus = new BTablas();
                DataTable dtMo = bTablas.getSELECTLIBRE("SELECT Cod_Solicitud,S.Cod_Cab_Req AS Cod_Cab_Req_Solicitud,IATA_CAB_REQ,(SELECT IATA_DES FROM dbo.IATA WHERE IATA_COD=IATA_CAB_REQ) DES_IATA, " +
" R.Cod_Pais as PAIS_CAB_REQ,(SELECT NOM_PAIS FROM PAIS AS P WHERE P.Cod_Pais=R.Cod_Pais) AS PAIS,RAZON_SOCIAL,DIRECCION,FEC_REG_CAB_REQ,Convert(varchar(10), FEC_RES_ESP_SOLICITUD,103) AS FEC_RES_ESP_SOLICITUD,observacion_solicitud FROM dbo.SolicitudAtencion AS S LEFT OUTER JOIN " +
" dbo.Requerimiento AS R ON (S.Cod_Cab_Req=R.COD_CAB_REQ) LEFT OUTER JOIN CLIENTE AS C ON (R.COD_CLIENTE=C.COD_CLIENTE) WHERE Cod_Solicitud=" + CorrSOLUPD);

                codigoReq = CorrREQUPD;

                codIATA = dtMo.Rows[0]["IATA_CAB_REQ"].ToString();
                desIATA = dtMo.Rows[0]["DES_IATA"].ToString();
                lblIATA.Text = desIATA;
                Razon = dtMo.Rows[0]["RAZON_SOCIAL"].ToString();
                Destino = dtMo.Rows[0]["DIRECCION"].ToString();
                Direccion = dtMo.Rows[0]["PAIS"].ToString();
                fecha1 = dtMo.Rows[0]["FEC_REG_CAB_REQ"].ToString().Substring(6, 2) + "/" + dtMo.Rows[0]["FEC_REG_CAB_REQ"].ToString().Substring(4, 2) + "/" + dtMo.Rows[0]["FEC_REG_CAB_REQ"].ToString().Substring(0, 4);
                fecha2 = dtMo.Rows[0]["FEC_RES_ESP_SOLICITUD"].ToString();
                PAIS_CAB_REQ = dtMo.Rows[0]["PAIS_CAB_REQ"].ToString();

                richTextBox1.Text = dtMo.Rows[0]["observacion_solicitud"].ToString().Trim();


                lblCodReq.Text = codigoReq.Trim();
                lblRazon.Text = Razon.Trim();
                lblDestino.Text = Destino.Trim();
                lblDireccion.Text = Direccion.Trim();
                dtFechaReg.Value = Convert.ToDateTime(fecha1);
                dtFechaEsp.Value = Convert.ToDateTime(fecha2);


            }
        }

        private void FormatoGrilla()
        {
            tbldetalle = new DataTable("tabll1");
            tbldetalle.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("producto", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("cantidad", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Medida", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("precio", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("cif", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("fob", typeof(decimal)));
            tbldetalle.PrimaryKey = new DataColumn[] { tbldetalle.Columns[0] };
            dataGridView1.DataSource = tbldetalle;


            dataGridView1.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["producto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Medida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["cif"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["fob"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        string codPROD = "";
        string desPROD = "";
        DataTable dtReqProSii = new DataTable();
        DataView dvReqProSii = new DataView();
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    dgvDocumento.GridColor = Color.Red;
                    int p = dataGridView1.CurrentRow.Index;

                    codPROD = dataGridView1.Rows[p].Cells["Codigo"].Value.ToString();
                    desPROD = dataGridView1.Rows[p].Cells["producto"].Value.ToString();
                    label22.Text = "Producto - Bateria " + desPROD;
                    //frm.ShowDialog();
                    //objBus = new BTablas();
                    dtReqProSii = bTablas.getSELECTLIBRE("SELECT R.cod_siicex,des_siicex,'Ver Doc' as DET FROM dbo.DocProdReq AS R left outer join " +
" dbo.DosSIICEX AS S on (R.cod_siicex=S.cod_siicex)  where r.Cod_Cab_Req= '" + CorrREQUPD + "' and r.idProducto='" + codPROD + "'");
                    panel1.Visible = true;
                    dgvDocumento.DataSource = dtReqProSii;

                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea aprobar solicitud?", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int K = bTransaccion.BTransaccionVarias("update dbo.SolicitudAtencion SET Estado_Solicitud='S' WHERE Cod_Solicitud='" + CorrSOLUPD + "'");
                MessageBox.Show("Solicitud Aprobada Correctamente", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAprobacionSolicitud.Actualiza = true;
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string CODPDF = "";
        private void dgvDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 3)
            {
                try
                {
                    int p = dgvDocumento.CurrentRow.Index;
                    CODPDF = dgvDocumento.Rows[p].Cells["cod_siicex"].Value.ToString();
                    tblDocAdjunto = bTablas.getSELECTLIBRE("SELECT TOP 1 DOCUMENTO_ADJUNTO FROM DetalleDocExportacion WHERE Cod_SIICEX=" + CODPDF + " AND Estado='A' ORDER BY Version DESC");
                    string ruta = tblDocAdjunto.Rows[0]["DOCUMENTO_ADJUNTO"].ToString();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = ruta;
                    proc.Start();
                    proc.Close();                    
                }
                catch {
                    MessageBox.Show("Documento no encontrado!!!!!!!!", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            oControl.ValidarCajaTexto(e, e.KeyChar);
        }

        

    }
}
