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
    public partial class AutoSimplecsSolution_win : Form
    {
        private Simplecs simplecs;

        public AutoSimplecsSolution_win(Main_win main_win)
        {
            simplecs = new Simplecs(main_win.simplecs);
            simplecs.init_table();

            while ((simplecs.execution_code != 0) && (simplecs.execution_code != 1) 
                && (simplecs.execution_code != 2))
            {
                simplecs.simplecs_method();
            }

            InitializeComponent();
            InitializeTableSimlecs(simplecs.execution_code);
        }
        
        //рисует таблицу //дописать
        private void InitializeTableSimlecs(int code_text)
        {
            Color c_bi = Color.FromArgb(238, 232, 170); //цвет для Bi
            Color c_xi = Color.FromArgb(95, 158, 160);//цвет для X - свободных
            Color c_ai = Color.FromArgb(176, 196, 222);//цвет для альфа и базисных Х
            Color c_pi = Color.FromArgb(255, 228, 196);//цвет для Pi
            int x = 0;
            int y = 0;
            Label[,] table = new Label[simplecs.s_row + 2, simplecs.s_column + 1];
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
            table[x, y] = cell_table(x, y, "Bi", "0."+y.ToString(), c_bi);
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
                    y++;
                    table[x, y] = cell_table(x, y,
                        simplecs.table[i, j].ToString(),
                        x.ToString() + "." + y.ToString(), c_ai);
                    panel1.Controls.Add(table[x, y]);
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
            for(int i = 0; i < simplecs.index_free.Length - 1; i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
