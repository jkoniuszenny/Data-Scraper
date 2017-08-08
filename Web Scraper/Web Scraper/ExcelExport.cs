using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Controls;

namespace Web_Scraper
{
    class ExcelExport
    {
        //Constructor
        public ExcelExport()
        {

        }

        //Method which exporting data from dataGrid to Excel file
        public void CreateExcel(DataGrid dataContext, string date, string table)
        {
            try
            {
                var xlApp = new Excel.Application();
                object misValue = System.Reflection.Missing.Value;

                var xlWorkBook = xlApp.Workbooks.Add(misValue);
                var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                string cell;
                double Num;
                int j = 0, i = 0;

                for (j = 0; j <= dataContext.Columns.Count - 1; j++)
                {
                    xlWorkSheet.Cells[1, j + 1] = dataContext.Columns[j].Header.ToString();
                    for (i = 0; i <= dataContext.Items.Count - 1; i++)
                    {
                        cell = (dataContext.Items[i] as DataRowView).Row.ItemArray[j].ToString();
                        if (double.TryParse(cell, out Num))
                        {
                            xlWorkSheet.Cells[i + 2, j + 1] = double.Parse(cell);
                        }
                        else
                        {
                            xlWorkSheet.Cells[i + 2, j + 1] = cell;
                        }
                    }
                }
                xlWorkBook.SaveAs(Environment.CurrentDirectory + "/" + date.Replace("-", "") + table.Substring(table.Length - 1, 1), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
