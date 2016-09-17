using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Extensions;
using UtilitiesForm.Extensions;
using posb = PosBusiness;

namespace WindowsFormsApplication1
{
    public partial class ProductMass : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage);

        public event Communication Result;

        private MassiveLoadTypes TypeMass;

        private string SheetName;

        #endregion

        public ProductMass(MassiveLoadTypes TypeMass)
        {
            InitializeComponent();

            this.TypeMass = TypeMass;

            this.SetSheetName();

            this.Text = "Carga masiva de " + this.SheetName;
        }

        private void SetSheetName()
        {
            switch (this.TypeMass)
            {
                case MassiveLoadTypes.Product:

                    this.SheetName = "Productos";

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (ofdExcel.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdExcel.FileName;
            }
        }

        private void ProductMass_Load(object sender, EventArgs e)
        {
            ConfigureShowDialog();
        }

        public void ConfigureShowDialog()
        {
            ofdExcel.FileName = string.Empty;

            ofdExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofdExcel.Title = "Indica el archivo Excel que contiene los productos";

            ofdExcel.DefaultExt = "xlsx";
            ofdExcel.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
        }

        /// <summary>
        /// Obtiene la informacion de una hoja de un archivo Excel.
        /// </summary>
        /// <param name="Path">Path donde se encuentra el archivo a cargar.</param>
        /// <param name="Hoja">Nombre de la hoja que se desea leer.</param>
        /// <returns>Objeto DataTable con la informacion de la hoja.</returns>
        public DataTable ImportExcel(String Path, String Hoja, String Rango = "")
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\""))
                {
                    using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + Hoja + "$" + Rango + "]", con))
                    {
                        using (OleDbDataAdapter ada = new OleDbDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {

                                DataTable Dt = new DataTable();

                                con.Open();
                                ada.Fill(dt);
                                con.Close();

                                Dt = DeleteEmptyRows(dt);

                                return Dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new DataTable();
            }
        }

        /// <summary>
        /// Elimina las filas del objeto DataTable donde el valor de todas las columnas es DbNull o String.Empty.
        /// </summary>
        /// <param name="Dt">Objeto DataTable.</param>
        /// <param name="Message"></param>
        /// <returns>Objeto DataTable sin filas vacias.</returns>
        public DataTable DeleteEmptyRows(DataTable Dt)
        {
            try
            {

                int row = Dt.Rows.Count,
                    column = Dt.Columns.Count,
                    empty = 0;

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (Dt.Rows[i][j] == DBNull.Value)
                        {
                            empty++;
                        }
                    }

                    if (empty.Equals(column))
                        Dt.Rows[i].Delete();

                    empty = 0;
                }

                Dt.AcceptChanges();

            }
            catch (Exception ex)
            {

            }

            return Dt;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
            lblAccion.Text = string.Empty;
            pb.Value = 0;

            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                try
                {
                    StringBuilder message = new StringBuilder();

                    message.AppendLine("Leyendo archivo...");
                    lblAccion.Text = "Leyendo archivo...";

                    using (DataTable dt = ImportExcel(txtPath.Text, this.SheetName))
                    {
                        using (posb.Product product = new posb.Product())
                        {
                            using (posb.Group group = new posb.Group())
                            {
                                int index = 1;

                                pb.Minimum = 0;
                                pb.Maximum = dt.Rows.Count;

                                foreach (DataRow dr in dt.Rows)
                                {
                                    lblAccion.Text = "Leyendo fila " + index + ".";

                                    try
                                    {
                                        if (!string.IsNullOrEmpty(dr["Nombre"].ToString()) && !string.IsNullOrEmpty(dr["Grupo"].ToString()) && !string.IsNullOrEmpty(dr["Activo"].ToString()))
                                        {
                                            lblAccion.Text = "Cargado el producto: " + dr["Nombre"].ToString();

                                            group.Name = dr["Grupo"].ToString();

                                            int idGroup = group.GetIdByNameGroup();

                                            if (idGroup != 0)
                                            {
                                                product.Name = dr["Nombre"].ToString();
                                                product.Active = dr["Activo"].ToString().Equals("Si", StringComparison.InvariantCultureIgnoreCase);
                                                product.IdGroup = idGroup;

                                                if (!product.Exist())
                                                {
                                                    if (product.Save())
                                                    {
                                                        message.AppendLine("El producto [" + product.Name + "] se cargo correctamente.");
                                                    }
                                                    else
                                                    {
                                                        message.AppendLine("Ocurrio un error al cargar el producto [" + product.Name + "]\r\n\tDescripcion: " + product.ErrorMessage);
                                                    }
                                                }
                                                else
                                                {
                                                    message.AppendLine("El producto [" + product.Name + "] ya se encuentra registrado.");
                                                }
                                            }
                                            else
                                            {
                                                message.AppendLine("Ocurrio un error al cargar el producto [" + product.Name + "]\r\n\tDescripcion: No se encuentra registrado el grupo [" + group.Name + "].");
                                            }
                                        }
                                        else
                                        {
                                            message.AppendLine("Ocurrio un error al leer la fila " + index + ".\r\n\tDescripcion: " + "Faltan campos por llenar.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        message.AppendLine("Ocurrio un error al leer la fila " + index + ".\r\n\tDescripcion: " + ex.Message + ".");
                                    }

                                    index ++;
                                    pb.Value ++;
                                }
                            }
                        }
                    }

                    message.AppendLine("Fin del proceso de carga masiva.");
                    lblAccion.Text = "Fin del proceso de carga masiva.";

                    txtLog.Text = message.ToString();

                    this.Result(true, "");
                }
                catch (Exception ex)
                {
                    txtLog.Text = "Ocurrio un error durante el proceso de carga masiva. \r\nDescripcion:" + ex.Message;
                }
            }
            else
            {
                this.Alert("Debe seleccionar un archivo para realizar la carga masiva");
            }
        }
    }

    public enum MassiveLoadTypes
    {
        Product
    }
}
