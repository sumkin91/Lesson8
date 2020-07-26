using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxLinkValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(textBox.Text, out int res))
                {
                    if (res >= numericUpDown.Minimum && res <= numericUpDown.Maximum)
                    {
                        numericUpDown.Value = res;
                    }
                    else MessageBox.Show($"Введите числов от {numericUpDown.Minimum} до {numericUpDown.Maximum}!");
                }
                else MessageBox.Show("Введены символы!");
            }
        }
    }
}
