namespace WindowsFormsApplication1
{
    partial class PM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM));
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbTypeLike = new System.Windows.Forms.ComboBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmBrand = new System.Windows.Forms.ComboBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntFind = new System.Windows.Forms.Button();
            this.bnCopiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.svdReportStock = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1169, 485);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 23);
            this.btnExit.TabIndex = 36;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbTypeLike
            // 
            this.cmbTypeLike.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTypeLike.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeLike.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeLike.FormattingEnabled = true;
            this.cmbTypeLike.Location = new System.Drawing.Point(1158, 12);
            this.cmbTypeLike.Name = "cmbTypeLike";
            this.cmbTypeLike.Size = new System.Drawing.Size(88, 21);
            this.cmbTypeLike.TabIndex = 65;
            this.cmbTypeLike.SelectedValueChanged += new System.EventHandler(this.cmbTypeLike_SelectedValueChanged);
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(347, 37);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(183, 21);
            this.cmbGroup.TabIndex = 64;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 63;
            this.label5.Text = "Grupo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(536, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "Marca:";
            // 
            // cmBrand
            // 
            this.cmBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBrand.FormattingEnabled = true;
            this.cmBrand.Location = new System.Drawing.Point(599, 37);
            this.cmBrand.Name = "cmBrand";
            this.cmBrand.Size = new System.Drawing.Size(183, 21);
            this.cmBrand.TabIndex = 61;
            this.cmBrand.SelectedIndexChanged += new System.EventHandler(this.cmBrand_SelectedIndexChanged);
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(884, 37);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(177, 21);
            this.cmbPaymentType.TabIndex = 60;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
            this.cmbPaymentType.SelectedValueChanged += new System.EventHandler(this.cmbPaymentType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(788, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "C / Imagen:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1003, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 58;
            this.button1.Text = "Wizard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(158, 456);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(17, 17);
            this.lblTotal.TabIndex = 57;
            this.lblTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Productos totales:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(90, 11);
            this.txtFind.MaxLength = 100;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(1062, 20);
            this.txtFind.TabIndex = 38;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Buscar:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEliminar.Location = new System.Drawing.Point(920, 456);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(77, 23);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(1169, 456);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(77, 23);
            this.btnNuevo.TabIndex = 33;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.AllowUserToResizeColumns = false;
            this.gvList.AllowUserToResizeRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nombre,
            this.alias,
            this.Activo,
            this.Código,
            this.Column2,
            this.Imagen,
            this.Column4,
            this.Column3,
            this.Column1});
            this.gvList.Location = new System.Drawing.Point(12, 67);
            this.gvList.MultiSelect = false;
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.ShowCellErrors = false;
            this.gvList.ShowCellToolTips = false;
            this.gvList.ShowEditingIcon = false;
            this.gvList.ShowRowErrors = false;
            this.gvList.Size = new System.Drawing.Size(1234, 383);
            this.gvList.TabIndex = 32;
            this.gvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvList_CellMouseDoubleClick);
            this.gvList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellMouseLeave);
            this.gvList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvList_CellMouseMove);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Identificador";
            this.id.MaxInputLength = 10;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MaxInputLength = 100;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 365;
            // 
            // alias
            // 
            this.alias.DataPropertyName = "alias";
            this.alias.HeaderText = "Alias";
            this.alias.Name = "alias";
            this.alias.ReadOnly = true;
            this.alias.Width = 240;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Aux";
            this.Activo.HeaderText = "Precio";
            this.Activo.MaxInputLength = 2;
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Código
            // 
            this.Código.DataPropertyName = "barcode";
            this.Código.HeaderText = "Código de Barras";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CodeVendor";
            this.Column2.HeaderText = "Código Proveedor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "HasImage";
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Width = 50;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Location";
            this.Column4.HeaderText = "Ubicacion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FreightString";
            this.Column3.HeaderText = "Flete";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Aux2";
            this.Column1.HeaderText = "Activo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // bntFind
            // 
            this.bntFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntFind.Image = ((System.Drawing.Image)(resources.GetObject("bntFind.Image")));
            this.bntFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntFind.Location = new System.Drawing.Point(963, 273);
            this.bntFind.Name = "bntFind";
            this.bntFind.Size = new System.Drawing.Size(77, 23);
            this.bntFind.TabIndex = 39;
            this.bntFind.Text = "Buscar";
            this.bntFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntFind.UseVisualStyleBackColor = true;
            this.bntFind.Click += new System.EventHandler(this.bntFind_Click);
            // 
            // bnCopiar
            // 
            this.bnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("bnCopiar.Image")));
            this.bnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnCopiar.Location = new System.Drawing.Point(1086, 456);
            this.bnCopiar.Name = "bnCopiar";
            this.bnCopiar.Size = new System.Drawing.Size(77, 23);
            this.bnCopiar.TabIndex = 67;
            this.bnCopiar.Text = "Copiar";
            this.bnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bnCopiar.UseVisualStyleBackColor = true;
            this.bnCopiar.Click += new System.EventHandler(this.bnCopiar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Negocio:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(90, 38);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(183, 21);
            this.cmbCompany.TabIndex = 69;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(839, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 70;
            this.button2.Text = "   Precios";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // PM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1258, 520);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bnCopiar);
            this.Controls.Add(this.cmbTypeLike);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmBrand);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.gvList);
            this.Controls.Add(this.bntFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.PM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.ComboBox cmBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbTypeLike;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn alias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button bnCopiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog svdReportStock;

    }
}