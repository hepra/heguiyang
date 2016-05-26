using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GZB_101变压器直流电阻测试仪
{
    class DBToExcel
    {         
            /// <summary>
            /// 数据库转为excel表格
            /// </summary>
            /// <param name="dataTable">数据库数据</param>
            /// <param name="SaveFile">导出的excel文件</param>
            public static void DataSetToExcel(DataTable dataTable, string SaveFile)
            {
                Microsoft.Office.Interop.Excel.Application excel;
                Microsoft.Office.Interop.Excel._Workbook workBook;
                Microsoft.Office.Interop.Excel._Worksheet workSheet;
                object misValue = System.Reflection.Missing.Value;
                excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                workBook = excel.Workbooks.Add(misValue);
                workSheet = (Microsoft.Office.Interop.Excel._Worksheet)workBook.ActiveSheet;
                int rowIndex = 1;
                int colIndex = 0;
                //取得标题
                foreach (DataColumn col in dataTable.Columns)
                {
                    colIndex++;
                    excel.Cells[1, colIndex] = col.ColumnName;
                }
                //取得表格中的数据
                foreach (DataRow row in dataTable.Rows)
                {
                    rowIndex++;
                    colIndex = 0;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        colIndex++;
                        excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString().Trim();
                        //设置表格内容居中对齐
                        ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[colIndex, rowIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //设置表格自动适应大小
                        workSheet.Cells.Columns.AutoFit();
                    }                    
                }
                excel.Visible = false;
                workBook.SaveAs(SaveFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue,
                    misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    misValue, misValue, misValue, misValue, misValue);
                dataTable = null;
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
        public class PublicMethod
        {
            [DllImport("User32.dll", CharSet = CharSet.Auto)]

            public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

            public static void Kill(Microsoft.Office.Interop.Excel.Application excel)
            {
                try
                {
                    IntPtr t = new IntPtr(excel.Hwnd);
                    int k = 0;
                    GetWindowThreadProcessId(t, out k);
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    p.Kill();
                }
                catch
                { }
            }
        }
    }
