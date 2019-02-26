using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Linear_programm_task
{
    public partial class StepSimplecsSolution_win : Form
    {
        private Simplecs[] history = new Simplecs[50];//история шагов
        private Simplecs simplecs;
        private bool flag = false;//для кнопки продолжения исскуственного базиса
        Control[,] table;//таблица элементов вывода
        private string[] function_or;

        public StepSimplecsSolution_win(Main_win main_win)
        {
            simplecs = new Simplecs(main_win.simplecs);//инициализация неких элементов после этого происходит, от этого и ошибка
            simplecs.init_table();
            function_or = main_win.function_or;

            InitializeComponent();
            btn_back.Enabled = false;
            InitializeTableSimlecs(simplecs.execution_code);
        }

        //рисует таблицу
        private void InitializeTableSimlecs(int code_text)
        {
            //x, y в данной функции координаты в рисуемой таблице
            //i, j в данной функции координаты эл-ов симпл. таблицы
            table = new Control[simplecs.s_row + 1, simplecs.s_column + 1];
            Color c_bi = Color.FromArgb(238, 232, 170);//цвет для Bi
            Color c_xi = Color.FromArgb(95, 158, 160);//цвет для X - свободных
            Color c_ai = Color.FromArgb(176, 196, 222);//цвет для альфа и базисных Х
            Color c_pi = Color.FromArgb(255, 228, 196);//цвет для Pi
            int x = 0;
            int y = 0;
            //прорисовка первой строки
            table[0, 0] = cell_table(x, y, "X^" + simplecs.iteration.ToString(), "0.0", c_xi);
            panel1.Controls.Add(table[x, y]);
            for (int j = 0; j < simplecs.index_free.Length - 1; j++)
            {
                y++;
                table[x, y] = cell_table(x, y,
                    "X " + simplecs.index_free[j].ToString(),
                    "0." + y.ToString(), c_xi);
                panel1.Controls.Add(table[x, y]);
            }
            y++;
            table[x, y] = cell_table(x, y, "Bi", "0." + y.ToString(), c_bi);
            panel1.Controls.Add(table[x, y]);
            //прорисовка от 2 до m - 1 строки, m - общее количество строк в таблице
            for (int i = 0; i < simplecs.s_row - 1; i++)
            {
                x++;
                y = 0;
                table[x, y] = cell_table(x, y,
                    "X " + simplecs.index_basic[i].ToString(),
                    x.ToString() + ".0", c_xi);
                panel1.Controls.Add(table[x, y]);
                for (int j = 0; j < simplecs.s_column - 1; j++)
                {
                    if (simplecs.table[i, j].p == 1 && code_text != 0 && code_text != 1 && code_text != 2)
                    {
                        y++;
                        if ((simplecs.i_min == i) && (simplecs.j_min == j))
                        {
                            table[x, y] = cellTable(x, y,
                                simplecs.table[i, j].ToString(),
                                x.ToString() + "." + y.ToString(), true);
                        } else
                        {
                            table[x, y] = cellTable(x, y,
                                simplecs.table[i, j].ToString(),
                                x.ToString() + "." + y.ToString(), false);
                        }
                        panel1.Controls.Add(table[x, y]);
                    }
                    else
                    {
                        y++;
                        table[x, y] = cell_table(x, y,
                            simplecs.table[i, j].ToString(),
                            x.ToString() + "." + y.ToString(), c_ai);
                        panel1.Controls.Add(table[x, y]);
                    }
                }
                y++;
                table[x, y] = cell_table(x, y,
                    simplecs.table[i, simplecs.s_column - 1].ToString(),
                    x.ToString() + "." + y.ToString(), c_bi);
                panel1.Controls.Add(table[x, y]);
            }
            x++;
            y = 0;
            table[x, y] = cell_table(x, y, "Pi", x.ToString() + ".0", c_pi);
            panel1.Controls.Add(table[x, y]);
            //прорисовка последней строки
            for (int i = 0; i < simplecs.index_free.Length - 1; i++)
            {
                y++;
                table[x, y] = cell_table(x, y,
                    simplecs.table[simplecs.s_row - 1, i].ToString(),
                    x.ToString() + "." + y.ToString(), c_pi);
                panel1.Controls.Add(table[x, y]);
            }
            y++;
            int l = simplecs.index_free.Length - 1;
            Rational p = new Rational(simplecs.table[simplecs.s_row - 1, l]);
            table[x, y] = cell_table(x, y, p.ToString(), x.ToString() + "." + y.ToString(), c_pi);
            panel1.Controls.Add(table[x, y]);
            if (!flag && code_text == 0)
            {
                code_text = 4;
                label1.Text = "Первый шаг выполнен успешно!";
                flag = true;
                btn_next.Enabled = true;
            }
            if (code_text == 0 && flag) { label1.Text = "Найден ответ"; btn_next.Enabled = false; }
            if (code_text == 1) { label1.Text = "Неограничена"; btn_next.Enabled = false; }
            if (code_text == 2) { label1.Text = "Отрицательная точка"; btn_next.Enabled = false; }
            if (code_text == 3) label1.Text = "Шаг пройден";
        }
        //создает клетку в таблице, Label
        private Label cell_table(int x, int y, string text, string name, Color color)
        {
            Label cell = new Label();
            cell.BorderStyle = BorderStyle.FixedSingle;
            cell.BackColor = color;
            cell.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            cell.Location = new Point(y * 120, x * 80);
            cell.Margin = new Padding(0);
            cell.MaximumSize = new Size(120, 80);
            cell.MinimumSize = new Size(120, 80);
            cell.Name = Name;
            cell.Size = new Size(120, 80);
            cell.TabIndex = 0;
            cell.Text = text;
            cell.TextAlign = ContentAlignment.MiddleCenter;
            return cell;
        }
        //создает клетку в таблице, CheckBox
        private CheckBox cellTable(int x, int y, string text, string name, bool check) {
            CheckBox cell = new CheckBox();
            cell.Appearance = Appearance.Button;
            cell.AutoSize = true;
            cell.BackColor = Color.FromArgb(176, 196, 222);
            cell.FlatAppearance.BorderColor = Color.OrangeRed;
            cell.FlatAppearance.CheckedBackColor = Color.FromArgb(152, 251, 152);
            cell.FlatStyle = FlatStyle.Flat;
            cell.Location = new Point(y * 120, x * 80);//настройка позиции
            cell.Name = name;
            cell.Size = new Size(120, 80);
            cell.Font = new Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            cell.TabIndex = 0;
            cell.Text = text;
            cell.Checked = check;
            cell.UseVisualStyleBackColor = false;
            cell.MaximumSize = new Size(120, 80);
            cell.MinimumSize = new Size(120, 80);
            cell.CheckAlign = ContentAlignment.TopLeft;
            cell.CheckedChanged += new EventHandler(this.click_box);
            return cell;
        }

        #region обработчики
        private void click_box(Object sender, EventArgs e)
        {
            int i = Int32.Parse((sender as CheckBox).Name.Split('.')[0]) - 1;
            int j = Int32.Parse((sender as CheckBox).Name.Split('.')[1]) - 1;

            if ((simplecs.i_min != i) || (simplecs.j_min != j))
            {
                int x = simplecs.i_min + 1;
                int y = simplecs.j_min + 1;

                (sender as CheckBox).Checked = true;
                (sender as CheckBox).Parent.Controls.Remove(table[x, y]);
                table[x, y] = cellTable(x, y,
                    simplecs.table[x - 1, y - 1].ToString(),
                    x.ToString() + "." + y.ToString(), false);
                (sender as CheckBox).Parent.Controls.Add(table[x, y]);

                simplecs.i_min = Int32.Parse((sender as CheckBox).Name.Split('.')[0]) - 1;
                simplecs.j_min = Int32.Parse((sender as CheckBox).Name.Split('.')[1]) - 1;
                panel1.Update();
            } else
            {
                (sender as CheckBox).Checked = true;
                panel1.Update();
            }
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (simplecs.execution_code != 0)
            {
                btn_back.Enabled = true;
                history[simplecs.iteration] = new Simplecs(simplecs);
                simplecs.simplecs_method();
                if ((simplecs.execution_code == 0) || (simplecs.execution_code == 1) ||
                    (simplecs.execution_code == 2)) btn_next.Enabled = false;
                panel1.Controls.Clear();

                InitializeTableSimlecs(simplecs.execution_code);
            }
            else
            {
                btn_back.Enabled = true;
                history[simplecs.iteration] = new Simplecs(simplecs);
                simplecs = new Simplecs(simplecs.artificial_base(simplecs, function_or));
                if (!simplecs.check_Pi()) simplecs.execution_code = 0;//решение найдено
                if (simplecs.check_limitation()) simplecs.execution_code = 1;//неограничена
                simplecs.search_supporting();
                simplecs.applicants_supporting();
                panel1.Controls.Clear();

                InitializeTableSimlecs(simplecs.execution_code);
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_next.Enabled = true;
            if (simplecs.iteration - 1 == 0) btn_back.Enabled = false;
            simplecs = new Simplecs(history[simplecs.iteration - 1]);
            panel1.Controls.Clear();
            if (simplecs.execution_code == 0) { flag = false; InitializeTableSimlecs(3); }
            else InitializeTableSimlecs(simplecs.execution_code);
        }
        private void btn_click_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
        #endregion
    }
}
