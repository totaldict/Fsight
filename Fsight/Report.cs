using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fsight
{
    public partial class Report : Form
    {
        SqlDataAdapter adapter;
        DataTable dTable;
        string reportNameExcel;
        public Report(string reportTheme, string reportName)
        {
            InitializeComponent();
            MakeReportToGridView(reportTheme, reportName);
            reportNameExcel = reportName;
            MainForm.TakeCurrencyFromDB();
            PresentDepositsSumm();
        }

        private void MakeReportToGridView(string theme, string name)
        {
            string sqlSelect = MakeSqlSelectString(theme, name);
            MainForm mainForm = this.Owner as MainForm;

            adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            dataGridViewReport.DataSource = dTable;    // Отображаем данные

        }
        /// <summary>
        /// Формирует строку SQL запроса
        /// </summary>
        private string MakeSqlSelectString(string theme, string name)
        {
            string[] nameArray = name.Split(';');
            if (theme == "Persons")
                return $@"SELECT * FROM Deposits WHERE Depositor = '{nameArray[1]}'";
            if (theme == "Bank")
                return $@"SELECT * FROM Deposits WHERE Bank = '{nameArray[0]}'";
            if (theme == "ExchangeRates")
                return $@"SELECT * FROM Deposits WHERE Currency LIKE '{name}'";
            return $@"SELECT * FROM Deposits";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MainForm.SaveReportToExcel(MainForm.MakeNewReportExcelFile(@"\Report1.xlsx"), $"Сумма вклада на текущий момент: {reportNameExcel}", $"{lblDepositsSumm.Text}", dTable);
        }
        ///// <summary>
        ///// Создаёт новый файл отчёта
        ///// </summary>
        ///// <returns></returns>
        //private string MakeNewReportExcelFile()
        //{
        //    FileInfo fn = new FileInfo($@"{MainForm.path}\Report1.xlsx");
        //    string newFileName = $@"{MainForm.reportPath}\Report{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.xlsx";
        //    fn.CopyTo(newFileName, true);
        //    return newFileName;
        //}
        ///// <summary>
        ///// Сохраняет таблицу в файл Excel
        ///// </summary>
        //private void SaveReportToExcel(string fileName)
        //{
        //    Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
        //    Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
        //    //Книга.
        //    ObjWorkBook = ObjExcel.Workbooks.Open($@"{fileName}",
        //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //    Type.Missing, Type.Missing);
        //    //ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
        //    //Таблица.
        //    ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
        //    //заголовок
        //    ObjWorkSheet.Cells[1, 1] = $"Сумма вклада на текущий момент: {reportNameExcel}";
        //    ObjWorkSheet.Cells[2, 1]=lblDepositsSumm.Text;  //строка общая сумма вклада
        //    //названия столбцов
        //    for (int columnNumber = 0; columnNumber < dataGridViewReport.ColumnCount; columnNumber++)
        //    {
        //        ObjWorkSheet.Cells[3, columnNumber + 1] = dataGridViewReport.Columns[columnNumber].HeaderText;
        //    }
        //    //заполнение ячеек
        //    for (int rowNumber = 0; rowNumber < dataGridViewReport.RowCount; rowNumber++)
        //        for (int columnNumber = 0; columnNumber < dataGridViewReport.ColumnCount; columnNumber++)
        //        {
        //            //Значения [x - строка, y - столбец]
        //            ObjWorkSheet.Cells[rowNumber + 4, columnNumber + 1] = dataGridViewReport[columnNumber, rowNumber].Value;
        //        }   //и не забываем что в Excel строки и столбцы начинаются с индекса 1!!!
            
        //    //Вызываем нашу созданную эксельку.
        //    ObjExcel.Visible = true;
        //    ObjExcel.UserControl = true;
        //}


        /// <summary>
        /// Вычисляет сумму вкладов из таблицы в рублях
        /// </summary>
        /// <returns></returns>
        public double ConputeDepositSumm()
        {
            double summRoubles=0;
            string currencyType;
            for (int rowNumber = 0; rowNumber < dataGridViewReport.RowCount-1; rowNumber++)
            {
                double deposit = double.Parse(dataGridViewReport[3, rowNumber].Value.ToString());
                currencyType = dataGridViewReport[4, rowNumber].Value.ToString();
                if (currencyType == "Dollar")
                {
                    summRoubles += deposit * double.Parse(MainForm.currencyList[1].ToString());
                }
                if (currencyType == "Euro")
                {
                    summRoubles += deposit * double.Parse(MainForm.currencyList[2].ToString());
                }
                if (currencyType == "Rub")
                {
                    summRoubles += deposit;
                }
            }
            return summRoubles;
        }
        /// <summary>
        /// Выводим на форму сумму вкладов
        /// </summary>
        public void PresentDepositsSumm()
        {
            lblDepositsSumm.Text += $"\nв рублях: {ConputeDepositSumm()}\nв USD: {ConputeDepositSumm()/double.Parse(MainForm.currencyList[1].ToString())}\nв EUR: {ConputeDepositSumm()/double.Parse(MainForm.currencyList[2].ToString())}";
        }
    }
}
