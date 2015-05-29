namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    partial class frmBusquedaRequerimiento
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaRequerimiento));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRequerimiento = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asociar = new System.Windows.Forms.DataGridViewImageColumn();
            this.CLI_CAB_REQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINO_CAB_REQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAIS_CAB_REQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequerimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTotal);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(727, 75);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTotal.Location = new System.Drawing.Point(6, 41);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(712, 29);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "Búsqueda de Requerimiento";
            this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(712, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Módulo Exportación";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button1);
            this.groupBox11.Controls.Add(this.btnBuscar);
            this.groupBox11.Controls.Add(this.txtRazon);
            this.groupBox11.Controls.Add(this.txtCod);
            this.groupBox11.Controls.Add(this.dtDesde);
            this.groupBox11.Controls.Add(this.dtHasta);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.Navy;
            this.groupBox11.Location = new System.Drawing.Point(12, 93);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(727, 91);
            this.groupBox11.TabIndex = 85;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Datos del Requerimiento Asociado";
            // 
            // button1
            // 
            this.button1.Image = global::ETNA.SGI.Presentacion.Properties.Resources.undo;
            this.button1.Location = new System.Drawing.Point(462, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 92;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.button1, "Mostrar Todos");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Buscar;
            this.btnBuscar.Location = new System.Drawing.Point(429, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 28);
            this.btnBuscar.TabIndex = 91;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(120, 58);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(302, 20);
            this.txtRazon.TabIndex = 89;
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(120, 27);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(104, 20);
            this.txtCod.TabIndex = 88;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(576, 24);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(126, 20);
            this.dtDesde.TabIndex = 87;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(576, 55);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(126, 20);
            this.dtHasta.TabIndex = 86;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(462, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 18);
            this.label17.TabIndex = 15;
            this.label17.Text = "Hasta :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(462, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 18);
            this.label15.TabIndex = 13;
            this.label15.Text = "Desde :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Razón Social :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cod.Req :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvRequerimiento
            // 
            this.dgvRequerimiento.AllowUserToAddRows = false;
            this.dgvRequerimiento.AllowUserToDeleteRows = false;
            this.dgvRequerimiento.AllowUserToResizeColumns = false;
            this.dgvRequerimiento.AllowUserToResizeRows = false;
            this.dgvRequerimiento.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequerimiento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvRequerimiento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRequerimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequerimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.razon,
            this.Destino,
            this.fecha1,
            this.fecha2,
            this.Asociar,
            this.CLI_CAB_REQ,
            this.DESTINO_CAB_REQ,
            this.DIRECCION,
            this.PAIS,
            this.RUC,
            this.PAIS_CAB_REQ});
            this.dgvRequerimiento.Location = new System.Drawing.Point(12, 190);
            this.dgvRequerimiento.Name = "dgvRequerimiento";
            this.dgvRequerimiento.ReadOnly = true;
            this.dgvRequerimiento.RowHeadersVisible = false;
            this.dgvRequerimiento.Size = new System.Drawing.Size(727, 286);
            this.dgvRequerimiento.TabIndex = 91;
            this.dgvRequerimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Asociar";
            this.dataGridViewImageColumn1.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Filter;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "COD_CAB_REQ";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Cod.Req";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // razon
            // 
            this.razon.DataPropertyName = "RAZON_SOCIAL";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.razon.DefaultCellStyle = dataGridViewCellStyle2;
            this.razon.HeaderText = "Razón social";
            this.razon.Name = "razon";
            this.razon.ReadOnly = true;
            this.razon.Width = 200;
            // 
            // Destino
            // 
            this.Destino.DataPropertyName = "NOM_PAIS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Destino.DefaultCellStyle = dataGridViewCellStyle3;
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            this.Destino.Width = 120;
            // 
            // fecha1
            // 
            this.fecha1.DataPropertyName = "Fec_Reg_Cab_Req";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "0000/00/00";
            dataGridViewCellStyle4.NullValue = null;
            this.fecha1.DefaultCellStyle = dataGridViewCellStyle4;
            this.fecha1.HeaderText = "Fecha Req.";
            this.fecha1.Name = "fecha1";
            this.fecha1.ReadOnly = true;
            // 
            // fecha2
            // 
            this.fecha2.DataPropertyName = "Fec_Esp_Cab_Req";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "0000/00/00";
            dataGridViewCellStyle5.NullValue = null;
            this.fecha2.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecha2.HeaderText = "Fecha Esperada";
            this.fecha2.Name = "fecha2";
            this.fecha2.ReadOnly = true;
            this.fecha2.Width = 120;
            // 
            // Asociar
            // 
            this.Asociar.HeaderText = "Asociar";
            this.Asociar.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Filter;
            this.Asociar.Name = "Asociar";
            this.Asociar.ReadOnly = true;
            this.Asociar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CLI_CAB_REQ
            // 
            this.CLI_CAB_REQ.DataPropertyName = "CLI_CAB_REQ";
            this.CLI_CAB_REQ.HeaderText = "1";
            this.CLI_CAB_REQ.Name = "CLI_CAB_REQ";
            this.CLI_CAB_REQ.ReadOnly = true;
            this.CLI_CAB_REQ.Visible = false;
            // 
            // DESTINO_CAB_REQ
            // 
            this.DESTINO_CAB_REQ.DataPropertyName = "DESTINO_CAB_REQ";
            this.DESTINO_CAB_REQ.HeaderText = "2";
            this.DESTINO_CAB_REQ.Name = "DESTINO_CAB_REQ";
            this.DESTINO_CAB_REQ.ReadOnly = true;
            this.DESTINO_CAB_REQ.Visible = false;
            // 
            // DIRECCION
            // 
            this.DIRECCION.DataPropertyName = "DIRECCION";
            this.DIRECCION.HeaderText = "3";
            this.DIRECCION.Name = "DIRECCION";
            this.DIRECCION.ReadOnly = true;
            this.DIRECCION.Visible = false;
            // 
            // PAIS
            // 
            this.PAIS.DataPropertyName = "PAIS";
            this.PAIS.HeaderText = "4";
            this.PAIS.Name = "PAIS";
            this.PAIS.ReadOnly = true;
            this.PAIS.Visible = false;
            // 
            // RUC
            // 
            this.RUC.DataPropertyName = "RUC";
            this.RUC.HeaderText = "5";
            this.RUC.Name = "RUC";
            this.RUC.ReadOnly = true;
            this.RUC.Visible = false;
            // 
            // PAIS_CAB_REQ
            // 
            this.PAIS_CAB_REQ.DataPropertyName = "PAIS_CAB_REQ";
            this.PAIS_CAB_REQ.HeaderText = "PAIS_CAB_REQ";
            this.PAIS_CAB_REQ.Name = "PAIS_CAB_REQ";
            this.PAIS_CAB_REQ.ReadOnly = true;
            this.PAIS_CAB_REQ.Visible = false;
            // 
            // frmBusquedaRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 481);
            this.Controls.Add(this.dgvRequerimiento);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBusquedaRequerimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Requerimiento";
            this.Load += new System.EventHandler(this.frmBusquedaRequerimiento_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequerimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRequerimiento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha2;
        private System.Windows.Forms.DataGridViewImageColumn Asociar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_CAB_REQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINO_CAB_REQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAIS_CAB_REQ;
    }
}