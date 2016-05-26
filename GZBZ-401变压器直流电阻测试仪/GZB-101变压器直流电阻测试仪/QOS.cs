using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    public partial class QOS : Form
    {
        public delegate void f(int Timeout, int Times);
        public int TimesOfCmdSend = 2;
        public int SendTimeOut = 150;
        public f Founction;
        public QOS(f f)
        {
            InitializeComponent();
            this.Founction = f;
        }

        private void QOS_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <=5;i++ )
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedIndex = 1;
            textBox1.Text = "150";
            try
            {
                SendTimeOut = Int16.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("请输入数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TimesOfCmdSend = int.Parse(comboBox1.SelectedItem.ToString());
            Founction(SendTimeOut, TimesOfCmdSend);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SendTimeOut = Int16.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("请输入数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TimesOfCmdSend = int.Parse(comboBox1.SelectedItem.ToString());
            Founction(SendTimeOut, TimesOfCmdSend);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendTimeOut = 150;
            TimesOfCmdSend =2;
            Founction(SendTimeOut, TimesOfCmdSend);
            this.Hide();
        }

        private void QOS_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
