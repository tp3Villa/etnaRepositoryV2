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
    public partial class frmOrdenCompra : Form
    {
        private BOrdenCompra bOrdenCompra = BOrdenCompra.getInstance();
        private BMoneda bMoneda = BMoneda.getInstance();
        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();
        private static double IGV = 0.19;
        private static int ESTADO_GENERADA = 4;
        private string codOrdenCompra;

        public string CodOrdenCompra
        {
            get { return codOrdenCompra; }
            set { codOrdenCompra = value; }
        }
        private string codRequerimiento;

        public string CodRequerimiento
        {
            get { return codRequerimiento; }
            set { codRequerimiento = value; }
        }
        private string codCotizacion;

        public string CodCotizacion
        {
            get { return codCotizacion; }
            set { codCotizacion = value; }
        }
        private string codMoneda;

        public string CodMoneda
        {
            get { return codMoneda; }
            set { codMoneda = value; }
        }
        private string fechaEntrega;

        public string FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }
        private string lugarEntrega;

        public string LugarEntrega
        {
            get { return lugarEntrega; }
            set { lugarEntrega = value; }
        }
        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        private string proveedor;

        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public frmOrdenCompra()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            // Carga de Combo Moneda
            /*DataTable dtMoneda = bMoneda.ObtenerListadoMoneda();
            cboMoneda.DataSource = dtMoneda;
            cboMoneda.DisplayMember = "desMoneda";
            cboMoneda.ValueMember = "codMoneda";*/

            txtIgv.Text = IGV.ToString("0.00");
            
            // Para nuevo registro de OC
            if ("".Equals(codOrdenCompra))
            {
               // cboMoneda.SelectedIndex = 0;

                // Fecha Actual
                dtpFechaEntrega.Value = DateTime.Today;

                txtLugarEntrega.Text = "";
                txtObservacion.Text = "";
                txtRequerimiento.Text = "";
                txtCotizacion.Text = "";
                txtProveedor.Text = "";
                txtSubTotal.Text = 0.ToString("0.00");                
                txtTotal.Text = 0.ToString("0.00");
                btnGenerar.Text = "Generar";
                btnBuscarRequerimiento.Enabled = true;
                this.Text = "Generar Órden de Compra";
            }
            else // Para modificacion de OC
            {
                //cboMoneda.SelectedValue = Int32.Parse(codMoneda);

                // Fecha Actual
                dtpFechaEntrega.Value = DateTime.Parse(fechaEntrega);

                txtLugarEntrega.Text = lugarEntrega;
                txtObservacion.Text = observacion;
                txtRequerimiento.Text = codRequerimiento;
                txtCotizacion.Text = codCotizacion;
                txtProveedor.Text = proveedor;

                btnGenerar.Text = "Modificar";
                btnBuscarRequerimiento.Enabled = false;
                this.Text = "Modificar Órden de Compra";

                DataTable dtDetalleRequerimientoCompra = bRequerimientoCompra.ObtenerListadoDetallePorCodigoRequerimientoCompra(Int32.Parse(codRequerimiento));
                calcularTotales(dtDetalleRequerimientoCompra);
            }
            
        }

        private void btnBuscarRequerimiento_Click(object sender, EventArgs e)
        {
            Formularios.Compras.frmListadoRequerimientoCompra frm = new frmListadoRequerimientoCompra();
            frm.CodRequerimientoCompra = txtRequerimiento.Text;
            frm.CodCotizacion = txtCotizacion.Text;
            frm.Proveedor = txtProveedor.Text;
            frm.ShowDialog();
            txtRequerimiento.Text = frm.CodRequerimientoCompra;
            txtCotizacion.Text = frm.CodCotizacion;
            txtProveedor.Text = frm.Proveedor;
            DataTable dtDetalleRequerimientoCompra = frm.DtDetalleRequerimientoCompra;
            calcularTotales(dtDetalleRequerimientoCompra);        
        }

        private void calcularTotales(DataTable dtDetalleRequerimientoCompra)
        {
            if (dtDetalleRequerimientoCompra != null && dtDetalleRequerimientoCompra.Rows.Count > 0)
            {
                DataColumn dcSubTotal = new DataColumn("subTotal");
                dcSubTotal.DataType = typeof(Double);
                dtDetalleRequerimientoCompra.Columns.Add(dcSubTotal);

                // Columnas a ocultar
                dtDetalleRequerimientoCompra.Columns["codRequerimiento"].ColumnMapping = MappingType.Hidden;
                dtDetalleRequerimientoCompra.Columns["codCotizacion"].ColumnMapping = MappingType.Hidden;
                dtDetalleRequerimientoCompra.Columns["razonSocial"].ColumnMapping = MappingType.Hidden;
                dtDetalleRequerimientoCompra.Columns["idProducto"].ColumnMapping = MappingType.Hidden;

                txtSubTotal.Text = 0.ToString("0.00");
                txtTotal.Text = 0.ToString("0.00");
                double totalDt = 0;
                for (int i = 0; i <= dtDetalleRequerimientoCompra.Rows.Count - 1; i++)
                {
                    int cantidad = Int32.Parse(dtDetalleRequerimientoCompra.Rows[i]["cantidad"].ToString());
                    double precioUnidad = Double.Parse(dtDetalleRequerimientoCompra.Rows[i]["precioUnidad"].ToString());
                    double descuento = Double.Parse(dtDetalleRequerimientoCompra.Rows[i]["descuento"].ToString());
                    double subTotalSinDesc = cantidad * precioUnidad;
                    //double subTotal = subTotalSinDesc - (subTotalSinDesc * descuento);
                    double subTotal = subTotalSinDesc - descuento;
                    dtDetalleRequerimientoCompra.Rows[i]["subTotal"] = subTotal;
                    totalDt += subTotal;
                }
                dtGridDetalleOC.DataSource = dtDetalleRequerimientoCompra;
                txtSubTotal.Text = totalDt.ToString("0.00");
                txtTotal.Text = (totalDt + (totalDt * IGV)).ToString("0.00");
                dtDetalleRequerimientoCompra.AcceptChanges();
            }    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpFechaEntrega.Value <= DateTime.Today)
            {
                MessageBox.Show("Debe seleccionar una fecha mayor a la actual");
                return;
            }
            if ("".Equals(txtLugarEntrega.Text)) {
                MessageBox.Show("Debe ingresar el lugar de entrega");
                return;
            }            
            if ("".Equals(txtRequerimiento.Text))
            {
                MessageBox.Show("Debe seleccionar el requerimiento de compra");
                return;
            }

            if (MessageBox.Show("Se procederá a grabar la orde de compra", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Generación de OC
                if ("".Equals(codOrdenCompra))
                {
                    // Guardar la Orden de Compra con su detalle
                    // Datos de Cabecera
                    EOrdenCompra eOrdenCompra = new EOrdenCompra();
                    //eOrdenCompra.CodMoneda = (int)cboMoneda.SelectedValue;
                    eOrdenCompra.FechaEntrega = dtpFechaEntrega.Value;
                    eOrdenCompra.LugarEntrega = txtLugarEntrega.Text;
                    eOrdenCompra.Observacion = txtObservacion.Text;
                    eOrdenCompra.CodRequerimiento = Int32.Parse(txtRequerimiento.Text);
                    eOrdenCompra.CodCotizacion = Int32.Parse(txtCotizacion.Text);
                    eOrdenCompra.Igv = Double.Parse(txtIgv.Text);
                    eOrdenCompra.CodEstado = ESTADO_GENERADA;
                    eOrdenCompra.FechaRegistro = DateTime.Today;
                    eOrdenCompra.UsuarioRegistro = Program.Usuario.Trim();

                    // Datos de detalle
                    DataTable dtCurrent = (DataTable)(dtGridDetalleOC.DataSource);

                    EOrdenCompraDetalle eOrdenCompraDetalle;
                    List<EOrdenCompraDetalle> listaEOrdenCompraDetalle = new List<EOrdenCompraDetalle>();
                    foreach (DataRow dr in dtCurrent.Rows)
                    {
                        eOrdenCompraDetalle = new EOrdenCompraDetalle();
                        eOrdenCompraDetalle.IdProducto = Int32.Parse(dr["idProducto"].ToString());
                        eOrdenCompraDetalle.Cantidad = Int32.Parse(dr["cantidad"].ToString());
                        eOrdenCompraDetalle.PrecioUnidad = Double.Parse(dr["precioUnidad"].ToString());
                        eOrdenCompraDetalle.Descuento = Double.Parse(dr["descuento"].ToString());
                        listaEOrdenCompraDetalle.Add(eOrdenCompraDetalle);
                    }

                    bOrdenCompra.RegistrarOrdenCompra(eOrdenCompra, listaEOrdenCompraDetalle);                    
                    MessageBox.Show("Orden de compra generada correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Guardar la Orden de Compra con su detalle
                    // Datos de Cabecera
                    EOrdenCompra eOrdenCompra = new EOrdenCompra();
                    eOrdenCompra.CodOrdenCompra = Int32.Parse(codOrdenCompra);
                    //eOrdenCompra.CodMoneda = (int)cboMoneda.SelectedValue;
                    eOrdenCompra.FechaEntrega = dtpFechaEntrega.Value;
                    eOrdenCompra.LugarEntrega = txtLugarEntrega.Text;
                    eOrdenCompra.Observacion = txtObservacion.Text;
                    eOrdenCompra.FechaActualizacion = DateTime.Today;
                    eOrdenCompra.UsuarioModificacion = Program.Usuario.Trim();

                    bOrdenCompra.ActualizarOrdenCompra(eOrdenCompra);                    
                    MessageBox.Show("Orden de compra actualizada correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();

            }
                        
            
        }
    }
}
