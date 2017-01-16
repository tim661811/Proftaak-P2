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
    public partial class Login : Form
    {
        string connectionString = @"Server=tcp:taskm8database.database.windows.net,1433;Initial Catalog=Proftaak_P2;Persist Security Info=False;User ID=taskM8;Password=Welkom00;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginActions();
        }


        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginActions();
            }
        }

        /// ////////////////////////////////////////////////////Methodes////////////////////////////////////////////////////////////

        private void loginActions()
        {
            // SQL CONNECTION + COMMAND

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter cmd = new SqlDataAdapter(@"SELECT role FROM user 
                                        WHERE username='"+ tbUsername.Text +"'and password='"+ tbPassword.Text + "'", conn);
            DataTable dt = new DataTable();
            
            cmd.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["role"] };
            conn.Open();
            // EINDE SQL GEDEELTE
            // KIJKEN OF DATA KLOPT AAN INGEVULDE WAARDE VVVVVVV
            try
            {
                if (dt.Rows.Count == 1)
                {
                    
                    MessageBox.Show("Welkom " + tbUsername.Text);

                    if (dt.Rows.Contains("parent"))
                    {
                        parentForm parentForm = new parentForm();

                        this.Hide();
                        parentForm.Show();
                    }
                    if (dt.Rows.Contains("child"))
                    {
                        childForm childForm = new childForm();

                        this.Hide();
                        childForm.Show();
                    }
                    if (dt.Rows.Contains("admin"))
                    {
                        childForm childForm = new childForm();
                        parentForm parentForm = new parentForm();

                        this.Hide();
                        parentForm.Show();
                        childForm.Show();
                    }


                }
                else
                {
                    MessageBox.Show("Gebruikersnaam / Wachtwoord onjuist, probeer opnieuw.");
                }

            }
            catch (Exception ex)
            {
                // Print error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close database connection

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }
}
