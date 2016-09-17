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
    public partial class Expense : FormBase
    {
        #region Properties

        private System.Windows.Forms.CheckBox CheckBoxHeader = new System.Windows.Forms.CheckBox();

        private posb.Expense Entity { get; set; }

        private string EntityName
        {
            get
            {
                return gvList[2, this.SelectRowIndex].Value.ToString();
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

        public Expense()
        {
            InitializeComponent();

            this.Entity = new posb.Expense();
        }

        #endregion

        #region Events

        private void dtpDate1_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckGridView();
        }

        private void Measure_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.GetExpensesCategory();

            this.ConfigureDateTimePicker();

            this.ConfigureDialogs();

            this.FillGridView();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar el gasto [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar el gasto [" + this.EntityName + "]", eForm.TypeError.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.OpenEdit(this.EntityId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void Result(bool IsCorrect, String ErrorMessage, int Id)
        {
            FillGridView();
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

        private void button1_Click(object sender, EventArgs e)
        {
            svdReportStock.FileName = "Gastos_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

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
                this.Alert("Debe seleccionar al menos un gasto");

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

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\Expenses\\" + this.AppSet<string>("ExpensesReport"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    this.Entity.StartDate = this.dtpDate1.Value;
                    this.Entity.EndDate = this.dtpDate2.Value;

                    List<PosBusiness.Expense> lSale = this.Entity.List();

                    for (int j = 0; j < this.gvList.RowCount; j++)
                    {
                        if (this.gvList[0, j].Value != null && (bool)this.gvList[0, j].Value)
                        {
                            lSale.Find(p => p.Id.Equals((int)this.gvList[1, j].Value)).ForReport = true;
                        }
                    }

                    foreach (PosBusiness.Expense expense in lSale)
                    {
                        if (expense.ForReport)
                        {
                            xlWorkSheetItems.Cells[index, 1] = expense.Id.ToString();

                            (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 2] = expense.Name;

                            (xlWorkSheetItems.Cells[index, 3] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 3] = expense.Category;

                            (xlWorkSheetItems.Cells[index, 4] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 4] = expense.CreatedDate.Value.ToString("dd/MM/yyyy hh:mm:ss");

                            (xlWorkSheetItems.Cells[index, 5] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 5] = expense.Description;

                            (xlWorkSheetItems.Cells[index, 6] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                            xlWorkSheetItems.Cells[index, 6] = expense.Amount;

                            index++;
                        }
                    }

                    xlWorkSheetItems.Cells[index + 1, 5].Font.Size = 14;
                    xlWorkSheetItems.Cells[index + 1, 5].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 1, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheetItems.Cells[index + 1, 5] = "Total:";

                    xlWorkSheetItems.Cells[index + 1, 6].Font.Size = 13;
                    xlWorkSheetItems.Cells[index + 1, 6].Font.Bold = true;
                    (xlWorkSheetItems.Cells[index + 1, 6] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                    xlWorkSheetItems.Cells[index + 1, 6].Formula = string.Format("=SUM(F{0}:F{1})", 2, index);

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

        #endregion

        #region Methods

        private void OpenEdit(int? Id = null)
        {
            ExpenseEdit ExpenseEdit = new ExpenseEdit(Id);

            ExpenseEdit.Result += new ExpenseEdit.Communication(Result);

            ExpenseEdit.ShowDialog();
        }


        private void OpenExpenseEdit(int Id)
        {
            ExpenseDetail ExpenseDetail = new ExpenseDetail(Id);

            //ExpenseDetail.Result += new ExpenseDetail.Communication(Result);

            ExpenseDetail.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.Name = txtFind.Text;

            this.Entity.StartDate = this.dtpDate1.Value;

            this.Entity.EndDate = this.dtpDate2.Value;

            int idCategory = 0;

            if (int.TryParse(this.cmbCategory.SelectedValue.ToString(), out idCategory))
            {
                if (idCategory.Equals(0))
                    this.Entity.IdCategory = null;
                else
                    this.Entity.IdCategory = idCategory;
            }

            List<posb.Expense> lExpenses = this.Entity.List();

            this.gvList.DataSource = lExpenses;

            lblTotal.Text = this.gvList.RowCount.ToString();

            this.gvList.ReadOnly = false;

            System.Drawing.Rectangle rect = this.gvList.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + (rect.Width / 4) + 2;
            rect.Y = 4;

            this.CheckBoxHeader.Name = "checkboxHeader";
            this.CheckBoxHeader.Checked = false;
            this.CheckBoxHeader.Size = new Size(18, 18);
            this.CheckBoxHeader.Location = rect.Location;
            this.CheckBoxHeader.BackColor = System.Drawing.Color.White;
            this.CheckBoxHeader.CheckedChanged += new EventHandler(ckBox_CheckedChanged);

            this.gvList.Controls.Add(this.CheckBoxHeader);

            this.lblTotalExpenses.Text = String.Format("{0:0.00}", lExpenses.Sum(item => item.Amount));
        }

        private void CheckGridView()
        {
            for (int j = 0; j < this.gvList.RowCount; j++)
            {
                this.gvList[0, j].Value = this.CheckBoxHeader.Checked;
            }

            this.gvList.EndEdit();
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

        private void GetExpensesCategory()
        {
            using (posb.Expense Expense = new posb.Expense())
            {
                this.cmbCategory.Fill(Expense.ListCategory());
            }
        }

        #endregion

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void gvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(2))
            {
                this.OpenEdit(this.EntityId);
            }
            else if (e.ColumnIndex.Equals(7))
            {
                this.OpenExpenseEdit(this.EntityId);
            }
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1) || e.ColumnIndex.Equals(7))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }
    }
}
