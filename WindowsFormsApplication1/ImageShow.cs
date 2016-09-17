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
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class ImageShow : FormBase
    {
        #region Members

        private int? Id = null;

        #endregion

        #region Builder

        public ImageShow(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        #endregion

        #region Events

        private void ProductEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.btnCerrar;

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void LoadData(int? Id)
        {
            using (posb.PM Entity = new posb.PM
            {
                Id = this.Id
            })
            {
                byte[] picture = Entity.GetImage();

                if (picture != null)
                {
                    pbPhoto.Image = Image.FromStream(new MemoryStream(picture));
                    pbPhoto.Refresh();
                }
            }
        }

        #endregion
    }
}
