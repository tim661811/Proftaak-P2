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
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ="
                + @"C:\Users\stant\OneDrive\- Fontys\- FUN12\DuikLogboek (database practise)\DuikLogboek (database practise)\Login.mdf; Integrated Security = True; Connect Timeout = 30";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }


       
/// ////////////////////////////////////////////////////Methodes////////////////////////////////////////////////////////////
        
        private void loginActions()
        {
            // SQL CONNECTION + COMMAND

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM login 
                                        WHERE username=@username and 
                                        password=@password", conn);
            cmd.Parameters.AddWithValue("@username", tbUsername.Text);
            cmd.Parameters.AddWithValue("@password", tbPassword.Text);
            conn.Open();
            // EINDE SQL GEDEELTE
            // KIJKEN OF DATA KLOPT AAN INGEVULDE WAARDE VVVVVVV
            try
            {
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    MessageBox.Show("Welkom " + tbUsername.Text);

                    Form1 newform = new Form1();

                    this.Hide();
                    newform.Show();

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
