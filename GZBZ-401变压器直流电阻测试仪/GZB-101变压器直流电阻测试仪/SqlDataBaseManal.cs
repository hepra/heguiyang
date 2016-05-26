using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    public partial class SqlDataBaseManal : Form
    {

        public Data Rec = new Data();
        public int  INDEX;
        public string _dataTableName;
        string conStr = "Data Source = 2013-20160429ts; Initial Catalog =master ;User ID =sa ;Password =000000 ";
        public string data;
        private int _tableNum =0;
        bool RealTimeUpdate = true;
        public SqlDataBaseManal(Data Resister,int Index)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            Rec = Resister;
            INDEX = Index;
            InitializeComponent();
        }

        List<string> tableName = new List<string>(); 
        private void GetTables_SystemTable()
        {
            //打开连接 
            //string strConnectionString = System.Configuration.ConfigurationSettings.AppSettings[conStr];
         using(  SqlConnection sqlcn = new SqlConnection(conStr))
         {
             try
             {
                 sqlcn.Open();
                 //使用信息架构视图 
                 SqlCommand sqlcmd = new SqlCommand("SELECT OBJECT_NAME (id) FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0", sqlcn);
                 SqlDataReader dr = sqlcmd.ExecuteReader();
                 while (dr.Read())
                 {
                     _tableNum++;
                     tableName.Add(dr.GetString(0));
                 }
             }
             catch(Exception exp)
             {
                 MessageBox.Show(exp.Message);
             }
         }
            comboBoxAllTables.Items.Clear();
            for (int i = 0; i < tableName.Count;i++ )
            {
                comboBoxAllTables.Items.Add(tableName[i]);
            }
        } 

        private void Form4_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(this.Owner.Location.X -this.Width, this.Location.Y);
            this.StartPosition = FormStartPosition.CenterScreen;
            textBoxTableName.Text = "master.dbo.GZB101";
            timer1.Interval = 1000;
            timer1.Start();
            GetTables_SystemTable();
            _dataTableName = System.DateTime.Now.ToString();
            _dataTableName = _dataTableName.Replace("/","");
            _dataTableName = _dataTableName.Replace(":","_");
            _dataTableName = _dataTableName.Replace(" ","");
            string StrCmd = "CREATE TABLE  [" + _dataTableName +
            "]([标号] [varchar](50) NOT NULL,[分接位置] [varchar](50) NULL,[测试相别] [varchar](50) NULL,[实测电阻] [varchar](50) NULL,[折算电阻] [varchar](50) NULL,[绕组温度] [varchar](50) NULL,[换算温度] [varchar](50) NULL,PRIMARY KEY CLUSTERED ([标号] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]";
            using (SqlConnection sqlconnection = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(StrCmd, sqlconnection);
                try
                {
                    sqlconnection.Open();
                    int rows = cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                GetTables_SystemTable();
            }
        }
        public void database_DataAdapt(string cmdstr)
        {
            SqlCommand cmd;
            SqlDataAdapter sda;
            DataSet ds;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand( cmdstr, con);
                try
                {
                    con.Open();
                    ds = new DataSet();
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                
            }
        }
        private void btnDataAdapt_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
           
        }
        List<string> Resistance = new List<string>();
        void addDatatoDB()
        {
            textBox1.Text = Rec._recistance +"  "+ Rec._convertRec;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cmdStr = "";
            textBoxTableName.Text = "master.dbo."+_dataTableName;
            
            if (Rec._convertRec.Length> 0)
            {
                
                cmdStr = "insert into  [master].[dbo].["+_dataTableName+"]  values('"+INDEX  + "','" + Rec._tapPostion + "','" + Rec._phase+ "','" + Rec._recistance + "','" + Rec._convertRec + "','" + Rec._RZRecTem +"','"+Rec._convertTem+ "')";                    
                
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand(cmdStr, conn);
                    command.CommandType = CommandType.Text;
                    try
                    {
                        conn.Open();
                        int row = command.ExecuteNonQuery();
                        if (row == 0)
                        {
                            MessageBox.Show("提示", "插入失败");
                        }
                        else
                        {
                            //MessageBox.Show("提示", "插入成功");
                        }
                    }
                    catch
                    {
                        return;
                    }
                    if (RealTimeUpdate)
                    {
                        database_DataAdapt("select * from " + " [master].[dbo].[" + _dataTableName + "]");
                    }
                }
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            addDatatoDB();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string cmd = "select * from " + " [master].[dbo].[" + _dataTableName+"]";
            
            using(SqlConnection sqlcon = new SqlConnection(conStr))
            {
                SaveFileDialog openfile = new SaveFileDialog();
                SqlDataAdapter sda;
                DataSet ds;
                DataTable dt = new DataTable();
                SqlCommand command = new SqlCommand(cmd, sqlcon);
                try
                {
                    sqlcon.Open();
                    ds = new DataSet();
                    sda = new SqlDataAdapter(command);
                    sda.Fill(ds);
                    dt = ds.Tables[0];
                    openfile.Title = "选择保存的文件路径";
                    string[] buffer_path = System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries);
                    openfile.InitialDirectory = buffer_path[0];
                    openfile.Filter = "Excel文件|*.xlsx";
                    openfile.FileName = Rec._transformerNmae+System.DateTime.Now.Date.ToString();
                    openfile.ShowDialog();
                    if (openfile.FileName != "")
                    {
                        DBToExcel.DataSetToExcel(dt, openfile.FileName);
                    }
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }  
        }

}

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            RealTimeUpdate = false;
            if(comboBoxAllTables.SelectedItem != null)
            {
                database_DataAdapt("select * from " + " [master].[dbo].[" + comboBoxAllTables.SelectedItem.ToString() + "]");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Visible = false;
        }

        private void btnViwCurTable_Click(object sender, EventArgs e)
        {
            RealTimeUpdate = true;
        }
     }

    }


