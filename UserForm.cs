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

        List<PictureBox> pbList = new List<PictureBox>();
        List<int> selectedList = new List<int>();
        PictureBox[] pbArray=new PictureBox[395];

        int osszesen=0;

        public UserForm()
        {
            InitializeComponent();
            foreach (var pb in this.Controls.OfType<PictureBox>())
            {
                pbList.Add(pb);
            }
            pbArray = pbList.ToArray();
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
            markSeats(comboBox1.SelectedItem.ToString());
            listBox1.Items.Clear();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            markSeats(comboBox1.SelectedItem.ToString());
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

        private void jeloles(PictureBox pb)
        {
            switch (pb.Tag.ToString())
            {
                case "VIP":
                    if (pb.BackColor == Color.FromArgb(192, 0, 192))
                    {
                        pb.BackColor = Color.Orange;
                        selectedList.Add(int.Parse(pb.Name.Replace("pictureBox", "")));
                        listBox1.Items.Add(getSeatNumber(pb.Name.Replace("pictureBox", "")) + " - VIP");
                        osszesen += 50000;
                        label_osszesen.Text = osszesen.ToString() + " Ft";
                    }
                    else
                    {
                        pb.BackColor = Color.FromArgb(192, 0, 192);
                        selectedList.Remove(int.Parse(pb.Name.Replace("pictureBox", "")));
                        listBox1.Items.Remove(getSeatNumber(pb.Name.Replace("pictureBox", "")) + " - VIP");
                        osszesen -= 50000;
                        label_osszesen.Text = osszesen.ToString() + " Ft";
                    }
                        
                    break;
                case "Normal":
                    if (pb.BackColor == Color.Green)
                    {
                        pb.BackColor = Color.Orange;
                        selectedList.Add(int.Parse(pb.Name.Replace("pictureBox", "")));
                        listBox1.Items.Add(getSeatNumber(pb.Name.Replace("pictureBox", "")) + " - Normál");
                        osszesen += 15000;
                        label_osszesen.Text = osszesen.ToString() + " Ft";
                    }
                    else
                    {
                        pb.BackColor = Color.Green;
                        selectedList.Remove(int.Parse(pb.Name.Replace("pictureBox", "")));
                        listBox1.Items.Remove(getSeatNumber(pb.Name.Replace("pictureBox", "")) + " - Normál");
                        osszesen -= 15000;
                        label_osszesen.Text = osszesen.ToString() + " Ft";
                    }
                        
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

        private string getSeatNumber(string seatID)
        {
            string seat;
            adatb.openConnection();
            cmd = new SQLiteCommand("Select section,row, column from "+GetProperDB()+" where seatID='"+seatID+"'",adatb.GetConnection());
            sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            seat = dt.Rows[0][0].ToString()+" "+dt.Rows[0][1].ToString()+dt.Rows[0][2].ToString();
            adatb.closeConnection();

            return seat;
        }

        private void markSeats(string match)
        {
            switch(match)
            {
                case "Németország - Anglia":
                    adatb.openConnection();
                    cmd = new SQLiteCommand("Select seatID, status, row from GERvsENG", adatb.GetConnection());
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
                    break;
                case "Franciaország - Svédország":
                    adatb.openConnection();
                    cmd = new SQLiteCommand("Select seatID, status, row from FRAvsSWE", adatb.GetConnection());
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
                    break;
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            adatb.openConnection();
            for(int i =0;i<selectedList.Count;i++)
            {
                cmd = new SQLiteCommand("UPDATE " + GetProperDB() + " SET status='booked', bookedBy='" + textBox_vasarlo.Text + "' where seatID=" + selectedList[i].ToString(), adatb.GetConnection());
                cmd.ExecuteNonQuery();
            }
            adatb.closeConnection();
            MessageBox.Show("Sikeres foglalás!");
            textBox_vasarlo.Text = "";
            label_osszesen.Text = "0 Ft";
            selectedList.Clear();
            listBox1.Items.Clear();
            markSeats(comboBox1.SelectedItem.ToString());
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            jeloles((PictureBox)sender);
        }
    }
}
