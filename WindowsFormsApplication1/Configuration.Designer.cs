namespace WindowsFormsApplication1
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMyIp = new System.Windows.Forms.TextBox();
            this.btnGetIp = new System.Windows.Forms.Button();
            this.btnTestSqlServer = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBrowserR = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCommissionR = new System.Windows.Forms.TextBox();
            this.txtPasswordR = new System.Windows.Forms.TextBox();
            this.txtUserR = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtClientDefault = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.cbStock = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.almacenamiento = new System.Windows.Forms.TabPage();
            this.btnLocalMac = new System.Windows.Forms.Button();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnMac = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtMyMac = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.txtConfirmDB = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.general = new System.Windows.Forms.TabPage();
            this.txtTimeUpdateSale = new System.Windows.Forms.TextBox();
            this.cbWizard = new System.Windows.Forms.CheckBox();
            this.cmMenuTruper = new System.Windows.Forms.CheckBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.impresion = new System.Windows.Forms.TabPage();
            this.txtLEPrint = new System.Windows.Forms.TextBox();
            this.txtSANPrint = new System.Windows.Forms.TextBox();
            this.txtPhonePrint = new System.Windows.Forms.TextBox();
            this.txtNamePrint = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.recargas = new System.Windows.Forms.TabPage();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ventas = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.almacenamiento.SuspendLayout();
            this.general.SuspendLayout();
            this.impresion.SuspendLayout();
            this.recargas.SuspendLayout();
            this.ventas.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(102, 15);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(341, 21);
            this.cmbPrinters.TabIndex = 0;
            this.cmbPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Impresora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Servidor:";
            // 
            // txtIpServer
            // 
            this.txtIpServer.Location = new System.Drawing.Point(94, 117);
            this.txtIpServer.MaxLength = 15;
            this.txtIpServer.Name = "txtIpServer";
            this.txtIpServer.Size = new System.Drawing.Size(268, 20);
            this.txtIpServer.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "IP del equipo:";
            // 
            // txtMyIp
            // 
            this.txtMyIp.BackColor = System.Drawing.Color.White;
            this.txtMyIp.Location = new System.Drawing.Point(94, 15);
            this.txtMyIp.MaxLength = 15;
            this.txtMyIp.Name = "txtMyIp";
            this.txtMyIp.ReadOnly = true;
            this.txtMyIp.Size = new System.Drawing.Size(268, 20);
            this.txtMyIp.TabIndex = 37;
            // 
            // btnGetIp
            // 
            this.btnGetIp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetIp.Image = ((System.Drawing.Image)(resources.GetObject("btnGetIp.Image")));
            this.btnGetIp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetIp.Location = new System.Drawing.Point(368, 13);
            this.btnGetIp.Name = "btnGetIp";
            this.btnGetIp.Size = new System.Drawing.Size(75, 23);
            this.btnGetIp.TabIndex = 43;
            this.btnGetIp.Text = "Obtener";
            this.btnGetIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetIp.UseVisualStyleBackColor = true;
            this.btnGetIp.Click += new System.EventHandler(this.btnGetIp_Click);
            // 
            // btnTestSqlServer
            // 
            this.btnTestSqlServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestSqlServer.Image = ((System.Drawing.Image)(resources.GetObject("btnTestSqlServer.Image")));
            this.btnTestSqlServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestSqlServer.Location = new System.Drawing.Point(368, 247);
            this.btnTestSqlServer.Name = "btnTestSqlServer";
            this.btnTestSqlServer.Size = new System.Drawing.Size(75, 23);
            this.btnTestSqlServer.TabIndex = 42;
            this.btnTestSqlServer.Text = "    Probar";
            this.btnTestSqlServer.UseVisualStyleBackColor = true;
            this.btnTestSqlServer.Click += new System.EventHandler(this.btnTestSqlServer_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 195);
            this.txtPassword.MaxLength = 15;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(349, 20);
            this.txtPassword.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Contraseña:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(94, 170);
            this.txtUser.MaxLength = 15;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(349, 20);
            this.txtUser.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Usuario:";
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(94, 143);
            this.txtCatalog.MaxLength = 15;
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(349, 20);
            this.txtCatalog.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Catalogo:";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(391, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
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
            this.btnAccept.Location = new System.Drawing.Point(310, 323);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 39;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Ver Navegador:";
            // 
            // cbBrowserR
            // 
            this.cbBrowserR.AutoSize = true;
            this.cbBrowserR.Location = new System.Drawing.Point(94, 116);
            this.cbBrowserR.Name = "cbBrowserR";
            this.cbBrowserR.Size = new System.Drawing.Size(15, 14);
            this.cbBrowserR.TabIndex = 45;
            this.cbBrowserR.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Usuario:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Contraseña:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Comisión:";
            // 
            // txtCommissionR
            // 
            this.txtCommissionR.Location = new System.Drawing.Point(94, 90);
            this.txtCommissionR.MaxLength = 15;
            this.txtCommissionR.Name = "txtCommissionR";
            this.txtCommissionR.Size = new System.Drawing.Size(349, 20);
            this.txtCommissionR.TabIndex = 40;
            // 
            // txtPasswordR
            // 
            this.txtPasswordR.Location = new System.Drawing.Point(94, 40);
            this.txtPasswordR.MaxLength = 15;
            this.txtPasswordR.Name = "txtPasswordR";
            this.txtPasswordR.PasswordChar = '*';
            this.txtPasswordR.Size = new System.Drawing.Size(349, 20);
            this.txtPasswordR.TabIndex = 39;
            // 
            // txtUserR
            // 
            this.txtUserR.Location = new System.Drawing.Point(94, 15);
            this.txtUserR.MaxLength = 15;
            this.txtUserR.Name = "txtUserR";
            this.txtUserR.Size = new System.Drawing.Size(349, 20);
            this.txtUserR.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Cliente Default:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "IVA:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Validar Stock:";
            // 
            // txtClientDefault
            // 
            this.txtClientDefault.Location = new System.Drawing.Point(89, 15);
            this.txtClientDefault.MaxLength = 15;
            this.txtClientDefault.Name = "txtClientDefault";
            this.txtClientDefault.Size = new System.Drawing.Size(354, 20);
            this.txtClientDefault.TabIndex = 47;
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(89, 40);
            this.txtIVA.MaxLength = 15;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(354, 20);
            this.txtIVA.TabIndex = 48;
            // 
            // cbStock
            // 
            this.cbStock.AutoSize = true;
            this.cbStock.Location = new System.Drawing.Point(89, 66);
            this.cbStock.Name = "cbStock";
            this.cbStock.Size = new System.Drawing.Size(15, 14);
            this.cbStock.TabIndex = 47;
            this.cbStock.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.almacenamiento);
            this.tabControl1.Controls.Add(this.general);
            this.tabControl1.Controls.Add(this.impresion);
            this.tabControl1.Controls.Add(this.recargas);
            this.tabControl1.Controls.Add(this.ventas);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 305);
            this.tabControl1.TabIndex = 43;
            // 
            // almacenamiento
            // 
            this.almacenamiento.Controls.Add(this.button1);
            this.almacenamiento.Controls.Add(this.btnLocalMac);
            this.almacenamiento.Controls.Add(this.txtMac);
            this.almacenamiento.Controls.Add(this.label26);
            this.almacenamiento.Controls.Add(this.btnMac);
            this.almacenamiento.Controls.Add(this.label25);
            this.almacenamiento.Controls.Add(this.txtMyMac);
            this.almacenamiento.Controls.Add(this.btnLocal);
            this.almacenamiento.Controls.Add(this.txtConfirmDB);
            this.almacenamiento.Controls.Add(this.label24);
            this.almacenamiento.Controls.Add(this.btnGetIp);
            this.almacenamiento.Controls.Add(this.label3);
            this.almacenamiento.Controls.Add(this.btnTestSqlServer);
            this.almacenamiento.Controls.Add(this.txtIpServer);
            this.almacenamiento.Controls.Add(this.txtPassword);
            this.almacenamiento.Controls.Add(this.label2);
            this.almacenamiento.Controls.Add(this.txtMyIp);
            this.almacenamiento.Controls.Add(this.label4);
            this.almacenamiento.Controls.Add(this.txtCatalog);
            this.almacenamiento.Controls.Add(this.label6);
            this.almacenamiento.Controls.Add(this.label5);
            this.almacenamiento.Controls.Add(this.txtUser);
            this.almacenamiento.Cursor = System.Windows.Forms.Cursors.Default;
            this.almacenamiento.Location = new System.Drawing.Point(4, 22);
            this.almacenamiento.Name = "almacenamiento";
            this.almacenamiento.Padding = new System.Windows.Forms.Padding(3);
            this.almacenamiento.Size = new System.Drawing.Size(450, 279);
            this.almacenamiento.TabIndex = 1;
            this.almacenamiento.Text = "Almacenamiento";
            this.almacenamiento.UseVisualStyleBackColor = true;
            // 
            // btnLocalMac
            // 
            this.btnLocalMac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalMac.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalMac.Image")));
            this.btnLocalMac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalMac.Location = new System.Drawing.Point(368, 88);
            this.btnLocalMac.Name = "btnLocalMac";
            this.btnLocalMac.Size = new System.Drawing.Size(75, 23);
            this.btnLocalMac.TabIndex = 57;
            this.btnLocalMac.Text = "  Local";
            this.btnLocalMac.UseVisualStyleBackColor = true;
            this.btnLocalMac.Click += new System.EventHandler(this.btnLocalMac_Click);
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(94, 91);
            this.txtMac.MaxLength = 17;
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(268, 20);
            this.txtMac.TabIndex = 56;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(55, 94);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 13);
            this.label26.TabIndex = 55;
            this.label26.Text = "MAC:";
            // 
            // btnMac
            // 
            this.btnMac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMac.Image = ((System.Drawing.Image)(resources.GetObject("btnMac.Image")));
            this.btnMac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMac.Location = new System.Drawing.Point(368, 39);
            this.btnMac.Name = "btnMac";
            this.btnMac.Size = new System.Drawing.Size(75, 23);
            this.btnMac.TabIndex = 54;
            this.btnMac.Text = "Obtener";
            this.btnMac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMac.UseVisualStyleBackColor = true;
            this.btnMac.Click += new System.EventHandler(this.btnMac_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 13);
            this.label25.TabIndex = 53;
            this.label25.Text = "MAC del equipo:";
            // 
            // txtMyMac
            // 
            this.txtMyMac.BackColor = System.Drawing.Color.White;
            this.txtMyMac.Location = new System.Drawing.Point(94, 41);
            this.txtMyMac.MaxLength = 15;
            this.txtMyMac.Name = "txtMyMac";
            this.txtMyMac.ReadOnly = true;
            this.txtMyMac.Size = new System.Drawing.Size(268, 20);
            this.txtMyMac.TabIndex = 52;
            // 
            // btnLocal
            // 
            this.btnLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnLocal.Image")));
            this.btnLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocal.Location = new System.Drawing.Point(369, 114);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(75, 23);
            this.btnLocal.TabIndex = 51;
            this.btnLocal.Text = "  Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // txtConfirmDB
            // 
            this.txtConfirmDB.Location = new System.Drawing.Point(94, 221);
            this.txtConfirmDB.MaxLength = 15;
            this.txtConfirmDB.Name = "txtConfirmDB";
            this.txtConfirmDB.PasswordChar = '*';
            this.txtConfirmDB.Size = new System.Drawing.Size(349, 20);
            this.txtConfirmDB.TabIndex = 50;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(34, 223);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 13);
            this.label24.TabIndex = 49;
            this.label24.Text = "Confirmar:";
            // 
            // general
            // 
            this.general.Controls.Add(this.txtTimeUpdateSale);
            this.general.Controls.Add(this.cbWizard);
            this.general.Controls.Add(this.cmMenuTruper);
            this.general.Controls.Add(this.txtBox);
            this.general.Controls.Add(this.txtOffice);
            this.general.Controls.Add(this.label22);
            this.general.Controls.Add(this.label21);
            this.general.Controls.Add(this.label20);
            this.general.Controls.Add(this.label19);
            this.general.Controls.Add(this.label18);
            this.general.Cursor = System.Windows.Forms.Cursors.Default;
            this.general.Location = new System.Drawing.Point(4, 22);
            this.general.Name = "general";
            this.general.Padding = new System.Windows.Forms.Padding(3);
            this.general.Size = new System.Drawing.Size(450, 279);
            this.general.TabIndex = 0;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // txtTimeUpdateSale
            // 
            this.txtTimeUpdateSale.Location = new System.Drawing.Point(230, 71);
            this.txtTimeUpdateSale.MaxLength = 15;
            this.txtTimeUpdateSale.Name = "txtTimeUpdateSale";
            this.txtTimeUpdateSale.Size = new System.Drawing.Size(31, 20);
            this.txtTimeUpdateSale.TabIndex = 49;
            // 
            // cbWizard
            // 
            this.cbWizard.AutoSize = true;
            this.cbWizard.Location = new System.Drawing.Point(230, 94);
            this.cbWizard.Name = "cbWizard";
            this.cbWizard.Size = new System.Drawing.Size(15, 14);
            this.cbWizard.TabIndex = 48;
            this.cbWizard.UseVisualStyleBackColor = true;
            // 
            // cmMenuTruper
            // 
            this.cmMenuTruper.AutoSize = true;
            this.cmMenuTruper.Location = new System.Drawing.Point(230, 111);
            this.cmMenuTruper.Name = "cmMenuTruper";
            this.cmMenuTruper.Size = new System.Drawing.Size(15, 14);
            this.cmMenuTruper.TabIndex = 46;
            this.cmMenuTruper.UseVisualStyleBackColor = true;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(47, 40);
            this.txtBox.MaxLength = 15;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(396, 20);
            this.txtBox.TabIndex = 43;
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(47, 15);
            this.txtOffice.MaxLength = 15;
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(396, 20);
            this.txtOffice.TabIndex = 42;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(48, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(184, 13);
            this.label22.TabIndex = 41;
            this.label22.Text = "Cerrar Wizard al agregar un producto:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(109, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Opción Truper en Menú:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(54, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(170, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "Tiempo para modifica una compra:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "# Caja:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Oficina:";
            // 
            // impresion
            // 
            this.impresion.Controls.Add(this.txtLEPrint);
            this.impresion.Controls.Add(this.txtSANPrint);
            this.impresion.Controls.Add(this.txtPhonePrint);
            this.impresion.Controls.Add(this.txtNamePrint);
            this.impresion.Controls.Add(this.label17);
            this.impresion.Controls.Add(this.label16);
            this.impresion.Controls.Add(this.label15);
            this.impresion.Controls.Add(this.label14);
            this.impresion.Controls.Add(this.cmbPrinters);
            this.impresion.Controls.Add(this.label1);
            this.impresion.Cursor = System.Windows.Forms.Cursors.Default;
            this.impresion.Location = new System.Drawing.Point(4, 22);
            this.impresion.Name = "impresion";
            this.impresion.Size = new System.Drawing.Size(450, 279);
            this.impresion.TabIndex = 4;
            this.impresion.Text = "Impresión";
            this.impresion.UseVisualStyleBackColor = true;
            // 
            // txtLEPrint
            // 
            this.txtLEPrint.Location = new System.Drawing.Point(102, 120);
            this.txtLEPrint.MaxLength = 15;
            this.txtLEPrint.Name = "txtLEPrint";
            this.txtLEPrint.Size = new System.Drawing.Size(341, 20);
            this.txtLEPrint.TabIndex = 42;
            // 
            // txtSANPrint
            // 
            this.txtSANPrint.Location = new System.Drawing.Point(102, 94);
            this.txtSANPrint.MaxLength = 15;
            this.txtSANPrint.Name = "txtSANPrint";
            this.txtSANPrint.Size = new System.Drawing.Size(341, 20);
            this.txtSANPrint.TabIndex = 41;
            // 
            // txtPhonePrint
            // 
            this.txtPhonePrint.Location = new System.Drawing.Point(102, 68);
            this.txtPhonePrint.MaxLength = 15;
            this.txtPhonePrint.Name = "txtPhonePrint";
            this.txtPhonePrint.Size = new System.Drawing.Size(341, 20);
            this.txtPhonePrint.TabIndex = 40;
            // 
            // txtNamePrint
            // 
            this.txtNamePrint.Location = new System.Drawing.Point(102, 42);
            this.txtNamePrint.MaxLength = 200;
            this.txtNamePrint.Name = "txtNamePrint";
            this.txtNamePrint.Size = new System.Drawing.Size(341, 20);
            this.txtNamePrint.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Localidad / Estado:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Calle y número:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Teléfono:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Nombre:";
            // 
            // recargas
            // 
            this.recargas.Controls.Add(this.txtConfirm);
            this.recargas.Controls.Add(this.label23);
            this.recargas.Controls.Add(this.label10);
            this.recargas.Controls.Add(this.label9);
            this.recargas.Controls.Add(this.cbBrowserR);
            this.recargas.Controls.Add(this.txtUserR);
            this.recargas.Controls.Add(this.label7);
            this.recargas.Controls.Add(this.txtPasswordR);
            this.recargas.Controls.Add(this.label8);
            this.recargas.Controls.Add(this.txtCommissionR);
            this.recargas.Location = new System.Drawing.Point(4, 22);
            this.recargas.Name = "recargas";
            this.recargas.Padding = new System.Windows.Forms.Padding(3);
            this.recargas.Size = new System.Drawing.Size(450, 279);
            this.recargas.TabIndex = 2;
            this.recargas.Text = "Recargas";
            this.recargas.UseVisualStyleBackColor = true;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(94, 66);
            this.txtConfirm.MaxLength = 15;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(349, 20);
            this.txtConfirm.TabIndex = 48;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(34, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 47;
            this.label23.Text = "Confirmar:";
            // 
            // ventas
            // 
            this.ventas.Controls.Add(this.cbStock);
            this.ventas.Controls.Add(this.label12);
            this.ventas.Controls.Add(this.txtIVA);
            this.ventas.Controls.Add(this.label11);
            this.ventas.Controls.Add(this.txtClientDefault);
            this.ventas.Controls.Add(this.label13);
            this.ventas.Location = new System.Drawing.Point(4, 22);
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(450, 279);
            this.ventas.TabIndex = 3;
            this.ventas.Text = "Ventas";
            this.ventas.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(287, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 58;
            this.button1.Text = "     Respaldo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 358);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.tabControl1.ResumeLayout(false);
            this.almacenamiento.ResumeLayout(false);
            this.almacenamiento.PerformLayout();
            this.general.ResumeLayout(false);
            this.general.PerformLayout();
            this.impresion.ResumeLayout(false);
            this.impresion.PerformLayout();
            this.recargas.ResumeLayout(false);
            this.recargas.PerformLayout();
            this.ventas.ResumeLayout(false);
            this.ventas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMyIp;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTestSqlServer;
        private System.Windows.Forms.Button btnGetIp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtUserR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCommissionR;
        private System.Windows.Forms.TextBox txtPasswordR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbBrowserR;
        private System.Windows.Forms.CheckBox cbStock;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtClientDefault;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.TabPage almacenamiento;
        private System.Windows.Forms.TabPage recargas;
        private System.Windows.Forms.TabPage ventas;
        private System.Windows.Forms.TabPage impresion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtLEPrint;
        private System.Windows.Forms.TextBox txtSANPrint;
        private System.Windows.Forms.TextBox txtPhonePrint;
        private System.Windows.Forms.TextBox txtNamePrint;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbWizard;
        private System.Windows.Forms.CheckBox cmMenuTruper;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtTimeUpdateSale;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtConfirmDB;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnMac;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtMyMac;
        private System.Windows.Forms.Button btnLocalMac;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button1;
    }
}