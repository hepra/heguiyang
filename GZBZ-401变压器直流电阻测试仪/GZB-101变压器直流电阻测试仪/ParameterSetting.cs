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
    public partial class FormParaSetting : Form
    {
        public  delegate void founction(int MIN, int MAX);
        public int RenderMAX;
        public int RenderMin;
        founction setValue;
        public FormParaSetting(founction a)
        {
            InitializeComponent();
            setValue = a;
        }

        private void FormParaSetting_Load(object sender, EventArgs e)
        {
            textBoxMax.Text = "99";
            textBoxMin.Text = "1";
        }

        private void btnUseParaSetting_Click(object sender, EventArgs e)
        {
            try
            {
                RenderMAX = int.Parse(textBoxMax.Text);
                RenderMin = int.Parse(textBoxMin.Text);
            }
            catch
            {
                MessageBox.Show("请输入数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setValue(RenderMin, RenderMAX);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RenderMAX = 99;
            RenderMin = 1;
            setValue(RenderMin, RenderMAX);
            this.Hide();
        }

        private void btnParseCache_Click(object sender, EventArgs e)
        {
            MessageBox.Show("缓存清空完毕！", "提示", MessageBoxButtons.OKCancel);
        }

        private void textBoxMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormParaSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            setValue(RenderMin, RenderMAX);
        }
    }
}
