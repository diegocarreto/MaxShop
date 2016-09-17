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
    }
}
