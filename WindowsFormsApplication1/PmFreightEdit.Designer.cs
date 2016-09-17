namespace WindowsFormsApplication1
{
    partial class PmFreightEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PmFreightEdit));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmDestination = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Location = new System.Drawing.Point(272, 322);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(353, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImage
            // 
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.Location = new System.Drawing.Point(434, 509);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 81;
            this.btnImage.Text = "Imagen";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnMap
            // 
            this.btnMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMap.Location = new System.Drawing.Point(172, 322);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(94, 23);
            this.btnMap.TabIndex = 17;
            this.btnMap.Text = "Ver mapa";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 79;
            this.label16.Text = "Otros:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(435, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(739, 301);
            this.webBrowser1.TabIndex = 67;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Viajes completos",
            "Varios viajes",
            "Con otro flete"});
            this.cmbTipo.Location = new System.Drawing.Point(66, 65);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(169, 21);
            this.cmbTipo.TabIndex = 4;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(287, 65);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(141, 20);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Precio:";
            // 
            // txtPrice2
            // 
            this.txtPrice2.BackColor = System.Drawing.Color.White;
            this.txtPrice2.Location = new System.Drawing.Point(287, 38);
            this.txtPrice2.MaxLength = 10;
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.ReadOnly = true;
            this.txtPrice2.Size = new System.Drawing.Size(141, 20);
            this.txtPrice2.TabIndex = 3;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOthers
            // 
            this.txtOthers.BackColor = System.Drawing.Color.White;
            this.txtOthers.Location = new System.Drawing.Point(64, 220);
            this.txtOthers.MaxLength = 2000;
            this.txtOthers.Multiline = true;
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.ReadOnly = true;
            this.txtOthers.Size = new System.Drawing.Size(363, 93);
            this.txtOthers.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Cantidad:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(66, 38);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(169, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Cliente:";
            // 
            // cmDestination
            // 
            this.cmDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmDestination.FormattingEnabled = true;
            this.cmDestination.Location = new System.Drawing.Point(66, 12);
            this.cmDestination.Name = "cmDestination";
            this.cmDestination.Size = new System.Drawing.Size(169, 21);
            this.cmDestination.TabIndex = 0;
            this.cmDestination.SelectedIndexChanged += new System.EventHandler(this.cmDestination_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Flete:";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.Location = new System.Drawing.Point(287, 12);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(141, 20);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.TabStop = false;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Items.AddRange(new object[] {
            "Viajes completos",
            "Varios viajes",
            "Con otro flete"});
            this.cmbClient.Location = new System.Drawing.Point(64, 91);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(334, 21);
            this.cmbClient.TabIndex = 83;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(63, 118);
            this.txtAddress.MaxLength = 2000;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(365, 96);
            this.txtAddress.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Dirección:";
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.Location = new System.Drawing.Point(404, 91);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(24, 21);
            this.btnClient.TabIndex = 86;
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // PmFreightEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(435, 353);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrice2);
            this.Controls.Add(this.txtOthers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmDestination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PmFreightEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fletes";
            this.Load += new System.EventHandler(this.MeasureEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmDestination;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrice2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClient;
    }
}