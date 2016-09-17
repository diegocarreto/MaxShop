using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class SelectByBarCode : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus);

        public event Communication Result;

        private List<posb.PM> Pms;

        #endregion

        #region Properties

        private int EntityId
        {
            get
            {
                return int.Parse(gvList[0, this.SelectRowIndex].Value.ToString());
            }
        }

        private int SelectRowIndex
        {
            get
            {
                return gvList.CurrentRow.Index;
            }
        }

        public TextBox TxtFocus { get; set; }

        #endregion

        #region Builder

        public SelectByBarCode(List<posb.PM> Pms)
        {
            InitializeComponent();

            this.Pms = Pms;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.DataSource = this.Pms;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Result != null)
            {
                this.Result(true, "", EntityId, this.TxtFocus);

                this.TxtFocus.Focus();
            }

            this.Close();
        }

        private void gvList_MouseMove(object sender, MouseEventArgs e)
        {
            gvList.Cursor = Cursors.Hand;
        }

        #region Methods
        #endregion
    }
}
