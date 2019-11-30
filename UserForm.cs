using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Jegyfoglalo
{
    public partial class UserForm : Form
    {
        DB adatb = new DB();
        SQLiteCommand cmd;
        SQLiteDataAdapter sda;
        DataTable dt;

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

        private void btnUpper_Click(object sender, EventArgs e)
        {
            groupBox_long.Show();
            label_longgroup.Text = "Felső szekció";
        }

        private void btnLongGroupClose_Click(object sender, EventArgs e)
        {
            groupBox_long.Hide();

        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            groupBox_long.Show();
            label_longgroup.Text = "Alsó szekció";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            groupBox_side.Show();
            label_side.Text = "Jobb szekció";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            groupBox_side.Show();
            label_side.Text = "Bal szekció";
        }

        private void btnSideGroupClose_Click(object sender, EventArgs e)
        {
            groupBox_side.Hide();
        }

        private void btnAddtoList_Click(object sender, EventArgs e)
        {
           // listBox1.Items.Add();
        }
        
        private void picBox_Click(object sender, EventArgs e)
        {
            jeloles((PictureBox)sender);
        }

        private void jeloles(PictureBox pb)
        {
            string name = pb.Name.Replace("picBox", "");
            if(int.Parse(name)>=1 && int.Parse(name) <= 12)
            {
                if (pb.BackColor == Color.FromArgb(192, 0, 192))
                    pb.BackColor = Color.Orange;
                else
                    pb.BackColor = Color.FromArgb(192, 0, 192);
            }
            else
            {
                if (pb.BackColor == Color.Green)
                    pb.BackColor = Color.Orange;
                else
                    pb.BackColor = Color.Green;
            }
            
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            adatb.openConnection();
            //cmd = new SQLiteCommand()
            adatb.closeConnection();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            jeloles((PictureBox)sender);
        }
    }
}
