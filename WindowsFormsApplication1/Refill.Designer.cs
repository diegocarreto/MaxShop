namespace WindowsFormsApplication1
{
    partial class Refill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Refill));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCode2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlRecargas = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbFolio = new System.Windows.Forms.CheckBox();
            this.lblTotalLetter = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.cmbAmount = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.btnRecharging = new System.Windows.Forms.Button();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlRecargas.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.label8);
            this.pnlLogin.Controls.Add(this.txtUser);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.btnAccept);
            this.pnlLogin.Controls.Add(this.txtCode);
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(197, 157);
            this.pnlLogin.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Código:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 3);
            this.txtUser.MaxLength = 10;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(116, 20);
            this.txtUser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Captcha:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 29);
            this.txtPassword.MaxLength = 12;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(116, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña:";
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(106, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(83, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "  Entrar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(73, 98);
            this.txtCode.MaxLength = 4;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(116, 20);
            this.txtCode.TabIndex = 4;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(73, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtCode2
            // 
            this.txtCode2.Location = new System.Drawing.Point(34, 414);
            this.txtCode2.MaxLength = 5;
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.Size = new System.Drawing.Size(82, 20);
            this.txtCode2.TabIndex = 5;
            this.txtCode2.TabStop = false;
            this.txtCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(34, 371);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pnlRecargas
            // 
            this.pnlRecargas.Controls.Add(this.label15);
            this.pnlRecargas.Controls.Add(this.txtFolio);
            this.pnlRecargas.Controls.Add(this.label14);
            this.pnlRecargas.Controls.Add(this.cbFolio);
            this.pnlRecargas.Controls.Add(this.lblTotalLetter);
            this.pnlRecargas.Controls.Add(this.btnView);
            this.pnlRecargas.Controls.Add(this.btnClear);
            this.pnlRecargas.Controls.Add(this.txtTotal);
            this.pnlRecargas.Controls.Add(this.label13);
            this.pnlRecargas.Controls.Add(this.txtCambio);
            this.pnlRecargas.Controls.Add(this.label7);
            this.pnlRecargas.Controls.Add(this.label12);
            this.pnlRecargas.Controls.Add(this.txtPago);
            this.pnlRecargas.Controls.Add(this.cmbAmount);
            this.pnlRecargas.Controls.Add(this.cmbCompany);
            this.pnlRecargas.Controls.Add(this.txtAmount);
            this.pnlRecargas.Controls.Add(this.txtConfirm);
            this.pnlRecargas.Controls.Add(this.label6);
            this.pnlRecargas.Controls.Add(this.txtPhone);
            this.pnlRecargas.Controls.Add(this.label10);
            this.pnlRecargas.Controls.Add(this.label5);
            this.pnlRecargas.Controls.Add(this.label4);
            this.pnlRecargas.Controls.Add(this.label9);
            this.pnlRecargas.Controls.Add(this.label11);
            this.pnlRecargas.Controls.Add(this.txtSaldoActual);
            this.pnlRecargas.Controls.Add(this.btnRecharging);
            this.pnlRecargas.Location = new System.Drawing.Point(12, 12);
            this.pnlRecargas.Name = "pnlRecargas";
            this.pnlRecargas.Size = new System.Drawing.Size(771, 353);
            this.pnlRecargas.TabIndex = 24;
            this.pnlRecargas.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(590, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 24);
            this.label15.TabIndex = 63;
            this.label15.Text = "Folio:";
            // 
            // txtFolio
            // 
            this.txtFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFolio.Enabled = false;
            this.txtFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(653, 151);
            this.txtFolio.MaxLength = 6;
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(105, 29);
            this.txtFolio.TabIndex = 5;
            this.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(142, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 24);
            this.label14.TabIndex = 61;
            this.label14.Text = "Solo Registro:";
            // 
            // cbFolio
            // 
            this.cbFolio.AutoSize = true;
            this.cbFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cbFolio.Location = new System.Drawing.Point(275, 163);
            this.cbFolio.Name = "cbFolio";
            this.cbFolio.Size = new System.Drawing.Size(15, 14);
            this.cbFolio.TabIndex = 4;
            this.cbFolio.UseVisualStyleBackColor = true;
            this.cbFolio.CheckedChanged += new System.EventHandler(this.cbFolio_CheckedChanged);
            // 
            // lblTotalLetter
            // 
            this.lblTotalLetter.AutoSize = true;
            this.lblTotalLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLetter.Location = new System.Drawing.Point(112, 263);
            this.lblTotalLetter.Name = "lblTotalLetter";
            this.lblTotalLetter.Size = new System.Drawing.Size(202, 20);
            this.lblTotalLetter.TabIndex = 59;
            this.lblTotalLetter.Text = "Cero Pesos 00/100 M.N.";
            // 
            // btnView
            // 
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(415, 288);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(105, 49);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "Ver";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(526, 288);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 49);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "  Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(653, 186);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(105, 29);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(591, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 24);
            this.label13.TabIndex = 40;
            this.label13.Text = "Total:";
            // 
            // txtCambio
            // 
            this.txtCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCambio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.Location = new System.Drawing.Point(653, 223);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(105, 29);
            this.txtCambio.TabIndex = 9;
            this.txtCambio.TabStop = false;
            this.txtCambio.Text = "0.00";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(567, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 38;
            this.label7.Text = "Cambio:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(210, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "Pago:";
            // 
            // txtPago
            // 
            this.txtPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago.Location = new System.Drawing.Point(275, 221);
            this.txtPago.MaxLength = 9;
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(105, 29);
            this.txtPago.TabIndex = 8;
            this.txtPago.Text = "0.00";
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // cmbAmount
            // 
            this.cmbAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAmount.FormattingEnabled = true;
            this.cmbAmount.Location = new System.Drawing.Point(116, 77);
            this.cmbAmount.Name = "cmbAmount";
            this.cmbAmount.Size = new System.Drawing.Size(642, 24);
            this.cmbAmount.TabIndex = 1;
            this.cmbAmount.SelectedIndexChanged += new System.EventHandler(this.cmbAmount_SelectedIndexChanged);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(116, 41);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(642, 30);
            this.cmbCompany.TabIndex = 0;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(275, 186);
            this.txtAmount.MaxLength = 100;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(105, 29);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtConfirm
            // 
            this.txtConfirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.Location = new System.Drawing.Point(494, 116);
            this.txtConfirm.MaxLength = 10;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(264, 29);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 24);
            this.label6.TabIndex = 31;
            this.label6.Text = "Confirmar:";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(116, 116);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(264, 29);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 24);
            this.label10.TabIndex = 30;
            this.label10.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 24);
            this.label5.TabIndex = 29;
            this.label5.Text = "Monto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 24);
            this.label4.TabIndex = 28;
            this.label4.Text = "Montos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "Compañia:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(47, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 24);
            this.label11.TabIndex = 26;
            this.label11.Text = "Saldo:";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSaldoActual.BackColor = System.Drawing.Color.White;
            this.txtSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoActual.Location = new System.Drawing.Point(116, 6);
            this.txtSaldoActual.MaxLength = 100;
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.ReadOnly = true;
            this.txtSaldoActual.Size = new System.Drawing.Size(642, 29);
            this.txtSaldoActual.TabIndex = 26;
            this.txtSaldoActual.TabStop = false;
            // 
            // btnRecharging
            // 
            this.btnRecharging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecharging.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecharging.Image = ((System.Drawing.Image)(resources.GetObject("btnRecharging.Image")));
            this.btnRecharging.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecharging.Location = new System.Drawing.Point(645, 288);
            this.btnRecharging.Name = "btnRecharging";
            this.btnRecharging.Size = new System.Drawing.Size(113, 49);
            this.btnRecharging.TabIndex = 10;
            this.btnRecharging.Text = "Recargar";
            this.btnRecharging.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecharging.UseVisualStyleBackColor = true;
            this.btnRecharging.Click += new System.EventHandler(this.btnRecharging_Click);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(789, 9);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(421, 314);
            this.webBrowser2.TabIndex = 22;
            this.webBrowser2.Visible = false;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(789, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(421, 311);
            this.webBrowser1.TabIndex = 21;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Refill
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 370);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlRecargas);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtCode2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Refill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recargas";
            this.Load += new System.EventHandler(this.Measure_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlRecargas.ResumeLayout(false);
            this.pnlRecargas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel pnlRecargas;
        private System.Windows.Forms.Button btnRecharging;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCode2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbAmount;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblTotalLetter;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbFolio;
        private System.Windows.Forms.TextBox txtConfirm;


    }
}