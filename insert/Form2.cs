using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insert
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            soapclient.device_token soapclient = new soapclient.device_token();
            try
            {
                if (soapclient.login(id.Text, pwd.Text) == "OK")
                {
                    //Form1 dlg = new Form1();
                    //dlg.Show();

                    //this.Close();
                    this.Hide();
                    //Form1.name = id.Text;
                    Form1 dlg = new Form1();
                    dlg.Show();



                }
                else
                {
                    MessageBox.Show("잘못된 정보입니다.");
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.id.GotFocus += new EventHandler(textBox1_Focus); // enter event==get focus event 
            this.pwd.GotFocus += new EventHandler(textBox2_Focus); // enter event==get focus event 
            this.id.Text = "ID";
            id.ForeColor = Color.LightGray;
            id.Select();
            this.pwd.Text = "Password";
            pwd.ForeColor = Color.LightGray;
        }
        public void textBox1_Focus(Object sender, EventArgs e)
        {
            id.Text = "";
            id.ForeColor = Color.Black;
        }
        public void textBox2_Focus(Object sender, EventArgs e)
        {
            pwd.Text = "";
            pwd.PasswordChar = '*';
            pwd.ForeColor = Color.Black;
        }

        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.StartsWith("insert"))
                {
                    process.Kill();
                }
            }
        }
    }
}
