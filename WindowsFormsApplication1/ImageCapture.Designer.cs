namespace WindowsFormsApplication1
{
    partial class ImageCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCapture));
            this.ofdDocument = new System.Windows.Forms.OpenFileDialog();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnURL = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWebCams = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.pbMark = new System.Windows.Forms.PictureBox();
            this.btnTake = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdDocument
            // 
            this.ofdDocument.FileName = "openFileDialog1";
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Location = new System.Drawing.Point(372, 384);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(453, 384);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1015;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(453, 298);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 300);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(384, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1016;
            this.label2.Text = "Buscar:";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(453, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnURL
            // 
            this.btnURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnURL.Image = ((System.Drawing.Image)(resources.GetObject("btnURL.Image")));
            this.btnURL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnURL.Location = new System.Drawing.Point(453, 323);
            this.btnURL.Name = "btnURL";
            this.btnURL.Size = new System.Drawing.Size(75, 23);
            this.btnURL.TabIndex = 3;
            this.btnURL.Text = "Imagen";
            this.btnURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnURL.UseVisualStyleBackColor = true;
            this.btnURL.Click += new System.EventHandler(this.btnURL_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(63, 326);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(384, 20);
            this.txtPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1011;
            this.label1.Text = "Imagen:";
            // 
            // cbWebCams
            // 
            this.cbWebCams.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbWebCams.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWebCams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWebCams.FormattingEnabled = true;
            this.cbWebCams.Location = new System.Drawing.Point(63, 354);
            this.cbWebCams.Name = "cbWebCams";
            this.cbWebCams.Size = new System.Drawing.Size(384, 21);
            this.cbWebCams.TabIndex = 4;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(11, 357);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(46, 13);
            this.label37.TabIndex = 1010;
            this.label37.Text = "Camara:";
            // 
            // pbMark
            // 
            this.pbMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMark.Location = new System.Drawing.Point(12, 12);
            this.pbMark.Name = "pbMark";
            this.pbMark.Size = new System.Drawing.Size(255, 270);
            this.pbMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMark.TabIndex = 1008;
            this.pbMark.TabStop = false;
            // 
            // btnTake
            // 
            this.btnTake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTake.Image = ((System.Drawing.Image)(resources.GetObject("btnTake.Image")));
            this.btnTake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTake.Location = new System.Drawing.Point(453, 352);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(75, 23);
            this.btnTake.TabIndex = 5;
            this.btnTake.Text = "Camara";
            this.btnTake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPhoto.Location = new System.Drawing.Point(273, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(255, 270);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 1005;
            this.pbPhoto.TabStop = false;
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbVideo.Location = new System.Drawing.Point(12, 12);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(255, 270);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 1004;
            this.pbVideo.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(372, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Aceptar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ImageCapture
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(537, 413);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnURL);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbWebCams);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.pbMark);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion Imagen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageCapture_FormClosing);
            this.Load += new System.EventHandler(this.ProductEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbMark;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.ComboBox cbWebCams;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog ofdDocument;
        private System.Windows.Forms.Button btnURL;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;


    }
}