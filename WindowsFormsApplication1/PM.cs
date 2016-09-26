using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesForm.Extensions;
using Utilities.Extensions;
using posb = PosBusiness;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class PM : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage);

        public event Communication UpdateList;

        private int ScrollPosition = 0;

        #endregion

        #region Properties

        private posb.PM Entity { get; set; }

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

        private bool LoadComplete = false;

        #endregion

        #region Builder

        public PM()
        {
            InitializeComponent();

            this.Entity = new posb.PM();
        }

        #endregion

        #region Events

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bnCopiar_Click(object sender, EventArgs e)
        {
            this.OpenEdit(this.EntityId, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PM_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFind;

            this.SetConImagen();

            this.SetTypeLike();

            this.ConfigureGridView();

            this.GetGroups();

            this.GetBrands();

            this.GetCompanies();

            this.LoadComplete = true;

            this.FillGridView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar el producto [" + this.EntityName + "]?"))
            {
                this.ScrollPosition = gvList.FirstDisplayedScrollingRowIndex;

                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar el producto [" + this.EntityName + "]", eForm.TypeError.Error);
            }
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void Result(bool IsCorrect, String ErrorMessage)
        {
            FillGridView();

            if (this.UpdateList != null)
                this.UpdateList(true, "");
        }

        private void Result2(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus)
        {
            FillGridView();

            if (this.UpdateList != null)
                this.UpdateList(true, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ScrollPosition = gvList.FirstDisplayedScrollingRowIndex;

            Wizard Wizard = new Wizard();

            Wizard.Result += new Wizard.Communication(Result2);

            Wizard.ShowDialog();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.ScrollPosition = 0;


            this.FillGridView();
        }

        private void ResultBarCode(bool IsCorrect, string ErrorMessage, string BarCode)
        {
            this.FillGridView();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public static void LoadProcessInControl(string _Process, Control _Control, bool IsMDI = true, string Arguments = "")
        {
            if (IsMDI)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(_Process, Arguments);

                p.WaitForInputIdle();

                Thread.Sleep(1000);

                SetParent(p.MainWindowHandle, _Control.Handle);
            }
            else
            {
                Process.Start(_Process, Arguments);
            }
        }

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1))
            {
                this.OpenEdit(this.EntityId);
            }
            else if (e.ColumnIndex.Equals(4))
            {
                BarCode BarCode = new BarCode(this.EntityId);

                BarCode.Result += new BarCode.Communication(ResultBarCode);

                BarCode.ShowDialog();
            }
            else if (e.ColumnIndex.Equals(5))
            {
                if (!gvList[5, this.SelectRowIndex].Value.ToString().Equals("N/A", StringComparison.InvariantCultureIgnoreCase))
                {
                    string url = "https://www.truper.com.mx/CatVigente/buscador.php?palabra=" + gvList[5, this.SelectRowIndex].Value.ToString();

                    LoadProcessInControl("chrome.exe", this, false, url);
                }
            }
            else if (e.ColumnIndex.Equals(6))
            {
                var id = this.EntityId;

                if (gvList[6, this.SelectRowIndex].Value.ToString().Equals("Si", StringComparison.InvariantCultureIgnoreCase))
                {
                    ImageShow ImageShow = new ImageShow(id);

                    ImageShow.ShowDialog();
                }
                else
                {
                    this.ScrollPosition = gvList.FirstDisplayedScrollingRowIndex;

                    ImageCapture ImageCapture = new ImageCapture(id);

                    ImageCapture.Result += new ImageCapture.Communication(delegate(bool IsCorrect, String ErrorMessage, int Id, Image Img)
                    {

                        this.FillGridView();
                    });

                    ImageCapture.ShowDialog();

                }
            }
            else if (e.ColumnIndex.Equals(8))
            {
                if (gvList[8, this.SelectRowIndex].Value.ToString().Equals("Si", StringComparison.InvariantCultureIgnoreCase))
                {
                    var id = this.EntityId;

                    Freight freight = new Freight(id);

                    freight.ShowDialog();
                }
            }
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1) || e.ColumnIndex.Equals(4) || e.ColumnIndex.Equals(5) || e.ColumnIndex.Equals(6) || e.ColumnIndex.Equals(8))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void cmbPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmbTypeLike_SelectedValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        #endregion

        #region Methods

        private void GetCompanies()
        {
            using (posb.Company company = new posb.Company())
            {
                this.cmbCompany.Fill(company.List());
            }
        }

        private void GetGroups()
        {
            using (posb.Group Group = new posb.Group())
            {
                this.cmbGroup.Fill(Group.List());
            }
        }

        private void GetBrands()
        {
            using (posb.Brand Brand = new posb.Brand())
            {
                this.cmBrand.Fill(Brand.List());
            }
        }

        private void SetTypeLike()
        {
            var tp = new
            {
                Id = 0,
                Name = string.Empty
            };

            var options = tp.ToList();

            options.Add(new { Id = 0, Name = "Inicia" });
            options.Add(new { Id = 1, Name = "Contiene" });
            options.Add(new { Id = 2, Name = "Termina" });

            this.cmbTypeLike.Fill(options, AddFirstOption: false);

            this.cmbTypeLike.SelectedIndex = 1;
        }

        private void SetConImagen()
        {
            var tp = new
            {
                Id = 0,
                Name = string.Empty
            };

            var options = tp.ToList();

            options.Add(new { Id = 1, Name = "Si" });
            options.Add(new { Id = 2, Name = "No" });

            this.cmbPaymentType.Fill(options);
        }

        private void OpenEdit(int? Id = null, bool IsCopy = false)
        {
            this.ScrollPosition = gvList.FirstDisplayedScrollingRowIndex;

            PMEdit PMEdit = new PMEdit(Id, IsCopy);

            PMEdit.Result += new PMEdit.Communication(Result);

            PMEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            this.gvList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FillGridView()
        {
            if (this.LoadComplete)
            {
                this.gvList.AutoGenerateColumns = false;

                int id = 0;

                this.Entity.Name = txtFind.Text;

                if (int.TryParse(this.Entity.Name, out id))
                {
                    this.Entity.Id = id;
                }
                else
                {
                    this.Entity.Id = null;
                }

                if (this.cmbPaymentType.SelectedValue.ToString().Equals("1"))
                {
                    this.Entity.HasImageFilter = true;
                }
                else if (this.cmbPaymentType.SelectedValue.ToString().Equals("2"))
                {
                    this.Entity.HasImageFilter = false;
                }
                else
                {
                    this.Entity.HasImageFilter = null;
                }

                if (this.cmBrand.SelectedIndex > 0)
                {
                    this.Entity.IdBrand = int.Parse(this.cmBrand.SelectedValue.ToString());
                }
                else
                {
                    this.Entity.IdBrand = null;
                }

                if (this.cmbCompany.SelectedIndex > 0)
                {
                    this.Entity.IdCompany = int.Parse(this.cmbCompany.SelectedValue.ToString());
                }
                else
                {
                    this.Entity.IdCompany = null;
                }

                if (this.cmbGroup.SelectedIndex > 0)
                {
                    this.Entity.IdGroup = int.Parse(this.cmbGroup.SelectedValue.ToString());
                }
                else
                {
                    this.Entity.IdGroup = null;
                }

                int typeLike = 0;

                if (this.cmbTypeLike.SelectedValue != null && int.TryParse(this.cmbTypeLike.SelectedValue.ToString(), out typeLike))
                {
                    this.Entity.TypeLike = typeLike;
                }
                else
                {
                    this.Entity.TypeLike = 0;
                }

                this.gvList.DataSource = this.Entity.List();

                lblTotal.Text = this.gvList.RowCount.ToString();

                try
                {
                    this.gvList.FirstDisplayedScrollingRowIndex = this.ScrollPosition;
                }
                catch
                {
                }
            }
        }

        #endregion

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }
    }
}
