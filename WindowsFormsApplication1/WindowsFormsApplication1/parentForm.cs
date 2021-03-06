﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Media;

namespace WindowsFormsApplication1
{
    
    public partial class parentForm : Form
    {
        SerialPort serial;

        public parentForm()
        {
            InitializeComponent();

            serial = new SerialPort();
            serial.PortName = "COM8";
            serial.BaudRate = 9600; //zou ik t zelfde zetten als je arduino applicatie
            serial.DtrEnable = true;
            serial.Encoding = Encoding.Default;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            serial.Open();

            Timer timerRead = new Timer();
            timerRead.Interval = 10; //hoevaak jij wil kijken
            timerRead.Tick += new EventHandler(timerRead_Tick);

            timer.Start();

            
        }

        String dataFromArduino;

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serial.ReadLine() != "0" && serial.ReadLine() != "#DISHES_DETECTED%")
            {
                MessageBox.Show(serial.ReadLine());
            }



            dataFromArduino = serial.ReadLine().ToString();
            if (dataFromArduino == "#DISHES_DETECTED%")
            {
                timer1.Start();
            }
                
            

        }

        int cleaningTime;
        bool TV;
        bool WiFi;
        bool Laptop;
        int timerCounter = 0;
        private static System.Timers.Timer timer1 = new System.Timers.Timer(60000);
        


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
                serial.Write("#KILL_WIFI%");
            }
            if (cbTv.Checked)
            {
                serial.Write("#KILL_TV%");
            }
            if (cbLaptop.Checked)
            {
                serial.Write("#KILL_LAPTOP%");
            }
            
        }

        private  void timerElapsedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            timerCounter++;
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }


        private void timerRead_Tick(object sender, EventArgs e)
        {
            timer1.Elapsed += timerElapsedEvent;

            if (timerCounter >= cleaningTime)
            {
                serial.Write("#KILL_TV%");
                //ALS WERKT DO SendData();
            }
            if (dataFromArduino == "MAKE_NOISE")
            {
                playSimpleSound();
            }
            //MessageBox.Show(dataFromArduino);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serial.Write("#PLAY_ALARM%");
        }
    }
}
