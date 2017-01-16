using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    
    public partial class parentForm : Form
    {
        SerialPort serial;

        public parentForm()
        {
            InitializeComponent();

            serial = new SerialPort();
            serial.PortName = "COM4";
            serial.BaudRate = 9600; //zou ik t zelfde zetten als je arduino applicatie
            serial.DtrEnable = true;
            serial.Encoding = Encoding.Default;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            //serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            serial.Open();

            Timer timerRead = new Timer();
            timerRead.Interval = 1000; //hoevaak jij wil kijken
            timerRead.Tick += new System.EventHandler(timerRead_Tick);

            timer.Start();
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
            
        }

        private void cbTv_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbLaptop_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SendData();
        }

        private void btnSaveSettings_Click_1(object sender, EventArgs e)
        {
            if (cbWifi.CheckState == CheckState.Checked)
            {
                WiFi = true;
            }
            else
            {
                WiFi = false;
            }

            if (cbTv.CheckState == CheckState.Checked)
            {
                TV = true;
            }
            else
            {
                TV = false;
            }

            if (cbLaptop.CheckState == CheckState.Checked)
            {
                Laptop = true;
            }
            else
            {
                Laptop = false;
            }
        }

        void SendData()
        {
            if (cbWifi.Checked)
            {
                serial.Write("Wifi");
            }
            else if (cbTv.Checked)
            {
                serial.Write("Tv");
            }
            else if (cbLaptop.Checked)
            {
                serial.Write("Laptop");
            }
            
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            String dataFromArduino = serial.ReadLine().ToString();
            if(dataFromArduino == "#DISHES_DETECTED%")
            {
                timer.Start();
                if(timer.ToString() == cleaningTime.ToString())
                {

                }
            }
        }
    }
}
