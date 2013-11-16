namespace Lasers
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.numericUpDownWidhField = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeightField = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton135 = new System.Windows.Forms.RadioButton();
            this.radioButton315 = new System.Windows.Forms.RadioButton();
            this.radioButton225 = new System.Windows.Forms.RadioButton();
            this.radioButton45 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownLaserPosY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownLaserPosX = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewMirrors = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewHoles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewGoals = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDepth = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonDepthInfo = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonBreadthInfo = new System.Windows.Forms.Button();
            this.buttonBreadth = new System.Windows.Forms.Button();
            this.buttonGradientInfo = new System.Windows.Forms.Button();
            this.buttonGradient = new System.Windows.Forms.Button();
            this.numericUpDownMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonPartialPathInfo = new System.Windows.Forms.Button();
            this.buttonPartialPath = new System.Windows.Forms.Button();
            this.numericUpDownLocaDepth = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidhField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightField)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLaserPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLaserPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMirrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocaDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownWidhField
            // 
            this.numericUpDownWidhField.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidhField.Location = new System.Drawing.Point(23, 44);
            this.numericUpDownWidhField.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownWidhField.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidhField.Name = "numericUpDownWidhField";
            this.numericUpDownWidhField.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownWidhField.TabIndex = 4;
            this.numericUpDownWidhField.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownWidhField.ValueChanged += new System.EventHandler(this.numericUpDownWidhField_ValueChanged);
            // 
            // numericUpDownHeightField
            // 
            this.numericUpDownHeightField.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHeightField.Location = new System.Drawing.Point(169, 44);
            this.numericUpDownHeightField.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownHeightField.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHeightField.Name = "numericUpDownHeightField";
            this.numericUpDownHeightField.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownHeightField.TabIndex = 5;
            this.numericUpDownHeightField.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownHeightField.ValueChanged += new System.EventHandler(this.numericUpDownHeightField_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ширина поля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Высота поля";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownWidhField);
            this.groupBox1.Controls.Add(this.numericUpDownHeightField);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поле";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton135);
            this.groupBox2.Controls.Add(this.radioButton315);
            this.groupBox2.Controls.Add(this.radioButton225);
            this.groupBox2.Controls.Add(this.radioButton45);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownLaserPosY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numericUpDownLaserPosX);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 142);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лазер";
            // 
            // radioButton135
            // 
            this.radioButton135.AutoSize = true;
            this.radioButton135.Checked = true;
            this.radioButton135.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton135.Location = new System.Drawing.Point(261, 87);
            this.radioButton135.Name = "radioButton135";
            this.radioButton135.Size = new System.Drawing.Size(64, 48);
            this.radioButton135.TabIndex = 15;
            this.radioButton135.TabStop = true;
            this.radioButton135.Text = "↙";
            this.radioButton135.UseVisualStyleBackColor = true;
            this.radioButton135.CheckedChanged += new System.EventHandler(this.radioButton135_CheckedChanged);
            // 
            // radioButton315
            // 
            this.radioButton315.AutoSize = true;
            this.radioButton315.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton315.Location = new System.Drawing.Point(317, 47);
            this.radioButton315.Name = "radioButton315";
            this.radioButton315.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton315.Size = new System.Drawing.Size(64, 48);
            this.radioButton315.TabIndex = 14;
            this.radioButton315.TabStop = true;
            this.radioButton315.Text = "↗";
            this.radioButton315.UseVisualStyleBackColor = true;
            this.radioButton315.CheckedChanged += new System.EventHandler(this.radioButton315_CheckedChanged);
            // 
            // radioButton225
            // 
            this.radioButton225.AutoSize = true;
            this.radioButton225.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton225.Location = new System.Drawing.Point(261, 47);
            this.radioButton225.Name = "radioButton225";
            this.radioButton225.Size = new System.Drawing.Size(64, 48);
            this.radioButton225.TabIndex = 13;
            this.radioButton225.TabStop = true;
            this.radioButton225.Text = "↖";
            this.radioButton225.UseVisualStyleBackColor = true;
            this.radioButton225.CheckedChanged += new System.EventHandler(this.radioButton225_CheckedChanged);
            // 
            // radioButton45
            // 
            this.radioButton45.AutoSize = true;
            this.radioButton45.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton45.Location = new System.Drawing.Point(317, 87);
            this.radioButton45.Name = "radioButton45";
            this.radioButton45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton45.Size = new System.Drawing.Size(64, 48);
            this.radioButton45.TabIndex = 12;
            this.radioButton45.Text = "↘";
            this.radioButton45.UseVisualStyleBackColor = true;
            this.radioButton45.CheckedChanged += new System.EventHandler(this.radioButton45_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Направление лазера";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Координата лазера по оси Y";
            // 
            // numericUpDownLaserPosY
            // 
            this.numericUpDownLaserPosY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLaserPosY.Location = new System.Drawing.Point(22, 103);
            this.numericUpDownLaserPosY.Maximum = new decimal(new int[] {
            195,
            0,
            0,
            0});
            this.numericUpDownLaserPosY.Name = "numericUpDownLaserPosY";
            this.numericUpDownLaserPosY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLaserPosY.TabIndex = 9;
            this.numericUpDownLaserPosY.ValueChanged += new System.EventHandler(this.numericUpDownLaserPosY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Координата лазера по оси X";
            // 
            // numericUpDownLaserPosX
            // 
            this.numericUpDownLaserPosX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLaserPosX.Location = new System.Drawing.Point(22, 51);
            this.numericUpDownLaserPosX.Maximum = new decimal(new int[] {
            195,
            0,
            0,
            0});
            this.numericUpDownLaserPosX.Name = "numericUpDownLaserPosX";
            this.numericUpDownLaserPosX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLaserPosX.TabIndex = 7;
            this.numericUpDownLaserPosX.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownLaserPosX.ValueChanged += new System.EventHandler(this.numericUpDownLaserPosX_ValueChanged);
            // 
            // dataGridViewMirrors
            // 
            this.dataGridViewMirrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMirrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewMirrors.Location = new System.Drawing.Point(12, 276);
            this.dataGridViewMirrors.Name = "dataGridViewMirrors";
            this.dataGridViewMirrors.RowTemplate.Height = 24;
            this.dataGridViewMirrors.Size = new System.Drawing.Size(143, 166);
            this.dataGridViewMirrors.TabIndex = 10;
            this.dataGridViewMirrors.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewMirrors_CellBeginEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Y";
            this.Column2.Name = "Column2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Зеркала";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дыры";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Цели";
            // 
            // dataGridViewHoles
            // 
            this.dataGridViewHoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewHoles.Location = new System.Drawing.Point(161, 276);
            this.dataGridViewHoles.Name = "dataGridViewHoles";
            this.dataGridViewHoles.RowTemplate.Height = 24;
            this.dataGridViewHoles.Size = new System.Drawing.Size(143, 166);
            this.dataGridViewHoles.TabIndex = 16;
            this.dataGridViewHoles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewHoles_CellBeginEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewGoals
            // 
            this.dataGridViewGoals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewGoals.Location = new System.Drawing.Point(310, 276);
            this.dataGridViewGoals.Name = "dataGridViewGoals";
            this.dataGridViewGoals.RowTemplate.Height = 24;
            this.dataGridViewGoals.Size = new System.Drawing.Size(143, 166);
            this.dataGridViewGoals.TabIndex = 17;
            this.dataGridViewGoals.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewGoals_CellBeginEdit);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "X";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Y";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // buttonDepth
            // 
            this.buttonDepth.Location = new System.Drawing.Point(489, 67);
            this.buttonDepth.Name = "buttonDepth";
            this.buttonDepth.Size = new System.Drawing.Size(143, 42);
            this.buttonDepth.TabIndex = 21;
            this.buttonDepth.Text = "Поиск в глубину";
            this.buttonDepth.UseVisualStyleBackColor = true;
            this.buttonDepth.Click += new System.EventHandler(this.buttonDepth_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Location = new System.Drawing.Point(559, 410);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(143, 166);
            this.dataGridView1.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "X";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Y";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(556, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Решениe";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(15, 448);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(215, 38);
            this.buttonApply.TabIndex = 24;
            this.buttonApply.Text = "Применить параметры";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(15, 494);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(215, 23);
            this.buttonSave.TabIndex = 25;
            this.buttonSave.Text = "Сохранить пример";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(240, 494);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(213, 23);
            this.buttonOpen.TabIndex = 26;
            this.buttonOpen.Text = "Загрузить пример";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonDepthInfo
            // 
            this.buttonDepthInfo.Location = new System.Drawing.Point(654, 67);
            this.buttonDepthInfo.Name = "buttonDepthInfo";
            this.buttonDepthInfo.Size = new System.Drawing.Size(99, 42);
            this.buttonDepthInfo.TabIndex = 27;
            this.buttonDepthInfo.Text = "Результаты";
            this.buttonDepthInfo.UseVisualStyleBackColor = true;
            this.buttonDepthInfo.Click += new System.EventHandler(this.buttonDepthInfo_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(240, 448);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(211, 38);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonBreadthInfo
            // 
            this.buttonBreadthInfo.Location = new System.Drawing.Point(654, 119);
            this.buttonBreadthInfo.Name = "buttonBreadthInfo";
            this.buttonBreadthInfo.Size = new System.Drawing.Size(99, 42);
            this.buttonBreadthInfo.TabIndex = 30;
            this.buttonBreadthInfo.Text = "Результаты";
            this.buttonBreadthInfo.UseVisualStyleBackColor = true;
            this.buttonBreadthInfo.Click += new System.EventHandler(this.buttonBreadthInfo_Click);
            // 
            // buttonBreadth
            // 
            this.buttonBreadth.Location = new System.Drawing.Point(489, 119);
            this.buttonBreadth.Name = "buttonBreadth";
            this.buttonBreadth.Size = new System.Drawing.Size(143, 42);
            this.buttonBreadth.TabIndex = 29;
            this.buttonBreadth.Text = "Поиск в ширину";
            this.buttonBreadth.UseVisualStyleBackColor = true;
            this.buttonBreadth.Click += new System.EventHandler(this.buttonBreadth_Click);
            // 
            // buttonGradientInfo
            // 
            this.buttonGradientInfo.Location = new System.Drawing.Point(654, 171);
            this.buttonGradientInfo.Name = "buttonGradientInfo";
            this.buttonGradientInfo.Size = new System.Drawing.Size(99, 42);
            this.buttonGradientInfo.TabIndex = 32;
            this.buttonGradientInfo.Text = "Результаты";
            this.buttonGradientInfo.UseVisualStyleBackColor = true;
            this.buttonGradientInfo.Click += new System.EventHandler(this.buttonGradientInfo_Click);
            // 
            // buttonGradient
            // 
            this.buttonGradient.Location = new System.Drawing.Point(489, 171);
            this.buttonGradient.Name = "buttonGradient";
            this.buttonGradient.Size = new System.Drawing.Size(143, 42);
            this.buttonGradient.TabIndex = 31;
            this.buttonGradient.Text = "Поиск по градиенту";
            this.buttonGradient.UseVisualStyleBackColor = true;
            this.buttonGradient.Click += new System.EventHandler(this.buttonGradient_Click);
            // 
            // numericUpDownMaxDepth
            // 
            this.numericUpDownMaxDepth.Location = new System.Drawing.Point(489, 37);
            this.numericUpDownMaxDepth.Maximum = new decimal(new int[] {
            195,
            0,
            0,
            0});
            this.numericUpDownMaxDepth.Name = "numericUpDownMaxDepth";
            this.numericUpDownMaxDepth.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownMaxDepth.TabIndex = 33;
            this.numericUpDownMaxDepth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(211, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Максимальная глубина поиска";
            // 
            // buttonPartialPathInfo
            // 
            this.buttonPartialPathInfo.Location = new System.Drawing.Point(654, 227);
            this.buttonPartialPathInfo.Name = "buttonPartialPathInfo";
            this.buttonPartialPathInfo.Size = new System.Drawing.Size(99, 42);
            this.buttonPartialPathInfo.TabIndex = 36;
            this.buttonPartialPathInfo.Text = "Результаты";
            this.buttonPartialPathInfo.UseVisualStyleBackColor = true;
            this.buttonPartialPathInfo.Click += new System.EventHandler(this.buttonPartialPathInfo_Click);
            // 
            // buttonPartialPath
            // 
            this.buttonPartialPath.Location = new System.Drawing.Point(489, 227);
            this.buttonPartialPath.Name = "buttonPartialPath";
            this.buttonPartialPath.Size = new System.Drawing.Size(143, 42);
            this.buttonPartialPath.TabIndex = 35;
            this.buttonPartialPath.Text = "Локально-углубленный поиск";
            this.buttonPartialPath.UseVisualStyleBackColor = true;
            this.buttonPartialPath.Click += new System.EventHandler(this.buttonPartialPath_Click);
            // 
            // numericUpDownLocaDepth
            // 
            this.numericUpDownLocaDepth.Location = new System.Drawing.Point(654, 275);
            this.numericUpDownLocaDepth.Maximum = new decimal(new int[] {
            195,
            0,
            0,
            0});
            this.numericUpDownLocaDepth.Name = "numericUpDownLocaDepth";
            this.numericUpDownLocaDepth.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownLocaDepth.TabIndex = 37;
            this.numericUpDownLocaDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(489, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Локальное углубление";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 588);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDownLocaDepth);
            this.Controls.Add(this.buttonPartialPathInfo);
            this.Controls.Add(this.buttonPartialPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownMaxDepth);
            this.Controls.Add(this.buttonGradientInfo);
            this.Controls.Add(this.buttonGradient);
            this.Controls.Add(this.buttonBreadthInfo);
            this.Controls.Add(this.buttonBreadth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDepthInfo);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonDepth);
            this.Controls.Add(this.dataGridViewGoals);
            this.Controls.Add(this.dataGridViewHoles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewMirrors);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Lasers";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidhField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightField)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLaserPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLaserPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMirrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocaDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownWidhField;
        private System.Windows.Forms.NumericUpDown numericUpDownHeightField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton135;
        private System.Windows.Forms.RadioButton radioButton315;
        private System.Windows.Forms.RadioButton radioButton225;
        private System.Windows.Forms.RadioButton radioButton45;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownLaserPosY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownLaserPosX;
        private System.Windows.Forms.DataGridView dataGridViewMirrors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dataGridViewHoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridViewGoals;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button buttonDepth;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonDepthInfo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonBreadthInfo;
        private System.Windows.Forms.Button buttonBreadth;
        private System.Windows.Forms.Button buttonGradientInfo;
        private System.Windows.Forms.Button buttonGradient;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxDepth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonPartialPathInfo;
        private System.Windows.Forms.Button buttonPartialPath;
        private System.Windows.Forms.NumericUpDown numericUpDownLocaDepth;
        private System.Windows.Forms.Label label11;
    }
}

