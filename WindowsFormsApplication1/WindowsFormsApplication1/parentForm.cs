using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class parentForm : Form
    {
        public parentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 99; i++)
            {
                MessageBox.Show("Test");
            }
            
        }
        int cleaningTime;
        bool TV;
        bool WiFi;
        bool Laptop;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dropDownTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleaningTime = Convert.ToInt32(dropDownTimer.Text.Substring(0,dropDownTimer.Text.IndexOf(" ")));
            MessageBox.Show(cleaningTime.ToString());
        }

        private void cbWifi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWifi.CheckState == CheckState.Checked)
            {
                WiFi = true;
            }
            else
            {
                WiFi = false;
            }
        }

        private void cbTv_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTv.CheckState == CheckState.Checked)
            {
                TV = true;
            }
            else
            {
                TV = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbLaptop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLaptop.CheckState == CheckState.Checked)
            {
                Laptop = true;
            }
            else
            {
                Laptop = false;
            }
        }
    }
}
