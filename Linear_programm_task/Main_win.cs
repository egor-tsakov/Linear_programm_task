using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Linear_programm_task
{
    public partial class Main_win : Form
    {
        public ComboBox[] signs = new ComboBox[16];
        private Simplecs mySimplecs;
        public string[] function_or;
        internal Simplecs simplecs { get => mySimplecs; set => mySimplecs = value; }

        public Main_win()
        {
            InitializeComponent();
            InitializeTable_andBox();
        }

        #region Инициализация динамических элементов
        private void InitializeTable_andBox()
        {
            matrix_table.RowTemplate.Height = 21;
            free_number.RowTemplate.Height = 21;
            matrix_table.RowCount = 4;
            matrix_table.ColumnCount = 3;
            matrix_table.Update();
            function.RowCount = 1;
            function.ColumnCount = 4;
            function.Update();
            free_number.RowCount = 4;
            free_number.ColumnCount = 1;
            for (int i = 0; i < 4; i++)
            {
                signs[i] = MyComboBox(i);
                panel1.Controls.Add(signs[i]);
            }
            m_myBasic.Mask = "0,0,0";
        }
        private void InitializeBox()
        {
            if (signs[(int)m_row.Value - 1] == null)
            {
                signs[(int)m_row.Value - 1] = MyComboBox((int)m_row.Value - 1);
                panel1.Controls.Add(signs[(int)m_row.Value - 1]);
            }
            else
            {
                panel1.Controls.Remove(signs[(int)m_row.Value]);
                signs[(int)m_row.Value] = null;
            }
            panel1.Update();
        }
        private ComboBox MyComboBox(int i)
        {
            ComboBox my = new ComboBox();
            my = new ComboBox();
            my.FormattingEnabled = true;
            my.Items.AddRange(new object[] { "=", "<=", ">=" });
            my.Location = new Point(8, 1 + i * 21);
            my.Name = i.ToString();
            my.Size = new Size(47, 18);
            my.MinimumSize = new Size(47, 18);
            my.MaximumSize = new Size(47, 18);
            my.TabIndex = 8;
            my.Text = "=";
            if (m_simplecs.Checked) my.Enabled = false;
            return my;
        }
        #endregion
        #region Обработчики
        
        //настройка строк
        private void m_row_ValueChanged(object sender, EventArgs e)
        {
            matrix_table.RowCount = (int)m_row.Value;
            matrix_table.ColumnCount = (int)m_column.Value - 1;
            free_number.RowCount = (int)m_row.Value;
            free_number.Update();
            matrix_table.Update();
            InitializeBox();
        }
        
        //настройка столбцов
        private void m_column_ValueChanged(object sender, EventArgs e)
        {
            matrix_table.RowCount = (int)m_row.Value;
            matrix_table.ColumnCount = (int)m_column.Value - 1;
            function.ColumnCount = (int)m_column.Value;
            matrix_table.Update();
            function.Update();
            string str = "0";
            for (int i = 0; i < (int)m_column.Value - 2; i++) str += ",0";
            m_myBasic.Mask = str;
        }
        
        //нажатие кнопок
        private void btn_decide_Click(object sender, EventArgs e)
        {
            //для исскуственного базиса
            if (m_userBasic.Checked)
            {
                for (int i = 0; i < (int)m_column.Value; i++)
                    if (i < (int)m_column.Value - (int)m_row.Value)
                        function.Rows[0].Cells[i].Value = "0";
                    else function.Rows[0].Cells[i].Value = "1";
                string m = (string)function.Rows[0].Cells[(int)m_column.Value - 1].Value;
                function.Rows[0].Cells[(int)m_column.Value - 1].Value = 
                    function.Rows[0].Cells[(int)m_column.Value - (int)m_row.Value - 1].Value;
                function.Rows[0].Cells[(int)m_column.Value - (int)m_row.Value - 1].Value = m;
            }

            if ((m_simplecs.Checked))
            {
                if (check_data() && check_coeff(matrix_table, (int)m_row.Value, (int)m_column.Value) &&
                    check_coeff(function, 1, (int)m_column.Value))
                {
                    simplecs = new Simplecs((int)m_row.Value, (int)m_column.Value);
                    {
                        for (int i = 0; i < (int)m_column.Value; i++)
                            simplecs.function[i] = new Rational((string)function.Rows[0].Cells[i].Value);
                        for (int i = 0; i < (int)m_row.Value; i++)
                        {
                            for (int j = 0; j < (int)m_column.Value - 1; j++)
                                simplecs.matrix[i, j] = new Rational((string)matrix_table.Rows[i].Cells[j].Value);
                            int last = (int)m_column.Value - 1;
                            simplecs.matrix[i, last] = new Rational((string)free_number.Rows[i].Cells[0].Value);
                        }
                        if (check_rang_matrix())
                        {
                            if ((check_basic()) && (simplecs.Method_gaussa(m_myBasic.Text.Split())))
                            {
                                option_solution();
                            }
                            else
                            {
                                MessageBox.Show("Заданный базис не подходит",
                                    "Неверный базис", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            try
            {
                string[] text;
                string[] str;
                string str1 = "0";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int row;
                    text = File.ReadAllLines(openFileDialog1.FileName);
                    if (!m_userBasic.Checked)
                    {
                        str = text[0].Split();
                        row = Int32.Parse(str[0]);
                        m_row.Value = Int32.Parse(str[0]);
                        m_column.Value = Int32.Parse(str[1]) + row;
                        for (int i = 0; i < (int)m_column.Value - 2; i++) str1 += ",0";
                        m_myBasic.Mask = str1;
                        str1 = "0";
                        for (int i = 0; i < (int)m_column.Value - 2 - row; i++) str1 += " 0";
                        for (int i = 0; i < row; i++) str1 += " 1";
                        m_myBasic.Text = str1;
                        str = text[1].Split();
                        function_or = str;
                        //for (int i = 0; i < (int)m_column.Value - row; i++)
                        //    simplecs.function[i] = new Rational("0");
                        //for (int i = (int)m_column.Value - row; i < (int)m_column.Value; i++)
                        //    simplecs.function[i] = new Rational("1");
                        for (int i = 0; i < (int)m_column.Value; i++)
                            if (i < (int)m_column.Value - row)
                                function.Rows[0].Cells[i].Value = str[i];
                            else function.Rows[0].Cells[i].Value = "0";
                        string m = (string)function.Rows[0].Cells[(int)m_column.Value - 1].Value;
                        function.Rows[0].Cells[(int)m_column.Value - 1].Value =
                            function.Rows[0].Cells[(int)m_column.Value - (int)m_row.Value - 1].Value;
                        function.Rows[0].Cells[(int)m_column.Value - (int)m_row.Value - 1].Value = m;
                        for (int i = 0; i < (int)m_row.Value; i++)
                        {
                            str = text[i + 2].Split();
                            for (int j = 0; j < (int)m_column.Value; j++)
                            {
                                if (j == (int)m_column.Value - row - 1) free_number.Rows[i].Cells[0].Value = str[j];
                                else
                                {
                                    if (j >= (int)m_column.Value - row)
                                        if (j - i == (int)m_column.Value - row) matrix_table.Rows[i].Cells[j - 1].Value = "1";
                                        else matrix_table.Rows[i].Cells[j - 1].Value = "0";
                                    else matrix_table.Rows[i].Cells[j].Value = str[j];
                                }
                            }
                        }
                    }
                    else
                    {
                        str = text[0].Split();
                        m_row.Value = Int32.Parse(str[0]);
                        m_column.Value = Int32.Parse(str[1]);
                        for (int i = 0; i < (int)m_column.Value - 2; i++) str1 += ",0";
                        m_myBasic.Mask = str1;
                        simplecs = new Simplecs((int)m_row.Value, (int)m_column.Value);
                        if (m_userBasic.Checked)
                            m_myBasic.Text = text[1];
                        str = text[2].Split();
                        for (int i = 0; i < (int)m_column.Value; i++)
                            function.Rows[0].Cells[i].Value = str[i];
                        for (int i = 0; i < (int)m_row.Value; i++)
                        {
                            str = text[i + 3].Split();
                            for (int j = 0; j < (int)m_column.Value; j++)
                                if (j == (int)m_column.Value - 1) free_number.Rows[i].Cells[0].Value = str[j];
                                else matrix_table.Rows[i].Cells[j].Value = str[j];
                        }
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Неверный набор данных файла",
                    "Ошибка чтения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Неверный набор данных файла",
                    "Ошибка чтения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_saveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string text = "";
                text += m_row.Value + " " + m_column.Value + "\r\n";
                if (m_userBasic.Checked) text += m_myBasic.Text + "\r\n";
                for (int i = 0; i < (int)m_column.Value; i++)
                    text += function.Rows[0].Cells[i].Value + " ";
                text += "\r\n";
                for (int i = 0; i < (int)m_row.Value; i++)
                {
                    for (int j = 0; j < (int)m_column.Value - 1; j++)
                        text += matrix_table.Rows[i].Cells[j].Value + " ";
                    text += free_number.Rows[i].Cells[0].Value + "\r\n";
                }
                File.WriteAllText(saveFileDialog1.FileName, text);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void option_solution()
        {
            if (m_simplecs.Checked)
            {
                if (m_auto.Checked)
                {
                    if (m_userBasic.Checked)
                    {
                        //автоматический режим, заданный базис, симплекс метода
                        AutoSimplecsSolution_win win = new AutoSimplecsSolution_win((Main_win)Form.ActiveForm);
                        win.ShowDialog();
                    } else
                    {
                        //автоматический режим, искусственный базис, симплекс метода
                    }
                } else
                {
                    if (m_userBasic.Checked)
                    {
                        //пошаговый режим, заданный базис, симплекс метода
                        StepSimplecsSolution_win win = new StepSimplecsSolution_win((Main_win)Form.ActiveForm);
                        win.ShowDialog();
                    } else
                    {
                        //пошаговый режим, искусственный базис, симплекс метода
                        StepSimplecsSolution_win win = new StepSimplecsSolution_win((Main_win)Form.ActiveForm);
                        win.ShowDialog();
                    }
                }
            } else
            {
                //автоматический режим, заданный базис, графического метода
            }
        }
        
        //флаги (radion buttons)
        private void m_graphic_CheckedChanged(object sender, EventArgs e)
        {
            m_auto.Checked = true;
            m_userBasic.Checked = true;
            m_programBasic.Enabled = false;
            groupBox3.Enabled = false;
            for (int i = 0; i < m_row.Value; i++)
                signs[i].Enabled = true;
        }

        private void m_simplecs_CheckedChanged(object sender, EventArgs e)
        {
            m_programBasic.Enabled = true;
            groupBox3.Enabled = true;
            for (int i = 0; i < m_row.Value; i++)
            {
                signs[i].Text = "=";
                signs[i].Enabled = false;
            }
        }

        private void m_programBasic_CheckedChanged(object sender, EventArgs e)
        {
            m_simplecs.Checked = true;
            groupBox2.Enabled = false;
            m_myBasic.Clear();
            m_myBasic.Enabled = false;
        }

        private void m_userBasic_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            m_myBasic.Enabled = true;
        }
        #endregion
        #region Проверка коррекности ввода
        //Проверки коррекности данных
        private bool check_data()
        {
            if (m_column.Value <= m_row.Value)
            {
                MessageBox.Show("Строк должно быть меньше столбцов", 
                    "Неверная размерность", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool check_coeff(DataGridView matrix, int row, int column)
        {
            char[] separator = { '/', '.', ',', ' ' };
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    string number = (string)matrix.Rows[i].Cells[j].Value;
                    if (number == null)
                    {
                        MessageBox.Show("Заполните все ячейки",
                            "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    string[] numbers = number.Split(separator);
                    if (number.Split(separator).Length > 2)
                    {
                        MessageBox.Show("Неверный формат",
                            "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    } else
                    {
                        for (int k = 0; k < numbers.Length; k++)
                            if (numbers[k] == "")
                            {
                                MessageBox.Show("Лишние пробелы или неверный формат",
                                    "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                    }
                }
                string number_last = (string)free_number.Rows[i].Cells[0].Value;
                if (number_last == null)
                {
                    MessageBox.Show("Заполните все ячейки",
                        "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string[] numbers_last = number_last.Split(separator);
                if (number_last.Split(separator).Length > 2)
                {
                    MessageBox.Show("Неверный формат",
                        "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    for (int k = 0; k < numbers_last.Length; k++)
                        if (numbers_last[k] == "")
                        {
                            MessageBox.Show("Лишние пробелы или неверный формат",
                                "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                }
            }
            return true;
        }

        private bool check_basic()
        {
            int k = 0;
            int s = 0;
            string[] str = m_myBasic.Text.Split();
            for(int i = 0; i < (int)m_column.Value - 1; i++)
            {
                if ((str[i] == "1") || (str[i] == "0")) k++;
                if (str[i] == "1") s++;
            }
            if ((k == (int)m_column.Value) || (s == (int)m_row.Value)) return true;
            return false;
        }
        private bool check_rang_matrix()
        {
            if (simplecs.check_rang()) return true;
            MessageBox.Show("Имеются одинаковые строки, ранг матрицы меньше числа строк", 
                "Невыполнимо условие", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion
    }
}
