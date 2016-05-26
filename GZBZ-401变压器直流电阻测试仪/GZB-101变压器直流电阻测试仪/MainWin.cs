using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    public partial class GZBZ_401_MAIN : Form
    {
        public GZBZ_401_MAIN()
        {        
            InitializeComponent();
            this.Size = new Size(1171 ,508);
        }

       
       //数据显示类
        DataShow showData;
        //串口设置窗口声明
        SerialSetting form5;
        //数据传输类
        DataTransmission Data = new DataTransmission() ;
        //数据匹配类
        Data Rec = new Data();
        //是否需要新建一行数据  如果 分接位 改变 测试相别改变 就增加
        bool   needAddRow = false;
        //当前行号
        int      INDEX = 1;
        //是否已经开始测试
        bool startTest = false;
        //是否是第一次测得的数据
        bool initialUpdate = true;
        //自定义的数据库类
        MyDataBaseClass MyDataBase;
        //启动 TIMER1
        string UpdateTime = "...";
        //窗口加载
        private void GZB_101_MAIN_Load(object sender, EventArgs e)
        {
            MyDataBase = new MyDataBaseClass();
            Rec._convertTem = "75";
            Rec._convertRec = "待测";
            Rec._recistance = "待测";
            Rec._RZRecTem = "20";
            Rec._tapPostion = "1";
            Rec._phase = "AO";
            showData = new DataShow(dataGridViewShow, listBoxDataShow, MyDataBase, INDEX);
            MyDataBase.AddColumnMember("标号");
            MyDataBase.AddColumnMember("分接位");
            MyDataBase.AddColumnMember("测试相别");
            MyDataBase.AddColumnMember("测量电阻");
            MyDataBase.AddColumnMember("折算电阻");
            MyDataBase.AddColumnMember("绕组温度");
            MyDataBase.AddColumnMember("换算温度");
            //LOGO加载
            string[] buffer_path =
            System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries);
            string picpath = buffer_path[0] + @"\picture\GZDL.png";
            //检测串口
                string[] ports = SerialPort.GetPortNames();
                Array.Sort(ports);//数组排序
                foreach(var temp in ports)
                {
                    serialCOM3.PortName = temp;
                    serialCOM3.Open();   
                   byte[] cmd = strToToHexByte(" 11 04 00 00");
                   SendCmd(cmd);
                   getPortReciveMsg();
                    if( Data.Data.Length >4)
                    {
                         break;
                    }
                    else
                    {
                        serialCOM3.Close();
                    }
                }
                if(serialCOM3.IsOpen == false)
                {
                    MessageBox.Show("自动配置失败，请手动配置串口信息", "提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    TipsInital();
                    SetPageShow();
                }
            //监听串口数据
            serialCOM3.DataReceived += (SerialDataReceivedEventHandler)(delegate
            {
                getPortReciveMsg();
                DataCorrection();
                if(DataDecode())
                {
                    timer2.Stop();
                    startTest = true;
                    if (comboBoxCurSelect.SelectedIndex != -1 &&
                    comboBoxTemperature.SelectedIndex != -1 &&
                    comboBoxThirdBit.SelectedIndex != -1 &&
                        comboBoxPhase.SelectedIndex != -1 &&
                        comboBoxPhase.SelectedIndex != -1 &&
                       comboBoxTapPostion.SelectedIndex != -1)
                    {
                        startTest = true;
                    }
                    //只更新最新一行的数据
                    try
                    {
                        for (int i = INDEX - 1; i < INDEX; i++)
                        {
                            if (initialUpdate)
                            {
                                MyDataBase.AddRowMember(INDEX.ToString());
                                MyDataBase.AddRowMember(Rec._tapPostion);
                                MyDataBase.AddRowMember(Rec._phase);
                                MyDataBase.AddRowMember(Rec._recistance);
                                MyDataBase.AddRowMember(Rec._convertRec);
                                MyDataBase.AddRowMember(Rec._RZRecTem);
                                MyDataBase.AddRowMember(Rec._convertTem);
                                initialUpdate = false;
                                comboBoxTapPostion.Enabled = true;
                                comboBoxPhase.Enabled = true;
                                comboBoxSecBit.Enabled = true;
                                comboBoxFirstBit.Enabled = true;
                                comboBoxTemperature.Enabled = true;
                                comboBoxThirdBit.Enabled = true;
                            }
                            else
                            {
                                MyDataBase.AddRowMember(INDEX.ToString(), new Point(i, 0));
                                MyDataBase.AddRowMember(Rec._tapPostion, new Point(i, 1));
                                MyDataBase.AddRowMember(Rec._phase, new Point(i, 2));
                                MyDataBase.AddRowMember(Rec._recistance, new Point(i, 3));
                                MyDataBase.AddRowMember(Rec._convertRec, new Point(i, 4));
                                MyDataBase.AddRowMember(Rec._RZRecTem, new Point(i, 5));
                                MyDataBase.AddRowMember(Rec._convertTem, new Point(i, 6));
                            }
                        }
                    }
                     catch
                    {
                        MessageBox.Show("非法操作，程序异常，即将关闭！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        stopTest();
                         System.Environment.Exit(System.Environment.ExitCode); 
                    }
                    int count = MyDataBase.RowCount;
                    showData.data = MyDataBase;
                    showData.dataGridView1 = dataGridViewShow;
                    showData.index = INDEX;
                    showData.show = listBoxDataShow;
                    try
                    {
                        listBox2.Font = new Font("黑体", 36, FontStyle.Bold);
                        listBox2.Items.Clear();
                        listBox2.Items.Add("绕组温度：    " + Rec._RZRecTem + "℃");
                        listBox2.Items.Add("换算温度：    " + Rec._convertTem + "℃");
                        listBox2.Items.Add("分接位置：    " + Rec._tapPostion);
                        listBox2.Items.Add("测试相别：    " + Rec._phase);
                        listBox2.Items.Add("实测电阻：    " + Rec._recistance);
                        listBox2.Items.Add("换算电阻：    " + Rec._convertRec);
                        listBox2.Items.Add(" ");
                        listBox2.Items.Add(" ");
                        listBox2.Items.Add(" ");
                        UpdateTime = System.DateTime.Now.ToString();
                        listBox2.Items.Add("数据更新时间：" + UpdateTime);
                    }
                    catch
                    {
                        MessageBox.Show("非法操作，程序异常，即将关闭！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    
                }    
            }
            );
            
                comboBoxSecBit.Visible = false;
                comboBoxThirdBit.Visible = false; 
                //初始化电流选项
                comboBoxCurSelect.Items.Add("2.5A");
                comboBoxCurSelect.Items.Add("5A");
                comboBoxCurSelect.Items.Add("10A");
                comboBoxCurSelect.Items.Add("20A");
                comboBoxCurSelect.Items.Add("40A");
                //初始化换算温度选项
                comboBoxTemperature.Items.Add("75");
                comboBoxTemperature.Items.Add("85");
                comboBoxTemperature.Items.Add("115");
                comboBoxTemperature.Items.Add("120");
                comboBoxTemperature.Items.Add("145");
                //初始化绕组温度选项
                for (int i = 0; i < 10; i++)
                {
                    comboBoxFirstBit.Items.Add(i.ToString());
                    comboBoxSecBit.Items.Add(i.ToString());
                    comboBoxThirdBit.Items.Add(i.ToString());
                }
             //初始化测试相别
            comboBoxPhase.Items.Add("AB");
            comboBoxPhase.Items.Add("BC");
            comboBoxPhase.Items.Add("CA");
            comboBoxPhase.Items.Add("AO");
            comboBoxPhase.Items.Add("BO");
            comboBoxPhase.Items.Add("CO");
            comboBoxPhase.Items.Add("ABm");
            comboBoxPhase.Items.Add("BCm");
            comboBoxPhase.Items.Add("CAm");
            comboBoxPhase.Items.Add("AOm");
            comboBoxPhase.Items.Add("BOm");
            comboBoxPhase.Items.Add("COm");
             comboBoxPhase.Items.Add("ab");
            comboBoxPhase.Items.Add("bc");
            comboBoxPhase.Items.Add("ca");
            comboBoxPhase.Items.Add("ao");
            comboBoxPhase.Items.Add("bo");
            comboBoxPhase.Items.Add("co");
            //初始化分接位置
            for (int i = RendMin; i < RendMax; i++)
            {
                   comboBoxTapPostion.Items.Add(i);
            }
            //解除跨线程 通信的异常通知
             Control.CheckForIllegalCrossThreadCalls = false;
            if(serialCOM3.PortName!=null)
            {
                comboBoxCurSelect.SelectedIndex = 0;
                comboBoxFirstBit.SelectedIndex = 2;
                comboBoxSecBit.SelectedIndex = 0;
                comboBoxThirdBit.SelectedIndex = 0;
                comboBoxTemperature.SelectedIndex = 0;
                comboBoxTapPostion.SelectedIndex = 0;
                comboBoxPhase.SelectedIndex = 0;
            }       
        }

        //进入设置页面

        //设置信息页面
        void SetPageShow()
        {
            if(form5 == null)
            {
                form5 = new SerialSetting(serialCOM3);
                form5.Owner = this;
                form5.Show();
            }
            else
            {
                form5.Close();
                form5 = new SerialSetting(serialCOM3);
                form5.Owner = this;
                form5.Show();
            }
        }

        //点击触发测试电流改变
        //获取下位机返回码
        private void getPortReciveMsg()
        {
            byte[] buffer = new byte[1024];
            int num = 0;
            try
            {
                num = serialCOM3.Read(buffer, 0,buffer.Length);
                 serialCOM3.DiscardInBuffer();
                 serialCOM3.DiscardOutBuffer();
            }
            catch
            {
            }
            string tempData = " ";
            for (int i=0; i < num; i++)
            {
                tempData += " " + buffer[i].ToString("X2");
            }
            
            if ( Data.Data !=null &&Data.Data.Length > 512)
            {
                Data.Data ="";
            }
            Data.Data += tempData;
            listBox1.Items.Add(tempData);
        }

        string EncodeASCToString(string r)
        {
            string dianzu = "";
            byte[] te = strToToHexByte(r);
            for (int j = 0; j < te.Length; j++)
            {
                byte[] temp = new byte[4];
                temp[0] = te[j];
                temp[1] = 0;
                temp[2] = 0;
                temp[3] = 0;
                int num = BitConverter.ToInt32(temp, 0);
                dianzu += Chr(num);
            }
            dianzu = dianzu.Replace(" ", "");
            return  dianzu+ "Ω";
        }
        public string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        private void BytetoHEX(byte[] bytes)
        {
            string returnStr = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                returnStr += " " + bytes[i].ToString("X2");
            }
        }


        private void GZB_101_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            stopTest();
            INDEX = 0;
            serialCOM3.Close();
            System.Environment.Exit(System.Environment.ExitCode); 
        }


        private void comboBoxTemperature_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            byte[] cmd = new byte[8];
            //if (!serialCOM3.IsOpen)
            //{
            //    DialogResult ret = MessageBox.Show("请重启程序并正确配置串口参数！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    if (ret == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //    return;
            //}
            Rec._convertTem = comboBoxTemperature.SelectedItem.ToString();
            switch (Rec._convertTem)
            {
                case "75": cmd = strToToHexByte("11 04 D6 01 EC "); break;
                case "85": cmd = strToToHexByte("11 04 D6 02 ED "); break;
                case "115": cmd = strToToHexByte("11 04 D6 03 EE "); break;
                case "120": cmd = strToToHexByte("11 04 D6 04 EF"); break;
                case "145": cmd = strToToHexByte("11 04 D6 05 F0 "); break;
                default: break;
            }
            if (startTest == false)
            {
               // SendCmd(cmd);
            }
            BytetoHEX(cmd);
            needAddRow = true;
            if (needAddRow && startTest)
            {
                INDEX++;
                initialUpdate = true;
                comboBoxTapPostion.Enabled = false;
                comboBoxPhase.Enabled = false;
                comboBoxSecBit.Enabled = false;
                comboBoxFirstBit.Enabled = false;
                comboBoxTemperature.Enabled = false;
                comboBoxThirdBit.Enabled = false;
            }
        }


        private void comboBoxFirstBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            byte[] cmd = new byte[8];
            //if (!serialCOM3.IsOpen)
            //{
            //    DialogResult ret = MessageBox.Show("请重启程序并正确配置串口参数！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    if (ret == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //    return;
            //}
            string str = comboBoxFirstBit. SelectedItem.ToString();
            if (str != "")
            {
                comboBoxSecBit.Visible =true;
            }
            switch (str)
            {
                case "0": cmd = strToToHexByte("11 04 D0  00 E5"); break;
                case "1": cmd = strToToHexByte("11 04 D0  01 E6"); break;
                case "2": cmd = strToToHexByte("11 04 D0  02 E7"); break;
                case "3": cmd = strToToHexByte("11 04 D0  03 E8"); break;
                case "4": cmd = strToToHexByte("11 04 D0  04 E9"); break;
                case "5": cmd = strToToHexByte("11 04 D0  05 EA"); break;
                case "6": cmd = strToToHexByte("11 04 D0  06 EB"); break;
                case "7": cmd = strToToHexByte("11 04 D0  07 EC"); break;
                case "8": cmd = strToToHexByte("11 04 D0  08 ED"); break;
                case "9": cmd = strToToHexByte("11 04 D0  09 EE"); break;
                default: break;
            }
            if (comboBoxFirstBit.SelectedIndex != -1 && comboBoxSecBit.SelectedIndex != -1 && comboBoxThirdBit.SelectedIndex !=-1)
            {
                Rec._RZRecTem = comboBoxFirstBit.SelectedItem.ToString() + comboBoxSecBit.SelectedItem.ToString() + "." + comboBoxThirdBit.SelectedItem.ToString();
                if (needAddRow && startTest)
                {
                    INDEX++;
                    initialUpdate = true;
                    comboBoxTapPostion.Enabled = false;
                    comboBoxPhase.Enabled = false;
                    comboBoxSecBit.Enabled = false;
                    comboBoxFirstBit.Enabled = false;
                    comboBoxTemperature.Enabled = false;
                    comboBoxThirdBit.Enabled = false;
                }
            }
            if (startTest == false)
            {
               // SendCmd(cmd);
            }
            BytetoHEX(cmd);

        }

        private void comboBoxSecBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] cmd = new byte[8];
            //if (!serialCOM3.IsOpen)
            //{
            //    DialogResult ret = MessageBox.Show("请重启程序并正确配置串口参数！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    if (ret == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //    return;
            //}
            string  str = comboBoxSecBit. SelectedItem.ToString();
            if (str != "")
            {
                comboBoxThirdBit.Visible = true;
            }
            switch (str)
            {
                case "0": cmd = strToToHexByte("11 04 D1  00 E6"); break;
                case "1": cmd = strToToHexByte("11 04 D1  01 E7"); break;
                case "2": cmd = strToToHexByte("11 04 D1  02 E8"); break;
                case "3": cmd = strToToHexByte("11 04 D1  03 E9"); break;
                case "4": cmd = strToToHexByte("11 04 D1  04 EA"); break;
                case "5": cmd = strToToHexByte("11 04 D1  05 EB"); break;
                case "6": cmd = strToToHexByte("11 04 D1  06 EC"); break;
                case "7": cmd = strToToHexByte("11 04 D1  07 ED"); break;
                case "8": cmd = strToToHexByte("11 04 D1  08 EE"); break;
                case "9": cmd = strToToHexByte("11 04 D1  09 EF"); break;
                default: break;
            }
            if (comboBoxFirstBit.SelectedIndex != -1 && comboBoxSecBit.SelectedIndex != -1 && comboBoxThirdBit.SelectedIndex != -1)
            {
                Rec._RZRecTem = comboBoxFirstBit.SelectedItem.ToString() + comboBoxSecBit.SelectedItem.ToString() + "." + comboBoxThirdBit.SelectedItem.ToString();
                if (needAddRow && startTest)
                {
                    INDEX++;
                    initialUpdate = true;
                    comboBoxTapPostion.Enabled = false;
                    comboBoxPhase.Enabled = false;
                    comboBoxSecBit.Enabled = false;
                    comboBoxFirstBit.Enabled = false;
                    comboBoxTemperature.Enabled = false;
                    comboBoxThirdBit.Enabled = false;
                }
            }
            if (startTest == false)
            {
                //SendCmd(cmd);
            }
            BytetoHEX(cmd);
        }

        private void comboBoxThirdBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] cmd = new byte[8];
            //if (!serialCOM3.IsOpen)
            //{
            //    DialogResult ret = MessageBox.Show("请重启程序并正确配置串口参数！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    if (ret == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //    return;
            //}
           string str = comboBoxThirdBit. SelectedItem.ToString();
            switch (str)
            {
                case "0": cmd = strToToHexByte("11 04 D2  00 E7"); break;
                case "1": cmd = strToToHexByte("11 04 D2  01 E8"); break;
                case "2": cmd = strToToHexByte("11 04 D2  02 E9"); break;
                case "3": cmd = strToToHexByte("11 04 D2  03 EA"); break;
                case "4": cmd = strToToHexByte("11 04 D2  04 EB"); break;
                case "5": cmd = strToToHexByte("11 04 D2  05 EC"); break;
                case "6": cmd = strToToHexByte("11 04 D2  06 ED"); break;
                case "7": cmd = strToToHexByte("11 04 D2  07 EE"); break;
                case "8": cmd = strToToHexByte("11 04 D2  08 EF"); break;
                case "9": cmd = strToToHexByte("11 04 D2  09 F0"); break;
                default: break;
            }
            if (startTest == false)
            {
               // SendCmd(cmd);
            }
            BytetoHEX(cmd);
            //显示当前绕组温度
            Rec._RZRecTem = comboBoxFirstBit.SelectedItem.ToString() + comboBoxSecBit.SelectedItem.ToString() + "." + comboBoxThirdBit.SelectedItem.ToString();
            needAddRow = true;
            if (needAddRow && startTest)
            {
                INDEX++;
                initialUpdate = true;
                comboBoxTapPostion.Enabled = false;
                comboBoxPhase.Enabled = false;
                comboBoxSecBit.Enabled = false;
                comboBoxFirstBit.Enabled = false;
                comboBoxTemperature.Enabled = false;
                comboBoxThirdBit.Enabled = false;
            }
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            stopTest();
        }

        private void GZB_101_MAIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialCOM3.Close();
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void btnWorking_Click(object sender, EventArgs e)
        {
            if (!serialCOM3.IsOpen)
            {
                DialogResult ret = MessageBox.Show("串口未打开,请点击【确定】关闭程序！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ret == DialogResult.OK)
                {
                    this.Close();
                }
                return;
            }
            byte[] cmd = new byte[8];
            if(comboBoxCurSelect.SelectedItem == null || comboBoxTemperature.SelectedItem == null ||comboBoxThirdBit.SelectedItem == null )
            {
                MessageBox.Show("请先将参数全部设置完成！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            cmd = strToToHexByte(" 11 04 A5 01 BB");
            SendCmd(cmd);
            timer2.Interval = 600;
            timer2.Start();
            comboBoxCurSelect.Enabled = false;
            btnWorking.Enabled = false;
            btnStopTest.Enabled = true;
            listBox2.Visible = true;
            listBoxDataShow.Visible = false;
            dataGridViewShow.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void 串口参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPageShow();
        }


        //保存数据
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            stopTest();
            SaveFileDialog openfile = new SaveFileDialog();
            openfile.Title = "选择保存的文件路径";
            string[] buffer_path = System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries);
            openfile.InitialDirectory = buffer_path[0];
            openfile.Filter = "Excel文件|*.xlsx |TXT文件|*.txt";
            openfile.FileOk += (CancelEventHandler)(delegate
            {
                if (openfile.FileName != "" && openfile.FilterIndex == 1)
                {
                    DataToExcel.DataSetToExcel(MyDataBase, openfile.FileName);
                }
                if (openfile.FileName != "" && openfile.FilterIndex == 2)
                {
                    using (FileStream fsWrite = new FileStream(openfile.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        byte[] buffer = new byte[1024 * 1024];
                        foreach (var a in listBoxDataShow.Items)
                        {

                            buffer = Encoding.UTF8.GetBytes(a.ToString() + "\r\n");
                            fsWrite.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            });
            openfile.FileName = textBox1.Text;
            openfile.ShowDialog(); 
        }

        private void comboBoxPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rec._phase = comboBoxPhase.SelectedItem.ToString();
            needAddRow = true;
            if (needAddRow && startTest)
            {
                INDEX++;
                initialUpdate = true;
                comboBoxTapPostion.Enabled = false;
                comboBoxPhase.Enabled = false;
                comboBoxSecBit.Enabled = false;
                comboBoxFirstBit.Enabled = false;
                comboBoxTemperature.Enabled = false;
                comboBoxThirdBit.Enabled = false;

            }
        }

        private void comboBoxTapPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rec._tapPostion = comboBoxTapPostion.SelectedItem.ToString();
            needAddRow = true;
            if (needAddRow && startTest)
            {
                INDEX++;
                initialUpdate = true;
                comboBoxTapPostion.Enabled = false;
                comboBoxPhase.Enabled = false;
                comboBoxSecBit.Enabled = false;
                comboBoxFirstBit.Enabled = false;
                comboBoxTemperature.Enabled = false;
                comboBoxThirdBit.Enabled = false;

            }
        }

        private void comboBoxCurSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] cmd = new byte[4] { 0, 0, 0, 0 };
            //if (!serialCOM3.IsOpen)
            //{
            //    DialogResult ret = MessageBox.Show("请重启程序并正确配置串口参数！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    if (ret == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //    return;
            //}
            string testcur = "";
            testcur = comboBoxCurSelect.SelectedItem.ToString();
            switch (testcur)
            {
                case "2.5A": cmd = strToToHexByte(" 11 04 A1 02 B8"); break;
                case "5A": cmd = strToToHexByte("11 04 A1 03 B9"); break;
                case "10A": cmd = strToToHexByte("11 04 A1 04 BA"); break;
                case "20A": cmd = strToToHexByte("11 04 A1 05 BB"); break;
                case "40A": cmd = strToToHexByte("11 04 A1 06 BC"); break;
                default: break;
            }
            SendCmd(cmd);
            BytetoHEX(cmd);
            needAddRow = true;
            if(needAddRow&&startTest)
            {
                INDEX++;
                initialUpdate = true;
                comboBoxTapPostion.Enabled = false;
                comboBoxPhase.Enabled = false;
                comboBoxSecBit.Enabled = false;
                comboBoxFirstBit.Enabled = false;
                comboBoxTemperature.Enabled = false;
                comboBoxThirdBit.Enabled = false;
            }
        }


        SqlDataBaseManal form4;
        private void 连接数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确认连接本机数据库！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(res == DialogResult.OK)
            {
                form4 = new SqlDataBaseManal(Rec,INDEX);
                form4.Owner = this;
                form4.Visible = false;
                form4.Owner = this;
                form4.Show();
                if (form4.Visible == false)
                {
                    form4.Visible = true;
                }
            }
            else
            {
                return;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }


        bool  DataDecode()
        {
            bool decode_success = false;
            string[] ASC = Data.Data.Split(new string[] { "110A" }, Data.Data.Length, StringSplitOptions.RemoveEmptyEntries);
            if(ASC.Length>1&&Data.Data.Length>50)
            {
                listBox1.Items.Add(Data.Data.Substring(Data.Data.Length -50 ,36));
                listBox1.Items.Add(ASC[ASC.Length-2]);
                listBox1.Items.Add(ASC[ASC.Length - 1]);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            if (ASC.Length > 2 && ASC.Length % 2 == 0 && ASC[ASC.Length - 2].Length == 16
                && ASC[ASC.Length - 1].Length == 16)
            {
                MessageBox.Show("串口通信繁忙，请重启下位机！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stopTest();
                System.Environment.Exit(System.Environment.ExitCode); 
                this.Close();
            }
            if (ASC.Length > 3 && ASC.Length % 2 == 0 && (ASC[ASC.Length - 4].Length == 14 || ASC[ASC.Length - 2].Length == 14))
              {
                  if (ASC[ASC.Length - 4].Length == 14)
                  {
                      Rec._recistance = EncodeASCToString(ASC[ASC.Length - 4]);
                  }
                if(ASC[ASC.Length - 2].Length == 14)
                  {
                      Rec._recistance = EncodeASCToString(ASC[ASC.Length - 2]);
                  } 
                  Rec._convertRec = EncodeASCToString(ASC[ASC.Length - 3]);
                  if (Rec._recistance.Contains("Y") && Rec._convertRec.Contains("X"))
                  {
                      string temp;
                      temp = Rec._recistance;
                      Rec._recistance = Rec._convertRec;
                      Rec._convertRec = temp;
                  }
                  Rec._recistance = Rec._recistance.Replace("X", "");
                  if(Rec._recistance.Length>6)
                  {
                      Rec._recistance = Rec._recistance.Substring(0,7);
                  }
                  string number = Rec._recistance.Substring(0, 5);
                  try
                  {
                      double convertR = (double.Parse(number) * ((235.0 + double.Parse(Rec._convertTem)))) / (235.0 + double.Parse(Rec._RZRecTem));
                      if (Rec._recistance.Contains("m"))
                      {
                          Rec._convertRec = convertR.ToString().Substring(0, 5) + "mΩ";
                      }
                      else
                      {
                          Rec._convertRec = convertR.ToString().Substring(0, 5) + "Ω";
                      }
                      decode_success = true;
                  }
                  catch
                  {
                      decode_success = false;
                  }
                 
              }
            else
              {
                  decode_success = false;
              }
            if(form4!=null)
            {
                form4.Rec = Rec;
                form4.INDEX = INDEX;
            }
              return decode_success;
        }


        void DataCorrection()
        {
            Data.Data = Data.Data.Replace(" 00", " ");
            Data.Data = Data.Data.Replace(" 20", "");
            for (int i = 70; i < 100; i++)
            {
                Data.Data = Data.Data.Replace(" "+i.ToString(), " ");
            }
            Data.Data = Data.Data.Replace(" 7A", " ");
            Data.Data = Data.Data.Replace(" 7B", " ");
            Data.Data = Data.Data.Replace(" 7C", " ");
            Data.Data = Data.Data.Replace(" 7D", " ");
            Data.Data = Data.Data.Replace(" 7E", " ");
            Data.Data = Data.Data.Replace(" 7F", " ");
            Data.Data = Data.Data.Replace(" 8A", " ");
            Data.Data = Data.Data.Replace(" 8B", " ");
            Data.Data = Data.Data.Replace(" 8C", " ");
            Data.Data = Data.Data.Replace(" 8D", " ");
            Data.Data = Data.Data.Replace(" 8E", " ");
            Data.Data = Data.Data.Replace(" 8F", " ");
            Data.Data = Data.Data.Replace(" 9A", " ");
            Data.Data = Data.Data.Replace(" 9B", " ");
            Data.Data = Data.Data.Replace(" 9C", " ");
            Data.Data = Data.Data.Replace(" 9D", " ");
            Data.Data = Data.Data.Replace(" 9E", " ");
            Data.Data = Data.Data.Replace(" 9F", " ");
            Data.Data = Data.Data.Replace(" AA ", " ");
            Data.Data = Data.Data.Replace(" AB ", " ");
            Data.Data = Data.Data.Replace(" AC ", " ");
            Data.Data = Data.Data.Replace(" AD ", " ");
            Data.Data = Data.Data.Replace(" AE ", " ");
            Data.Data = Data.Data.Replace(" AF ", " ");
            Data.Data = Data.Data.Replace(" 3A", "");
            Data.Data = Data.Data.Replace(" 3B", "");
            Data.Data = Data.Data.Replace(" 3C", "");
            Data.Data = Data.Data.Replace(" 3D", "");
            Data.Data = Data.Data.Replace(" 3E", "");
            Data.Data = Data.Data.Replace(" 3F", "");
            Data.Data = Data.Data.Replace(" 40", "");
            Data.Data = Data.Data.Replace("11 04", " ");
            Data.Data = Data.Data.Replace(" ", "");
        }

        int i = 0;
        string st = "        正在充电，请稍等";
        private void timer2_Tick(object sender, EventArgs e)
        {
            listBox2.Font = new Font("黑体", 40, FontStyle.Bold);
            i++;
            listBox2.Items.Clear();
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            st += ".";
            if (i == 7)
            {
                i = 0;
                st = "        正在充电，请稍等 ";
            }
            listBox2.Items.Add(st);
        }
        int ShowModeIndex = 1;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(ShowModeIndex ==1)
            {
                dataGridViewShow.Visible = true;
                showData.ShowExcel();
                listBoxDataShow.Visible = false;
                listBox2.Visible = false;
                ShowModeIndex = 2;
                buttonShowMode.Text = "列表显示";
            }
            else
            {
                listBoxDataShow.Visible = true;
                showData.ShowList();
                dataGridViewShow.Visible = false;
                listBox2.Visible = false;
                ShowModeIndex = 1;
                buttonShowMode.Text = "表格显示";
            }  
        }


        private void GZBZ_401_MAIN_SizeChanged(object sender, EventArgs e)
        {
            setLocation();
        }
        void setLocation()
        {
            groupBoxbianyaqixinhao.Top = this.Location.Y + 20 + MainMenuStrip.Height;
            groupBoxbianyaqixinhao.Left = this.Left +20;
            groupBoxbianyaqixinhao.Size = new Size(340, 78);
            groupBoxCeshishezhi.Size = new Size(340, 260);
            btnStopTest.Width = (groupBoxCeshishezhi.Width - 10) / 2;
            btnWorking.Width = btnStopTest.Width;
            btnStopTest.Font = new Font("楷体", (btnStopTest.Height - 25) / 2,FontStyle.Bold);
            btnWorking.Font = btnStopTest.Font;
            btnSaveFile.Height = 50;
            btnSaveFile.Width = 120;
            btnOpenFile.Width = 120;
            btnOpenFile.Height = btnSaveFile.Height;
            btnCurrentData.Height = btnSaveFile.Height;
            buttonShowMode.Height = btnSaveFile.Height;
            groupBoxCeshishezhi.Location = new Point(groupBoxbianyaqixinhao.Location.X, groupBoxbianyaqixinhao.Location.Y + 10 + groupBoxbianyaqixinhao.Size.Height);
            groupBoxShujuxianshi.Location = new Point(this.Location.X +groupBoxbianyaqixinhao.Location.X+ groupBoxbianyaqixinhao.Size.Width + 20, groupBoxbianyaqixinhao.Location.Y);
            groupBoxShujuxianshi.Height = this.Size.Height - 2*btnSaveFile.Height-2*menuStrip1.Height;
            groupBoxShujuxianshi.Width = this.Right - groupBoxShujuxianshi.Location.X - 10 ;
            btnOpenFile.Location = new Point(groupBoxShujuxianshi.Location.X + groupBoxShujuxianshi.Size.Width - 20 - 2 * btnSaveFile.Size.Width, groupBoxShujuxianshi.Location.Y + groupBoxShujuxianshi.Height + 20);
            btnSaveFile.Location = new Point(groupBoxShujuxianshi.Location.X + groupBoxShujuxianshi.Width - btnSaveFile.Width, btnOpenFile.Location.Y);
            listBoxDataShow.Height = groupBoxShujuxianshi.Height - 20;
            listBoxDataShow.Width = groupBoxShujuxianshi.Width - 20;
            dataGridViewShow.Width = groupBoxShujuxianshi.Width - 20;
            dataGridViewShow.Height = groupBoxShujuxianshi.Height - 20;
            btnStopTest.Location = new Point(groupBoxbianyaqixinhao.Location.X, groupBoxCeshishezhi.Location.Y + groupBoxCeshishezhi.Height + 20);
            btnWorking.Location = new Point(btnStopTest.Location.X + 10 + btnStopTest.Width, btnStopTest.Location.Y);
            buttonShowMode.Location = new Point(groupBoxShujuxianshi.Location.X, btnOpenFile.Location.Y);
            listBox1.Location = new Point(groupBoxbianyaqixinhao.Location.X, btnStopTest.Location.Y+btnStopTest.Height + 20);
            listBox1.Height = this.Height - listBox1.Location.Y - 40;
            listBox1.Width = groupBoxCeshishezhi.Width;
            listBox2.Location = listBoxDataShow.Location;
            listBox2.Size = listBoxDataShow.Size;
            buttonShowMode.Width = (groupBoxShujuxianshi.Width - btnSaveFile.Width * 2 -btnOpenFile.Width ) / 2;
            btnCurrentData.Width = buttonShowMode.Width;
            btnCurrentData.Location = new Point(buttonShowMode.Location.X + buttonShowMode.Width + 10, buttonShowMode.Location.Y);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            stopTest();
            listBox2.Items.Clear();
            dataGridViewShow.Visible = false;
            listBoxDataShow.Visible = false;
            listBox2.Visible = true;
            listBox2.Font = new Font("楷体", 12, FontStyle.Bold);       
            OpenFileDialog openData = new OpenFileDialog();
            openData.Filter = "文本文件|*.txt";
            openData.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries)[0];
            openData.ShowDialog();
            if (openData.FileName != "")
            {
                using (FileStream fsRead = new FileStream(openData.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int count = fsRead.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer);
                    string[] datas = data.Split(new string[] { "\r\n" }, count, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string da in datas)
                    {
                        listBoxDataShow.Items.Add(da);
                        listBox2.Items.Add(da);
                    }
                }
            }
        }
        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help helpmenu = new help();
            helpmenu.Show();
        }
        QOS qos;
        public int  SendTimeOut = 100;
        public int ResendTimes = 2;
        private void 指令传输质量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(qos == null)
            {
               qos = new QOS(SetQos);
               qos.Show();
            }
            else
            {
                qos.Show();
            }
        }
        public void  SetQos(int Timeout,int Times)
        {
            this.SendTimeOut = Timeout;
            this.ResendTimes = Times;
        }
       public int RendMax =100;
        public int RendMin = 1;
        FormParaSetting parameterSetting;
        private void 分接位显示范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(parameterSetting == null)
            {
                parameterSetting = new FormParaSetting(setValue);
                parameterSetting.Show();
            }
            else
            {
                parameterSetting.Show();       
            }       
        }
        void setValue(int Min,int Max)
        {
            RendMax = Max;
            RendMin = Min;
            comboBoxTapPostion.Items.Clear();
            for (int i = parameterSetting.RenderMin; i < parameterSetting.RenderMAX; i++)
            {
                comboBoxTapPostion.Items.Add(i);
            }
        }
        void stopTest()
        {
            byte[] cmd = new byte[8];
            cmd = strToToHexByte("11 04 aa 01 c0");
            SendCmd(cmd);
            Data.Data = "";
            timer1.Stop();
            timer2.Stop();
            listBox2.Items.Clear();
            comboBoxTapPostion.Enabled = true;
            comboBoxPhase.Enabled = true;
            comboBoxSecBit.Enabled = true;
            comboBoxFirstBit.Enabled = true;
            comboBoxCurSelect.Enabled = true;
            comboBoxTemperature.Enabled = true;
            comboBoxThirdBit.Enabled = true;
            INDEX += 1;
            startTest = false;
            initialUpdate = true;
            btnWorking.Enabled = true;
            btnStopTest.Enabled = false;
        }

        void SendCmd(byte[] cmd)
        {
            for (int i = 0; i <ResendTimes; i++)
            {
                if (serialCOM3.IsOpen)
                {
                    serialCOM3.Write(cmd, 0, cmd.Length);
                }
                Thread.Sleep(SendTimeOut);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Rec._transformerNmae = textBox1.Text;
        }

        private void 开发者模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox2.Font = new Font("黑体", 36, FontStyle.Bold);
            listBox2.Items.Clear();
            listBox2.Items.Add("绕组温度：    " + Rec._RZRecTem + "℃");
            listBox2.Items.Add("换算温度：    " + Rec._convertTem + "℃");
            listBox2.Items.Add("分接位置：    " + Rec._tapPostion);
            listBox2.Items.Add("测试相别：    " + Rec._phase);
            listBox2.Items.Add("实测电阻：    " + Rec._recistance);
            listBox2.Items.Add("换算电阻：    " + Rec._convertRec);
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            listBox2.Items.Add(" ");
            listBox2.Items.Add("数据更新时间：" + UpdateTime);
            listBoxDataShow.Visible = false;
            dataGridViewShow.Visible = false;
            buttonShowMode.Text = "显示已测数据";
        }

        private void 复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] cmd = new byte[8];
            cmd = strToToHexByte("11 04 aa 01 c0");
            SendCmd(cmd);
            Data.Data = "";
            timer1.Stop();
            timer2.Stop();
            listBox2.Items.Clear();
            listBoxDataShow.Items.Clear();
            dataGridViewShow.Rows.Clear();
            MyDataBase.RowClear();
            comboBoxTapPostion.Enabled = true;
            comboBoxPhase.Enabled = true;
            comboBoxSecBit.Enabled = true;
            comboBoxFirstBit.Enabled = true;
            comboBoxCurSelect.Enabled = true;
            comboBoxTemperature.Enabled = true;
            comboBoxThirdBit.Enabled = true;
            btnStopTest.Enabled = false;
            btnWorking.Enabled = true;
            INDEX = 1;
            startTest = false;
            initialUpdate = true;
        }
        void TipsInital()
        {
            listBox2.Items.Clear();
            listBox2.Font = new Font("楷体", 16, FontStyle.Bold);
            listBox2.Items.Add("①串口检测失败处理：返回桌面-> 右键单击【我的电脑");
            listBox2.Items.Add("【我的电脑】->属性->设备管理器 ->端口 ->serialPort(COMxx)");
            listBox2.Items.Add("②返回本软件->点击【串口设置】，选择 正确COM口");
            listBox2.Items.Add("③配置好测试环境，点击【开始测试】");
            listBox2.Items.Add("④若点击【开始测试】下位机无响应，请安装正确驱动");
        }

    }
    class DataTransmission
    {
        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
   
   
   
}

