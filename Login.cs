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
    public partial class Login : Form
    {
        DB adatb = new DB();
        SQLiteCommand cmd;
        SQLiteDataAdapter sda;
        DataTable dt;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            adatb.openConnection();
            cmd = new SQLiteCommand("Select count (*) from login where username = '" + textBox_user.Text + "' and password = '" + textBox_pw.Text + "'", adatb.GetConnection());
            sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "0") {
                MessageBox.Show("Hibás belépési adatok!");
                adatb.closeConnection();
            }
            else
            {
                cmd = new SQLiteCommand("Select * from login where username = '" + textBox_user.Text + "' and password = '" + textBox_pw.Text + "'", adatb.GetConnection());
                sda = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                switch (dt.Rows[0][2])
                {
                    case "admin":
                        this.Hide();
                        adatb.closeConnection();
                        AdminForm af = new AdminForm();
                        af.Show();
                        break;

                    case "user":
                        this.Hide();
                        adatb.closeConnection();
                        UserForm uf = new UserForm();
                        uf.Show();
                        break;
                }
            }
        }

        private void checkBox_Show_Hide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Show_Hide.Checked == true)
                textBox_pw.UseSystemPasswordChar = false;
            else
                textBox_pw.UseSystemPasswordChar = true;
        }

        private void textBox_pw_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
