namespace Linear_programm_task
{
    partial class Main_win
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
            this.matrix_table = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_column = new System.Windows.Forms.NumericUpDown();
            this.m_row = new System.Windows.Forms.NumericUpDown();
            this.btn_decide = new System.Windows.Forms.Button();
            this.function = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.free_number = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_graphic = new System.Windows.Forms.RadioButton();
            this.m_simplecs = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_step = new System.Windows.Forms.RadioButton();
            this.m_auto = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_programBasic = new System.Windows.Forms.RadioButton();
            this.m_userBasic = new System.Windows.Forms.RadioButton();
            this.m_myBasic = new System.Windows.Forms.MaskedTextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_saveFile = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.matrix_table)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_column)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.function)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.free_number)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // matrix_table
            // 
            this.matrix_table.AccessibleDescription = "";
            this.matrix_table.AllowUserToAddRows = false;
            this.matrix_table.AllowUserToDeleteRows = false;
            this.matrix_table.AllowUserToResizeColumns = false;
            this.matrix_table.AllowUserToResizeRows = false;
            this.matrix_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matrix_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.matrix_table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.matrix_table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.matrix_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrix_table.ColumnHeadersVisible = false;
            this.matrix_table.GridColor = System.Drawing.SystemColors.ControlLight;
            this.matrix_table.Location = new System.Drawing.Point(12, 152);
            this.matrix_table.MultiSelect = false;
            this.matrix_table.Name = "matrix_table";
            this.matrix_table.RowHeadersVisible = false;
            this.matrix_table.ShowCellErrors = false;
            this.matrix_table.ShowCellToolTips = false;
            this.matrix_table.ShowEditingIcon = false;
            this.matrix_table.ShowRowErrors = false;
            this.matrix_table.Size = new System.Drawing.Size(452, 340);
            this.matrix_table.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_column);
            this.groupBox1.Controls.Add(this.m_row);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размерность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Столбцы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Строки";
            // 
            // m_column
            // 
            this.m_column.Location = new System.Drawing.Point(67, 46);
            this.m_column.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.m_column.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_column.Name = "m_column";
            this.m_column.Size = new System.Drawing.Size(36, 20);
            this.m_column.TabIndex = 1;
            this.m_column.TabStop = false;
            this.m_column.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_column.ValueChanged += new System.EventHandler(this.m_column_ValueChanged);
            // 
            // m_row
            // 
            this.m_row.Location = new System.Drawing.Point(67, 21);
            this.m_row.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.m_row.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_row.Name = "m_row";
            this.m_row.Size = new System.Drawing.Size(36, 20);
            this.m_row.TabIndex = 0;
            this.m_row.TabStop = false;
            this.m_row.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_row.ValueChanged += new System.EventHandler(this.m_row_ValueChanged);
            // 
            // btn_decide
            // 
            this.btn_decide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_decide.Location = new System.Drawing.Point(601, 297);
            this.btn_decide.Name = "btn_decide";
            this.btn_decide.Size = new System.Drawing.Size(154, 23);
            this.btn_decide.TabIndex = 2;
            this.btn_decide.TabStop = false;
            this.btn_decide.Text = "Решить задачу";
            this.btn_decide.UseVisualStyleBackColor = true;
            this.btn_decide.Click += new System.EventHandler(this.btn_decide_Click);
            // 
            // function
            // 
            this.function.AllowUserToAddRows = false;
            this.function.AllowUserToDeleteRows = false;
            this.function.AllowUserToResizeColumns = false;
            this.function.AllowUserToResizeRows = false;
            this.function.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.function.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.function.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.function.BackgroundColor = System.Drawing.SystemColors.Control;
            this.function.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.function.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.function.ColumnHeadersVisible = false;
            this.function.GridColor = System.Drawing.SystemColors.ControlLight;
            this.function.Location = new System.Drawing.Point(12, 111);
            this.function.MultiSelect = false;
            this.function.Name = "function";
            this.function.RowHeadersVisible = false;
            this.function.ShowCellErrors = false;
            this.function.ShowCellToolTips = false;
            this.function.ShowEditingIcon = false;
            this.function.ShowRowErrors = false;
            this.function.Size = new System.Drawing.Size(520, 22);
            this.function.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Коэффициенты функции";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Коэффициенты ограничений";
            // 
            // free_number
            // 
            this.free_number.AccessibleDescription = "";
            this.free_number.AllowUserToAddRows = false;
            this.free_number.AllowUserToDeleteRows = false;
            this.free_number.AllowUserToResizeColumns = false;
            this.free_number.AllowUserToResizeRows = false;
            this.free_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.free_number.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.free_number.BackgroundColor = System.Drawing.SystemColors.Control;
            this.free_number.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.free_number.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.free_number.ColumnHeadersVisible = false;
            this.free_number.GridColor = System.Drawing.SystemColors.ControlLight;
            this.free_number.Location = new System.Drawing.Point(532, 152);
            this.free_number.MultiSelect = false;
            this.free_number.Name = "free_number";
            this.free_number.RowHeadersVisible = false;
            this.free_number.ShowCellErrors = false;
            this.free_number.ShowCellToolTips = false;
            this.free_number.ShowEditingIcon = false;
            this.free_number.ShowRowErrors = false;
            this.free_number.Size = new System.Drawing.Size(63, 340);
            this.free_number.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "———>MIN";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(466, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 340);
            this.panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.m_graphic);
            this.groupBox2.Controls.Add(this.m_simplecs);
            this.groupBox2.Location = new System.Drawing.Point(141, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 76);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Метод";
            // 
            // m_graphic
            // 
            this.m_graphic.AutoSize = true;
            this.m_graphic.Enabled = false;
            this.m_graphic.Location = new System.Drawing.Point(6, 50);
            this.m_graphic.Name = "m_graphic";
            this.m_graphic.Size = new System.Drawing.Size(157, 17);
            this.m_graphic.TabIndex = 1;
            this.m_graphic.Text = "Графический двухмерный";
            this.m_graphic.UseVisualStyleBackColor = true;
            this.m_graphic.CheckedChanged += new System.EventHandler(this.m_graphic_CheckedChanged);
            // 
            // m_simplecs
            // 
            this.m_simplecs.AutoSize = true;
            this.m_simplecs.Checked = true;
            this.m_simplecs.Location = new System.Drawing.Point(6, 22);
            this.m_simplecs.Name = "m_simplecs";
            this.m_simplecs.Size = new System.Drawing.Size(110, 17);
            this.m_simplecs.TabIndex = 0;
            this.m_simplecs.TabStop = true;
            this.m_simplecs.Text = "Симплекс метод";
            this.m_simplecs.UseVisualStyleBackColor = true;
            this.m_simplecs.CheckedChanged += new System.EventHandler(this.m_simplecs_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.m_step);
            this.groupBox3.Controls.Add(this.m_auto);
            this.groupBox3.Location = new System.Drawing.Point(316, 12);
            this.groupBox3.MinimumSize = new System.Drawing.Size(169, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 76);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Режим";
            // 
            // m_step
            // 
            this.m_step.AutoSize = true;
            this.m_step.Location = new System.Drawing.Point(6, 49);
            this.m_step.Name = "m_step";
            this.m_step.Size = new System.Drawing.Size(84, 17);
            this.m_step.TabIndex = 1;
            this.m_step.Text = "Пошаговый";
            this.m_step.UseVisualStyleBackColor = true;
            // 
            // m_auto
            // 
            this.m_auto.AutoSize = true;
            this.m_auto.Checked = true;
            this.m_auto.Location = new System.Drawing.Point(6, 22);
            this.m_auto.Name = "m_auto";
            this.m_auto.Size = new System.Drawing.Size(109, 17);
            this.m_auto.TabIndex = 0;
            this.m_auto.TabStop = true;
            this.m_auto.Text = "Автоматический";
            this.m_auto.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.m_programBasic);
            this.groupBox4.Controls.Add(this.m_userBasic);
            this.groupBox4.Controls.Add(this.m_myBasic);
            this.groupBox4.Location = new System.Drawing.Point(491, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 76);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Базис";
            // 
            // m_programBasic
            // 
            this.m_programBasic.AutoSize = true;
            this.m_programBasic.Location = new System.Drawing.Point(99, 23);
            this.m_programBasic.Name = "m_programBasic";
            this.m_programBasic.Size = new System.Drawing.Size(105, 17);
            this.m_programBasic.TabIndex = 8;
            this.m_programBasic.Text = "Искусственный";
            this.m_programBasic.UseVisualStyleBackColor = true;
            this.m_programBasic.CheckedChanged += new System.EventHandler(this.m_programBasic_CheckedChanged);
            // 
            // m_userBasic
            // 
            this.m_userBasic.AutoSize = true;
            this.m_userBasic.Checked = true;
            this.m_userBasic.Location = new System.Drawing.Point(14, 22);
            this.m_userBasic.Name = "m_userBasic";
            this.m_userBasic.Size = new System.Drawing.Size(76, 17);
            this.m_userBasic.TabIndex = 7;
            this.m_userBasic.TabStop = true;
            this.m_userBasic.Text = "Заданный";
            this.m_userBasic.UseVisualStyleBackColor = true;
            this.m_userBasic.CheckedChanged += new System.EventHandler(this.m_userBasic_CheckedChanged);
            // 
            // m_myBasic
            // 
            this.m_myBasic.Location = new System.Drawing.Point(10, 43);
            this.m_myBasic.Name = "m_myBasic";
            this.m_myBasic.PromptChar = ',';
            this.m_myBasic.ResetOnSpace = false;
            this.m_myBasic.Size = new System.Drawing.Size(248, 20);
            this.m_myBasic.TabIndex = 4;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(601, 335);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(154, 23);
            this.btn_close.TabIndex = 12;
            this.btn_close.TabStop = false;
            this.btn_close.Text = "Закрыть";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_saveFile
            // 
            this.btn_saveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveFile.Location = new System.Drawing.Point(601, 259);
            this.btn_saveFile.Name = "btn_saveFile";
            this.btn_saveFile.Size = new System.Drawing.Size(154, 23);
            this.btn_saveFile.TabIndex = 13;
            this.btn_saveFile.TabStop = false;
            this.btn_saveFile.Text = "Сохранить в файл (txt)";
            this.btn_saveFile.UseVisualStyleBackColor = true;
            this.btn_saveFile.Click += new System.EventHandler(this.btn_saveFile_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.Location = new System.Drawing.Point(601, 221);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(154, 23);
            this.btn_openFile.TabIndex = 14;
            this.btn_openFile.TabStop = false;
            this.btn_openFile.Text = "Открыть файл (txt)";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.txt)|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "(*.txt)|*.txt";
            // 
            // Main_win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(767, 495);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_saveFile);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.free_number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.function);
            this.Controls.Add(this.btn_decide);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.matrix_table);
            this.MinimumSize = new System.Drawing.Size(775, 525);
            this.Name = "Main_win";
            this.Text = "Задача линейного программирования";
            ((System.ComponentModel.ISupportInitialize)(this.matrix_table)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_column)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.function)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.free_number)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView matrix_table;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown m_column;
        private System.Windows.Forms.NumericUpDown m_row;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btn_decide;
        private System.Windows.Forms.DataGridView function;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView free_number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MaskedTextBox m_myBasic;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_saveFile;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.RadioButton m_graphic;
        private System.Windows.Forms.RadioButton m_simplecs;
        private System.Windows.Forms.RadioButton m_step;
        private System.Windows.Forms.RadioButton m_auto;
        private System.Windows.Forms.RadioButton m_programBasic;
        private System.Windows.Forms.RadioButton m_userBasic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

