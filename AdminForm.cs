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
    public partial class AdminForm : Form
    {
        DB adatb = new DB();
        SQLiteCommand cmd;
        SQLiteDataAdapter sda;
        DataTable dt;

        List<PictureBox> pbList = new List<PictureBox>();
        List<int> selectedList = new List<int>();
        PictureBox[] pbArray = new PictureBox[395];

        int osszesen = 0;
        int ossz_normal = 0;
        int ossz_vip = 0;

        public AdminForm()
        {
            InitializeComponent();
            foreach (var pb in this.Controls.OfType<PictureBox>())
            {
                pbList.Add(pb);
            }
            pbArray = pbList.ToArray();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void kijelentkezésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Biztosan szeretne kijelentkezni?", "Kijelentkezés", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Készítette: Tremmel Dávid", "Névjegy");
        }

        private void markSeats()
        {
            adatb.openConnection();
            cmd = new SQLiteCommand("Select seatID, status, row from "+GetProperDB(), adatb.GetConnection());
            sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < pbArray.Length; i++)
            {
                string name = pbArray[i].Name.Replace("pictureBox", "");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j][0].ToString() == name)
                    {
                        jeloles_load(pbArray[i], dt.Rows[j][1].ToString(), dt.Rows[j][2].ToString());
                    }
                }
            }

            adatb.closeConnection();
        }

        private void showDataTable()
        {
            adatb.openConnection();
            cmd = new SQLiteCommand("SELECT bookedBy, section, row, column FROM " + GetProperDB()+" WHERE status='booked' ORDER BY bookedBy asc", adatb.GetConnection());
            sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            adatb.closeConnection();
        }

        private void calculateIncome()
        {
            osszesen = 0;
            ossz_normal = 0;
            ossz_vip = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == "A")
                {
                    ossz_vip += 50000;
                    osszesen += 50000;
                }
                else
                {
                    ossz_normal += 15000;
                    osszesen += 15000;
                }
            }

            label_bevNormalSzam.Text = ossz_normal.ToString() + " Ft";
            label_bevVIPSzam.Text = ossz_vip.ToString() + " Ft";
            label_bevTeljesSzam.Text = osszesen.ToString() + " Ft";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label_meccs.Text = comboBox1.SelectedItem.ToString();
            markSeats();
            showDataTable();
            calculateIncome();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            markSeats();
            showDataTable();
            calculateIncome();
        }

        private void jeloles_load(PictureBox pb, string status, string vip)
        {
            switch (status)
            {
                case "available":

                    if (vip == "A")
                    {
                        pb.BackColor = Color.FromArgb(192, 0, 192);
                        pb.Tag = "VIP";
                    }
                    else
                    {
                        pb.BackColor = Color.Green;
                        pb.Tag = "Normal";
                    }
                    break;
                case "booked":
                    pb.BackColor = Color.Red;
                    pb.Tag = "Booked";
                    break;
            }
        }

        private string GetProperDB()
        {
            if (comboBox1.SelectedItem.ToString() == "Németország - Anglia")
            {
                return "GERvsENG";
            }
            if (comboBox1.SelectedItem.ToString() == "Franciaország - Svédország")
            {
                return "FRAvsSWE";
            }
            else
                return "";
        }
    }
}
