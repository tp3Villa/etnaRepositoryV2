using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETNA.SGI.Bussiness.Compras;
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Utils;
using System.Globalization;


namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmListadoRequerimientoCompra : Form
    {

        private BCategoria bCategoria = BCategoria.getInstance();
        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();

        private string codRequerimientoCompra;

        public string CodRequerimientoCompra
        {
            get { return codRequerimientoCompra; }
            set { codRequerimientoCompra = value; }
        }

        private string codCotizacion;

        public string CodCotizacion
        {
            get { return codCotizacion; }
            set { codCotizacion = value; }
        }

        private string proveedor;

        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        private DataTable dtDetalleRequerimientoCompra;

        public DataTable DtDetalleRequerimientoCompra
        {
            get { return dtDetalleRequerimientoCompra; }
            set { dtDetalleRequerimientoCompra = value; }
        }
                        
        public frmListadoRequerimientoCompra()
        {
            InitializeComponent();
        }
               
        private void frmListadoRequerimientoCompra_Load(object sender, EventArgs e)
        {
            // Carga de Combo Estado
            DataTable dtCategoria = bCategoria.ObtenerListadoCategoria();
            cboCategoria.DataSource = dtCategoria;
            cboCategoria.DisplayMember = "desCategoria";
            cboCategoria.ValueMember = "codCategoria";

            DataRow dr = dtCategoria.NewRow();
            dr["desCategoria"] = "Todos";
            dr["codCategoria"] = 0;

            dtCategoria.Rows.InsertAt(dr, 0);
            cboCategoria.SelectedIndex = 0;

            txtCodigo.Text = "";
            
            // Carga de Grilla
            cargarGrilla(new ERequerimientoCompra());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int currentIndex = dataGridView1.CurrentRow.Index;

                    codRequerimientoCompra = dataGridView1.Rows[currentIndex].Cells["codRequerimiento"].Value.ToString();                     
                    dtDetalleRequerimientoCompra = bRequerimientoCompra.ObtenerListadoDetallePorCodigoRequerimientoCompra(Int32.Parse(codRequerimientoCompra));
                    codCotizacion = dtDetalleRequerimientoCompra.Rows[0]["codCotizacion"].ToString();
                    proveedor = dtDetalleRequerimientoCompra.Rows[0]["razonSocial"].ToString();
                    
                    this.Close();
                }
                catch { }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ERequerimientoCompra eRequerimientoCompra = new ERequerimientoCompra();
            if (!"".Equals(txtCodigo.Text))
            {
                eRequerimientoCompra.CodRequerimiento = Int32.Parse(txtCodigo.Text);
            }
            
            eRequerimientoCompra.CodCategoria = (int)cboCategoria.SelectedValue;

            cargarGrilla(eRequerimientoCompra);
        }

        private void cargarGrilla(ERequerimientoCompra eRequerimientoCompra)
        {
            DataTable dtRequerimientoCompra = bRequerimientoCompra.ObtenerListadoRequerimientoCompraOrdenCompra(eRequerimientoCompra);
            dataGridView1.DataSource = dtRequerimientoCompra; 
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
