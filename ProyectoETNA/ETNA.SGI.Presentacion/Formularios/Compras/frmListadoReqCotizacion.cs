using ETNA.SGI.Bussiness.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmListadoReqCotizacion : Form
    {

        public string vCodigoReq;
        public string sOpcion;

        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();
        private BCategoria bCategoria = BCategoria.getInstance();

        public frmListadoReqCotizacion()
        {
            InitializeComponent();
        }

        private void txtRequerimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmListadoReqCotizacion_Load(object sender, EventArgs e)
        {
            // Carga de Combo Categoria
            DataTable dtCategoria = bCategoria.ObtenerListadoCategoria();
            cboCategoria.DataSource = dtCategoria;
            cboCategoria.DisplayMember = "desCategoria";
            cboCategoria.ValueMember = "codCategoria";

            DataRow dr = dtCategoria.NewRow();
            dr["desCategoria"] = "Todos";
            dr["codCategoria"] = 0;

            dtCategoria.Rows.InsertAt(dr, 0);
            cboCategoria.SelectedIndex = 0;

            txtRequerimiento.Text = "";

            // Carga de Grilla
            DataTable tblDetalle = new DataTable();
            tblDetalle = bRequerimientoCompra.ObtenerListadoRequerimientoCompraCotizacion_Final(new ERequerimientoCompra());
            dataGridView1.DataSource = tblDetalle;

           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ERequerimientoCompra eRequerimientoCompra = new ERequerimientoCompra();

            if (!"".Equals(txtRequerimiento.Text))
            {
                eRequerimientoCompra.CodRequerimiento = Int32.Parse(txtRequerimiento.Text);
            }

            eRequerimientoCompra.CodCategoria = (int)cboCategoria.SelectedValue;

      
                DataTable tblDetalle = new DataTable();
                tblDetalle = bRequerimientoCompra.ObtenerListadoRequerimientoCompraCotizacion_Final(eRequerimientoCompra);
                dataGridView1.DataSource = tblDetalle;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    vCodigoReq = dataGridView1.Rows[p].Cells["codRequerimiento"].Value.ToString();
                    this.Close();
                }
                catch { }
            }
        }
    }
}
