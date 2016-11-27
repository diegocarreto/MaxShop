namespace WindowsFormsApplication1
{
    partial class PMEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMEdit));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.cbColor = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.wbGetImagen = new System.Windows.Forms.WebBrowser();
            this.txtStockMax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStockMin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbFreight = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cmBrand = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbMeasure2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMeasure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(394, 358);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(475, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbColor
            // 
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbColor.Location = new System.Drawing.Point(484, 228);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(66, 16);
            this.pbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColor.TabIndex = 89;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbColor
            // 
            this.cbColor.AutoSize = true;
            this.cbColor.Location = new System.Drawing.Point(463, 229);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(15, 14);
            this.cbColor.TabIndex = 88;
            this.cbColor.UseVisualStyleBackColor = true;
            this.cbColor.CheckedChanged += new System.EventHandler(this.cbColor_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(429, 228);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 87;
            this.label16.Text = "Color:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(103, 63);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(324, 21);
            this.cmbCompany.TabIndex = 86;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(47, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Negocio:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(575, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 21);
            this.button2.TabIndex = 84;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // wbGetImagen
            // 
            this.wbGetImagen.Location = new System.Drawing.Point(703, 9);
            this.wbGetImagen.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGetImagen.Name = "wbGetImagen";
            this.wbGetImagen.ScriptErrorsSuppressed = true;
            this.wbGetImagen.Size = new System.Drawing.Size(100, 101);
            this.wbGetImagen.TabIndex = 83;
            this.wbGetImagen.Visible = false;
            this.wbGetImagen.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbGetImagen_DocumentCompleted);
            // 
            // txtStockMax
            // 
            this.txtStockMax.CausesValidation = false;
            this.txtStockMax.Location = new System.Drawing.Point(324, 224);
            this.txtStockMax.MaxLength = 29;
            this.txtStockMax.Name = "txtStockMax";
            this.txtStockMax.Size = new System.Drawing.Size(103, 20);
            this.txtStockMax.TabIndex = 82;
            this.txtStockMax.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(237, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 81;
            this.label14.Text = "Stock máximo:";
            // 
            // txtStockMin
            // 
            this.txtStockMin.CausesValidation = false;
            this.txtStockMin.Location = new System.Drawing.Point(106, 224);
            this.txtStockMin.MaxLength = 29;
            this.txtStockMin.Name = "txtStockMin";
            this.txtStockMin.Size = new System.Drawing.Size(103, 20);
            this.txtStockMin.TabIndex = 80;
            this.txtStockMin.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Stock mínimo:";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateCode.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateCode.Image")));
            this.btnGenerateCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateCode.Location = new System.Drawing.Point(430, 197);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateCode.TabIndex = 78;
            this.btnGenerateCode.Text = "   Generador";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 37);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(447, 20);
            this.txtName.TabIndex = 77;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 76;
            this.label11.Text = "Alias:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(103, 170);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(324, 21);
            this.cmbLocation.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Ubicacion:";
            // 
            // cbFreight
            // 
            this.cbFreight.AutoSize = true;
            this.cbFreight.Checked = true;
            this.cbFreight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFreight.Location = new System.Drawing.Point(181, 353);
            this.cbFreight.Name = "cbFreight";
            this.cbFreight.Size = new System.Drawing.Size(15, 14);
            this.cbFreight.TabIndex = 73;
            this.cbFreight.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(142, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "Flete:";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(103, 144);
            this.txtCodigoProveedor.MaxLength = 29;
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(324, 20);
            this.txtCodigoProveedor.TabIndex = 56;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Código Proveedor:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CausesValidation = false;
            this.txtCodigo.Location = new System.Drawing.Point(106, 199);
            this.txtCodigo.MaxLength = 29;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(321, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // cmBrand
            // 
            this.cmBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBrand.FormattingEnabled = true;
            this.cmBrand.Location = new System.Drawing.Point(103, 90);
            this.cmBrand.Name = "cmBrand";
            this.cmBrand.Size = new System.Drawing.Size(324, 21);
            this.cmBrand.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Código de Barras:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Marca:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Precio:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(103, 118);
            this.txtPrice.MaxLength = 5;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(324, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.cmbMeasure2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbMeasure);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Propiedad 2";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(508, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 21);
            this.button4.TabIndex = 52;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "# de B en A:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(98, 73);
            this.txtAmount.MaxLength = 29;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(434, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // cmbMeasure2
            // 
            this.cmbMeasure2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMeasure2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMeasure2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasure2.FormattingEnabled = true;
            this.cmbMeasure2.Location = new System.Drawing.Point(98, 46);
            this.cmbMeasure2.Name = "cmbMeasure2";
            this.cmbMeasure2.Size = new System.Drawing.Size(434, 21);
            this.cmbMeasure2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "B:";
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMeasure.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.Location = new System.Drawing.Point(98, 22);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.Size = new System.Drawing.Size(404, 21);
            this.cmbMeasure.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "A:";
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPhoto.Location = new System.Drawing.Point(430, 63);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(120, 128);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 44;
            this.pbPhoto.TabStop = false;
            this.pbPhoto.Click += new System.EventHandler(this.pbPhoto_Click);
            // 
            // cmbProduct
            // 
            this.cmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(103, 12);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(447, 21);
            this.cmbProduct.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Producto:";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Location = new System.Drawing.Point(112, 353);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 8;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Activo:";
            // 
            // PMEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(557, 393);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.wbGetImagen);
            this.Controls.Add(this.txtStockMax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtStockMin);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbFreight);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cmBrand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion Producto";
            this.Load += new System.EventHandler(this.PMEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.ComboBox cmBrand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMeasure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMeasure2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.CheckBox cbFreight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStockMin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtStockMax;
        private System.Windows.Forms.WebBrowser wbGetImagen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox cbColor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pbColor;
    }
}