using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesForm.Extensions
{
    public static class eForm
    {
        public static Form Alert(this Form Frm, string Message, TypeError Type = TypeError.Exclamation)
        {
            if (Type.Equals(TypeError.Exclamation))
                MessageBox.Show(Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return Frm;
        }

        public static bool Confirm(this Form Frm, string Message)
        {
            return MessageBox.Show(Message, "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(System.Windows.Forms.DialogResult.Yes);
        }

        public static string GetPath(this Form Frm)
        {
            return System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }

        /// <summary>
        /// Libera los recursos de los objetos indicados.
        /// </summary>
        /// <param name="Objs">Arreglo de objetos.</param>
        public static void ReleasingObjects(this Form Frm, params Object[] Objs)
        {
            for (int i = 0; i < Objs.Length; i++)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Objs[i]);
                }
                catch
                {
                    Objs[i] = null;
                }
                finally
                {
                    GC.Collect();
                }
            }

            Objs = null;
            GC.Collect();
        }

        public enum TypeError
        {
            Exclamation,
            Error
        }
    }
}
