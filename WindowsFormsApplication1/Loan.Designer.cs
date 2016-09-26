namespace WindowsFormsApplication1
{
    partial class Loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.bntFind = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPagado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1079, 462);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(81, 13);
            this.txtFind.MaxLength = 100;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(1073, 20);
            this.txtFind.TabIndex = 30;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Buscar:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEliminar.Location = new System.Drawing.Point(994, 433);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(77, 25);
            this.btnEliminar.TabIndex = 27;
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
            this.btnNuevo.Location = new System.Drawing.Point(1077, 433);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(77, 25);
            this.btnNuevo.TabIndex = 25;
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
            this.detail,
            this.Column1,
            this.Column3,
            this.Balance,
            this.Column2});
            this.gvList.Location = new System.Drawing.Point(12, 69);
            this.gvList.MultiSelect = false;
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.ShowCellErrors = false;
            this.gvList.ShowCellToolTips = false;
            this.gvList.ShowEditingIcon = false;
            this.gvList.ShowRowErrors = false;
            this.gvList.Size = new System.Drawing.Size(1142, 355);
            this.gvList.TabIndex = 24;
            this.gvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvList_CellMouseDoubleClick);
            this.gvList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellMouseLeave);
            this.gvList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvList_CellMouseMove);
            // 
            // bntFind
            // 
            this.bntFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntFind.Image = ((System.Drawing.Image)(resources.GetObject("bntFind.Image")));
            this.bntFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntFind.Location = new System.Drawing.Point(491, 210);
            this.bntFind.Name = "bntFind";
            this.bntFind.Size = new System.Drawing.Size(77, 23);
            this.bntFind.TabIndex = 31;
            this.bntFind.Text = "Buscar";
            this.bntFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntFind.UseVisualStyleBackColor = true;
            this.bntFind.Click += new System.EventHandler(this.bntFind_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnActualizar.Location = new System.Drawing.Point(773, 297);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(77, 25);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(81, 39);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(183, 21);
            this.cmbEmployee.TabIndex = 41;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Empleado:";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenses.Location = new System.Drawing.Point(93, 437);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(17, 17);
            this.lblTotalExpenses.TabIndex = 78;
            this.lblTotalExpenses.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 77;
            this.label6.Text = "Prestado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 79;
            this.label3.Text = "Pagado:";
            // 
            // lblPagado
            // 
            this.lblPagado.AutoSize = true;
            this.lblPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagado.Location = new System.Drawing.Point(321, 437);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Size = new System.Drawing.Size(17, 17);
            this.lblPagado.TabIndex = 80;
            this.lblPagado.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(488, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 81;
            this.label4.Text = "Saldo:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(548, 437);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(17, 17);
            this.lblSaldo.TabIndex = 82;
            this.lblSaldo.Text = "0";
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Seleccione...",
            "Pagado",
            "Por pagar"});
            this.cmbType.Location = new System.Drawing.Point(313, 39);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(183, 21);
            this.cmbType.TabIndex = 84;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "Tipo:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(911, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 25);
            this.button1.TabIndex = 85;
            this.button1.Text = "    Pago";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDate2
            // 
            this.dtpDate2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDate2.Location = new System.Drawing.Point(1040, 39);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(114, 20);
            this.dtpDate2.TabIndex = 87;
            this.dtpDate2.ValueChanged += new System.EventHandler(this.dtpDate2_ValueChanged);
            // 
            // dtpDate1
            // 
            this.dtpDate1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDate1.Location = new System.Drawing.Point(883, 38);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(114, 20);
            this.dtpDate1.TabIndex = 86;
            this.dtpDate1.ValueChanged += new System.EventHandler(this.dtpDate1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(843, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Inicio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1010, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Fin:";
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Identificador";
            this.id.MaxInputLength = 10;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Empleado";
            this.Nombre.MaxInputLength = 100;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 378;
            // 
            // detail
            // 
            this.detail.DataPropertyName = "detail";
            this.detail.HeaderText = "Detalle";
            this.detail.Name = "detail";
            this.detail.ReadOnly = true;
            this.detail.Width = 250;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "amount";
            dataGridViewCellStyle1.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Monto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "paymentTotal";
            dataGridViewCellStyle2.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Pagado";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle3.Format = "N2";
            this.Balance.DefaultCellStyle = dataGridViewCellStyle3;
            this.Balance.HeaderText = "Saldo";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "date";
            this.Column2.HeaderText = "Fecha";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1166, 496);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpDate1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPagado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalExpenses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.gvList);
            this.Controls.Add(this.bntFind);
            this.Controls.Add(this.btnActualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Measure_FormClosed);
            this.Load += new System.EventHandler(this.Measure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button bntFind;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPagado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.DateTimePicker dtpDate1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}