﻿using System;
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

        private void getChildInfo()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string result = @"SELECT * FROM kind WHERE id= kindnummer AND date = @dateTimePicker1;";

            SqlCommand showresult = new SqlCommand(result, conn);
            SqlDataReader data = showresult.ExecuteReader();
            label3.Text = data["aantal keer op tijd"].ToString();
            label4.Text = data["aantal keer te laat"].ToString();
        }
    }
}
