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
using Utilities.Extensions;
using Utilities;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Concentrated : FormBase
    {
        #region Members

        private System.Windows.Forms.CheckBox CheckBoxHeader = new System.Windows.Forms.CheckBox();

        #endregion

        #region Properties

        private posb.Concentrated Entity { get; set; }

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
                return int.Parse(gvList[1, this.SelectRowIndex].Value.ToString());
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

        public Concentrated()
        {
            InitializeComponent();

            this.Entity = new posb.Concentrated();
        }

        #endregion

        #region Events

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                this.OpenEdit(this.EntityId);
            }
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void Product_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.ConfigureDialogs();

            this.ConfigureDateTimePicker();

            this.FillGridView();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Result(bool IsCorrect, String ErrorMessage)
        {
            FillGridView();
        }

        private void btnMass_Click(object sender, EventArgs e)
        {
            ProductMass ProductMass = new ProductMass(MassiveLoadTypes.Product);

            ProductMass.Result += new ProductMass.Communication(Result);

            ProductMass.ShowDialog();
        }

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            svdReportStock.FileName = "Concentrado_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

            int total = 0;

            for (int j = 0; j < this.gvList.RowCount; j++)
            {
                if (this.gvList[0, j].Value != null && (bool)this.gvList[0, j].Value)
                {
                    total++;
                }
            }

            if (total.Equals(0))
            {
                this.Alert("Debe seleccionar al menos una operación");

                return;
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

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\Concentrated\\" + this.AppSet<string>("ConcentratedReport"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    List<PosBusiness.Concentrated> lConcentrated = this.Entity.List(this.dtpDate1.Value, this.dtpDate2.Value);

                    for (int j = 0; j < this.gvList.RowCount; j++)
                    {
                        if (this.gvList[0, j].Value != null && (bool)this.gvList[0, j].Value)
                        {
                            lConcentrated.Find(p => p.Id.Equals((int)this.gvList[2, j].Value)
                                                 && p.Name.Trim().Equals(this.gvList[3, j].Value.ToString().Trim(), StringComparison.InvariantCultureIgnoreCase)).ForReport = true;
                        }
                    }

                    foreach (PosBusiness.Concentrated concentrated in lConcentrated)
                    {
                        if (concentrated.ForReport)
                        {
                            xlWorkSheetItems.Cells[index, 1] = concentrated.Type;

                            xlWorkSheetItems.Cells[index, 2] = concentrated.Id.ToString();

                            (xlWorkSheetItems.Cells[index, 3] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 3] = concentrated.Name;

                            (xlWorkSheetItems.Cells[index, 4] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                            xlWorkSheetItems.Cells[index, 4] = concentrated.Amount;

                            (xlWorkSheetItems.Cells[index, 5] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 5] = concentrated.CreatedDate.Value.ToString("dd/MM/yyyy");

                            index++;
                        }
                    }

                    xlWorkSheetItems.Cells[index + 1, 3].Font.Size = 13;
                    xlWorkSheetItems.Cells[index + 1, 3].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 1, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheetItems.Cells[index + 1, 3] = "Total:";


                    xlWorkSheetItems.Cells[index + 1, 4].Font.Size = 14;
                    xlWorkSheetItems.Cells[index + 1, 4].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 1, 4].Formula = string.Format("=SUM(L2:D{0})", index);

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
                    this.Alert("Error: " + ex.Message);
                }
                finally
                {
                    this.ReleasingObjects(xlWorkSheetItems, xlWorkBook, xlApp);
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void svdReportStock_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void dtpDate1_ValueChanged(object sender, EventArgs e)
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
            this.Entity.Name = txtFind.Text;

            List<posb.Concentrated> lConcentrated = this.Entity.List(this.dtpDate1.Value, this.dtpDate2.Value);

            this.gvList.DataSource = lConcentrated;

            lblTotal.Text = this.gvList.RowCount.ToString();

            this.gvList.ReadOnly = false;

            System.Drawing.Rectangle rect = this.gvList.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + (rect.Width / 4) + 2;
            rect.Y = 4;

            this.CheckBoxHeader.Name = "checkboxHeader";
            this.CheckBoxHeader.Checked = false;
            this.CheckBoxHeader.Size = new Size(18, 18);
            this.CheckBoxHeader.Location = rect.Location;
            this.CheckBoxHeader.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHeader.CheckedChanged += new EventHandler(ckBox_CheckedChanged);

            gvList.Controls.Add(this.CheckBoxHeader);

            this.lblTotalExpenses.Text = String.Format("{0:0.00}", lConcentrated.Sum(item => item.Amount));
        }

        private void ConfigureDateTimePicker()
        {
            dtpDate1.Format = DateTimePickerFormat.Custom;
            dtpDate1.CustomFormat = "dd/MM/yyyy";
            dtpDate1.Value = DateTime.Now.AddDays(-7);

            dtpDate2.Format = DateTimePickerFormat.Custom;
            dtpDate2.CustomFormat = "dd/MM/yyyy";
            dtpDate2.Value = DateTime.Now;
        }

        private void ConfigureDialogs()
        {
            svdReportStock.Filter = "Archivo de Excel(*.xlsx)|*.xlsx";
            svdReportStock.FilterIndex = 0;
            svdReportStock.Title = "Guardar como";
            svdReportStock.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void CheckGridView()
        {
            for (int j = 0; j < this.gvList.RowCount; j++)
            {
                this.gvList[0, j].Value = this.CheckBoxHeader.Checked;
            }

            this.gvList.EndEdit();
        }

        private void OpenEdit(int? Id = null)
        {
            Sale sale = new Sale(Id);

            sale.ShowDialog();
        }

        #endregion

        public IEnumerable<posb.Concentrated> lConcentrated { get; set; }
    }
}


