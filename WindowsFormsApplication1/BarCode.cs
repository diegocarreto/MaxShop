using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;
using BarcodeLib;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class BarCode : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, string ErrorMessage, string BarCode);

        public event Communication Result;

        #endregion

        #region Properties

        public int Id { get; set; }

        #endregion

        #region Builder

        public BarCode(int Id)
        {
            this.Id = Id;

            InitializeComponent();
        }

        #endregion

        #region Events

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var height = 20;

                if (this.cbName.Checked)
                {
                    height += 30;
                }

                if (!this.cbName.Checked && this.cbPrice.Checked)
                {
                    height += 10;
                }

                Bitmap prevImage = this.DrawFilledRectangle(pbPrint.Width + 2, pbPrint.Height + height);
                Bitmap prevImage2 = new Bitmap(pbPrint.Image, pbPrint.Width, pbPrint.Height);

                using (Bitmap customImage = this.OverlayImages(prevImage, prevImage2, 1, 5))
                {
                    using (Graphics g = Graphics.FromImage(customImage))
                    {
                        Font fontTime = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                        Font fontName = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Pixel);

                        System.Drawing.Color colTime = System.Drawing.ColorTranslator.FromHtml("#000");
                        SolidBrush brushTime = new SolidBrush(colTime);

                        if (this.cbName.Checked)
                        {
                            var name = (this.txtName.Text.Length <= 37) ? this.txtName.Text : this.txtName.Text.Substring(0, 36) + "...";

                            int space = 37 - name.Length;

                            if (space > 0)
                            {
                                space = space / 2;

                                for (var i = 0; i <= (space + 6); i++)
                                {
                                    name = " " + name;
                                }
                            }
                            g.DrawString(name, fontName, brushTime, 2, 3);

                            g.DrawString("Código: " + this.Id.ToString().PadLeft(5, '0'), fontTime, brushTime, 25, 16);

                            if (this.cbPrice.Checked)
                            {
                                var price = new posb.PM { Id = this.Id }.GetPriceForBarCode();

                                g.DrawString("Precio: " + String.Format("{0:0.00}", price), fontTime, brushTime, 25, 69);
                            }
                        }
                        else if (this.cbPrice.Checked)
                        {
                            var price = new posb.PM { Id = this.Id }.GetPriceForBarCode();

                            g.DrawString("Código:" + this.Id.ToString().PadLeft(5, '0'), fontTime, brushTime, 25, 4);
                            g.DrawString("Precio: " + String.Format("{0:0.00}", price), fontTime, brushTime, 25, 57);
                        }
                        else
                        {
                            g.DrawString("Código:" + this.Id.ToString().PadLeft(5, '0'), fontTime, brushTime, 25, 0);
                        }

                        g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(0, 0, customImage.Width - 1, customImage.Height - 1));

                        customImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        this.SetBarCode();

                        this.Result(true, "", this.txtCode.Text);

                        if (this.Confirm("¿Deseas abrir la imagen?"))
                            Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void SetBarCode()
        {
            new posb.PM
            {
                Id = this.Id,
                BarCode = this.txtCode.Text
            }.SetBarCode();
        }

        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            return bmp;
        }

        public Bitmap OverlayImages(Image backImage, Image topImage, int topPosX = 0, int topPosY = 0)
        {
            if (backImage == null)
            {
                throw new ArgumentNullException(paramName: "backImage");
            }
            else if (topImage == null)
            {
                throw new ArgumentNullException(paramName: "topImage");
            }
            else if ((topImage.Width > backImage.Width) || (topImage.Height > backImage.Height))
            {
                throw new ArgumentException("Image bounds are greater than background image.", "topImage");
            }
            else
            {
                topPosX += Convert.ToInt32((backImage.Width / 2) - (topImage.Width / 2));
                topPosY += Convert.ToInt32((backImage.Height / 2) - (topImage.Height / 2));

                Bitmap bmp = new Bitmap(backImage.Width, backImage.Height);

                using (Graphics canvas = Graphics.FromImage(bmp))
                {
                    canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    canvas.DrawImage(image: backImage, destRect: new Rectangle(0, 0, bmp.Width, bmp.Height), srcRect: new Rectangle(0, 0, bmp.Width, bmp.Height), srcUnit: GraphicsUnit.Pixel);
                    canvas.DrawImage(image: topImage, destRect: new Rectangle(topPosX, topPosY, topImage.Width, topImage.Height), srcRect: new Rectangle(0, 0, topImage.Width, topImage.Height), srcUnit: GraphicsUnit.Pixel);

                    canvas.Save();
                }
                return bmp;
            }
        }

        private void BarCode_Load(object sender, EventArgs e)
        {
            this.GetCodeBardCode();

            this.GetName();

            this.GetBardCode();

            this.ConfigureDialog();
        }

        private void GetName()
        {
            this.txtName.Text = new posb.PM { Id = this.Id }.GetNameForBarCode();
        }

        private void ConfigureDialog()
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "Browse Text Files";
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "JPG files (*.jpg)|*.jpg";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.FileName = this.Id.ToString().PadLeft(5, '0') + "_" + this.txtCode.Text + ".jpg";
        }

        private void GetCodeBardCode()
        {
            string rnd = String.Empty,
                   automaticBarCode = new posb.PM { Id = this.Id }.GetBarCode();

            if (string.IsNullOrEmpty(automaticBarCode))
            {
                //Se debe verificar si tiene un codigo de barras o se debe calcular, los pasos son en el caso que se deba calcular

                //codigo del pais 750 
                //letra L 12 y letra D 04 = 1204
                //5 digitos del identificador del PM
                //Digito de control control
                automaticBarCode = "7501204" + this.Id.ToString().PadLeft(5, '0');

                automaticBarCode = automaticBarCode + this.GetControlDigit(automaticBarCode);
            }

            this.txtCode.Text = automaticBarCode;
        }

        private int GetControlDigit(string BarCode)
        {
            int val1 = 0,
                val2 = 0,
                mult = 0;

            for (int i = 0; i < BarCode.Length; i++)
            {
                string value = BarCode[i].ToString();
                int intValue = int.Parse(value);

                if ((i % 2).Equals(0))
                {
                    val2 += intValue;
                }
                else
                {
                    val1 += intValue;
                }
            }

            val1 *= 3;

            val1 += val2;

            if (val1 < 100)
                mult = 100;
            else if (val1 < 200)
                mult = 200;
            else if (val1 < 300)
                mult = 300;

            val1 = mult - val1;

            string preValue = val1.ToString();

            preValue = preValue.Substring(preValue.Length - 1, 1);

            val1 = int.Parse(preValue);

            return val1;
        }

        private void GetBardCode()
        {
            BarcodeLib.Barcode code = new Barcode();

            code.IncludeLabel = true;

            this.pbBarCode.Image = code.Encode(BarcodeLib.TYPE.EAN13, this.txtCode.Text, Color.Black, Color.White,
                303, 83);

            this.pbPrint.Image = code.Encode(BarcodeLib.TYPE.EAN13, this.txtCode.Text, Color.Black, Color.White,
               150, 40);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.SetBarCode();

            this.Result(true, "", this.txtCode.Text);

            this.Close();
        }

        #endregion


    }
}
