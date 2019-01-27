using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fsight
{
    public partial class NewDepositForm : Form
    {
        DataTable dTable;
        public NewDepositForm()
        {
            InitializeComponent();

        }

        private void NewDepositForm_Load(object sender, EventArgs e)
        {
            AddDepositorsToComboBox();
            AddBanksToComboBox();
            AddCurrencyToComboBox();
            AddDepositNumberToLabel();
        }
        /// <summary>
        /// Добавление вкладчиков в комбобокс
        /// </summary>
        private void AddDepositorsToComboBox()
        {
            string sqlSelectDepositors = "SELECT * FROM Persons";           //запрос sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectDepositors, MainForm.connection);
            dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            for (int i = 0; i < dTable.Rows.Count; i++)     //заполняем комбобокс
                cBoxDepositor.Items.Add($"{dTable.Rows[i]["Name"].ToString()};{dTable.Rows[i]["Passport"].ToString()}");
        }
        /// <summary>
        /// Добавление банков в комбобокс
        /// </summary>
        private void AddBanksToComboBox()
        {
            string sqlSelectBanks = "SELECT * FROM Bank";           //запрос sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectBanks, MainForm.connection);
            dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            for (int i = 0; i < dTable.Rows.Count; i++)     //заполняем комбобокс
                cBoxBanks.Items.Add($"{dTable.Rows[i]["LicenseNumber"].ToString()};{dTable.Rows[i]["Name"].ToString()}");
        }
        /// <summary>
        /// Добавление валюты в комбобокс
        /// </summary>
        private void AddCurrencyToComboBox()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM ExchangeRates", MainForm.connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                for (int i = 1; i < reader.FieldCount; i++)     //с 1 т.к. нулевое поле в таблице у нас дата!
                    cBoxCurrency.Items.Add(reader.GetName(i));
                reader.Close();
            }
        }
        /// <summary>
        /// Автоматически вычисляет номер нового вклада
        /// </summary>
        private void AddDepositNumberToLabel()
        {
            //Ищем номер последнего вклада и делаем +1
            string sqlSelectNumber = "SELECT TOP 1 * FROM Deposits ORDER BY DepositNumber DESC";           //запрос sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectNumber, MainForm.connection);
            dTable = new DataTable();
            adapter.Fill(dTable);       // Заполняем DataTable
            int depositNumber = int.Parse(dTable.Rows[0]["DepositNumber"].ToString()) + 1;
            labelDepositNumber.Text = depositNumber.ToString();
        }

        private void btnAddNewDeposit_Click(object sender, EventArgs e)
        {   //заполненные данные из полей добавляем в список
            MainForm mainForm = this.Owner as MainForm;
            if (mainForm != null)
            {
                mainForm.addNewDepositRow.Add(int.Parse(labelDepositNumber.Text));
                string[] arrayDepositorName = cBoxDepositor.Text.Split(';');
                mainForm.addNewDepositRow.Add(arrayDepositorName[1]);
                mainForm.addNewDepositRow.Add(textBoxDepositName.Text);
                mainForm.addNewDepositRow.Add(double.Parse(maskedTBSumm.Text));
                mainForm.addNewDepositRow.Add(cBoxCurrency.Text);
                mainForm.addNewDepositRow.Add(DateTime.Parse(dateTimePicker1.Text));
                mainForm.addNewDepositRow.Add(DateTime.Parse(dateTimePicker2.Text));
                mainForm.addNewDepositRow.Add(float.Parse(maskedTBPercent.Text));
                string[] arrayBank = cBoxBanks.Text.Split(';');
                mainForm.addNewDepositRow.Add(arrayBank[0]);
                //добавляем строку к таблице
                mainForm.AddRowToTable();
                this.Close();
            }
        }

        private void btnCancelDeposit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
