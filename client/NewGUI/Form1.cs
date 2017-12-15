using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Signin siginForm = new Signin();
            this.Hide();
            siginForm.ShowDialog();
        }
    }
}
