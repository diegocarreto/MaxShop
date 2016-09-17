namespace WindowsFormsApplication1
{
    partial class ClientEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientEdit));
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMunicipality = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtColony = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtForeign = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInside = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Location = new System.Drawing.Point(286, 183);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 36;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Activo:";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(351, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(270, 333);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 32;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(65, 155);
            this.txtState.MaxLength = 30;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(362, 20);
            this.txtState.TabIndex = 91;
            this.txtState.Text = "Estado de mexico";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 104;
            this.label17.Text = "Estado:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 210);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 103;
            this.label16.Text = "Otros:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(65, 181);
            this.txtZipCode.MaxLength = 6;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(141, 20);
            this.txtZipCode.TabIndex = 92;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 184);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 102;
            this.label15.Text = "CP:";
            // 
            // txtMunicipality
            // 
            this.txtMunicipality.Location = new System.Drawing.Point(65, 131);
            this.txtMunicipality.MaxLength = 30;
            this.txtMunicipality.Name = "txtMunicipality";
            this.txtMunicipality.Size = new System.Drawing.Size(362, 20);
            this.txtMunicipality.TabIndex = 90;
            this.txtMunicipality.Text = "Los Reyes Acaquilpa";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 101;
            this.label14.Text = "Municipio:";
            // 
            // txtColony
            // 
            this.txtColony.Location = new System.Drawing.Point(64, 107);
            this.txtColony.MaxLength = 30;
            this.txtColony.Name = "txtColony";
            this.txtColony.Size = new System.Drawing.Size(362, 20);
            this.txtColony.TabIndex = 89;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 100;
            this.label13.Text = "Colonia:";
            // 
            // txtForeign
            // 
            this.txtForeign.Location = new System.Drawing.Point(64, 84);
            this.txtForeign.MaxLength = 10;
            this.txtForeign.Name = "txtForeign";
            this.txtForeign.Size = new System.Drawing.Size(141, 20);
            this.txtForeign.TabIndex = 87;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(238, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "Interior:";
            // 
            // txtInside
            // 
            this.txtInside.Location = new System.Drawing.Point(286, 81);
            this.txtInside.MaxLength = 10;
            this.txtInside.Name = "txtInside";
            this.txtInside.Size = new System.Drawing.Size(141, 20);
            this.txtInside.TabIndex = 88;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 98;
            this.label11.Text = "Exterior:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(64, 60);
            this.txtStreet.MaxLength = 250;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(362, 20);
            this.txtStreet.TabIndex = 86;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(63, 207);
            this.txtOther.MaxLength = 2000;
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(363, 120);
            this.txtOther.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Calle:";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(286, 34);
            this.txtPhone2.MaxLength = 10;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(141, 20);
            this.txtPhone2.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "Telefono 2:";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(65, 34);
            this.txtPhone1.MaxLength = 10;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(141, 20);
            this.txtPhone1.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Telefono 1:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(65, 6);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(362, 20);
            this.txtName.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Nombre:";
            // 
            // ClientEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(436, 361);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMunicipality);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtColony);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtForeign);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtInside);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion Clientes";
            this.Load += new System.EventHandler(this.MeasureEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMunicipality;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtColony;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtForeign;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtInside;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}