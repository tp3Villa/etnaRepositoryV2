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
    public partial class frmListadoAprobacionCotizacion : Form
    {
        public frmListadoAprobacionCotizacion()
        {
            InitializeComponent();
        }

        private BCotizacion bCotizacion = BCotizacion.getInstance();
        ECotizacion eCotizacion = new ECotizacion();

        private void frmListadoAprobacionCotizacion_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = bCotizacion.DGetCotizacionAprobacion();
            //table = bCotizacion.DGetCotizacionAprobacionWithParameters(Convert.ToDateTime(dtExpiracionFrom.Text), Convert.ToDateTime(dtExpiracionTo.Text)); 

            dataGridView1.DataSource = table;

         }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            //table = bCotizacion.DGetCotizacionAprobacion();
            int codProveedor = 0;
            int codRequerimiento = 0;

            if (txtProveedor.Text != "") { 
                codProveedor = Convert.ToInt32(txtProveedor.Text);
            }

            if (txtSolicitud.Text != "") {
                codRequerimiento = Convert.ToInt32(txtSolicitud.Text);
            }

            table = bCotizacion.DGetCotizacionAprobacionWithParameters(Convert.ToDateTime(dtExpiracionFrom.Text), Convert.ToDateTime(dtExpiracionTo.Text),codRequerimiento, codProveedor); 

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if (MessageBox.Show("Se procederá a aprobar la cotización, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int p = dataGridView1.CurrentRow.Index;

                        eCotizacion.CodCotizacion = Convert.ToInt32(dataGridView1.Rows[p].Cells["codCotizacion"].Value.ToString());
                        eCotizacion.CodEstado = 2;
                        eCotizacion.UsuarioAprobacion = Program.Usuario.Trim();

                        eCotizacion.FechaAprobacion =  DateTime.Now;
                        
                        int exito = bCotizacion.DUpdateAprobacionCotizacion(eCotizacion);

                        MessageBox.Show("La cotización fue aprobada. ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataTable table = new DataTable();
                        table = bCotizacion.DGetCotizacionAprobacion();

                        dataGridView1.DataSource = table;
                    }                   
                }
                catch { }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se procederá a cerrar la ventana, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Compras.frmBusquedaProveedor frm = new frmBusquedaProveedor();
            frm.ShowDialog();

            txtProveedor.Text = frm.vCodigo;
        }

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            Compras.frmListadoReqCotizacion frm = new frmListadoReqCotizacion();
            frm.ShowDialog();

            txtSolicitud.Text = frm.vCodigoReq;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProveedor.Text = "";
            txtSolicitud.Text = "";
            dtExpiracionFrom.Value = DateTime.Now;
            dtExpiracionTo.Value = DateTime.Now;
        }
    }
}
