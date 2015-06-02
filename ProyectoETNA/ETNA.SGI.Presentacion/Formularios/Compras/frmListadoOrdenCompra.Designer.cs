namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    partial class frmListadoOrdenCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodOC = new System.Windows.Forms.TextBox();
            this.txtCodReq = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.dtGridOC = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerarOC = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.codOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codRequerimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lugarEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modificar = new System.Windows.Forms.DataGridViewImageColumn();
            this.anular = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOC)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(10, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(692, 49);
            this.groupBox6.TabIndex = 100;
            this.groupBox6.TabStop = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(677, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Lista de Órdenes de Compra";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(17, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(376, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(177, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Requerimiento:";
            // 
            // txtCodOC
            // 
            this.txtCodOC.Location = new System.Drawing.Point(79, 77);
            this.txtCodOC.Name = "txtCodOC";
            this.txtCodOC.Size = new System.Drawing.Size(79, 20);
            this.txtCodOC.TabIndex = 104;
            this.txtCodOC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodOC_KeyPress);
            // 
            // txtCodReq
            // 
            this.txtCodReq.Location = new System.Drawing.Point(271, 77);
            this.txtCodReq.Name = "txtCodReq";
            this.txtCodReq.Size = new System.Drawing.Size(79, 20);
            this.txtCodReq.TabIndex = 105;
            this.txtCodReq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodReq_KeyPress);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "GENERADA",
            "ANULADA"});
            this.cboEstado.Location = new System.Drawing.Point(431, 77);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 21);
            this.cboEstado.TabIndex = 106;
            // 
            // dtGridOC
            // 
            this.dtGridOC.AllowUserToAddRows = false;
            this.dtGridOC.AllowUserToDeleteRows = false;
            this.dtGridOC.AllowUserToResizeColumns = false;
            this.dtGridOC.AllowUserToResizeRows = false;
            this.dtGridOC.BackgroundColor = System.Drawing.Color.White;
            this.dtGridOC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dtGridOC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtGridOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codOrdenCompra,
            this.codRequerimiento,
            this.codCotizacion,
            this.razonSocial,
            this.desEstado,
            this.fechaEntrega,
            this.lugarEntrega,
            this.codEstado,
            this.observacion,
            this.modificar,
            this.anular});
            this.dtGridOC.Location = new System.Drawing.Point(12, 133);
            this.dtGridOC.Name = "dtGridOC";
            this.dtGridOC.ReadOnly = true;
            this.dtGridOC.RowHeadersVisible = false;
            this.dtGridOC.Size = new System.Drawing.Size(686, 229);
            this.dtGridOC.TabIndex = 107;
            this.dtGridOC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridOC_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerarOC);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(273, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 81);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // btnGenerarOC
            // 
            this.btnGenerarOC.Image = global::ETNA.SGI.Presentacion.Properties.Resources.FACTURAR12;
            this.btnGenerarOC.Location = new System.Drawing.Point(11, 18);
            this.btnGenerarOC.Name = "btnGenerarOC";
            this.btnGenerarOC.Size = new System.Drawing.Size(81, 57);
            this.btnGenerarOC.TabIndex = 6;
            this.btnGenerarOC.Text = "Generar OC";
            this.btnGenerarOC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarOC.UseVisualStyleBackColor = true;
            this.btnGenerarOC.Click += new System.EventHandler(this.btnGenerarOC_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::ETNA.SGI.Presentacion.Properties.Resources.ELIMINA;
            this.btnClose.Location = new System.Drawing.Point(98, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 57);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Buscar;
            this.button1.Location = new System.Drawing.Point(584, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 49);
            this.button1.TabIndex = 108;
            this.button1.Text = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codOrdenCompra
            // 
            this.codOrdenCompra.DataPropertyName = "codOrdenCompra";
            this.codOrdenCompra.HeaderText = "Código";
            this.codOrdenCompra.Name = "codOrdenCompra";
            this.codOrdenCompra.ReadOnly = true;
            this.codOrdenCompra.Width = 60;
            // 
            // codRequerimiento
            // 
            this.codRequerimiento.DataPropertyName = "codRequerimiento";
            this.codRequerimiento.HeaderText = "Requerimiento";
            this.codRequerimiento.Name = "codRequerimiento";
            this.codRequerimiento.ReadOnly = true;
            this.codRequerimiento.Width = 80;
            // 
            // codCotizacion
            // 
            this.codCotizacion.DataPropertyName = "codCotizacion";
            this.codCotizacion.HeaderText = "Cotización";
            this.codCotizacion.Name = "codCotizacion";
            this.codCotizacion.ReadOnly = true;
            this.codCotizacion.Width = 60;
            // 
            // razonSocial
            // 
            this.razonSocial.DataPropertyName = "razonSocial";
            this.razonSocial.HeaderText = "Proveedor";
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.ReadOnly = true;
            // 
            // desEstado
            // 
            this.desEstado.DataPropertyName = "desEstado";
            this.desEstado.HeaderText = "Estado";
            this.desEstado.Name = "desEstado";
            this.desEstado.ReadOnly = true;
            // 
            // fechaEntrega
            // 
            this.fechaEntrega.DataPropertyName = "fechaEntrega";
            this.fechaEntrega.HeaderText = "Fecha Entrega";
            this.fechaEntrega.Name = "fechaEntrega";
            this.fechaEntrega.ReadOnly = true;
            // 
            // lugarEntrega
            // 
            this.lugarEntrega.DataPropertyName = "lugarEntrega";
            this.lugarEntrega.HeaderText = "Lugar Entrega";
            this.lugarEntrega.Name = "lugarEntrega";
            this.lugarEntrega.ReadOnly = true;
            // 
            // codEstado
            // 
            this.codEstado.DataPropertyName = "codEstado";
            this.codEstado.HeaderText = "codEstado";
            this.codEstado.Name = "codEstado";
            this.codEstado.ReadOnly = true;
            this.codEstado.Visible = false;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "Observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Visible = false;
            // 
            // modificar
            // 
            this.modificar.DataPropertyName = "modificar";
            this.modificar.HeaderText = "";
            this.modificar.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Edit;
            this.modificar.Name = "modificar";
            this.modificar.ReadOnly = true;
            this.modificar.Width = 40;
            // 
            // anular
            // 
            this.anular.DataPropertyName = "anular";
            this.anular.HeaderText = "";
            this.anular.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Cancel_Red_mini;
            this.anular.Name = "anular";
            this.anular.ReadOnly = true;
            this.anular.Width = 40;
            // 
            // frmListadoOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtGridOC);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.txtCodReq);
            this.Controls.Add(this.txtCodOC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.MaximizeBox = false;
            this.Name = "frmListadoOrdenCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Órdenes de Compra";
            this.Load += new System.EventHandler(this.frmListadoOrdenCompra_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodOC;
        private System.Windows.Forms.TextBox txtCodReq;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.DataGridView dtGridOC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerarOC;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn codRequerimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn lugarEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewImageColumn modificar;
        private System.Windows.Forms.DataGridViewImageColumn anular;

    }
}