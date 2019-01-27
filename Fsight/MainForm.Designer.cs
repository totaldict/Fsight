namespace Fsight
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBanks = new System.Windows.Forms.Button();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.btnDepositors = new System.Windows.Forms.Button();
            this.btnDeleteDeposit = new System.Windows.Forms.Button();
            this.btnSaveDepositChanges = new System.Windows.Forms.Button();
            this.btnLoadDepositsFromDB = new System.Windows.Forms.Button();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxPeriod = new System.Windows.Forms.CheckBox();
            this.cBoxDepositPercent = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDepositDynamic = new System.Windows.Forms.Button();
            this.btnCurrencyPeriod = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerCurrencyEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCurrencyBegin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxReport1 = new System.Windows.Forms.ComboBox();
            this.radioBtnCurrency = new System.Windows.Forms.RadioButton();
            this.radioBtnBank = new System.Windows.Forms.RadioButton();
            this.radioBtnPerson = new System.Windows.Forms.RadioButton();
            this.btnMakeReport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnChangeConnectionString = new System.Windows.Forms.Button();
            this.textBoxConnection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPage1);
            this.tabSettings.Controls.Add(this.tabPage3);
            this.tabSettings.Controls.Add(this.tabPage2);
            this.tabSettings.Location = new System.Drawing.Point(0, 12);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(870, 568);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnBanks);
            this.tabPage1.Controls.Add(this.btnCurrency);
            this.tabPage1.Controls.Add(this.btnDepositors);
            this.tabPage1.Controls.Add(this.btnDeleteDeposit);
            this.tabPage1.Controls.Add(this.btnSaveDepositChanges);
            this.tabPage1.Controls.Add(this.btnLoadDepositsFromDB);
            this.tabPage1.Controls.Add(this.btnAddDeposit);
            this.tabPage1.Controls.Add(this.dataGridViewMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вклады";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(754, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Справочники:";
            // 
            // btnBanks
            // 
            this.btnBanks.Image = global::Fsight.Properties.Resources.icoBank;
            this.btnBanks.Location = new System.Drawing.Point(749, 505);
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.Size = new System.Drawing.Size(100, 25);
            this.btnBanks.TabIndex = 7;
            this.btnBanks.Text = "Банки";
            this.btnBanks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanks.UseVisualStyleBackColor = true;
            this.btnBanks.Click += new System.EventHandler(this.btnBanks_Click);
            // 
            // btnCurrency
            // 
            this.btnCurrency.Image = global::Fsight.Properties.Resources.icoDollar;
            this.btnCurrency.Location = new System.Drawing.Point(749, 476);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(100, 25);
            this.btnCurrency.TabIndex = 6;
            this.btnCurrency.Text = "Курсы валют";
            this.btnCurrency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurrency.UseVisualStyleBackColor = true;
            this.btnCurrency.Click += new System.EventHandler(this.btnCurrency_Click);
            // 
            // btnDepositors
            // 
            this.btnDepositors.Image = global::Fsight.Properties.Resources.icoMan;
            this.btnDepositors.Location = new System.Drawing.Point(749, 447);
            this.btnDepositors.Name = "btnDepositors";
            this.btnDepositors.Size = new System.Drawing.Size(100, 25);
            this.btnDepositors.TabIndex = 5;
            this.btnDepositors.Text = "Вкладчики";
            this.btnDepositors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepositors.UseVisualStyleBackColor = true;
            this.btnDepositors.Click += new System.EventHandler(this.btnDepositors_Click);
            // 
            // btnDeleteDeposit
            // 
            this.btnDeleteDeposit.Image = global::Fsight.Properties.Resources.icoTrash;
            this.btnDeleteDeposit.Location = new System.Drawing.Point(111, 422);
            this.btnDeleteDeposit.Name = "btnDeleteDeposit";
            this.btnDeleteDeposit.Size = new System.Drawing.Size(95, 40);
            this.btnDeleteDeposit.TabIndex = 4;
            this.btnDeleteDeposit.Text = "Удалить вклад";
            this.btnDeleteDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteDeposit.UseVisualStyleBackColor = true;
            this.btnDeleteDeposit.Click += new System.EventHandler(this.btnDeleteDeposit_Click);
            // 
            // btnSaveDepositChanges
            // 
            this.btnSaveDepositChanges.Image = global::Fsight.Properties.Resources.icoSave;
            this.btnSaveDepositChanges.Location = new System.Drawing.Point(10, 492);
            this.btnSaveDepositChanges.Name = "btnSaveDepositChanges";
            this.btnSaveDepositChanges.Size = new System.Drawing.Size(107, 40);
            this.btnSaveDepositChanges.TabIndex = 3;
            this.btnSaveDepositChanges.Text = "Сохранить изменения";
            this.btnSaveDepositChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveDepositChanges.UseVisualStyleBackColor = true;
            this.btnSaveDepositChanges.Click += new System.EventHandler(this.btnSaveDepositChanges_Click);
            // 
            // btnLoadDepositsFromDB
            // 
            this.btnLoadDepositsFromDB.Image = global::Fsight.Properties.Resources.icoRefresh;
            this.btnLoadDepositsFromDB.Location = new System.Drawing.Point(123, 493);
            this.btnLoadDepositsFromDB.Name = "btnLoadDepositsFromDB";
            this.btnLoadDepositsFromDB.Size = new System.Drawing.Size(118, 40);
            this.btnLoadDepositsFromDB.TabIndex = 2;
            this.btnLoadDepositsFromDB.Text = "Загрузить вклады из БД";
            this.btnLoadDepositsFromDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadDepositsFromDB.UseVisualStyleBackColor = true;
            this.btnLoadDepositsFromDB.Click += new System.EventHandler(this.btnLoadDepositsFromDB_Click);
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Image = global::Fsight.Properties.Resources.icoPlus;
            this.btnAddDeposit.Location = new System.Drawing.Point(10, 422);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(95, 40);
            this.btnAddDeposit.TabIndex = 1;
            this.btnAddDeposit.Text = "Добавить вклад";
            this.btnAddDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.Size = new System.Drawing.Size(850, 410);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(862, 542);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Отчёты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnDepositDynamic);
            this.groupBox2.Controls.Add(this.btnCurrencyPeriod);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateTimePickerCurrencyEnd);
            this.groupBox2.Controls.Add(this.dateTimePickerCurrencyBegin);
            this.groupBox2.Location = new System.Drawing.Point(8, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 122);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отчёты за период:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxPeriod);
            this.groupBox3.Controls.Add(this.cBoxDepositPercent);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(236, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Процент по вкладам:";
            // 
            // checkBoxPeriod
            // 
            this.checkBoxPeriod.AutoSize = true;
            this.checkBoxPeriod.Location = new System.Drawing.Point(6, 46);
            this.checkBoxPeriod.Name = "checkBoxPeriod";
            this.checkBoxPeriod.Size = new System.Drawing.Size(78, 17);
            this.checkBoxPeriod.TabIndex = 8;
            this.checkBoxPeriod.Text = "За период";
            this.checkBoxPeriod.UseVisualStyleBackColor = true;
            // 
            // cBoxDepositPercent
            // 
            this.cBoxDepositPercent.FormattingEnabled = true;
            this.cBoxDepositPercent.Location = new System.Drawing.Point(6, 19);
            this.cBoxDepositPercent.Name = "cBoxDepositPercent";
            this.cBoxDepositPercent.Size = new System.Drawing.Size(432, 21);
            this.cBoxDepositPercent.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Image = global::Fsight.Properties.Resources.icoExcel;
            this.button1.Location = new System.Drawing.Point(339, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Получено процентов";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDepositDynamic
            // 
            this.btnDepositDynamic.Image = global::Fsight.Properties.Resources.icoExcel;
            this.btnDepositDynamic.Location = new System.Drawing.Point(112, 73);
            this.btnDepositDynamic.Name = "btnDepositDynamic";
            this.btnDepositDynamic.Size = new System.Drawing.Size(98, 40);
            this.btnDepositDynamic.TabIndex = 5;
            this.btnDepositDynamic.Text = "Динамика вкладов";
            this.btnDepositDynamic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepositDynamic.UseVisualStyleBackColor = true;
            this.btnDepositDynamic.Click += new System.EventHandler(this.btnDepositDynamic_Click);
            // 
            // btnCurrencyPeriod
            // 
            this.btnCurrencyPeriod.Image = global::Fsight.Properties.Resources.icoExcel;
            this.btnCurrencyPeriod.Location = new System.Drawing.Point(17, 73);
            this.btnCurrencyPeriod.Name = "btnCurrencyPeriod";
            this.btnCurrencyPeriod.Size = new System.Drawing.Size(90, 40);
            this.btnCurrencyPeriod.TabIndex = 4;
            this.btnCurrencyPeriod.Text = "Курсы валют";
            this.btnCurrencyPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurrencyPeriod.UseVisualStyleBackColor = true;
            this.btnCurrencyPeriod.Click += new System.EventHandler(this.btnCurrencyPeriod_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "по:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "с:";
            // 
            // dateTimePickerCurrencyEnd
            // 
            this.dateTimePickerCurrencyEnd.Location = new System.Drawing.Point(37, 47);
            this.dateTimePickerCurrencyEnd.Name = "dateTimePickerCurrencyEnd";
            this.dateTimePickerCurrencyEnd.Size = new System.Drawing.Size(193, 20);
            this.dateTimePickerCurrencyEnd.TabIndex = 1;
            // 
            // dateTimePickerCurrencyBegin
            // 
            this.dateTimePickerCurrencyBegin.Location = new System.Drawing.Point(37, 21);
            this.dateTimePickerCurrencyBegin.Name = "dateTimePickerCurrencyBegin";
            this.dateTimePickerCurrencyBegin.Size = new System.Drawing.Size(193, 20);
            this.dateTimePickerCurrencyBegin.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxReport1);
            this.groupBox1.Controls.Add(this.radioBtnCurrency);
            this.groupBox1.Controls.Add(this.radioBtnBank);
            this.groupBox1.Controls.Add(this.radioBtnPerson);
            this.groupBox1.Controls.Add(this.btnMakeReport);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сумма вклада на текущий момент:";
            // 
            // cBoxReport1
            // 
            this.cBoxReport1.FormattingEnabled = true;
            this.cBoxReport1.Location = new System.Drawing.Point(6, 42);
            this.cBoxReport1.Name = "cBoxReport1";
            this.cBoxReport1.Size = new System.Drawing.Size(334, 21);
            this.cBoxReport1.TabIndex = 3;
            // 
            // radioBtnCurrency
            // 
            this.radioBtnCurrency.AutoSize = true;
            this.radioBtnCurrency.Location = new System.Drawing.Point(238, 19);
            this.radioBtnCurrency.Name = "radioBtnCurrency";
            this.radioBtnCurrency.Size = new System.Drawing.Size(77, 17);
            this.radioBtnCurrency.TabIndex = 2;
            this.radioBtnCurrency.Text = "по валюте";
            this.radioBtnCurrency.UseVisualStyleBackColor = true;
            this.radioBtnCurrency.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioBtnBank
            // 
            this.radioBtnBank.AutoSize = true;
            this.radioBtnBank.Location = new System.Drawing.Point(133, 19);
            this.radioBtnBank.Name = "radioBtnBank";
            this.radioBtnBank.Size = new System.Drawing.Size(69, 17);
            this.radioBtnBank.TabIndex = 1;
            this.radioBtnBank.Text = "по банку";
            this.radioBtnBank.UseVisualStyleBackColor = true;
            this.radioBtnBank.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioBtnPerson
            // 
            this.radioBtnPerson.AutoSize = true;
            this.radioBtnPerson.Location = new System.Drawing.Point(6, 19);
            this.radioBtnPerson.Name = "radioBtnPerson";
            this.radioBtnPerson.Size = new System.Drawing.Size(92, 17);
            this.radioBtnPerson.TabIndex = 0;
            this.radioBtnPerson.Text = "по вкладчику";
            this.radioBtnPerson.UseVisualStyleBackColor = true;
            this.radioBtnPerson.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnMakeReport
            // 
            this.btnMakeReport.Image = global::Fsight.Properties.Resources.icoFind;
            this.btnMakeReport.Location = new System.Drawing.Point(215, 74);
            this.btnMakeReport.Name = "btnMakeReport";
            this.btnMakeReport.Size = new System.Drawing.Size(125, 39);
            this.btnMakeReport.TabIndex = 3;
            this.btnMakeReport.Text = "Сформировать";
            this.btnMakeReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMakeReport.UseVisualStyleBackColor = true;
            this.btnMakeReport.Click += new System.EventHandler(this.btnMakeReport_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSaveSettings);
            this.tabPage2.Controls.Add(this.btnChangeConnectionString);
            this.tabPage2.Controls.Add(this.textBoxConnection);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пример: Data Source=.\\SQLEXPRESS;Initial Catalog=fsight222;Integrated Security=Tr" +
    "ue";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Image = global::Fsight.Properties.Resources.icoSave;
            this.btnSaveSettings.Location = new System.Drawing.Point(749, 493);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(105, 40);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Сохранить настройки";
            this.btnSaveSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnChangeConnectionString
            // 
            this.btnChangeConnectionString.Location = new System.Drawing.Point(735, 25);
            this.btnChangeConnectionString.Name = "btnChangeConnectionString";
            this.btnChangeConnectionString.Size = new System.Drawing.Size(75, 23);
            this.btnChangeConnectionString.TabIndex = 2;
            this.btnChangeConnectionString.Text = "Применить";
            this.btnChangeConnectionString.UseVisualStyleBackColor = true;
            this.btnChangeConnectionString.Click += new System.EventHandler(this.btnChangeConnectionString_Click);
            // 
            // textBoxConnection
            // 
            this.textBoxConnection.Location = new System.Drawing.Point(11, 28);
            this.textBoxConnection.Name = "textBoxConnection";
            this.textBoxConnection.Size = new System.Drawing.Size(718, 20);
            this.textBoxConnection.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка подключения к базе:";
            // 
            // button2
            // 
            this.button2.Image = global::Fsight.Properties.Resources.icoExcel;
            this.button2.Location = new System.Drawing.Point(470, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "Сформировать";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(8, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(608, 84);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Прогнозирование:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(595, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Прогнозирование тенденций вкладов методом линейного тренда с учётом сезонности по" +
    " данным за прошлый год.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 579);
            this.Controls.Add(this.tabSettings);
            this.Name = "MainForm";
            this.Text = "Вклады";
            this.tabSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnChangeConnectionString;
        private System.Windows.Forms.TextBox textBoxConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button btnDeleteDeposit;
        private System.Windows.Forms.Button btnSaveDepositChanges;
        private System.Windows.Forms.Button btnLoadDepositsFromDB;
        private System.Windows.Forms.Button btnAddDeposit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBanks;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Button btnDepositors;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnCurrency;
        private System.Windows.Forms.RadioButton radioBtnBank;
        private System.Windows.Forms.RadioButton radioBtnPerson;
        private System.Windows.Forms.Button btnMakeReport;
        private System.Windows.Forms.ComboBox cBoxReport1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCurrencyPeriod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerCurrencyEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerCurrencyBegin;
        private System.Windows.Forms.Button btnDepositDynamic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBoxDepositPercent;
        private System.Windows.Forms.CheckBox checkBoxPeriod;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
    }
}

