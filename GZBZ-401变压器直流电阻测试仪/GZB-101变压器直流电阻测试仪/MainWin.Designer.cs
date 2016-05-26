namespace GZB_101变压器直流电阻测试仪
{
    partial class GZBZ_401_MAIN
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GZBZ_401_MAIN));
            this.comboBoxCurSelect = new System.Windows.Forms.ComboBox();
            this.serialCOM3 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxTemperature = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFirstBit = new System.Windows.Forms.ComboBox();
            this.comboBoxSecBit = new System.Windows.Forms.ComboBox();
            this.comboBoxThirdBit = new System.Windows.Forms.ComboBox();
            this.btnWorking = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTapPostion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPhase = new System.Windows.Forms.ComboBox();
            this.groupBoxCeshishezhi = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.软件设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指令传输质量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分接位显示范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开发者模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewShow = new System.Windows.Forms.DataGridView();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.groupBoxShujuxianshi = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBoxDataShow = new System.Windows.Forms.ListBox();
            this.groupBoxbianyaqixinhao = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonShowMode = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCurrentData = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxCeshishezhi.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).BeginInit();
            this.groupBoxShujuxianshi.SuspendLayout();
            this.groupBoxbianyaqixinhao.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCurSelect
            // 
            this.comboBoxCurSelect.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxCurSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCurSelect.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxCurSelect.FormattingEnabled = true;
            this.comboBoxCurSelect.Location = new System.Drawing.Point(100, 35);
            this.comboBoxCurSelect.Name = "comboBoxCurSelect";
            this.comboBoxCurSelect.Size = new System.Drawing.Size(167, 30);
            this.comboBoxCurSelect.TabIndex = 6;
            this.comboBoxCurSelect.Text = "请选择测试电流";
            this.comboBoxCurSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurSelect_SelectedIndexChanged);
            // 
            // serialCOM3
            // 
            this.serialCOM3.DiscardNull = true;
            this.serialCOM3.DtrEnable = true;
            this.serialCOM3.PortName = "COM3";
            this.serialCOM3.ReadTimeout = 1000;
            this.serialCOM3.WriteTimeout = 1000;
            // 
            // comboBoxTemperature
            // 
            this.comboBoxTemperature.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxTemperature.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxTemperature.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxTemperature.FormattingEnabled = true;
            this.comboBoxTemperature.Location = new System.Drawing.Point(100, 80);
            this.comboBoxTemperature.Name = "comboBoxTemperature";
            this.comboBoxTemperature.Size = new System.Drawing.Size(167, 30);
            this.comboBoxTemperature.TabIndex = 13;
            this.comboBoxTemperature.Text = "请选择换算温度";
            this.comboBoxTemperature.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemperature_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "绕组温度:";
            // 
            // comboBoxFirstBit
            // 
            this.comboBoxFirstBit.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxFirstBit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxFirstBit.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxFirstBit.FormattingEnabled = true;
            this.comboBoxFirstBit.Location = new System.Drawing.Point(100, 123);
            this.comboBoxFirstBit.Name = "comboBoxFirstBit";
            this.comboBoxFirstBit.Size = new System.Drawing.Size(55, 30);
            this.comboBoxFirstBit.TabIndex = 17;
            this.comboBoxFirstBit.Text = "十位";
            this.comboBoxFirstBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxFirstBit_SelectedIndexChanged);
            // 
            // comboBoxSecBit
            // 
            this.comboBoxSecBit.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxSecBit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSecBit.ForeColor = System.Drawing.Color.SpringGreen;
            this.comboBoxSecBit.FormattingEnabled = true;
            this.comboBoxSecBit.Location = new System.Drawing.Point(161, 123);
            this.comboBoxSecBit.Name = "comboBoxSecBit";
            this.comboBoxSecBit.Size = new System.Drawing.Size(57, 30);
            this.comboBoxSecBit.TabIndex = 18;
            this.comboBoxSecBit.Text = "个位";
            this.comboBoxSecBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxSecBit_SelectedIndexChanged);
            // 
            // comboBoxThirdBit
            // 
            this.comboBoxThirdBit.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxThirdBit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxThirdBit.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxThirdBit.FormattingEnabled = true;
            this.comboBoxThirdBit.Location = new System.Drawing.Point(242, 123);
            this.comboBoxThirdBit.Name = "comboBoxThirdBit";
            this.comboBoxThirdBit.Size = new System.Drawing.Size(57, 30);
            this.comboBoxThirdBit.TabIndex = 19;
            this.comboBoxThirdBit.Text = "小数";
            this.comboBoxThirdBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxThirdBit_SelectedIndexChanged);
            // 
            // btnWorking
            // 
            this.btnWorking.BackColor = System.Drawing.Color.White;
            this.btnWorking.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWorking.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnWorking.Location = new System.Drawing.Point(197, 389);
            this.btnWorking.Name = "btnWorking";
            this.btnWorking.Size = new System.Drawing.Size(165, 65);
            this.btnWorking.TabIndex = 25;
            this.btnWorking.Text = "开始测试";
            this.btnWorking.UseVisualStyleBackColor = false;
            this.btnWorking.Click += new System.EventHandler(this.btnWorking_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "测试电流:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "折算温度:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 30;
            this.label4.Text = "分接位置:";
            // 
            // comboBoxTapPostion
            // 
            this.comboBoxTapPostion.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxTapPostion.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxTapPostion.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxTapPostion.FormattingEnabled = true;
            this.comboBoxTapPostion.Location = new System.Drawing.Point(100, 209);
            this.comboBoxTapPostion.Name = "comboBoxTapPostion";
            this.comboBoxTapPostion.Size = new System.Drawing.Size(199, 30);
            this.comboBoxTapPostion.TabIndex = 31;
            this.comboBoxTapPostion.Text = "请选择分接位";
            this.comboBoxTapPostion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTapPostion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 32;
            this.label5.Text = "测量相别:";
            // 
            // comboBoxPhase
            // 
            this.comboBoxPhase.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxPhase.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxPhase.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxPhase.FormattingEnabled = true;
            this.comboBoxPhase.Location = new System.Drawing.Point(100, 165);
            this.comboBoxPhase.Name = "comboBoxPhase";
            this.comboBoxPhase.Size = new System.Drawing.Size(199, 30);
            this.comboBoxPhase.TabIndex = 33;
            this.comboBoxPhase.Text = "请选择测量相别";
            this.comboBoxPhase.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhase_SelectedIndexChanged);
            // 
            // groupBoxCeshishezhi
            // 
            this.groupBoxCeshishezhi.Controls.Add(this.label9);
            this.groupBoxCeshishezhi.Controls.Add(this.label8);
            this.groupBoxCeshishezhi.Controls.Add(this.label6);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxCurSelect);
            this.groupBoxCeshishezhi.Controls.Add(this.label4);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxTapPostion);
            this.groupBoxCeshishezhi.Controls.Add(this.label5);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxPhase);
            this.groupBoxCeshishezhi.Controls.Add(this.label2);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxTemperature);
            this.groupBoxCeshishezhi.Controls.Add(this.label3);
            this.groupBoxCeshishezhi.Controls.Add(this.label1);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxFirstBit);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxSecBit);
            this.groupBoxCeshishezhi.Controls.Add(this.comboBoxThirdBit);
            this.groupBoxCeshishezhi.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxCeshishezhi.ForeColor = System.Drawing.Color.Black;
            this.groupBoxCeshishezhi.Location = new System.Drawing.Point(22, 114);
            this.groupBoxCeshishezhi.Name = "groupBoxCeshishezhi";
            this.groupBoxCeshishezhi.Size = new System.Drawing.Size(340, 260);
            this.groupBoxCeshishezhi.TabIndex = 34;
            this.groupBoxCeshishezhi.TabStop = false;
            this.groupBoxCeshishezhi.Text = "测试设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(270, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 27);
            this.label9.TabIndex = 37;
            this.label9.Text = "℃";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(298, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 27);
            this.label8.TabIndex = 36;
            this.label8.Text = "℃";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(224, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = ".";
            // 
            // btnStopTest
            // 
            this.btnStopTest.BackColor = System.Drawing.Color.White;
            this.btnStopTest.Enabled = false;
            this.btnStopTest.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopTest.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnStopTest.Location = new System.Drawing.Point(22, 389);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(155, 65);
            this.btnStopTest.TabIndex = 35;
            this.btnStopTest.Text = "停止测试";
            this.btnStopTest.UseVisualStyleBackColor = false;
            this.btnStopTest.Click += new System.EventHandler(this.btnStopTest_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.软件设置ToolStripMenuItem,
            this.串口参数设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.连接数据库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 27);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 软件设置ToolStripMenuItem
            // 
            this.软件设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.指令传输质量ToolStripMenuItem,
            this.分接位显示范围ToolStripMenuItem,
            this.开发者模式ToolStripMenuItem,
            this.复位ToolStripMenuItem});
            this.软件设置ToolStripMenuItem.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.软件设置ToolStripMenuItem.Name = "软件设置ToolStripMenuItem";
            this.软件设置ToolStripMenuItem.Size = new System.Drawing.Size(101, 23);
            this.软件设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 指令传输质量ToolStripMenuItem
            // 
            this.指令传输质量ToolStripMenuItem.Name = "指令传输质量ToolStripMenuItem";
            this.指令传输质量ToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.指令传输质量ToolStripMenuItem.Text = "传输质量(QoS)";
            this.指令传输质量ToolStripMenuItem.Click += new System.EventHandler(this.指令传输质量ToolStripMenuItem_Click);
            // 
            // 分接位显示范围ToolStripMenuItem
            // 
            this.分接位显示范围ToolStripMenuItem.Name = "分接位显示范围ToolStripMenuItem";
            this.分接位显示范围ToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.分接位显示范围ToolStripMenuItem.Text = "其他显示设置";
            this.分接位显示范围ToolStripMenuItem.Click += new System.EventHandler(this.分接位显示范围ToolStripMenuItem_Click);
            // 
            // 开发者模式ToolStripMenuItem
            // 
            this.开发者模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.隐藏ToolStripMenuItem});
            this.开发者模式ToolStripMenuItem.Name = "开发者模式ToolStripMenuItem";
            this.开发者模式ToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.开发者模式ToolStripMenuItem.Text = "调试窗口";
            this.开发者模式ToolStripMenuItem.Click += new System.EventHandler(this.开发者模式ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 隐藏ToolStripMenuItem
            // 
            this.隐藏ToolStripMenuItem.Name = "隐藏ToolStripMenuItem";
            this.隐藏ToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.隐藏ToolStripMenuItem.Text = "隐藏";
            this.隐藏ToolStripMenuItem.Click += new System.EventHandler(this.隐藏ToolStripMenuItem_Click);
            // 
            // 复位ToolStripMenuItem
            // 
            this.复位ToolStripMenuItem.Name = "复位ToolStripMenuItem";
            this.复位ToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.复位ToolStripMenuItem.Text = "设备初始化";
            this.复位ToolStripMenuItem.Click += new System.EventHandler(this.复位ToolStripMenuItem_Click);
            // 
            // 串口参数设置ToolStripMenuItem
            // 
            this.串口参数设置ToolStripMenuItem.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.串口参数设置ToolStripMenuItem.Name = "串口参数设置ToolStripMenuItem";
            this.串口参数设置ToolStripMenuItem.Size = new System.Drawing.Size(101, 23);
            this.串口参数设置ToolStripMenuItem.Text = "串口配置";
            this.串口参数设置ToolStripMenuItem.Click += new System.EventHandler(this.串口参数设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于软件ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            this.关于软件ToolStripMenuItem.Click += new System.EventHandler(this.关于软件ToolStripMenuItem_Click);
            // 
            // 连接数据库ToolStripMenuItem
            // 
            this.连接数据库ToolStripMenuItem.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.连接数据库ToolStripMenuItem.Name = "连接数据库ToolStripMenuItem";
            this.连接数据库ToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.连接数据库ToolStripMenuItem.Text = "连接数据库";
            this.连接数据库ToolStripMenuItem.Click += new System.EventHandler(this.连接数据库ToolStripMenuItem_Click);
            // 
            // dataGridViewShow
            // 
            this.dataGridViewShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShow.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.RowTemplate.Height = 23;
            this.dataGridViewShow.Size = new System.Drawing.Size(670, 354);
            this.dataGridViewShow.TabIndex = 37;
            this.dataGridViewShow.Visible = false;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.Silver;
            this.btnSaveFile.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveFile.ForeColor = System.Drawing.Color.Black;
            this.btnSaveFile.Location = new System.Drawing.Point(933, 416);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(133, 38);
            this.btnSaveFile.TabIndex = 39;
            this.btnSaveFile.Text = "保存文件";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.Silver;
            this.btnOpenFile.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenFile.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFile.Location = new System.Drawing.Point(755, 416);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(133, 38);
            this.btnOpenFile.TabIndex = 40;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // groupBoxShujuxianshi
            // 
            this.groupBoxShujuxianshi.Controls.Add(this.listBox2);
            this.groupBoxShujuxianshi.Controls.Add(this.listBoxDataShow);
            this.groupBoxShujuxianshi.Controls.Add(this.dataGridViewShow);
            this.groupBoxShujuxianshi.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxShujuxianshi.Location = new System.Drawing.Point(384, 30);
            this.groupBoxShujuxianshi.Name = "groupBoxShujuxianshi";
            this.groupBoxShujuxianshi.Size = new System.Drawing.Size(682, 380);
            this.groupBoxShujuxianshi.TabIndex = 41;
            this.groupBoxShujuxianshi.TabStop = false;
            this.groupBoxShujuxianshi.Text = "数据显示";
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox2.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox2.ForeColor = System.Drawing.Color.Gold;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 48;
            this.listBox2.Location = new System.Drawing.Point(4, 23);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(673, 340);
            this.listBox2.TabIndex = 39;
            // 
            // listBoxDataShow
            // 
            this.listBoxDataShow.BackColor = System.Drawing.SystemColors.MenuText;
            this.listBoxDataShow.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxDataShow.ForeColor = System.Drawing.Color.Gold;
            this.listBoxDataShow.FormattingEnabled = true;
            this.listBoxDataShow.ItemHeight = 24;
            this.listBoxDataShow.Location = new System.Drawing.Point(6, 21);
            this.listBoxDataShow.Name = "listBoxDataShow";
            this.listBoxDataShow.Size = new System.Drawing.Size(670, 340);
            this.listBoxDataShow.TabIndex = 38;
            this.listBoxDataShow.Visible = false;
            // 
            // groupBoxbianyaqixinhao
            // 
            this.groupBoxbianyaqixinhao.Controls.Add(this.textBox1);
            this.groupBoxbianyaqixinhao.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxbianyaqixinhao.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxbianyaqixinhao.Location = new System.Drawing.Point(22, 30);
            this.groupBoxbianyaqixinhao.Name = "groupBoxbianyaqixinhao";
            this.groupBoxbianyaqixinhao.Size = new System.Drawing.Size(340, 78);
            this.groupBoxbianyaqixinhao.TabIndex = 42;
            this.groupBoxbianyaqixinhao.TabStop = false;
            this.groupBoxbianyaqixinhao.Text = "变压器型号";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Location = new System.Drawing.Point(6, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "请输入变压器型号";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonShowMode
            // 
            this.buttonShowMode.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonShowMode.Location = new System.Drawing.Point(384, 416);
            this.buttonShowMode.Name = "buttonShowMode";
            this.buttonShowMode.Size = new System.Drawing.Size(151, 38);
            this.buttonShowMode.TabIndex = 43;
            this.buttonShowMode.Text = "显示已测数据";
            this.buttonShowMode.UseVisualStyleBackColor = true;
            this.buttonShowMode.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.listBox1.ForeColor = System.Drawing.Color.Gold;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(22, 460);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(356, 140);
            this.listBox1.TabIndex = 44;
            this.listBox1.Visible = false;
            // 
            // btnCurrentData
            // 
            this.btnCurrentData.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCurrentData.Location = new System.Drawing.Point(541, 416);
            this.btnCurrentData.Name = "btnCurrentData";
            this.btnCurrentData.Size = new System.Drawing.Size(148, 38);
            this.btnCurrentData.TabIndex = 45;
            this.btnCurrentData.Text = "显示当前数据";
            this.btnCurrentData.UseVisualStyleBackColor = true;
            this.btnCurrentData.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // GZBZ_401_MAIN
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1084, 642);
            this.Controls.Add(this.btnCurrentData);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonShowMode);
            this.Controls.Add(this.groupBoxbianyaqixinhao);
            this.Controls.Add(this.groupBoxShujuxianshi);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnStopTest);
            this.Controls.Add(this.groupBoxCeshishezhi);
            this.Controls.Add(this.btnWorking);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GZBZ_401_MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GZBZ-401直流电阻测试仪";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GZB_101_MAIN_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GZB_101_MAIN_FormClosed);
            this.Load += new System.EventHandler(this.GZB_101_MAIN_Load);
            this.SizeChanged += new System.EventHandler(this.GZBZ_401_MAIN_SizeChanged);
            this.groupBoxCeshishezhi.ResumeLayout(false);
            this.groupBoxCeshishezhi.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).EndInit();
            this.groupBoxShujuxianshi.ResumeLayout(false);
            this.groupBoxbianyaqixinhao.ResumeLayout(false);
            this.groupBoxbianyaqixinhao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCurSelect;
        private System.Windows.Forms.ComboBox comboBoxTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFirstBit;
        private System.Windows.Forms.ComboBox comboBoxSecBit;
        private System.Windows.Forms.ComboBox comboBoxThirdBit;
        public System.IO.Ports.SerialPort serialCOM3;
        private System.Windows.Forms.Button btnWorking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTapPostion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPhase;
        private System.Windows.Forms.GroupBox groupBoxCeshishezhi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 软件设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接数据库ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewShow;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox groupBoxShujuxianshi;
        private System.Windows.Forms.GroupBox groupBoxbianyaqixinhao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBoxDataShow;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonShowMode;
        private System.Windows.Forms.ToolStripMenuItem 指令传输质量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分接位显示范围ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem 开发者模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnCurrentData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 复位ToolStripMenuItem;
    }
}

