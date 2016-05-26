using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GZB_101变压器直流电阻测试仪
{
    class DataToExcel
    {
        /// <summary>
        /// 数据库转为excel表格
        /// </summary>
        /// <param name="dataTable">数据库数据</param>
        /// <param name="SaveFile">导出的excel文件</param>
        public static void DataSetToExcel(MyDataBaseClass DataBase, string SaveFile)
        {
           
            Microsoft.Office.Interop.Excel.Application excel;

            Microsoft.Office.Interop.Excel._Workbook workBook;

            Microsoft.Office.Interop.Excel._Worksheet workSheet;

            object misValue = System.Reflection.Missing.Value;

            excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

            workBook = excel.Workbooks.Add(misValue);

            workSheet = (Microsoft.Office.Interop.Excel._Worksheet)workBook.ActiveSheet;
            int rowIndex =1;
            int colIndex = 1;
            try
            {
                  //取得标题
            foreach (var col in DataBase.ColumnMember)
            {
                string value = col as string;
                excel.Cells[1, colIndex] = value;
                colIndex++;
            }
             int temp =  DataBase.RowCount;
            //取得表格中的数据
                 for (int i =1; i <= DataBase.RowCount; i++)
                 {
                     for (int j = 0; j < DataBase.ColumnCount; j++)
                     {
                     colIndex =i+1;
                     rowIndex = j+1 ;
                     int index = (i-1) * DataBase.ColumnCount + j;
                     string value = DataBase.RowMember[index] as string;
                     excel.Cells[colIndex, rowIndex] = value;
                     //设置表格内容居中对齐
                     ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[colIndex, rowIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    //设置表格自动适应大小
                     workSheet.Cells.Columns.AutoFit();
                     }  
             }
             workSheet.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment =
                                 Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            excel.Visible = false;
            workBook.SaveAs(SaveFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue,

                misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,

                misValue, misValue, misValue, misValue, misValue);

            workBook.Close(true, misValue, misValue);

            excel.Quit();

            PublicMethod.Kill(excel);//调用kill当前excel进程

            releaseObject(workSheet);

            releaseObject(workBook);

            releaseObject(excel);

        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
