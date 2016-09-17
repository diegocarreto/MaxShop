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

namespace WindowsFormsApplication1
{
    public partial class TruperBrowser : FormBase
    {
        #region Properties

        private string Url = "";

        #endregion

        #region Builder

        public TruperBrowser()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Measure_Load(object sender, EventArgs e)
        { 
        }

        #endregion

        #region Methods

        public void ChangeUrl(string Url)
        {
            this.Url = Url;

            this.webBrowser1.Navigate(this.Url);
        }

        #endregion
    }
}
