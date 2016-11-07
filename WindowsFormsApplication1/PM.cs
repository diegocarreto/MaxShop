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
using Microsoft.Office.Interop.Excel;

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

            this.ConfigureDialogs();

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

        private void Result2(bool IsCorrect, String ErrorMessage, int IdPm, System.Windows.Forms.TextBox TxtFocus)
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

        private void ConfigureDialogs()
        {
            svdReportStock.Filter = "Archivo de Excel(*.xlsx)|*.xlsx";
            svdReportStock.FilterIndex = 0;
            svdReportStock.Title = "Guardar como";
            svdReportStock.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

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

                this.Entity.Name = this.txtFind.Text;

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

                if (this.Entity.Name.Length.Equals(13))
                {
                    double barCode = 0;

                    if (double.TryParse(this.Entity.Name, out barCode))
                    {
                        this.gvList.DataSource = this.Entity.ListByCode();
                    }
                    else
                        this.gvList.DataSource = this.Entity.List();
                }
                else
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.cmbCompany.SelectedIndex > 0)
            {
                svdReportStock.FileName = "Precios_" + this.cmbCompany.Text.Replace(" ", "_") + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            }
            else
            {
                svdReportStock.FileName = "Precios_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            }

            if (svdReportStock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = 2;

                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Workbook xlWorkBook = null;
                Worksheet xlWorkSheetItems = null;
                ColorConverter cc = new ColorConverter();

                object misValue = System.Reflection.Missing.Value;

                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();

                    xlApp.Visible = false;
                    xlApp.DisplayAlerts = false;
                    xlApp.EnableEvents = false;

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\PM\\" + this.AppSet<string>("PM"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    int id = 0;

                    this.Entity.Name = this.txtFind.Text;

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

                    List<posb.PM> lpm;

                    if (this.Entity.Name.Length.Equals(13))
                    {
                        double barCode = 0;

                        if (double.TryParse(this.Entity.Name, out barCode))
                        {
                            lpm = this.Entity.ListByCode();
                        }
                        else
                            lpm = this.Entity.List();
                    }
                    else
                        lpm = this.Entity.List();

                    foreach (var pm in lpm)
                    {
                        (xlWorkSheetItems.Cells[index, 1] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 1] = pm.Name;

                        (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                        xlWorkSheetItems.Cells[index, 2] = pm.Price;

                        index++;
                    }

                    //Mantiene el encabezado fijo
                    xlWorkSheetItems.Application.ActiveWindow.SplitRow = 1;
                    xlWorkSheetItems.Application.ActiveWindow.FreezePanes = true;

                    //Agrega autofiltros
                    Microsoft.Office.Interop.Excel.Range firstRow = (Microsoft.Office.Interop.Excel.Range)xlWorkSheetItems.Rows[1];
                    firstRow.Activate();
                    firstRow.Select();
                    firstRow.AutoFilter(1,
                                        Type.Missing,
                                        Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd,
                                        Type.Missing,
                                        true);

                    xlWorkSheetItems.Cells[1, 1].Select();

                    //Ajusta el ancho de las columnas a su contenido
                    Microsoft.Office.Interop.Excel.Range aRange = xlWorkSheetItems.get_Range("A1", "ZZ1000000");
                    aRange.EntireColumn.AutoFit();

                    xlApp.EnableEvents = true;

                    xlWorkBook.SaveAs(svdReportStock.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                                                                                                                                                     Type.Missing, Type.Missing,
                                                                                                                                                     Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                                                                                                                                     Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing, Type.Missing, false);

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Application.Quit();
                    xlApp.Quit();

                    if (this.Confirm("¿Deseas abrir el reporte?"))
                        Process.Start(svdReportStock.FileName);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    this.ReleasingObjects(xlWorkSheetItems, xlWorkBook, xlApp);
                }
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
