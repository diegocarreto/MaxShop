using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesForm.Extensions
{
    public static class eComboBox
    {
        public static ComboBox FillStrings<T>(this ComboBox Cmb, List<T> List, string Value = "Id", string Display = "Name", string Title = "Seleccione...", bool AddFirstOption = true)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            if (AddFirstOption)
                values.Add("0", Title);

            foreach (T obj in List)
            {
                string id = obj.GetType().GetProperty(Value).GetValue(obj, null).ToString();

                string name = obj.GetType().GetProperty(Display).GetValue(obj, null).ToString();

                values.Add(id, name);
            }

            Cmb.DataSource = new BindingSource(values, null);
            Cmb.DisplayMember = "Value";
            Cmb.ValueMember = "Key";

            Cmb.SelectedIndex = 0;

            return Cmb;
        }

        public static ComboBox Fill<T>(this ComboBox Cmb, List<T> List, string Value = "Id", string Display = "Name", string Title = "Seleccione...", bool AddFirstOption = true)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();

            if(AddFirstOption)
                values.Add(0, Title);

            foreach (T obj in List)
            {
                int id = (int)obj.GetType().GetProperty(Value).GetValue(obj, null);

                string name = obj.GetType().GetProperty(Display).GetValue(obj, null).ToString();

                values.Add(id, name);
            }

            Cmb.DataSource = new BindingSource(values, null);
            Cmb.DisplayMember = "Value";
            Cmb.ValueMember = "Key";

            Cmb.SelectedIndex = 0;

            return Cmb;
        }
    }
}
