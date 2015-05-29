namespace ETNA.SGI.Presentacion.Formularios
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvUsuarios1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lvAccesos = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Cod_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pwd_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filler1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cod_usuario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pwd_usuario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom_usuario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_usuario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_Usuario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filler12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CLIENTES.bmp");
            this.imageList1.Images.SetKeyName(1, "ACCESOS.bmp");
            this.imageList1.Images.SetKeyName(2, "USER.ICO");
            this.imageList1.Images.SetKeyName(3, "AS.ICO");
            this.imageList1.Images.SetKeyName(4, "ASOCIADO.ICO");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(11, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(802, 75);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(785, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Configuración";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(785, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Módulo Exportación";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.dgvUsuarios1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.lvAccesos);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(794, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Accesos";
            this.tabPage3.ToolTipText = "Accesos";
            // 
            // dgvUsuarios1
            // 
            this.dgvUsuarios1.AllowUserToAddRows = false;
            this.dgvUsuarios1.AllowUserToDeleteRows = false;
            this.dgvUsuarios1.AllowUserToOrderColumns = true;
            this.dgvUsuarios1.AllowUserToResizeColumns = false;
            this.dgvUsuarios1.AllowUserToResizeRows = false;
            this.dgvUsuarios1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios1.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsuarios1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_usuario2,
            this.pwd_usuario2,
            this.nom_usuario2,
            this.tipo_usuario2,
            this.Estado_Usuario2,
            this.filler12});
            this.dgvUsuarios1.Location = new System.Drawing.Point(6, 44);
            this.dgvUsuarios1.Name = "dgvUsuarios1";
            this.dgvUsuarios1.ReadOnly = true;
            this.dgvUsuarios1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsuarios1.Size = new System.Drawing.Size(364, 279);
            this.dgvUsuarios1.TabIndex = 52;
            this.dgvUsuarios1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios1_CellContentClick_1);
            this.dgvUsuarios1.SelectionChanged += new System.EventHandler(this.dgvUsuarios1_SelectionChanged);
            // 
            // button5
            // 
            this.button5.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra04;
            this.button5.Location = new System.Drawing.Point(404, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 57);
            this.button5.TabIndex = 50;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra07;
            this.button4.Location = new System.Drawing.Point(343, 339);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 57);
            this.button4.TabIndex = 47;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lvAccesos
            // 
            this.lvAccesos.CheckBoxes = true;
            this.lvAccesos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvAccesos.GridLines = true;
            this.lvAccesos.Location = new System.Drawing.Point(376, 44);
            this.lvAccesos.Name = "lvAccesos";
            this.lvAccesos.Size = new System.Drawing.Size(409, 279);
            this.lvAccesos.TabIndex = 33;
            this.lvAccesos.UseCompatibleStateImageBehavior = false;
            this.lvAccesos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "";
            this.columnHeader3.Text = "Código";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Accesos";
            this.columnHeader4.Width = 300;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.rdb2);
            this.tabPage1.Controls.Add(this.rdb1);
            this.tabPage1.Controls.Add(this.btnConfirmar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtNom);
            this.tabPage1.Controls.Add(this.txtUsu);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnModifica);
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Controls.Add(this.txtPwd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvUsuarios);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.ToolTipText = "Usuarios";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(392, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 29);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tipo :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Enabled = false;
            this.rdb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2.Location = new System.Drawing.Point(539, 111);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(70, 19);
            this.rdb2.TabIndex = 43;
            this.rdb2.Text = "Cliente";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Enabled = false;
            this.rdb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb1.Location = new System.Drawing.Point(458, 111);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(75, 19);
            this.rdb1.TabIndex = 42;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "Usuario";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra07;
            this.btnConfirmar.Location = new System.Drawing.Point(606, 281);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(55, 57);
            this.btnConfirmar.TabIndex = 41;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::ETNA.SGI.Presentacion.Properties.Resources._16__Find_;
            this.btnBuscar.Location = new System.Drawing.Point(751, 146);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 28);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(452, 151);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(293, 20);
            this.txtNom.TabIndex = 37;
            // 
            // txtUsu
            // 
            this.txtUsu.BackColor = System.Drawing.Color.White;
            this.txtUsu.Enabled = false;
            this.txtUsu.Location = new System.Drawing.Point(452, 192);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(144, 20);
            this.txtUsu.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(369, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Nombre :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra04;
            this.btnEliminar.Location = new System.Drawing.Point(545, 281);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(55, 57);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra03;
            this.btnModifica.Location = new System.Drawing.Point(484, 281);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(55, 57);
            this.btnModifica.TabIndex = 34;
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::ETNA.SGI.Presentacion.Properties.Resources.barra01;
            this.btnNuevo.Location = new System.Drawing.Point(423, 281);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(55, 57);
            this.btnNuevo.TabIndex = 33;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.Enabled = false;
            this.txtPwd.Location = new System.Drawing.Point(452, 237);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(144, 20);
            this.txtPwd.TabIndex = 32;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(97, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(583, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "Usuarios Módulo Exportación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(354, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "Password :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Usuario,
            this.Pwd_Usuario,
            this.Nom_Usuario,
            this.Tipo_Usuario,
            this.Estado_Usuario,
            this.Filler1});
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 67);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsuarios.Size = new System.Drawing.Size(339, 336);
            this.dgvUsuarios.TabIndex = 28;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // Cod_Usuario
            // 
            this.Cod_Usuario.DataPropertyName = "Cod_Usuario";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cod_Usuario.DefaultCellStyle = dataGridViewCellStyle5;
            this.Cod_Usuario.HeaderText = "Cod.Usuario";
            this.Cod_Usuario.Name = "Cod_Usuario";
            this.Cod_Usuario.ReadOnly = true;
            this.Cod_Usuario.Width = 80;
            // 
            // Pwd_Usuario
            // 
            this.Pwd_Usuario.DataPropertyName = "Pwd_Usuario";
            this.Pwd_Usuario.HeaderText = "PWD";
            this.Pwd_Usuario.Name = "Pwd_Usuario";
            this.Pwd_Usuario.ReadOnly = true;
            this.Pwd_Usuario.Visible = false;
            // 
            // Nom_Usuario
            // 
            this.Nom_Usuario.DataPropertyName = "Nom_Usuario";
            this.Nom_Usuario.HeaderText = "Nom.Usuario";
            this.Nom_Usuario.Name = "Nom_Usuario";
            this.Nom_Usuario.ReadOnly = true;
            this.Nom_Usuario.Width = 200;
            // 
            // Tipo_Usuario
            // 
            this.Tipo_Usuario.DataPropertyName = "Tipo_Usuario";
            this.Tipo_Usuario.HeaderText = "Tipo";
            this.Tipo_Usuario.Name = "Tipo_Usuario";
            this.Tipo_Usuario.ReadOnly = true;
            this.Tipo_Usuario.Width = 50;
            // 
            // Estado_Usuario
            // 
            this.Estado_Usuario.DataPropertyName = "Estado_Usuario";
            this.Estado_Usuario.HeaderText = "Estado";
            this.Estado_Usuario.Name = "Estado_Usuario";
            this.Estado_Usuario.ReadOnly = true;
            this.Estado_Usuario.Visible = false;
            // 
            // Filler1
            // 
            this.Filler1.DataPropertyName = "Filler1";
            this.Filler1.HeaderText = "Filler1";
            this.Filler1.Name = "Filler1";
            this.Filler1.ReadOnly = true;
            this.Filler1.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(369, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(11, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 454);
            this.tabControl1.TabIndex = 32;
            // 
            // cod_usuario2
            // 
            this.cod_usuario2.DataPropertyName = "cod_usuario";
            this.cod_usuario2.HeaderText = "Código";
            this.cod_usuario2.Name = "cod_usuario2";
            this.cod_usuario2.ReadOnly = true;
            this.cod_usuario2.Width = 80;
            // 
            // pwd_usuario2
            // 
            this.pwd_usuario2.DataPropertyName = "pwd_usuario";
            this.pwd_usuario2.HeaderText = "pwd";
            this.pwd_usuario2.Name = "pwd_usuario2";
            this.pwd_usuario2.ReadOnly = true;
            this.pwd_usuario2.Visible = false;
            // 
            // nom_usuario2
            // 
            this.nom_usuario2.DataPropertyName = "nom_usuario";
            this.nom_usuario2.HeaderText = "Nombre";
            this.nom_usuario2.Name = "nom_usuario2";
            this.nom_usuario2.ReadOnly = true;
            this.nom_usuario2.Width = 210;
            // 
            // tipo_usuario2
            // 
            this.tipo_usuario2.DataPropertyName = "tipo_usuario";
            this.tipo_usuario2.HeaderText = "Tipo";
            this.tipo_usuario2.Name = "tipo_usuario2";
            this.tipo_usuario2.ReadOnly = true;
            this.tipo_usuario2.Width = 50;
            // 
            // Estado_Usuario2
            // 
            this.Estado_Usuario2.DataPropertyName = "Estado_Usuario";
            this.Estado_Usuario2.HeaderText = "Estado";
            this.Estado_Usuario2.Name = "Estado_Usuario2";
            this.Estado_Usuario2.ReadOnly = true;
            this.Estado_Usuario2.Visible = false;
            // 
            // filler12
            // 
            this.filler12.DataPropertyName = "filler1";
            this.filler12.HeaderText = "filler";
            this.filler12.Name = "filler12";
            this.filler12.ReadOnly = true;
            this.filler12.Visible = false;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros de Configuración";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.groupBox6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView lvAccesos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pwd_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filler1;
        public System.Windows.Forms.DataGridView dgvUsuarios1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_usuario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pwd_usuario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom_usuario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_usuario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_Usuario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn filler12;
    }
}