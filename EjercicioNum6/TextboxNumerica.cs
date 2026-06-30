using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioNum6
{
    internal class TextboxNumerica : TextBox
    {
        public bool ToFloat(out float value, string campo)
        {
            if (!float.TryParse(this.Text, out value))
            {
                MessageBox.Show($"El numero introducido en el campo {campo} introducido debe ser un valor numerico");
                return false;
            }
            return true;

        }

        public bool ToInt(out int value, string campo)
        {
            if (!int.TryParse(this.Text, out value))
            {
                MessageBox.Show($"El numero introducido en el campo {campo} introducido debe ser un valor numerico entero");
                return false;
            }
            return true;

        }
    }
}
