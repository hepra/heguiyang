using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
namespace GZB_101变压器直流电阻测试仪
{
    public partial class SerialSetting : Form
    {
        public SerialPort serial;
        public string COMName;
        public bool RtsEnable;
        public bool DtrEnable;
        public bool _isDone = false;
        public string Data = "";

        public SerialSetting(SerialPort ser)
        {
            InitializeComponent();
            this.serial = ser;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string[] buffer_path =
            System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries);
            string picpath = buffer_path[0] + @"\picture\GZDL.png";
            pictureBox1.Image = Image.FromFile(picpath);
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                MessageBox.Show("没有检测到可用串口！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            Array.Sort(ports);//数组排序
            comboBoxCOM.Items.AddRange(ports);
            comboBoxCOM.SelectedIndex = ports.Length>0 ? 0 : -1;
            comboBoxBute.Items.Add("300");
            comboBoxBute.Items.Add("600");
            comboBoxBute.Items.Add("1200");
            comboBoxBute.Items.Add("2400");
            comboBoxBute.Items.Add("4800");
            comboBoxBute.Items.Add("9600");
            comboBoxBute.Items.Add("19200");
            comboBoxBute.Items.Add("38400");
            comboBoxBute.Items.Add("43000");
            comboBoxBute.Items.Add("56000");
            comboBoxBute.Items.Add("57600");
            comboBoxBute.Items.Add("115200");

            comboBoxDtrEnable.Items.Add("true");
            comboBoxDtrEnable.Items.Add("false");

            comboBoxRtsEnable.Items.Add("true");
            comboBoxRtsEnable.Items.Add("false");

            for (int i = 1; i < 17; i++)
            {
                comBoxDataBits.Items.Add(i.ToString());
            }

            comboBoxWriteTimeout.Items.Add("100");
            comboBoxWriteTimeout.Items.Add("500");
            comboBoxWriteTimeout.Items.Add("1000");
            comboBoxWriteTimeout.Items.Add("1500");
            comboBoxWriteTimeout.Items.Add("2000");
            comboBoxWriteTimeout.Items.Add("2500");
            comboBoxWriteTimeout.Items.Add("3000");

            comboBoxReadTimeout.Items.Add("100");
            comboBoxReadTimeout.Items.Add("500");
            comboBoxReadTimeout.Items.Add("1000");
            comboBoxReadTimeout.Items.Add("1500");
            comboBoxReadTimeout.Items.Add("2000");
            comboBoxReadTimeout.Items.Add("2500");
            comboBoxReadTimeout.Items.Add("3000");

            comboBoxStopBits.Items.Add("0");
            comboBoxStopBits.Items.Add("1");
            comboBoxStopBits.Items.Add("1.5");
            comboBoxStopBits.Items.Add("2");
            //默认选项
            comboBoxBute.SelectedItem = "9600";
            comboBoxDtrEnable.SelectedItem = "true";
            comboBoxRtsEnable.SelectedItem = "false";
            comboBoxStopBits.SelectedItem = "1";
            comBoxDataBits.SelectedItem = "8";
            comboBoxReadTimeout.SelectedItem = "2000";
            comboBoxWriteTimeout.SelectedItem = "2000";  
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            serial.Close();
            if(comboBoxBute.SelectedItem ==null||
                comboBoxCOM.SelectedItem ==null||
                comboBoxDtrEnable.SelectedItem ==null||
                comboBoxRtsEnable.SelectedItem ==null||
                comboBoxStopBits.SelectedItem ==null||
                comBoxDataBits.SelectedItem ==null||
                comboBoxReadTimeout. SelectedItem ==null||
                comboBoxWriteTimeout. SelectedItem ==null)
            {
                MessageBox.Show("请设置全部属性！");
            }
            else
            {
                this.serial.BaudRate = int.Parse(comboBoxBute.SelectedItem.ToString());
                this.serial.PortName = comboBoxCOM.SelectedItem.ToString();
                this.serial.DtrEnable = bool.Parse(comboBoxDtrEnable.SelectedItem.ToString());
                this.serial.RtsEnable = bool.Parse(comboBoxRtsEnable.SelectedItem.ToString());
                switch (comboBoxStopBits.SelectedItem.ToString())
                {
                    case "0": this.serial.StopBits = StopBits.None; break;
                    case "1": this.serial.StopBits = StopBits.One; break;
                    case "1.5": this.serial.StopBits = StopBits.OnePointFive; break;
                    case "2": this.serial.StopBits = StopBits.Two; break;
                    default: this.serial.StopBits = StopBits.One; break;
                }
                this.serial.DataBits = int.Parse(comBoxDataBits.SelectedItem.ToString());
                this.serial.ReadTimeout = int.Parse(comboBoxReadTimeout.SelectedItem.ToString());
                this.serial.WriteTimeout = int.Parse(comboBoxWriteTimeout.SelectedItem.ToString());
            }
            this.Visible = false;
            this._isDone = true;
            try
            {
                serial.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("串口打开失败！\r\n请配置串口参数重新尝试打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
            }
            if (serial.IsOpen)
            {
                this.Owner.Visible = true;
                this.Owner.Show();
                this.Owner.ShowInTaskbar = true;
                this.Owner.Location = new Point(50, 100);
                this.Close();
            }
        }

        private void btnUseDefault_Click(object sender, EventArgs e)
        {
            serial.Close();
            this.serial.BaudRate =9600;
            this.serial.PortName = comboBoxCOM.SelectedItem.ToString();
            this.serial.DtrEnable =true;
            this.serial.RtsEnable = false;
            this.serial.StopBits = StopBits.One; 
            this.serial.DataBits = 8;
            this.serial.ReadTimeout = -1;
            this.serial.WriteTimeout =-1;
            this.Visible = false;
            this._isDone = true;
            
            try
            {
                serial.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("串口打开失败！\r\n请配置串口参数重新尝试打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
            }
            if(serial.IsOpen)
            {
                this.Owner.Visible = true;
                this.Owner.Show();
                this.Owner.ShowInTaskbar = true;
                this.Owner.Location = new Point(50, 100);
                this.Close();
            }
        }

        private void SerialSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Visible = true;
            this.Owner.Show();
            this.Owner.ShowInTaskbar = true;
            this.Owner.Location = new Point(50, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getPortReciveMsg()
        {
            byte[] buffer = new byte[1024];
            int num = 0;
            num = serial.Read(buffer, 0, buffer.Length);
            string tempData = "";
            for (int i = 0; i < num; i++)
            {
                tempData += " " + buffer[i].ToString("X2");
            }
            Data += tempData;
        }
        private  byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


    }
}
