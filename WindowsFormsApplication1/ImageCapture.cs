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
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class ImageCapture : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id, Image Img);

        public event Communication Result;

        private int? Id = null;

        private FilterInfoCollection VideoDevices;

        private VideoCaptureDevice VideoSource = null;

        #endregion

        #region Builder

        public ImageCapture(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        #endregion

        #region Events

        private void btnFindImg_Click(object sender, EventArgs e)
        {

        }

        private void ProductEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtPath;

            this.ConfigureOpenFileDialog();

            this.SearchDevicesVideo();

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (pbPhoto.Image != null)
            {
                using (posb.PM pm = new posb.PM
                {
                    Id = this.Id
                })
                {
                    pm.SaveImage(this.ImageToByte(pbPhoto.Image));
                }

                this.Result(true, "", this.Id.Value, pbPhoto.Image);

                this.Close();
            }
            else
            {
                this.Alert("Seleccione o capture una imagen");
            }
        }

        private void ImageCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VideoSource != null)
            {
                VideoSource.NewFrame += null;
                VideoSource.Stop();
                VideoSource = null;
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            if (btnTake.Text.Equals("Camara"))
            {
                this.btnTake.Text = "Capturar";
                this.StartVideo();
            }
            else
            {
                this.btnTake.Text = "Capturar";
                this.pbPhoto.Image = pbVideo.Image;
            }
        }

        private void FrameVideo(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            Graphics g = Graphics.FromImage(bmp);

            Pen pen = new Pen(Color.Red, 2);

            pen.Alignment = PenAlignment.Center;

            g.DrawRectangle(pen, 270, 186, 100, 100);
            this.pbMark.Image = bmp;

            this.pbVideo.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        #endregion

        #region Methods

        private void DownloadImage()
        {
            try
            {
                var request = WebRequest.Create(this.txtPath.Text);

                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        pbPhoto.Image = Bitmap.FromStream(stream);
                        pbPhoto.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Alert("Ocurrió un erro al intentar cargar la imagen.");
            }
        }

        private bool IsUrl(string Url)
        {
            Uri uriResult;
            return Uri.TryCreate(Url, UriKind.Absolute, out uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp
                   || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void ConfigureOpenFileDialog()
        {
            ofdDocument.FileName = string.Empty;

            ofdDocument.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofdDocument.Title = "Seleccione la imagen";

            ofdDocument.DefaultExt = "jpg";
            ofdDocument.Filter = "Imagenes jpg (*.jpg)|*.jpg|Imagenes png (*.png)|*.png";
        }

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void LoadData(int? Id)
        {
            using (posb.PM entity = new posb.PM
            {
                Id = this.Id,
                Name = this.Id.ToString()
            })
            {
                byte[] picture = entity.GetImage();

                entity.Get();

                txtSearch.Text = entity.Name.Replace("[", "")
                                            .Replace("]", "")
                                            .Replace(".", "")
                    //.Replace("/", "")
                                            .Replace(":", "")
                                            .Replace("Marca", "")
                                            .Replace("\"", " pulgadas")
                                            .Replace("  ", " ");

                if (picture != null)
                {
                    pbPhoto.Image = Image.FromStream(new MemoryStream(picture));
                    pbPhoto.Refresh();
                }
            }
        }

        public void SearchDevicesVideo()
        {
            VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (VideoDevices.Count != 0)
                LoadDevicesVideo();
        }

        public void LoadDevicesVideo()
        {
            cbWebCams.Items.Add("Seleccione...");

            for (int i = 0; i <= VideoDevices.Count - 1; i++)
            {
                cbWebCams.Items.Add(VideoDevices[i].Name.ToString());
            }

            if (VideoDevices.Count.Equals(1))
                cbWebCams.SelectedIndex = 1;
            else
                cbWebCams.SelectedIndex = 0;
        }

        public void StartVideo()
        {
            try
            {
                string MonikerString = VideoDevices[cbWebCams.SelectedIndex - 1].MonikerString,
                    name = cbWebCams.Text;

                if (!string.IsNullOrEmpty(MonikerString))
                {
                    VideoSource = new VideoCaptureDevice(MonikerString);

                    VideoSource.NewFrame += new NewFrameEventHandler(FrameVideo);

                    VideoSource.Start();
                }
                else
                    MessageBox.Show("No se ha seleccionado una cámara.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar mostrar el video.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnURL_Click(object sender, EventArgs e)
        {
            if (this.IsUrl(txtPath.Text))
            {
                this.DownloadImage();

                return;
            }

            if (ofdDocument.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdDocument.FileName;

                pbPhoto.Image = new Bitmap(ofdDocument.FileName);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string find = this.txtSearch.Text.Trim().Replace(" ", "+");

            this.txtPath.Focus();

            Process.Start("chrome.exe", "https://www.google.com.mx/search?q=" + find + "&source=lnms&tbm=isch&sa=X&ved=0ahUKEwj0wIT4pv_JAhVB5iYKHUEoBr0Q_AUIBygB&biw=1366&bih=667");
        }
    }
}
