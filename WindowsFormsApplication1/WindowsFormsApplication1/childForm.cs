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
        

        public childForm(string currentUser)
        {
            
            InitializeComponent();
            label5.Text = currentUser;
            //MessageBox.Show(currentUser);
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

        private void childForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = label5.Text;
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM Vaat WHERE Username ='"+user+"' AND Datum ='"+dateTimePicker1.Value.ToString()+"'", conn))
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
