using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using ETNA.SGI.Entity.Exportacion;
using ETNA.SGI.Bussiness.Exportacion;
using System.Globalization;

namespace ETNA.SGI.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        ELogin ObjEnt = new ELogin();
        BLogin ObjBus = new BLogin();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        void proLogin()
        {
            ObjEnt.Usuario = textBox1.Text.ToUpper();
            ObjEnt.Pasw = textBox2.Text.ToUpper();
            int nroUsuario = 0;
            try
            {
                nroUsuario = ObjBus.BLogueo(ObjEnt).Rows.Count;
            }
            catch (Exception ex)
            {
                global::System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            if (nroUsuario > 0)
            {
                try
                {
                    Program.Usuario = ObjBus.BLogueo(ObjEnt).Rows[0][0].ToString();
                    Program.Nombre = ObjBus.BLogueo(ObjEnt).Rows[0][2].ToString();
                    Program.CodCli = ObjBus.BLogueo(ObjEnt).Rows[0][5].ToString().Trim();
                }
                catch (Exception ex)
                {
                    global::System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                Menu frm = new Presentacion.Menu();
                this.Visible = false;
                frm.Show();
            }
            else
            {
                String sw = "0";
                if ((textBox1.Text == "") && (sw == "0"))
                {
                    global::System.Windows.Forms.MessageBox.Show("Por favor Ingrese Usuario...!");
                    sw = "1";
                }
                if ((textBox2.Text == "") && (sw == "0"))
                {
                    global::System.Windows.Forms.MessageBox.Show("Por favor Ingrese su Password...!");
                    sw = "1";
                }
                else
                {
                    global::System.Windows.Forms.MessageBox.Show("Usuario no existe...!");
                    sw = "1";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
            }
        
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            proLogin();           
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DateTime FechaSis = DateTime.Now;
            CultureInfo ci = new CultureInfo("Es-Es");
            string DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek)).Substring(0, 1);
            //MessageBox.Show(DIASEMANA);
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox1.Focus();
            textBox1.Text = "JPEREZ";
            textBox2.Text = "123";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) proLogin();
        }
    }
}
