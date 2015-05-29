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
    public partial class frmListadoCotizacion : Form
    {
      

        private BCotizacion bCotizacion = BCotizacion.getInstance();
        private BEstado bEstado = BEstado.getInstance();
        DataTable dtCotizacion = new DataTable();

        public frmListadoCotizacion()
        {
            InitializeComponent();
        }

        private void txtCotizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRequerimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Formularios.Compras.frmProveedor frm = new frmProveedor();
            frm.ShowDialog();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            ECotizacion eCotizacion = new ECotizacion();
            if (!"".Equals(txtCotizacion.Text))
            {
                eCotizacion.CodCotizacion = Int32.Parse(txtCotizacion.Text);
            }
            if (!"".Equals(txtRequerimiento.Text))
            {
                eCotizacion.CodRequerimiento = Int32.Parse(txtRequerimiento.Text);
            }

            eCotizacion.CodEstado = (int)cboEstado.SelectedValue;

            DataTable tblDetalle = new DataTable();
            tblDetalle = bCotizacion.ObtenerListadoCotizacion(eCotizacion);
            dtGridCot.DataSource = tblDetalle;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se procederá a cerrar la ventana, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Formularios.Compras.frmCotizacion frm = new Formularios.Compras.frmCotizacion();
            frm.Show();
            //this.Cursor = Cursors.Default;

            /* Listado de nuevo */
            // Carga de Grilla
            ECotizacion eCotizacion = new ECotizacion();
            eCotizacion.CodEstado = (int)cboEstado.SelectedValue;

            DataTable tblDetalle = new DataTable();
            tblDetalle = bCotizacion.ObtenerListadoCotizacion(eCotizacion);
            dtGridCot.DataSource = tblDetalle;


        }

        private void frmListadoCotizacion_Load(object sender, EventArgs e)
        {
            // Carga de Combo Estado
            DataTable dtEstado = bEstado.ObtenerListadoEstadoPorCotizacion();
            cboEstado.DataSource = dtEstado;
            cboEstado.DisplayMember = "desEstado";
            cboEstado.ValueMember = "codEstado";

            DataRow dr = dtEstado.NewRow();
            dr["desEstado"] = "Todos";
            dr["codEstado"] = 0;

            dtEstado.Rows.InsertAt(dr, 0);
            cboEstado.SelectedIndex = 0;

            txtCotizacion.Text = "";
            txtRequerimiento.Text = "";

            // Carga de Grilla
            DataTable tblDetalle = new DataTable();
            tblDetalle = bCotizacion.ObtenerListadoCotizacion(new ECotizacion());
            dtGridCot.DataSource = tblDetalle;
        }


        private void dtGridCot_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dtGridCot.CurrentRow.Index;
                    Formularios.Compras.frmCotizacion frm = new frmCotizacion();
                     frm.sOpcion = "UPD";
                    frm.icodCotizacion = Convert.ToInt32(dtGridCot.Rows[p].Cells["codCotizacion"].Value.ToString());
                    frm.ShowDialog();
                }
                catch { }
            }
            else if
                (e.ColumnIndex == 1)
            {
                int p = dtGridCot.CurrentRow.Index;
                int i_codCotizacion = Convert.ToInt32(dtGridCot.Rows[p].Cells["codCotizacion"].Value.ToString());
                
                DataTable tblDetalle = new DataTable();
                tblDetalle = bCotizacion.ObtenerEstadoCotizacionPorId(i_codCotizacion);

                string estadoCotizacion = tblDetalle.Rows[0][0].ToString();

                if (estadoCotizacion == "2")
                {
                    MessageBox.Show("No se puede eliminar una cotizacion aprobada ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Esta seguro de eliminar la cotizacion selecccionada?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                int result = bCotizacion.EliminarCotizacion(i_codCotizacion);
                MessageBox.Show("Cotizacion Eliminada correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataTable tblDetalleFinal = new DataTable();
                tblDetalleFinal = bCotizacion.ObtenerListadoCotizacion(new ECotizacion());
                dtGridCot.DataSource = tblDetalleFinal;


                }

            }

        }


    }
}
