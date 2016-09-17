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
    public partial class StockPM : FormBase
    {
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

        public StockPM()
        {
            InitializeComponent();

            this.Entity = new posb.PM();
        }

        #endregion

        #region Events

        private void cmProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            svdReportStock.FileName = "OrderDeCompra_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

            if (svdReportStock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = 2;

                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Workbook xlWorkBook = null;
                Worksheet xlWorkSheetItems = null;

                object misValue = System.Reflection.Missing.Value;

                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();

                    xlApp.Visible = false;
                    xlApp.DisplayAlerts = false;
                    xlApp.EnableEvents = false;

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\Stock\\" + this.AppSet<string>("PurchaseOrder"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    this.FillGridView();

                    List<PosBusiness.PM> lPm = this.Entity.ListStock();

                    foreach (PosBusiness.PM pm in lPm)
                    {
                       

                        (xlWorkSheetItems.Cells[index, 1] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 1] = pm.Name + " " + pm.Material + " " + pm.Measure + " " + pm.Brand + " ";

                        (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 2] = pm.CodeVendor;

                        xlWorkSheetItems.Cells[index, 3] = pm.Buy;

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

                    if (this.Confirm("¿Deseas abrir la orden de compra?"))
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

        private void button1_Click(object sender, EventArgs e)
        {
            svdReportStock.FileName = "Stock_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

            if (svdReportStock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = 2;

                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Workbook xlWorkBook = null;
                Worksheet xlWorkSheetItems = null;

                object misValue = System.Reflection.Missing.Value;

                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();

                    xlApp.Visible = false;
                    xlApp.DisplayAlerts = false;
                    xlApp.EnableEvents = false;

                    xlWorkBook = xlApp.Workbooks.Open(this.GetPath() + "\\Templates\\Stock\\" + this.AppSet<string>("StockReport"), Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                                                                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                                                                    Type.Missing, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlNormalLoad);

                    //Agrega la hoja de items
                    xlWorkSheetItems = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    this.FillGridView();

                    List<PosBusiness.PM> lPm = this.Entity.ListStock();

                    foreach (PosBusiness.PM pm in lPm)
                    {
                        (xlWorkSheetItems.Cells[index, 1] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 1] = pm.Id.ToString().PadLeft(5, '0');

                        (xlWorkSheetItems.Cells[index, 2] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 2] = pm.Name;

                        (xlWorkSheetItems.Cells[index, 3] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 3] = pm.Material;

                        (xlWorkSheetItems.Cells[index, 4] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 4] = pm.Measure;

                        (xlWorkSheetItems.Cells[index, 5] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "@";
                        xlWorkSheetItems.Cells[index, 5] = pm.Brand;

                        xlWorkSheetItems.Cells[index, 6] = pm.Price;
                        (xlWorkSheetItems.Cells[index, 6] as Microsoft.Office.Interop.Excel.Range).NumberFormat = "$###,##";

                        xlWorkSheetItems.Cells[index, 7] = pm.Stock;

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

        private void Product_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.GetProvider();

            this.ConfigureDialogs();

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

        #endregion

        #region Methods

        private void GetProvider()
        {
            using (posb.Provider Provider = new posb.Provider())
            {
                this.cmProvider.Fill(Provider.List());
            }
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            if (this.LoadComplete)
            {
                this.Entity.Name = txtFind.Text;

                if (this.cmProvider.SelectedIndex > 0)
                {
                    this.Entity.IdProvider = int.Parse(this.cmProvider.SelectedValue.ToString());
                }
                else
                {
                    this.Entity.IdProvider = null;
                }

                this.gvList.DataSource = this.Entity.ListStock();

                lblTotal.Text = this.gvList.RowCount.ToString();
            }
        }

        private void ConfigureDialogs()
        {
            svdReportStock.Filter = "Archivo de Excel(*.xlsx)|*.xlsx";
            svdReportStock.FilterIndex = 0;
            svdReportStock.Title = "Guardar como";
            svdReportStock.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        #endregion

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1))
            {
                this.OpenEdit(this.EntityId);
            }
        }


        private void OpenEdit(int? Id = null, bool IsCopy = false)
        {
            PMEdit PMEdit = new PMEdit(Id, IsCopy);

            PMEdit.Result += new PMEdit.Communication(ResultPM);

            PMEdit.ShowDialog();
        }

        private void ResultPM(bool IsCorrect, String ErrorMessage)
        {
            this.FillGridView();
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

    }
}


