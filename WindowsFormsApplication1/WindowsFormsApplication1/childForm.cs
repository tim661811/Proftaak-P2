using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class childForm : Form
    {

        string connectionString = @"Server=tcp:taskm8database.database.windows.net,1433;Initial Catalog=Proftaak_P2;Persist Security Info=False;User ID=taskM8;Password=Welkom00;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public childForm()
        {
            InitializeComponent();
        }

        string toViewDate;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            toViewDate = dateTimePicker1.Value.ToString();
        }

        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*private void getChildInfo()
        {

            
            
            SqlConnection conn = new SqlConnection(connectionString);
            string result = @"SELECT * FROM Vaat WHERE Datum = '" + dateTimePicker1.Value.ToString() + "';";
            conn.Open();
            SqlCommand showresult = new SqlCommand(result, conn);
            SqlDataReader data = showresult.ExecuteReader();
            lbOnTime.Items.Add(data["Vaat_optijd"].ToString());
            lbTooLate.Items.Add(data["Vaat_TeLaat"].ToString());
            lbUpcoming.Items.Add(data["Vaat_aankomend"].ToString());
            conn.Close();
        }*/

        private void childForm_Load(object sender, EventArgs e)
        {
            //getChildInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM Vaat WHERE Datum ='"+dateTimePicker1.Value.ToString()+"'", conn))
            {

                var data = new DataTable();
                query.Fill(data);

                lbOnTime.DisplayMember = "Vaat_optijd";
                lbTooLate.DisplayMember = "Vaat_TeLaat";
                lbUpcoming.DisplayMember = "Vaat_aankomend";

                lbOnTime.DataSource = data;
                lbTooLate.DataSource = data;
                lbUpcoming.DataSource = data;

            }
                

        }
    }
}
