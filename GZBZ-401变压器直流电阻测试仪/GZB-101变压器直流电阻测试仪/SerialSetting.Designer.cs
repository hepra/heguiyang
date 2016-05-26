namespace GZB_101变压器直流电阻测试仪
{
    partial class SerialSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialSetting));
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.comboBoxBute = new System.Windows.Forms.ComboBox();
            this.comBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDtrEnable = new System.Windows.Forms.ComboBox();
            this.comboBoxRtsEnable = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnUseDefault = new System.Windows.Forms.Button();
            this.comboBoxReadTimeout = new System.Windows.Forms.ComboBox();
            this.comboBoxWriteTimeout = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.BackColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxCOM.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCOM.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(147, 6);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(157, 24);
            this.comboBoxCOM.TabIndex = 0;
            this.comboBoxCOM.Text = "请选择COM口";
            // 
            // comboBoxBute
            // 
            this.comboBoxBute.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBute.FormattingEnabled = true;
            this.comboBoxBute.Location = new System.Drawing.Point(147, 41);
            this.comboBoxBute.Name = "comboBoxBute";
            this.comboBoxBute.Size = new System.Drawing.Size(157, 24);
            this.comboBoxBute.TabIndex = 1;
            this.comboBoxBute.Text = "选择波特率";
            // 
            // comBoxDataBits
            // 
            this.comBoxDataBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comBoxDataBits.FormattingEnabled = true;
            this.comBoxDataBits.Location = new System.Drawing.Point(147, 74);
            this.comBoxDataBits.Name = "comBoxDataBits";
            this.comBoxDataBits.Size = new System.Drawing.Size(102, 24);
            this.comBoxDataBits.TabIndex = 2;
            this.comBoxDataBits.Text = "数据位";
            // 
            // comboBoxDtrEnable
            // 
            this.comboBoxDtrEnable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDtrEnable.FormattingEnabled = true;
            this.comboBoxDtrEnable.Location = new System.Drawing.Point(147, 216);
            this.comboBoxDtrEnable.Name = "comboBoxDtrEnable";
            this.comboBoxDtrEnable.Size = new System.Drawing.Size(102, 24);
            this.comboBoxDtrEnable.TabIndex = 3;
            this.comboBoxDtrEnable.Text = "设置Dtr";
            // 
            // comboBoxRtsEnable
            // 
            this.comboBoxRtsEnable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxRtsEnable.FormattingEnabled = true;
            this.comboBoxRtsEnable.Location = new System.Drawing.Point(147, 248);
            this.comboBoxRtsEnable.Name = "comboBoxRtsEnable";
            this.comboBoxRtsEnable.Size = new System.Drawing.Size(102, 24);
            this.comboBoxRtsEnable.TabIndex = 4;
            this.comboBoxRtsEnable.Text = "设置Rts";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(269, 220);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(144, 49);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "使用用当前设置";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnUseDefault
            // 
            this.btnUseDefault.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUseDefault.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnUseDefault.Location = new System.Drawing.Point(269, 173);
            this.btnUseDefault.Name = "btnUseDefault";
            this.btnUseDefault.Size = new System.Drawing.Size(144, 41);
            this.btnUseDefault.TabIndex = 7;
            this.btnUseDefault.Text = "使用默认设置";
            this.btnUseDefault.UseVisualStyleBackColor = true;
            this.btnUseDefault.Click += new System.EventHandler(this.btnUseDefault_Click);
            // 
            // comboBoxReadTimeout
            // 
            this.comboBoxReadTimeout.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxReadTimeout.FormattingEnabled = true;
            this.comboBoxReadTimeout.Location = new System.Drawing.Point(147, 141);
            this.comboBoxReadTimeout.Name = "comboBoxReadTimeout";
            this.comboBoxReadTimeout.Size = new System.Drawing.Size(102, 20);
            this.comboBoxReadTimeout.TabIndex = 8;
            this.comboBoxReadTimeout.Text = "设置读取超时";
            // 
            // comboBoxWriteTimeout
            // 
            this.comboBoxWriteTimeout.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxWriteTimeout.FormattingEnabled = true;
            this.comboBoxWriteTimeout.Location = new System.Drawing.Point(147, 182);
            this.comboBoxWriteTimeout.Name = "comboBoxWriteTimeout";
            this.comboBoxWriteTimeout.Size = new System.Drawing.Size(102, 20);
            this.comboBoxWriteTimeout.TabIndex = 9;
            this.comboBoxWriteTimeout.Text = "设置写入超时";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(147, 107);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(102, 24);
            this.comboBoxStopBits.TabIndex = 10;
            this.comboBoxStopBits.Text = "停止位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "检测到的串口:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(13, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "设置波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "设置数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(13, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "设置停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "读取超时（ms）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(13, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "设置Dtr可用";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(13, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "写入超时（ms）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(13, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "设置Rts可用";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(295, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 87);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // SerialSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(425, 280);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.comboBoxWriteTimeout);
            this.Controls.Add(this.comboBoxReadTimeout);
            this.Controls.Add(this.btnUseDefault);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.comboBoxRtsEnable);
            this.Controls.Add(this.comboBoxDtrEnable);
            this.Controls.Add(this.comBoxDataBits);
            this.Controls.Add(this.comboBoxBute);
            this.Controls.Add(this.comboBoxCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialSetting";
            this.Text = "串口参数设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialSetting_FormClosing);
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.ComboBox comboBoxBute;
        private System.Windows.Forms.ComboBox comBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxDtrEnable;
        private System.Windows.Forms.ComboBox comboBoxRtsEnable;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnUseDefault;
        private System.Windows.Forms.ComboBox comboBoxReadTimeout;
        private System.Windows.Forms.ComboBox comboBoxWriteTimeout;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}