using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWarehouse.Models;

namespace Lab3_4
{
    public partial class Form1 : Form
     {
        private List<City> cityList { get; set; }
        private bool CalendarStatus = false;
        public Form1()
        {
            InitializeComponent();
            cityList = Task.Run(ApiConnector.GetCities).Result;
            var cityList2 = new List<City>(cityList);
            comboBox1.DataSource = cityList;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "CityName";
                   
            comboBox2.DataSource = cityList2;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "CityName";
        }
        
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (CalendarStatus == false)
            {
                groupBox1.Show();
                CalendarStatus = true;
            }
            else if (CalendarStatus == true) {
                groupBox1.Visible = false;
                CalendarStatus = false;
            }
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToString("dd.MM.yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //this.Hide();
            f2.ShowDialog();
            if (ApiConnector.CurrentUser.Login != null) this.Name = this.Name + " - " + ApiConnector.CurrentUser.Login;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            //this.Hide();
            f3.ShowDialog();
            if (ApiConnector.CurrentUser.Login != null) this.Name = this.Name + " - " + ApiConnector.CurrentUser.Login;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add(cityList);
            //comboBox2.Items.Add(cityList);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var searchTrip = new SearchTrip()
            {
                IdCityFrom = ((City)comboBox1.SelectedItem).Id,
                IdCityTo = ((City)comboBox1.SelectedItem).Id,
                TripDate = monthCalendar1.SelectionStart.Date
            };

            List<Trip> tripList = Task.Run(()=>ApiConnector.SearchTrips(searchTrip)).Result;

        }
    }
}
