using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BelieveOrNotBelieve;

namespace WindowsFormsAppBase
{
    public partial class Form1 : Form
    {
        TrueFalse database;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Надеюсь программа нормальная, но это не точно!\nVersion: 0.0.1\nCopyright opensourse", "About",MessageBoxButtons.OK);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save(sfd.FileName);
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
            else MessageBox.Show("Создайте новую базу данных", "Сообщение");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }

        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
            database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    database.Save(saveFile.FileName);
                }
            }
            else MessageBox.Show("База данных не создана");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }
    }
}
