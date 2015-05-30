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

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmListadoProducto : Form
    {
        public ECategoria vCategoria { get; set; }
        public delegate void SeleccionarArticulo(EProducto eProducto);
        public event SeleccionarArticulo EventoSeleccionarArticulo;

        private BProducto bProducto = BProducto.getInstance();
        private BMarca bMarca = BMarca.getInstance();

        public frmListadoProducto()
        {
            InitializeComponent();
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            txtCategoria.Text = this.vCategoria.DesCategoria;

            //carga la lista de marcas
            List<EMarca> marcaList = bMarca.Lista();
            EMarca marca = new EMarca();
            marca.CodMarca = 0;
            marca.DesMarca = "--- TODOS ---";
            marcaList.Insert(0, marca);
            cboMarca.DataSource = marcaList;
            cboMarca.ValueMember = "Codigo";
            cboMarca.DisplayMember = "Descripcion";

            //carga los articulos por categoria
            dataGridView1.DataSource = bProducto.ListarPorCategoria(this.vCategoria.CodCategoria);
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codMarca = Convert.ToInt32(cboMarca.SelectedValue);
                if (codMarca == 0)
                {
                    dataGridView1.DataSource = bProducto.ListarPorCategoria(this.vCategoria.CodCategoria);
                }
                else
                {

                    dataGridView1.DataSource = bProducto.ListarPorCategoriaYMarca(this.vCategoria.CodCategoria, codMarca);
                }
            }
            catch
            {

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                EProducto producto = new EProducto();
                producto.IdProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                producto.CodCategoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                producto.DesCategoria = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                producto.CodMarca = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                producto.DesMarca = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                producto.DescripcionProducto = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                producto.TipoUnidadMedida = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (EventoSeleccionarArticulo != null)
                {
                    EventoSeleccionarArticulo(producto);
                }
            }
            this.Close();
        }

    }
}
