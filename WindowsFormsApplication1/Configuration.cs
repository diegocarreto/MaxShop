using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesForm.Extensions;
using posb = PosBusiness;

namespace WindowsFormsApplication1
{
    public partial class Configuration : FormBase
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            this.GetIp();

            this.GetMAC();

            this.GetDataBase();

            this.GetGeneral();

            this.GetPrint();

            this.GetSale();

            this.GetRecharge();
        }

        private void GetDataBase()
        {
            this.txtIpServer.Text = this.GetConfig("DataSource");
            this.txtCatalog.Text = this.GetConfig("InitialCatalog");
            this.txtUser.Text = this.GetConfig("UserId");
            this.txtPassword.Text = this.GetConfig("Password");
            this.txtConfirmDB.Text = this.GetConfig("Password");
            this.txtMac.Text = this.GetConfig("MacAddress");
        }

        private void GetGeneral()
        {
            this.txtOffice.Text = this.GetConfig("BranchOffice");
            this.txtBox.Text = this.GetConfig("CashRegister");
            this.txtTimeUpdateSale.Text = this.GetConfig("MaxHoursModifyPurchase");

            this.cbWizard.Checked = bool.Parse(this.GetConfig("WizardCloseWhenFinishedAdding"));
            this.cmMenuTruper.Checked = bool.Parse(this.GetConfig("ShowOptionTruper"));
        }

        private void GetPrint()
        {
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                this.cmbPrinters.Items.Add(strPrinter.Trim());
            }

            this.cmbPrinters.Text = this.GetConfig("Printer");

            this.txtNamePrint.Text = this.GetConfig("ShopName").Replace("°", " ");
            this.txtPhonePrint.Text = this.GetConfig("TicketPhoneNumber");
            this.txtSANPrint.Text = this.GetConfig("TicketAddress1");
            this.txtLEPrint.Text = this.GetConfig("TicketAddress2");

        }

        private void GetSale()
        {
            this.txtClientDefault.Text = this.GetConfig("ClientDefault");
            this.txtIVA.Text = this.GetConfig("Iva");

            this.cbStock.Checked = bool.Parse(this.GetConfig("CheckStock"));
        }

        private void GetRecharge()
        {
            this.txtUserR.Text = this.GetConfig("UserForRecharge");
            this.txtPasswordR.Text = this.GetConfig("PasswordForRecharge");
            this.txtConfirm.Text = this.GetConfig("PasswordForRecharge");
            this.txtCommissionR.Text = this.GetConfig("CommissionForRecharge");

            this.cbBrowserR.Checked = bool.Parse(this.GetConfig("ShowBrowserForRecharge"));
        }

        private void GetIp()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIPs)
                this.txtMyIp.Text = address.ToString();
        }

        private void GetMAC(TextBox Txt = null)
        {
            if (Txt == null)
            {
                Txt = this.txtMyMac;
            }

            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()
                   ).FirstOrDefault();

            var mac = string.Empty;

            for (int i = 0; i < macAddr.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    mac += macAddr[i].ToString() + "-";
                }
                else
                {
                    mac += macAddr[i].ToString();
                }
            }

            mac = mac.Remove(mac.Length - 1);

            Txt.Text = mac;
        }

        private void SetConfig(string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private string GetConfig(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            return config.AppSettings.Settings[key].Value.ToString().Trim();
        }

        private void btnTestSqlServer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string message = string.Empty;

            if (this.IsServerConnected("Data Source=" + this.txtIpServer.Text +
                                   ";Initial Catalog=" + this.txtCatalog.Text +
                                   ";User Id=" + this.txtUser.Text +
                                   ";Password=" + this.txtPassword.Text, ref message))
            {
                this.Alert(message, eForm.TypeError.Exclamation);
            }
            else
            {
                this.Alert(message, eForm.TypeError.Error);
                this.txtIpServer.Focus();
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Test that the server is connected
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <returns>true if the connection is opened</returns>
        public bool IsServerConnected(string ConnectionString, ref string Message)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var query = "SELECT 1";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        Message += "Conexión exitosa.\r\n";

                        command.ExecuteScalar();
                        Message += "Ejecución exitosa.\r\n";

                        connection.Close();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Message += "Ocurrió un error durante la prueba.\r\nDescripción:" + ex.Message;

                return false;
            }
        }

        private void btnGetIp_Click(object sender, EventArgs e)
        {
            this.GetIp();
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetConfig("DataSource", this.txtIpServer.Text);
                this.SetConfig("InitialCatalog", this.txtCatalog.Text);
                this.SetConfig("UserId", this.txtUser.Text);
                this.SetConfig("Password", this.txtPassword.Text);
                this.SetConfig("Password", this.txtConfirmDB.Text);
                this.SetConfig("MacAddress", this.txtMac.Text);

                this.SetConfig("BranchOffice", this.txtOffice.Text);
                this.SetConfig("CashRegister", this.txtBox.Text);
                this.SetConfig("MaxHoursModifyPurchase", this.txtTimeUpdateSale.Text);

                this.SetConfig("WizardCloseWhenFinishedAdding", this.cbWizard.Checked.ToString());
                this.SetConfig("ShowOptionTruper", this.cmMenuTruper.Checked.ToString());

                this.SetConfig("Printer", this.cmbPrinters.Text);

                this.SetConfig("ShopName", this.txtNamePrint.Text.Replace(" ", "°"));
                this.SetConfig("TicketPhoneNumber", this.txtPhonePrint.Text);
                this.SetConfig("TicketAddress1", this.txtSANPrint.Text);
                this.SetConfig("TicketAddress2", this.txtLEPrint.Text);

                this.SetConfig("ClientDefault", this.txtClientDefault.Text);
                this.SetConfig("Iva", this.txtIVA.Text);

                this.SetConfig("CheckStock", this.cbStock.Checked.ToString());

                this.SetConfig("UserForRecharge", this.txtUserR.Text);
                this.SetConfig("PasswordForRecharge", this.txtPasswordR.Text);
                this.SetConfig("CommissionForRecharge", this.txtCommissionR.Text);

                this.SetConfig("ShowBrowserForRecharge", this.cbBrowserR.Checked.ToString());

                Application.Restart();
            }
            catch (Exception ex)
            {
                this.Alert("Ocurrió un error al intentar guardar los cambios. Descripción: " + ex.Message, eForm.TypeError.Error);
            }
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            this.txtIpServer.Text = "127.0.0.1";
        }

        private void btnMac_Click(object sender, EventArgs e)
        {
            this.GetMAC();
        }

        private void btnLocalMac_Click(object sender, EventArgs e)
        {
            this.GetMAC(this.txtMac);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                posb.Configuration con = new posb.Configuration();

                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BackUp";

                con.CreateBackUpDataBase(path);

            }).Start();

            this.Alert("Se creara el respaldo de la información y se subirá a la nube.");
        }

    }
}
