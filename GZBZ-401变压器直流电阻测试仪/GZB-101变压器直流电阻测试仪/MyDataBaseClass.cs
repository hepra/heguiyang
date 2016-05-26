using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    class MyDataBaseClass
    {
        public List<object> ColumnMember = new List<object>();
        public List<object> RowMember = new List<object>();
        public int ColumnCount =0;
        public int RowCount = 0;
        public int memberCount= 0;
        public void AddColumnMember (object Column,int colIndex)
        {
            ColumnMember[colIndex] = Column;
        }
        public void AddColumnMember(object Column)
        {
            ColumnMember.Add(Column);
            ColumnCount++;
        }
        public void AddRowMember(object Row,Point rowCoordinates)
        {
            try
            {
                int rowIndex = rowCoordinates.X * ColumnCount + rowCoordinates.Y;
                RowMember[rowIndex] = Row;
            }
            catch
            {
            }
           
        }
        public void AddRowMember(object Row)
        {
            RowMember.Add(Row);
            memberCount++;
            RowCount = memberCount / ColumnCount;
        }
        public void DeleteRowmember(Point rowCoordinates )
        {
            int rowIndex = rowCoordinates.X * ColumnCount + rowCoordinates.Y;
            RowMember.Remove(rowIndex);

        }
        public void DataClear()
        {
            ColumnMember.Clear();
            ColumnMember.Clear();
            RowCount = 0;
            ColumnCount = 0;
        }
        public void ColumnClear()
        {
            ColumnMember.Clear();
            ColumnCount = 0;
        }
        public void RowClear()
        {
            RowMember.Clear();
            memberCount = 0;
            RowCount = 0;
        }
        public void RowClear(int index)
        {
            RowMember.RemoveRange(ColumnCount *index,ColumnCount);
            RowCount--;
        }
    }
}
