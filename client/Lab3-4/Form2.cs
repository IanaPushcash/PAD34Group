using DataWarehouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApiConnector.CurrentUser = null;
            var userForLogin = new User()
            {
                Login = textBox1.Text,
                Password = textBox2.Text
            };
            User user = Task.Run(() => ApiConnector.Login(userForLogin)).Result;
            if (user.Id == 0) MessageBox.Show("Логин или пароль не верен!", "Ошибка");
            else
            {
                ApiConnector.CurrentUser = user;
                this.Close();
            }
        }
    }
}
