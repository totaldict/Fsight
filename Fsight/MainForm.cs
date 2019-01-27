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
    public partial class MainForm : Form
    {
        string connectionString;    //строка соединения с БД    
        public static SqlConnection connection;   //наше соединение с БД
        public static string path;                //путь где находится исполняемый файл
        public static string reportPath = @"D:";          //путь сохранения отчётов, пока так
        SqlDataAdapter adapter;
        public static DataSet dataSet;
        DataTable depositTable = new DataTable();
        public List<object> addNewDepositRow = new List<object>();
        public static List<object> currencyList = new List<object>();      //будут храниться значения валюты на сегодняшний день

        public MainForm()
        {
            InitializeComponent();
            try
            {
                ReadSettingsFromFile();
                connectionString = $@"{textBoxConnection.Text}";
                DBConnectionUp();   //соединение с БД при запуске формы
                TakeCurrencyFromDB();
                FillCBoxDepositPercent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangeConnectionString_Click(object sender, EventArgs e)
        {
            DBConnectionDown();         //переподключение с парамертами, указанными в текстбоксе подключения
            connectionString = $@"{textBoxConnection.Text}";
            DBConnectionUp();
        }
        /// <summary>
        /// Открывает соединение с БД
        /// </summary>
        private void DBConnectionUp()
        {
            if (connectionString.CompareTo("") == 0)    //если строка соединения пустая - не пытаемся подключиться
                return;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open(); // Открываем подключение
                LoadDepositsFromDB();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Закрывает соединение с БД
        /// </summary>
        private void DBConnectionDown()
        {
            connection.Close();
        }
        /// <summary>
        /// Загружает файл настроек, если он есть
        /// </summary>
        private void ReadSettingsFromFile()
        {
            //узнаём где находимся, проверяем есть ли файл настроек, если нет - создаём
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (System.IO.File.Exists($@"{path}\settings.ini"))     //если есть файл настроек-грузим их.
                textBoxConnection.Text = $@"{System.IO.File.ReadAllText($@"{path}\settings.ini")}";
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {       //сохраняем в файл настроек
            File.WriteAllText($@"{path}\settings.ini", textBoxConnection.Text, Encoding.Default);
        }

        private void btnSaveDepositChanges_Click(object sender, EventArgs e)
        {   //сохранение изменений депозитов
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);
        }

        private void btnLoadDepositsFromDB_Click(object sender, EventArgs e)
        {
            LoadDepositsFromDB();
        }
        /// <summary>
        /// Загружает данные по депозитам в главную форму
        /// </summary>
        private void LoadDepositsFromDB()
        {
            string sqlSelect = "SELECT * FROM Deposits ORDER BY DepositNumber DESC";           //запрос sql
            adapter = new SqlDataAdapter(sqlSelect, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);       // Заполняем Dataset
            dataGridViewMain.DataSource = dataSet.Tables[0];    // Отображаем данные

        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            NewDepositForm depositForm = new NewDepositForm();
            depositForm.Owner = this;
            depositForm.Show();
        }
        /// <summary>
        /// Добавляет новую строку к таблице
        /// </summary>
        public void AddRowToTable()
        {
            depositTable = dataSet.Tables[0];
            DataRow row = depositTable.NewRow();
            row.ItemArray = new object[] {addNewDepositRow[0], addNewDepositRow[1], addNewDepositRow[2],
                addNewDepositRow[3], addNewDepositRow[4], addNewDepositRow[5],
                addNewDepositRow[6], addNewDepositRow[7], addNewDepositRow[8] };
            depositTable.Rows.Add(row); // добавляем строку

            dataGridViewMain.DataSource = dataSet.Tables[0];
            addNewDepositRow.Clear();
        }
        /// <summary>
        /// Кнопка, вызывает справочник вкладчиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepositors_Click(object sender, EventArgs e)
        {
            DictionaryForm depositorsForm = new DictionaryForm("depositors");
            depositorsForm.Show();
        }
        /// <summary>
        /// Кнопка, вызывает справочник валюты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCurrency_Click(object sender, EventArgs e)
        {
            DictionaryForm currencyForm = new DictionaryForm("currency");
            currencyForm.Show();
        }
        /// <summary>
        /// Кнопка, вызывает справочник банков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBanks_Click(object sender, EventArgs e)
        {
            DictionaryForm bankForm = new DictionaryForm("banks");
            bankForm.Show();
        }
        /// <summary>
        /// Кнопка удаления вкладов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDeposit_Click(object sender, EventArgs e)
        {
            string msg = "Вы хотите удалить данный вклад?";
            DialogResult dialogResult = MessageBox.Show(msg, "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewMain.SelectedRows)
                {
                    dataGridViewMain.Rows.Remove(row);
                }
            }
        }
        //далее идут 3 радиобаттона для выбора отчёта
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FillComboBox("SELECT * FROM Persons", "Name", "Passport");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FillComboBox("SELECT * FROM Bank", "LicenseNumber", "Name");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cBoxReport1.Text = "";
            cBoxReport1.Items.Clear();
            using (SqlCommand command = new SqlCommand("SELECT * FROM ExchangeRates", MainForm.connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                for (int i = 1; i < reader.FieldCount; i++)     //с 1 т.к. нулевое поле в таблице у нас дата!
                    cBoxReport1.Items.Add(reader.GetName(i));
                reader.Close();
            }
        }
        /// <summary>
        /// Заполняет комбобокс
        /// </summary>
        /// <param name="sqlSelect">запрос</param>
        /// <param name="rowName">какое поле выводим</param>
        private void FillComboBox(string sqlSelect, string rowName1, string rowName2)
        {
            cBoxReport1.Text = "";
            cBoxReport1.Items.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            for (int i = 0; i < dTable.Rows.Count; i++)     //заполняем комбобокс
                cBoxReport1.Items.Add($"{dTable.Rows[i][rowName1].ToString()};{dTable.Rows[i][rowName2].ToString()}");
        }

        /// <summary>
        /// Кнопка формирования отчёта по суммам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            if (cBoxReport1.Text == "")     //поле выбора темы отчёта пустое - ничего не делаем.
                return;
            string reportTheme = "";
            if (radioBtnPerson.Checked) reportTheme = "Persons";        //определяем на какую тему отчёт
            if (radioBtnBank.Checked) reportTheme = "Bank";
            if (radioBtnCurrency.Checked) reportTheme = "ExchangeRates";
            Report report1 = new Report(reportTheme, cBoxReport1.Text);
            report1.Owner = this;
            report1.Show();
        }
        /// <summary>
        /// Кнопка построения отчёта для курса валют
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCurrencyPeriod_Click(object sender, EventArgs e)
        {
            string[] datesRange = ReadDatesFromDateTimeOickers();
            //запрос
            string sqlSelect = $"SELECT Date, Dollar, Euro FROM ExchangeRates WHERE Date BETWEEN '{datesRange[0]}' AND '{datesRange[1]}'";
            adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            SaveReportToExcel(MakeNewReportExcelFile(@"\Report2Currency.xlsx"), "Курсы валют в диапазоне", $"от {datesRange[0]} по {datesRange[1]}.", dTable);
        }
        /// <summary>
        /// Читает данные из dateTimePicker и возвращает массив string с 2 датами
        /// </summary>
        /// <returns></returns>
        private string[] ReadDatesFromDateTimeOickers()
        {
            string[] dates = new string[2];
            dates[0] = $"{dateTimePickerCurrencyBegin.Value.Year}-{dateTimePickerCurrencyBegin.Value.Month}-{dateTimePickerCurrencyBegin.Value.Day}";
            dates[1] = $"{dateTimePickerCurrencyEnd.Value.Year}-{dateTimePickerCurrencyEnd.Value.Month}-{dateTimePickerCurrencyEnd.Value.Day}";
            return dates;
        }
        /// <summary>
        /// Создаёт новый файл отчёта и возвращает его название
        /// </summary>
        /// <returns></returns>
        public static string MakeNewReportExcelFile(string reportFile)
        {
            FileInfo fn = new FileInfo($@"{MainForm.path}{reportFile}");
            string newFileName = $@"{MainForm.reportPath}\Report{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.xlsx";
            fn.CopyTo(newFileName, true);
            return newFileName;
        }
        /// <summary>
        /// Сохраняет данные в Excel
        /// </summary>
        /// <param name="fileName">путь к файлу отчёта</param>
        /// <param name="title1">Заголовок 1</param>
        /// <param name="title2">Заголовок 1</param>
        /// <param name="dataTable">таблица, которую фигачим в отчёт</param>
        public static void SaveReportToExcel(string fileName, string title1, string title2, DataTable dataTable, string epilogueTitle = "", int x = 0, int y = 0)
        {   //х,у - смещение вставки таблицы в отчёт
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Open($@"{fileName}",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            //заголовок
            ObjWorkSheet.Cells[1, 1] = title1;
            ObjWorkSheet.Cells[2, 1] = title2;
            //названия столбцов
            for (int columnNumber = 0; columnNumber < dataTable.Columns.Count; columnNumber++)
            {
                ObjWorkSheet.Cells[x + 3, y + columnNumber + 1] = dataTable.Columns[columnNumber].ColumnName;
            }
            //заполнение ячеек
            for (int rowNumber = 0; rowNumber < dataTable.Rows.Count; rowNumber++)
                for (int columnNumber = 0; columnNumber < dataTable.Columns.Count; columnNumber++)
                {
                    //Значения [x - строка, y - столбец]
                    ObjWorkSheet.Cells[x + rowNumber + 4, y + columnNumber + 1] = dataTable.Rows[rowNumber][columnNumber];
                }   //и не забываем что в Excel строки и столбцы начинаются с индекса 1!!!
            if (epilogueTitle == "DepositDynamic")    //если задан эпилог, то пишем него
            {
                ObjWorkSheet.Cells[3, 6] = "Количество вкладов:";
                ObjWorkSheet.Cells[3, 7] = dataTable.Rows.Count;
                ObjWorkSheet.Cells[4, 6] = "Сумма вкладов:";
                int summ = 0;
                for (int rowNumber = 0; rowNumber < dataTable.Rows.Count; rowNumber++)
                {
                    if (dataTable.Rows[rowNumber][3].ToString() != "")      //считаем сумму всех вкладов в таблице
                        summ += int.Parse(dataTable.Rows[rowNumber][3].ToString());
                }
                ObjWorkSheet.Cells[4, 7] = $"в рублях: {summ}";
                ObjWorkSheet.Cells[5, 7] = $"в USD: {summ / (double.Parse(MainForm.currencyList[1].ToString()))}";
                ObjWorkSheet.Cells[6, 7] = $"в EUR: {summ / (double.Parse(MainForm.currencyList[2].ToString()))}";
            }
            //Вызываем нашу созданную эксельку.
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }

        /// <summary>
        /// Кнопка динамика вкладов за период
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepositDynamic_Click(object sender, EventArgs e)
        {
            string[] datesRange = ReadDatesFromDateTimeOickers();   //границы
            string sqlSelect = $"SELECT DepositDate, Sum, Currency FROM Deposits WHERE DepositDate BETWEEN '{datesRange[0]}' AND '{datesRange[1]}'";
            adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            if (dTable.Rows.Count == 0) //Проверка на пустую таблицу
                return;
            AddRublesColumnToDTable(dTable);  //добавляем в нашу таблицу колонку со значениями вкладов в рублях
            SummTheSameDaysDeposits(dTable);    //складываем суммы вкладов по каждому дню
            SaveReportToExcel(MakeNewReportExcelFile(@"\Report3DepositDynamic.xlsx"), "Динамика вкладов за период", $"от {datesRange[0]} по {datesRange[1]}.", dTable, "DepositDynamic");
        }
        /// <summary>
        /// В передаваемой таблице складывает рублевые суммы вкладов в один день. Это для отчёта по динамике.
        /// </summary>
        /// <param name="dTable"></param>
        private void SummTheSameDaysDeposits(DataTable dTable)
        {
            object lastDayRow = dTable.Rows[0][0];
            for (int rowNumber = 0; rowNumber < dTable.Rows.Count - 1; rowNumber++)
            {
                if (lastDayRow.ToString() == dTable.Rows[rowNumber + 1][0].ToString())
                {

                    dTable.Rows[rowNumber + 1][0] = DBNull.Value;
                    dTable.Rows[rowNumber][3] = int.Parse(dTable.Rows[rowNumber][3].ToString()) + int.Parse(dTable.Rows[rowNumber + 1][3].ToString());
                    dTable.Rows[rowNumber + 1][3] = "";
                }
                if (lastDayRow.ToString() != dTable.Rows[rowNumber + 1][0].ToString())
                {
                    lastDayRow = dTable.Rows[rowNumber + 1][0];
                }
            }
        }
        /// <summary>
        /// Добавляет колонку с пересчитанным вкладом в рублях
        /// </summary>
        /// <param name="dTable">таблица, в которую добавляем колонку</param>
        /// <returns></returns>
        private void AddRublesColumnToDTable(DataTable dTable)
        {
            dTable.Columns.Add(@"Deposit in RUR/day");
            for (int rowNumber = 0; rowNumber < dTable.Rows.Count; rowNumber++)
            {               //смотрим по валюте и умножаем на курс на сегодняшний день
                if (dTable.Rows[rowNumber][2].ToString() == "Dollar")
                {
                    dTable.Rows[rowNumber][3] = Math.Round(double.Parse(dTable.Rows[rowNumber][1].ToString()) * (double.Parse(MainForm.currencyList[1].ToString())));
                }
                if (dTable.Rows[rowNumber][2].ToString() == "Euro")
                {
                    dTable.Rows[rowNumber][3] = Math.Round(double.Parse(dTable.Rows[rowNumber][1].ToString()) * (double.Parse(MainForm.currencyList[2].ToString())));
                }
                if (dTable.Rows[rowNumber][2].ToString() == "Rub")
                {
                    dTable.Rows[rowNumber][3] = Math.Round(double.Parse(dTable.Rows[rowNumber][1].ToString()));
                }
            }
        }
        /// <summary>
        /// Получаем последние известные значения валют из БД
        /// </summary>
        public static void TakeCurrencyFromDB()
        {
            string sqlSelectNumber = "SELECT TOP 1 * FROM ExchangeRates ORDER BY Date DESC";           //запрос sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectNumber, MainForm.connection);
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            MainForm.currencyList.Add(dTable.Rows[0]["Date"]);
            MainForm.currencyList.Add(dTable.Rows[0]["Dollar"]);
            MainForm.currencyList.Add(dTable.Rows[0]["Euro"]);
        }
        /// <summary>
        /// Заполняет comboBox выбора вклада при отчёте по процентам
        /// </summary>
        public void FillCBoxDepositPercent()
        {
            string sqlSelectNumber = "SELECT DepositNumber, DepositName FROM Deposits";           //запрос sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectNumber, MainForm.connection);
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            for (int i = 0; i < dTable.Rows.Count; i++)     //заполняем комбобокс
                cBoxDepositPercent.Items.Add($"{dTable.Rows[i]["DepositNumber"].ToString()};{dTable.Rows[i]["DepositName"].ToString()}");
        }
        /// <summary>
        /// Формирует отчёт по процентам.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            MakeTableForPercentReport(dTable);
            AddPercentSummPerDayColumn(dTable);
            string[] datesRange;
            if (checkBoxPeriod.Checked) //если выбрано "За период"
            {
                DateTime date1 = DateTime.Now, date2 = DateTime.Now; //даты периода расчёта процентов во вкладе
                datesRange = ReadDatesFromDateTimeOickers();
                for (int rowNumber = 0; rowNumber < dTable.Rows.Count; rowNumber++)
                {
                    DateTime depositTerm = DateTime.Parse(dTable.Rows[rowNumber][6].ToString());//вычисляем количество дней вклада
                    DateTime depositDate = DateTime.Parse(dTable.Rows[rowNumber][5].ToString());
                    if (depositDate > DateTime.Parse(datesRange[1]))    //если период отчёта не включает период депозита
                    {
                        dTable.Rows[rowNumber]["PercentsSummPerDay"] = 0;
                        dTable.Rows[rowNumber]["PercentsSummFull"] = 0;
                        continue;
                    }
                    if (depositDate > DateTime.Parse(datesRange[0]))    //установка сроков исчисления процентов
                        date1 = depositDate;
                    else
                        date1 = DateTime.Parse(datesRange[0]);
                    if (depositTerm < DateTime.Parse(datesRange[1]))
                        date2 = depositTerm;
                    else
                        date2 = DateTime.Parse(datesRange[1]);
                    TimeSpan depositPeriod = date2 - date1;

                    dTable.Rows[rowNumber]["PercentsSummFull"] = depositPeriod.Days * Convert.ToDouble(dTable.Rows[rowNumber]["PercentsSummPerDay"]);
                }
                SaveReportToExcel(MakeNewReportExcelFile(@"\Report1.xlsx"), "Отчёт по процентам", $"с {datesRange[0]} по {datesRange[1]}.", dTable);
            }
            else //за все время
            {
                datesRange = null;
                SaveReportToExcel(MakeNewReportExcelFile(@"\Report1.xlsx"), "Отчёт по процентам", $"за полный период вклада.", dTable);
            }
        }
        /// <summary>
        /// Заполняем табличку
        /// </summary>
        /// <param name="dTable"></param>
        private void MakeTableForPercentReport(DataTable dTable)
        {
            string sqlSelect;
            string DepositName = cBoxDepositPercent.Text;
            if (DepositName != "")      //если не выбран конкретный вклад - значит выбираем все вклады
            {
                string[] arrayDepositName = cBoxDepositPercent.Text.Split(';');
                sqlSelect = $"Select * FROM Deposits WHERE DepositNumber={arrayDepositName[0]}";
            }
            else
            {
                sqlSelect = $"Select * FROM Deposits";
            }   //выполняем запрос
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            //dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
        }
        /// <summary>
        /// Добавляет колонку начисленной суммы % в день
        /// </summary>
        /// <param name="dTable"></param>
        private void AddPercentSummPerDayColumn(DataTable dTable)
        {
            dTable.Columns.Add("PercentsSummPerDay", typeof(Double));
            dTable.Columns.Add("PercentsSummFull", typeof(Double));
            for (int rowNumber = 0; rowNumber < dTable.Rows.Count; rowNumber++)
            {       //сумма процентов за весь срок вклада
                double peercentSummFull = double.Parse(dTable.Rows[rowNumber][3].ToString()) *
                    double.Parse(dTable.Rows[rowNumber][7].ToString()) / 100;
                DateTime depositTerm = DateTime.Parse(dTable.Rows[rowNumber][6].ToString());//вычисляем количество дней вклада
                DateTime depositDate = DateTime.Parse(dTable.Rows[rowNumber][5].ToString());
                TimeSpan depositPeriod = depositTerm - depositDate;
                double peercentPerDay = peercentSummFull / Convert.ToDouble(depositPeriod.Days);
                dTable.Rows[rowNumber]["PercentsSummPerDay"] = peercentPerDay;
                dTable.Rows[rowNumber]["PercentsSummFull"] = peercentSummFull;
            }
        }
        /// <summary>
        /// Кнопка формирования отчёта линейного трнеда за прошлый год
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            TakeLastYearDepodits(dTable);
            DataTable byMonthsTable = GroupYearByMonths(dTable);
            SaveReportToExcel(MakeNewReportExcelFile(@"\Report4ForecastLineTrendSes.xlsx"), "Прогнозирование тенденций вкладов методом линейного тренда", $"с учётом сезонности по данным за {DateTime.Now.Year - 1} год.", byMonthsTable, "", 3, 2);

        }
        /// <summary>
        /// Выбирает данные за прошлый год
        /// </summary>
        /// <param name="dTable">записывает их в эту таблицу</param>
        private void TakeLastYearDepodits(DataTable dTable)
        {
            int yearNow = DateTime.Now.Year; //определяем текущий год
            string sqlSelectYear = $"SELECT DepositDate, Sum, Currency FROM Deposits WHERE DepositDate BETWEEN '{yearNow - 1}-01-01' AND '{yearNow - 1}-12-31'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectYear, MainForm.connection);
            adapter.Fill(dTable);       // Заполняем DataTable
        }
        /// <summary>
        /// Вычисляет сумму вкладов за каждый месяц и возвращает эту таблицу
        /// </summary>
        /// <param name="dTable">Таблица вкладов за прошлый год</param>
        /// <returns></returns>
        private DataTable GroupYearByMonths(DataTable dTable)
        {
            DataTable byMonthsTable = new DataTable();
            byMonthsTable.Columns.Add("Deposits", typeof(double));
            for (int i = 0; i < 12; i++)//добавляем 12 строк
            {
                byMonthsTable.Rows.Add();
                byMonthsTable.Rows[i]["Deposits"] = 0;
            }
            for (int rowNumber = 0; rowNumber < dTable.Rows.Count; rowNumber++)
            {               //в новую таблицу byMonthsTable складываем суммы вкладов по месяцам. Пересчитано в рублях!
                if (dTable.Rows[rowNumber]["Currency"].ToString() == "Dollar")
                {
                    int month = Convert.ToDateTime(dTable.Rows[rowNumber]["DepositDate"]).Month;
                    byMonthsTable.Rows[month - 1]["Deposits"] =
                        Convert.ToDouble(byMonthsTable.Rows[month - 1]["Deposits"]) +
                        Convert.ToDouble(dTable.Rows[rowNumber]["Sum"]) * Convert.ToDouble(currencyList[1]);
                }
                if (dTable.Rows[rowNumber]["Currency"].ToString() == "Euro")
                {
                    int month = Convert.ToDateTime(dTable.Rows[rowNumber]["DepositDate"]).Month;
                    byMonthsTable.Rows[month - 1]["Deposits"] =
                        Convert.ToDouble(byMonthsTable.Rows[month - 1]["Deposits"]) +
                        Convert.ToDouble(dTable.Rows[rowNumber]["Sum"]) * Convert.ToDouble(currencyList[2]);
                }
                if (dTable.Rows[rowNumber]["Currency"].ToString() == "Rub")
                {
                    int month = Convert.ToDateTime(dTable.Rows[rowNumber]["DepositDate"]).Month;
                    byMonthsTable.Rows[month - 1]["Deposits"] =
                        Convert.ToDouble(byMonthsTable.Rows[month - 1]["Deposits"]) +
                        Convert.ToDouble(dTable.Rows[rowNumber]["Sum"]);
                }
            }
            return byMonthsTable;
        }
    }
}
