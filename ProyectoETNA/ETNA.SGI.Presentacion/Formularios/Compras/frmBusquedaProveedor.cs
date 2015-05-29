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
    public partial class frmBusquedaProveedor : Form
    {

        public string vCodigo;
        public string vRazonSocial;

        private BProveedor bProveedor = BProveedor.getInstance();
        EProveedor proveedor = new EProveedor();

        public frmBusquedaProveedor()
        {
            InitializeComponent();
        }

        private void frmBusquedaProveedor_Load(object sender, EventArgs e)
        {
            DataTable tblDetalle = new DataTable();

            proveedor.CodEstado = 5;
            tblDetalle = bProveedor.DGetAllProveedorActive(proveedor);

            dataGridView1.DataSource = tblDetalle; 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tblDetalle = new DataTable();

            proveedor.RazonSocial = txtRazonSocial.Text.Trim();

            proveedor.CodEstado = 5;
            tblDetalle = bProveedor.DGetAllProveedorActive(proveedor);

            dataGridView1.DataSource = tblDetalle;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    vCodigo = dataGridView1.Rows[p].Cells["codProveedor"].Value.ToString();
                    vRazonSocial = dataGridView1.Rows[p].Cells["razonSocial"].Value.ToString();
                    this.Close();
                }
                catch { }
            }
        }
    }
}
