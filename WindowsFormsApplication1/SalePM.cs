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
    public partial class SalePM : FormBase
    {
        #region Members

        private System.Windows.Forms.CheckBox CheckBoxHeader = new System.Windows.Forms.CheckBox();

        private bool LoadComplete = false;

        #endregion

        #region Properties

        private posb.Sale Entity { get; set; }

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

        public SalePM()
        {
            InitializeComponent();

            this.Entity = new posb.Sale();
        }

        #endregion

        #region Events

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                this.OpenEdit(this.EntityId);
            }
            else if (e.ColumnIndex == 6)
            {
                var cancelTitle= gvList[6, this.SelectRowIndex].Value.ToString();

                if (cancelTitle.Equals("No", StringComparison.InvariantCultureIgnoreCase))
                {
                    var client = gvList[2, this.SelectRowIndex].Value.ToString();

                    if (this.Confirm("¿Realmente deseas cancelar la venta [" + this.EntityId + "] del cliente: " + client + "?"))
                    {
                        using (posb.Sale entity = new posb.Sale())
                        {
                            entity.Cancel(this.EntityId);

                            this.OpenEdit(this.EntityId, true);

                            this.FillGridView();
                        }
                    }
                }
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
            //this.SetAutoCompleteProducts();

            this.ConfigureGridView();

            this.ConfigureDialogs();

            this.ConfigureDateTimePicker();

            this.LoadComplete = true;

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
            svdReportStock.FileName = "Ventas_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

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
                this.Alert("Debe seleccionar al menos una venta");

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

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\Sales\\" + this.AppSet<string>("SalesReport"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    List<PosBusiness.Sale> lSale = this.Entity.List(this.dtpDate1.Value, this.dtpDate2.Value);

                    for (int j = 0; j < this.gvList.RowCount; j++)
                    {
                        if (this.gvList[0, j].Value != null && (bool)this.gvList[0, j].Value)
                        {
                            lSale.Find(p => p.Id.Equals((int)this.gvList[1, j].Value)).ForReport = true;
                        }
                    }

                    foreach (PosBusiness.Sale sale in lSale)
                    {
                        if (sale.ForReport)
                        {
                            sale.GetDetailSale();

                            xlWorkSheetItems.Cells[index, 1] = sale.Id.ToString();

                            (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 2] = sale.Name;

                            (xlWorkSheetItems.Cells[index, 3] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 3] = sale.CreatedDate.Value.ToString("dd/MM/yyyy hh:mm:ss");

                            (xlWorkSheetItems.Cells[index, 10] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                            xlWorkSheetItems.Cells[index, 10] = sale.PaymentType;

                            (xlWorkSheetItems.Cells[index, 11] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                            xlWorkSheetItems.Cells[index, 11] = sale.Total;

                            (xlWorkSheetItems.Cells[index, 12] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                            xlWorkSheetItems.Cells[index, 12] = sale.Sales.Sum(item => item.Gain);

                            for (int i = 1; i <= 12; i++)
                            {
                                xlWorkSheetItems.Cells[index, i].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#DDEBF7"));
                            }

                            index++;

                            foreach (PosBusiness.Sale sale2 in sale.Sales)
                            {
                                (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                                xlWorkSheetItems.Cells[index, 2] = sale2.Id.ToString().PadLeft(5, '0');

                                (xlWorkSheetItems.Cells[index, 3] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                                xlWorkSheetItems.Cells[index, 3] = sale2.Name;

                                (xlWorkSheetItems.Cells[index, 4] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                                xlWorkSheetItems.Cells[index, 4] = sale2.Group;

                                xlWorkSheetItems.Cells[index, 5] = sale2.Amount;

                                (xlWorkSheetItems.Cells[index, 6] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                                xlWorkSheetItems.Cells[index, 6] = sale2.AvgCost;

                                (xlWorkSheetItems.Cells[index, 7] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                                xlWorkSheetItems.Cells[index, 7] = sale2.AvgTotalCost;

                                (xlWorkSheetItems.Cells[index, 8] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                                xlWorkSheetItems.Cells[index, 8] = sale2.Unitary;

                                (xlWorkSheetItems.Cells[index, 9] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                                xlWorkSheetItems.Cells[index, 9] = sale2.Price;

                                (xlWorkSheetItems.Cells[index, 10] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                                xlWorkSheetItems.Cells[index, 10] = sale2.Gain;

                                for (int i = 1; i <= 12; i++)
                                {
                                    xlWorkSheetItems.Cells[index, i].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                                    xlWorkSheetItems.Cells[index + 1, i].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                                }

                                index += 2;
                            }
                        }
                    }

                    xlWorkSheetItems.Cells[index + 1, 10].Font.Size = 14;
                    xlWorkSheetItems.Cells[index + 1, 10].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 1, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheetItems.Cells[index + 1, 10].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    xlWorkSheetItems.Cells[index + 1, 10] = "Inversión:";

                    xlWorkSheetItems.Cells[index + 2, 10].Font.Size = 14;
                    xlWorkSheetItems.Cells[index + 2, 10].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 2, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheetItems.Cells[index + 2, 10].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    xlWorkSheetItems.Cells[index + 2, 10] = "Utilidad:";

                    xlWorkSheetItems.Cells[index + 3, 10].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));

                    xlWorkSheetItems.Cells[index + 4, 10].Font.Size = 14;
                    xlWorkSheetItems.Cells[index + 4, 10].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 4, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheetItems.Cells[index + 4, 10].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    xlWorkSheetItems.Cells[index + 4, 10] = "Total:";

                    xlWorkSheetItems.Cells[index + 1, 11].Font.Size = 13;
                    xlWorkSheetItems.Cells[index + 1, 11].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 1, 11].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    (xlWorkSheetItems.Cells[index + 1, 11] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";
                    xlWorkSheetItems.Cells[index + 1, 11].Formula = string.Format("=(K{0} - K{1})", index + 4, index + 2);

                    xlWorkSheetItems.Cells[index + 2, 11].Font.Size = 13;
                    xlWorkSheetItems.Cells[index + 2, 11].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 2, 11].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    xlWorkSheetItems.Cells[index + 2, 11].Formula = string.Format("=SUM(L2:L{0})", index);

                    xlWorkSheetItems.Cells[index + 3, 11].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));

                    xlWorkSheetItems.Cells[index + 4, 11].Font.Size = 13;
                    xlWorkSheetItems.Cells[index + 4, 11].Font.Bold = true;
                    xlWorkSheetItems.Cells[index + 4, 11].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#FFFFFF"));
                    xlWorkSheetItems.Cells[index + 4, 11].Formula = string.Format("=SUM(K2:K{0})", index);

                    //Agrega los bordes

                    //Define a range object(A2).
                    Microsoft.Office.Interop.Excel.Range _range;
                    _range = xlWorkSheetItems.get_Range(10.GetExcelColumnName().ToString() + (index + 1).ToString(), 11.GetExcelColumnName().ToString() + (index + 4).ToString());

                    //Get the borders collection.
                    //Microsoft.Office.Interop.Excel.Borders borders = _range.Borders;
                    //borders[XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //borders[XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //borders[XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //borders[XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    _range.BorderAround(Type.Missing,
                                        XlBorderWeight.xlThin,
                                        Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                                        System.Drawing.ColorTranslator.ToOle((Color)cc.ConvertFromString("#00B050")));

                    //_range.Borders.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#00B050"));
                    ////Set the hair lines style.
                    //borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //borders.Weight = 2d;

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

        public void SetAutoCompleteProducts()
        {
            this.txtFind.AutoCompleteMode = AutoCompleteMode.None;
            this.txtFind.AutoCompleteSource = AutoCompleteSource.None;

            List<posb.PM> pms = new posb.PM().List(IsItForSale: true);

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            foreach (posb.PM pm in pms)
            {
                data.Add(pm.Aux);

                //if (!string.IsNullOrEmpty(pm.Alias))
                //    data.Add(pm.Alias);
            }

            this.txtFind.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtFind.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtFind.AutoCompleteCustomSource = data;
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            //DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();
            //btnCancel.Name = "cancelar";
            //btnCancel.Text = "Cancelar";

            //btnCancel.HeaderText = "Cancelar";

            //int columnIndex = 6;

            //if (this.gvList.Columns["cancelar"] == null)
            //{
            //    this.gvList.Columns.Insert(columnIndex, btnCancel);
            //}
        }

        private void FillGridView()
        {
            if (this.LoadComplete)
            {
                this.Entity.Name = txtFind.Text;

                List<posb.Sale> lSale = this.Entity.List(this.dtpDate1.Value, this.dtpDate2.Value);

                this.gvList.DataSource = lSale;

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

                gvList.Controls.Add(this.CheckBoxHeader);

                this.lblTotalExpenses.Text = String.Format("{0:0.00}", lSale.Sum(item => item.Total));
            }
        }

        private void ConfigureDateTimePicker()
        {
            dtpDate1.Format = DateTimePickerFormat.Custom;
            dtpDate1.CustomFormat = "dd/MM/yyyy";
            dtpDate1.Value = DateTime.Now;//.AddDays(-7);

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

        private void OpenEdit(int? Id = null,bool Cancellation = false)
        {
            Sale sale = new Sale(Id, Cancellation);

            sale.ShowDialog();
        }

        #endregion

        private void dtpDate1_ValueChanged_1(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void dtpDate2_ValueChanged_1(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void gvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == this.gvList.Columns["Cancelar"].Index)
            //{
            //    if (this.Confirm("¿Realmente deseas cancelar la venta?"))
            //    {
            //        using (posb.Sale Entity = new posb.Sale())
            //        {
            //            Entity.Cancel(this.EntityId);
            //        }
            //    }
            //}
        }
    }
}


