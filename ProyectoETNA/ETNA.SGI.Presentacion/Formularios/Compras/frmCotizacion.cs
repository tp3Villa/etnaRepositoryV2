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
    public partial class frmCotizacion : Form
    {

        public int icodCotizacion;
        public string sOpcion;
        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();

        ECotizacion cotizacion = new ECotizacion();
        BCotizacion bCotizacion = BCotizacion.getInstance();
        ECotizacionDetalle cotizacionDetalle = new ECotizacionDetalle();
        public frmCotizacion()
        {
            InitializeComponent();
        }

        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            if (sOpcion == "UPD")
            {
                DataTable tblDetalle = new DataTable();

                cotizacion.CodCotizacion = icodCotizacion;
                tblDetalle = bCotizacion.ObtenerCotizacionPorId(cotizacion);

                txtRequerimiento.Text = tblDetalle.Rows[0]["codRequerimiento"].ToString();
                txtProveedor.Text = tblDetalle.Rows[0]["codProveedor"].ToString();
                txtTelefono.Text = tblDetalle.Rows[0]["telefono"].ToString();
                txtDescripcion.Text = tblDetalle.Rows[0]["descripcion"].ToString();
                dtExpiracion.Text = tblDetalle.Rows[0]["fechaExpiracion"].ToString();

                btnFindProv.Enabled = false;
                btnFindReq.Enabled = false;
                txtDescripcion.Enabled = false;

                DataTable tblDetalle2 = new DataTable();


                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["precioUnidad"].Value = 0;
                    dataGridView1.Rows[i].Cells["descuento"].Value = 0;

                }

                cotizacionDetalle.CodCotizacion = icodCotizacion;
                tblDetalle2 = bCotizacion.ObtenerCotizacionDetallePorId(cotizacionDetalle);
                dataGridView1.DataSource = tblDetalle2;

                double dAmount = 0;
                double dActualAmount = 0;

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    dActualAmount =
                       (Convert.ToDouble(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString()) *
                        Convert.ToDouble(dataGridView1.Rows[i].Cells["precioUnidad"].Value.ToString())) -
                        Convert.ToDouble(dataGridView1.Rows[i].Cells["descuento"].Value.ToString());
                    dAmount = dAmount + dActualAmount;
                }

                txtTotal.Text = Convert.ToString(dAmount);

                DataTable tblDetalle3 = new DataTable();
                 tblDetalle3 = bCotizacion.ObtenerEstadoCotizacionPorId(icodCotizacion);

                 string estadoCotizacion = tblDetalle3.Rows[0][0].ToString();

                //Si esta aprobada no habilitamos nada
                if (estadoCotizacion == "2") 
                {
                    txtTelefono.Enabled = false;
                    dtExpiracion.Enabled = false;
                    btnGrabar.Enabled = false;
                    for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                    {
                       dataGridView1.Rows[i].Cells["precioUnidad"].ReadOnly = true;
                       dataGridView1.Rows[i].Cells["descuento"].ReadOnly = true;
                    }

                }

            }
            else
            {
               txtRequerimiento.Text = "";
               txtProveedor.Text = "";
               txtTelefono.Text = "";
               txtDescripcion.Text = "";
               btnFindProv.Enabled = true;
               btnFindReq.Enabled = true;
               txtDescripcion.Enabled= true;
               dtExpiracion.Value = DateTime.Today;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
                 DataTable tblDetalle3 = new DataTable();
                 tblDetalle3 = bCotizacion.ObtenerEstadoCotizacionPorId(icodCotizacion);

                 string estadoCotizacion = tblDetalle3.Rows[0][0].ToString();

                //Si esta aprobada no mostramos nada
                if (estadoCotizacion == "2") 
                {
                    this.Close();
                }
                else
                 {
                     if (MessageBox.Show("Se procederá a cerrar la ventana, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                     {
                         this.Close();
                     }
                 }
        }

        private void btnFindReq_Click(object sender, EventArgs e)
        {
            Compras.frmListadoReqCotizacion frm = new frmListadoReqCotizacion();
          
            frm.ShowDialog();

            txtRequerimiento.Text = frm.vCodigoReq;

            if  (txtRequerimiento.Text != "")
            {
                DataTable tblDetalle = new DataTable();
                tblDetalle = bRequerimientoCompra.ObtenerRequerimientoDetalleCompraCotizacion(txtRequerimiento.Text);
                dataGridView1.DataSource = tblDetalle;

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {                    
                        dataGridView1.Rows[i].Cells["precioUnidad"].Value=0;
                        dataGridView1.Rows[i].Cells["descuento"].Value=0;
                
                }
            }
            
        }

        private void btnFindProv_Click(object sender, EventArgs e)
        {
            Compras.frmBusquedaProveedor frm = new frmBusquedaProveedor();
            frm.ShowDialog();

            txtProveedor.Text = frm.vCodigo;
        }
        
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Validamos sólo el ingreso de nùmeros */
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DateTime FechaSis = DateTime.Now;

            string fecha;
            FechaSis = DateTime.Now;

            if (dtExpiracion.Value <= DateTime.Today)
            {
    
                MessageBox.Show("Debe seleccionar una fecha de expiracìón mayor a la actual", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtExpiracion.Focus();
                this.Cursor = Cursors.Default;
                return; 
            }


            if (txtRequerimiento.Text == "") 
            { 
                MessageBox.Show("Seleccionar Requerimiento", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                btnFindReq.Focus(); 
                this.Cursor = Cursors.Default; 
                return; 
            }

            if (txtProveedor.Text == "") 
            { 
                MessageBox.Show("Seleccionar Proveedor", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnFindProv.Focus(); 
                this.Cursor = Cursors.Default;
                return; 
            }

            if (txtTelefono.Text == "") 
            {
                MessageBox.Show("Ingresar Teléfono", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                this.Cursor = Cursors.Default;
                return; 
            }

            double precioUnidadValida;
            double descuentoValida;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {

                precioUnidadValida = Convert.ToDouble(dataGridView1.Rows[i].Cells["precioUnidad"].Value.ToString());
                descuentoValida = Convert.ToDouble(dataGridView1.Rows[i].Cells["descuento"].Value.ToString());

                if (precioUnidadValida <= 0  ) 
                 {
                MessageBox.Show("Ingresar un precio mayor a cero", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
                }
            }
           
            if (MessageBox.Show("Se procederá a grabar la cotización", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                string corr = "";
                if (sOpcion == "UPD")
                {
                    corr = Convert.ToString(icodCotizacion);
                }
                else
                {
                    corr = bCotizacion.CorrelativoCotizacion().Rows[0][0].ToString();
                }
                fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);

                cotizacion = new ECotizacion();
                cotizacion.CodCotizacion = Convert.ToInt32(corr);
                cotizacion.CodRequerimiento = Convert.ToInt32(txtRequerimiento.Text.Trim());
                cotizacion.CodProveedor = Convert.ToInt32(txtProveedor.Text.Trim());
                cotizacion.Descripcion = txtDescripcion.Text.Trim();
                cotizacion.Telefono = Convert.ToInt32(txtTelefono.Text.Trim());
                cotizacion.FechaExpiracion = Convert.ToDateTime(dtExpiracion.Text.Trim());
                cotizacion.CodEstado = 4;

                // Datos de detalle
                DataTable dtCurrent = (DataTable)(dataGridView1.DataSource);

                ECotizacionDetalle eCotizacionDetalle;
                List<ECotizacionDetalle> listaECotizacionDetalle = new List<ECotizacionDetalle>();
       
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    eCotizacionDetalle = new ECotizacionDetalle();
                    eCotizacionDetalle.IdProducto = Int32.Parse(dataGridView1.Rows[i].Cells["idProducto"].Value.ToString());
                    eCotizacionDetalle.Cantidad = Int32.Parse(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString());
                    eCotizacionDetalle.PrecioUnidad = Double.Parse(dataGridView1.Rows[i].Cells["precioUnidad"].Value.ToString());
                    eCotizacionDetalle.Descuento = Double.Parse(dataGridView1.Rows[i].Cells["descuento"].Value.ToString());
                    listaECotizacionDetalle.Add(eCotizacionDetalle);
                }


                if (sOpcion == "UPD")
                {
                    cotizacion.FechaActualizacion = DateTime.Today;
                    cotizacion.UsuarioModificacion = Program.Usuario.Trim();
                }
                else
                {
                    cotizacion.FechaRegistro = DateTime.Today;
                    cotizacion.UsuarioRegistro = Program.Usuario.Trim();
                    cotizacion.FechaActualizacion = DateTime.Today;
                    cotizacion.UsuarioModificacion = Program.Usuario.Trim();
                }
                if (sOpcion == "UPD")
                {
                    int result = bCotizacion.ActualizarCotizacion(cotizacion, listaECotizacionDetalle);
                    MessageBox.Show("Cotizacion actualizada correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int result = bCotizacion.RegistrarCotizacion(cotizacion, listaECotizacionDetalle);
                    MessageBox.Show("Cotizacion registrada correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();


            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double dAmount = 0;
                double dActualAmount = 0;

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                   dActualAmount =
                      (Convert.ToDouble(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString()) * 
                       Convert.ToDouble(dataGridView1.Rows[i].Cells["precioUnidad"].Value.ToString())) -
                       Convert.ToDouble(dataGridView1.Rows[i].Cells["descuento"].Value.ToString());
                   dAmount = dAmount + dActualAmount;
                }

                txtTotal.Text = Convert.ToString(dAmount);
            }
            catch { }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            /* Validamos sólo el ingreso de nùmeros */
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
            /* Se valida el ingreso de solo valores de tipo double */
                double i;

                if (!Double.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Formato incorrecto.", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
        }

   
    }
}
