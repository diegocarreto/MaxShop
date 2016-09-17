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
using BarcodeLib;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Utilities.Extensions;

namespace WindowsFormsApplication1
{
    public partial class Box : FormBase
    {
        #region Members

        public bool Close = false;

        public int CountClose = 0;

        #endregion

        #region Properties

        public int Id { get; set; }

        public bool New { get; set; }

        #endregion

        #region Builder

        public Box(bool New)
        {
            this.New = New;

            InitializeComponent();
        }

        #endregion

        #region Events


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.button1.Text.Equals("   Cerrar"))
            {
                this.Close = true;
            }

            this.Close();
        }

        #endregion

        private void Box_Load(object sender, EventArgs e)
        {
            if (!this.New)
            {
                this.button1.Text = "   Cerrar";
                this.txtOrigin.ReadOnly = true;

                using (posb.Box box = new posb.Box
                {
                    IdUser = 1,
                    CashRegister = this.AppSet<int>("CashRegister")
                })
                {
                    box.Get();

                    this.txtOrigin.Text = String.Format("${0:0.00}", box.Origin);
                    this.txtCurrent.Text = String.Format("${0:0.00}", box.Total);
                    this.txtDif.Text = String.Format("${0:0.00}", box.Obtained);
                }
            }

            this.ActiveControl = this.txtOrigin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text.Equals("   Cerrar"))
            {
                if (this.Confirm("¿Realmente desea realizar el corte de caja?"))
                {
                    using (posb.Box box = new posb.Box
                    {
                        IdUser = 1,
                        CashRegister = this.AppSet<int>("CashRegister"),
                        Total = decimal.Parse(this.txtCurrent.Text.Replace("$", string.Empty))
                    })
                    {
                        if (box.Close())
                        {
                            this.Close = true;
                            Application.Restart();
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtOrigin.Text))
                {
                    using (posb.Box box = new posb.Box
                    {
                        IdUser = 1,
                        CashRegister = this.AppSet<int>("CashRegister"),
                        Total = decimal.Parse(this.txtOrigin.Text)
                    })
                    {
                        if (box.Open())
                        {
                            this.Close = true;
                        }
                    }
                }
                else
                {
                    this.Alert("Debe indicar el monto actual.");
                    this.txtOrigin.Focus();
                }

            }
        }

        private void Box_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Close)
            {
                this.CountClose++;

                if (this.CountClose > 2)
                    Application.Exit();
                else
                {
                    e.Cancel = true;

                    this.Alert("Debe indicar el monto actual y abrir caja. Intento " + this.CountClose + " de " + "3.");
                }
            }
        }

        #region Methods
        #endregion
    }
}
