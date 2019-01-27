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
    public partial class DictionaryForm : Form
    {
        SqlDataAdapter adapter;
        DataSet dataSet;
        public DictionaryForm(string dictionaryType)
        {
            InitializeComponent();
            LoadDictionary(dictionaryType); //по переданному параметру понимаем, какой справочник грузить
        }

        private void DepositorsForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// По переданному параметру понимаем, какой справочник грузить
        /// </summary>
        /// <param name="dictType"></param>
        private void LoadDictionary(string dictType)
        {
            string sqlSelect="";
            if (dictType== "depositors")        //выбираем тип запроса sql
                sqlSelect = "SELECT * FROM Persons";
            if (dictType == "banks")        
                sqlSelect = "SELECT * FROM Bank";
            if (dictType == "currency")        
                sqlSelect = "SELECT * FROM ExchangeRates";
            adapter = new SqlDataAdapter(sqlSelect, MainForm.connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);       // Заполняем Dataset
            dataGridViewDictionary.DataSource = dataSet.Tables[0];    // Отображаем данные
        }

        /// <summary>
        /// Кнопка отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Кнопка сохранения в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);
        }

        /// <summary>
        /// Удаление выделеных записей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "Вы хотите удалить запись?";
            DialogResult dialogResult = MessageBox.Show(msg, "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewDictionary.SelectedRows)
                {
                    dataGridViewDictionary.Rows.Remove(row);
                }
            }
        }
    }
}
