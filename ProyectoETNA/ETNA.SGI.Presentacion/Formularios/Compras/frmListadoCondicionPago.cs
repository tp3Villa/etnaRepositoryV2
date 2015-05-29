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
    public partial class frmListadoCondicionPago : Form
    {

        public int iCodCondicionPago;
        public string vCodigo;
        public string vDescripcion;

        private BCondicionPago bCondicionPago = BCondicionPago.getInstance();
        ECondicionPago eCondicionPago = new ECondicionPago();

        public frmListadoCondicionPago()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmListadoCondicionPago_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = bCondicionPago.DGetAllCondicionPago();

            dataGridView1.DataSource = table; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    vCodigo = dataGridView1.Rows[p].Cells["codCondicionPago"].Value.ToString();
                    vDescripcion = dataGridView1.Rows[p].Cells["desCondicionPago"].Value.ToString();
                    this.Close();
                }
                catch { }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            eCondicionPago.DesCondicionPago = txtDescripcion.Text;

            table = bCondicionPago.DGetAllCondicionPagoByDesc(eCondicionPago);

            dataGridView1.DataSource = table; 
        }
    }
}
