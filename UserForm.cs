using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jegyfoglalo
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Készítette: Tremmel Dávid", "Névjegy");
        }

        private void kijelentkezésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Biztosan szeretne kijelentkezni?", "Kijelentkezés", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedItem.ToString();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
