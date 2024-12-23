using System;
using System.Windows.Forms;

namespace insert
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dlg = new Form1();
            dlg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Show();
        }
    }
}
