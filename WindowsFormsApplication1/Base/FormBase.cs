using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Extensions;

namespace WindowsFormsApplication1
{
    public class FormBase : Form
    {       
        protected override void OnLoad(EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(this.AppSet<string>("BackColorForm"));

            this.StartPosition = FormStartPosition.CenterScreen;

            foreach (var gv in this.Controls.OfType<DataGridView>())
            {
                gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(this.AppSet<string>("BackColorHeaderGrid"));
            }

            foreach (var btn in this.Controls.OfType<Button>())
            {
                btn.BackColor = ColorTranslator.FromHtml(this.AppSet<string>("BackColorButtons"));
            }

            base.OnLoad(e);
        }

        protected void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
    }
}
