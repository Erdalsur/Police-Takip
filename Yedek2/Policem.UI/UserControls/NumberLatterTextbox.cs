using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policem.UI.UserControls
{
    public partial class NumberLatterTextbox : TextBox
    {
        public DataType DataType { get; set; }
        public NumberLatterTextbox()
        {
            InitializeComponent();
            DataType = DataType.NumberLetter;
            KeyPress += OnKeyPress;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (DataType == DataType.Number ? !char.IsDigit(e.KeyChar) : DataType == DataType.Letter ? !Char.IsLetter(e.KeyChar) : !Char.IsLetterOrDigit(e.KeyChar)) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
    public enum DataType
    {
        Number,
        Letter,
        NumberLetter
    }
}
