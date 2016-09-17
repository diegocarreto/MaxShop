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
    public partial class RefillList : FormBase
    {
        #region Properties

        private posb.TelephoneRecharge Entity { get; set; }

        private string EntityName
        {
            get
            {
                return gvList[1, this.SelectRowIndex].Value.ToString();
            }
        }

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

        #endregion

        #region Builder

        public RefillList()
        {
            InitializeComponent();

            this.Entity = new posb.TelephoneRecharge();
        }

        #endregion

        #region Events

        private void Measure_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.FillGridView();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void Measure_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Entity.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        #endregion

        #region Methods

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.Phone = txtFind.Text;

            this.gvList.DataSource = this.Entity.List();
        }

        #endregion

    }
}
