using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    class DataShow
    {
        public DataGridView dataGridView1;
        public ListBox show;
        public MyDataBaseClass data;
        public int index = 0;
        public  DataShow(DataGridView dataView,ListBox listbox, MyDataBaseClass values, int INDEX)
        {
            this.dataGridView1 = dataView;
            this.data = values;
            index = INDEX;
            show = listbox;
        }
        public void ShowList()
        {
            string strings = "";
            show.Items.Clear();
            show.Items.Add("标号    分接位  相别    实测电阻    折算电阻    绕组温度 换算温度");
            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    if(j==4)
                    {
                        strings += "   "+ data.RowMember[i * data.ColumnCount + j].ToString() + "\t";
                    }
                    else
                    {
                        strings += data.RowMember[i * data.ColumnCount + j].ToString() + "\t";
                    }
                }
                show.Items.Add(strings);
                strings = "";
            }
        }

        DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
    public void ShowExcel()
    {
        try
        {
            dataGridView1.Invalidate();
            dataGridView1.ColumnCount = data.ColumnCount;
            dataGridView1.ColumnHeadersVisible = true;
            // 设置DataGridView控件标题列的样式

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("黑体", 16, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Font = new Font("楷体", 14,FontStyle.Bold);

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
            
            for (int i = 0; i < data.ColumnCount; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //设置DataGridView控件的标题列名data
            for (int i = 0; i < data.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Name = (string)data.ColumnMember[i];
            }
            object[] values = new object[data.ColumnCount];

            dataGridView1.Rows.Clear();
            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    values[j] = data.RowMember[i * data.ColumnCount + j].ToString();
                }
                dataGridView1.Rows.Add(values);
            }
        }
        catch
        {
            MessageBox.Show("非法操作，程序异常，即将关闭！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            System.Environment.Exit(System.Environment.ExitCode); 
        }
       
    }
    //    public DataTable CreateDataTable()
    //{
    //        DataTable DT = new DataTable();
    //        for(int i =0;i<data.ColumnCount;i++)
    //        {
    //            DT.Columns[i].ColumnName =(string)data.ColumnMember[i];
    //        }
    //        for (int i = 0; i < data.RowCount; i++)
    //        {
    //            DataRow dr = new DataRow();
    //            for (int j = 0; j < data.ColumnCount; j++)
    //            {
    //                dr[j] = data.RowMember[i * data.ColumnCount + j].ToString();
    //            }
    //            DT.Rows.Add(dr);
    //        }
    //        return DT;
    //}
    }

}

