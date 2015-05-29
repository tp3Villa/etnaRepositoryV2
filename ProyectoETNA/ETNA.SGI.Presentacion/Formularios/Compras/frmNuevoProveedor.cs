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
    public partial class frmNuevoProveedor : Form
    {
        public frmNuevoProveedor()
        {
            InitializeComponent();
        }


        public string Opcion = "";
        TControlVB oControl = new TControlVB();
        BTablasCompras objBus = new BTablasCompras();
        BTransaccionCompras objtra = new BTransaccionCompras();

        DateTime FechaSis = DateTime.Now;

        EProveedor proveedor = new EProveedor();

        private void button4_Click(object sender, EventArgs e)
        {
            string fecha;
            FechaSis = DateTime.Now;

            if (txtRazonSocial.Text == "") { MessageBox.Show("Ingresar Razón Social", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtRazonSocial.Focus(); this.Cursor = Cursors.Default; return; }
              if (txtRuc.Text == "") { MessageBox.Show("Ingresar RUC", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtRuc.Focus(); this.Cursor = Cursors.Default; return; }
              if (txtTelefono.Text == "") { MessageBox.Show("Ingresar Teléfono", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtTelefono.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtdir.Text == "") { MessageBox.Show("Ingresar Direccion", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtdir.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtEmail.Text == "") { MessageBox.Show("Ingresar Correo Eléctronico", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); this.Cursor = Cursors.Default; return; }
            if (richTextBox1.Text == "") { MessageBox.Show("Ingresar Observaciones", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); richTextBox1.Focus(); this.Cursor = Cursors.Default; return; }
         
            if (MessageBox.Show("Se Procedera a Grabar el proveedor", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string corr = "";

                corr = objBus.BCorrelativoProveedor().Rows[0][0].ToString();
             

                objtra = new BTransaccionCompras();
               
                objBus = new BTablasCompras();                
                fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);

                proveedor = new EProveedor();
                proveedor.CodProveedor = Convert.ToInt32(corr);
                proveedor.RazonSocial =txtRazonSocial.Text.Trim();
                proveedor.Direccion = txtdir.Text.Trim();
                proveedor.Telefono = Convert.ToInt32(txtTelefono.Text.Trim());
                proveedor.FechaRegistro = FechaSis;
                proveedor.Email = txtEmail.Text.Trim();
                proveedor.Ruc = Convert.ToInt32(txtRuc.Text.Trim());
                proveedor.Observacion = richTextBox1.Text.Trim();


            
                objtra = new BTransaccionCompras();
                int h = objtra.BInsertProveedor(proveedor);



                MessageBox.Show("Proveedor Ingresado Correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                this.Close();


            }

            





        }


      

        private void frmNuevoProveedor_Load(object sender, EventArgs e)
        {
           

                
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Cancelar la Transaccion", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

   
   
     

       
       }
}
