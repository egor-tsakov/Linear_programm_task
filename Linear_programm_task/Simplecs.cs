using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linear_programm_task
{
    class Simplecs
    {
        public Rational[,] matrix;//матрица коэффициентов ограничений
        public int row; //строк в матрице
        public int column;//столбцов в матрице
        public int[] index;//порядок индексов переменной X
        public Rational[] function;//коэффициенты функции

        public Rational[,] table;//симплекс таблица
        public int s_row;//строк в таблице
        public int s_column;//столбцов в таблице
        public int[] index_basic;//индексы базисных Х
        public int[] index_free;//индексы свободных Х
        public int iteration;

        public int i_min; //индекс строки опорного эл-та
        public int j_min; //индекс столбца опорного эл-та
        public int execution_code; //код завершения симплекс хода

        //первая инициализация (матрица коэффициентов)
        public Simplecs(int m_row, int m_column)
        {
            this.column = m_column;
            this.row = m_row;
            this.matrix = new Rational[this.row, this.column];
            this.function = new Rational[column];
            this.index = new int[this.column];
            for (int i = 0; i < this.column; i++) index[i] = i + 1;
        }
        public Simplecs(Simplecs old)
        {
            this.row = (int)old.row;
            this.column = (int)old.column;
            this.matrix = new Rational[this.row, this.column];
            this.function = new Rational[column];
            this.index = new int[this.column];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    this.matrix[i, j] = (Rational)old.matrix[i, j];
            old.index.CopyTo(this.index, 0);
            old.function.CopyTo(this.function, 0);

            this.s_row = (int)old.s_row;
            this.s_column = (int)old.s_column;
            table = new Rational[s_row, s_column];
            index_basic = new int[s_row];
            index_free = new int[s_column];
            if (old.table != null)
                for (int i = 0; i < s_row; i++)
                    for (int j = 0; j < s_column; j++)
                        this.table[i, j] = (Rational)old.table[i, j];
            if (old.index_basic != null) old.index_basic.CopyTo(this.index_basic, 0);
            if (old.index_free != null) old.index_free.CopyTo(this.index_free, 0);
            this.iteration = (int)old.iteration;

            this.i_min = (int)old.i_min;
            this.j_min = (int)old.j_min;
            this.execution_code = (int)old.execution_code;
        }
        //вторая инициализация (симплекс таблица)
        public void init_table()
        {
            iteration = 0;
            s_row = row + 1;
            s_column = column - row;
            index_basic = new int[row];
            index_free = new int[s_column];
            table = new Rational[s_row, s_column];
            //бизисные переменные
            for (int i = 0; i < row; i++)
                index_basic[i] = index[i];
            //свободные переменные
            for (int i = 0; i + row < column; i++)
                index_free[i] = index[i + row];
            //таблица симплекс
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j + row < column; j++)
                    table[i, j] = matrix[i, j + row];
            }
            simplecs_function();

            execution_code = 3;
            search_supporting();//найдем опорный
            if (!check_Pi()) execution_code = 0;//решение найдено
            if (check_limitation()) execution_code = 1;//неограничена

            //обозначаем возможные опорные (необходимо при рисовании)
            applicants_supporting();
        }
        //коэф. новой функции
        public void simplecs_function()
        {
            for (int i = 0; i < index_free.Length - 1; i++)
            {
                table[s_row - 1, i] = function[index_free[i] - 1];
                for (int j = 0; j < index_basic.Length; j++)
                    table[s_row - 1, i] += function[index_basic[j] - 1] * (new Rational(0, 1) - table[j, i]);
            }
            table[s_row - 1, index_free.Length - 1] = function[index_free[index_free.Length - 1] - 1];
            for (int j = 0; j < index_basic.Length; j++)
                table[s_row - 1, index_free.Length - 1] += function[index_basic[j] - 1] * table[j, index_free.Length - 1];
        }

        #region Метод Гаусса
        //метод Гаусса
        public bool Method_gaussa(string[] str)
        {
            shift_column(str);
            for (int i = 0; i < row; i++)
            {
                glavelem(i);
                if (matrix[i, i] == new Rational(0, 1))
                {
                    return false;
                }
                for (int j = column - 1; j >= i; j--)
                    matrix[i, j] /= matrix[i, i];
                for (int k = i + 1; k < row; k++)
                    for (int j = column - 1; j >= i; j--)
                        matrix[k, j] -= matrix[i, j] * matrix[k, i];
            }
            for (int i = row - 1; i > 0; i--)
                for (int s = i - 1; s >= 0; s--)
                {
                    for (int j = column - 1; j >= i; j--)
                        matrix[s, j] -= matrix[s, i] * matrix[i, j];
                }
            return true;
        }

        //Переставляем стодбцы базиса
        private void shift_column(string[] str)
        {
            for (int i = 0; i < row; i++)
            {
                int k = 0;
                if (str[i] == "0")
                {
                    k = i;
                    for (int j = i; j < column - 1 ; j++)
                    {
                        if (str[j] == "1") break;
                        k++;
                    }
                    for (int j = 0; j < row; j++)
                    {
                        Rational temp = matrix[j, i];
                        matrix[j, i] = matrix[j, k];
                        matrix[j, k] = temp;
                    }
                    int l = index[i];
                    index[i] = index[k];
                    index[k] = l;
                    str[i] = "1";
                    str[k] = "0";
                }
            }
        }

        //поиск макс элемента в квадрате(i,i), перестановка макс элемента в позицию(i,i)
        private void glavelem(int k)
        {
            int i, j, i_max = k, j_max = k;
            Rational temp;
            for (i = k; i < row; i++)
                for (j = k; j < row; j++)
                    if (matrix[i_max, j_max].Abs() < matrix[i, j].Abs())
                    {
                        i_max = i;
                        j_max = j;
                    }
            for (j = k; j < column; j++)
            {
                temp = matrix[k, j];
                matrix[k, j] = matrix[i_max, j];
                matrix[i_max, j] = temp;
            }
            for (i = 0; i < row; i++)
            {
                temp = matrix[i, k];
                matrix[i, k] = matrix[i, j_max];
                matrix[i, j_max] = temp;
            }
            i = index[k];
            index[k] = index[j_max];
            index[j_max] = i;
        }

        //проверка на условие m = rgA, т.е. ранг тот же что и кол-во ограничений
        public bool check_rang()
        {
            int[] flag = new int[column - 1];
            int[] flags = new int[row - 1];
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column - 1; j++)
                    if (matrix[i, j] / matrix[i + 1, j] != matrix[i, j + 1] / matrix[i + 1, j + 1]) flag[j] = 0;
                    else flag[j] = 1;
                flags[i] = 1;
                for (int k = 0; k < column - 1; k++)
                    if (flag[k] == 0) flags[i] = 0;
            }
            for (int i = 0; i < row - 1; i++)
                if (flags[i] == 1) return false;
            return true;
        }
        #endregion
        #region Симплекс метод
        
        public void simplecs_method() //true искать опорный
        {
            Rational nul = new Rational(0, 1);
            Rational one = new Rational(1, 1);
            Rational[,] new_table = new Rational[s_row, s_column];

            Rational supporting = new Rational(one / table[i_min, j_min]);
            new_table[i_min, j_min] = supporting;

            //убираем из базиса в свободные
            int t = index_basic[i_min];
            index_basic[i_min] = index_free[j_min];
            index_free[j_min] = t;

            //получаем новый столбец опорного эл-та
            for (int i = 0; i < s_row; i++)
                if (i != i_min) new_table[i, j_min] = (nul - supporting) * table[i, j_min];
                
            //получаем новую строку опорного эл-та
            for (int j = 0; j < s_column; j++)
                if (j != j_min) new_table[i_min, j] = supporting * table[i_min, j];
                
            //получаем остальные строки таблицы
            for (int i = 0; i < s_row; i++)
                if (i != i_min)
                    for (int j = 0; j < s_column; j++)
                        if (j != j_min)
                            new_table[i, j] = table[i, j] - table[i, j_min] * new_table[i_min, j];

            table = new_table;
            iteration++;

            if (!check_Pi()) execution_code = 0;//решение найдено
            if (check_limitation()) execution_code = 1;//неограничена
            if (check_Bi()) execution_code = 2;//ответ отрицателен
            
            //опорный
            search_supporting();

            //обозначаем возможные опорные (необходимо при рисовании)
            applicants_supporting();
        }
        //проверка Bi
        public bool check_Bi()
        {
            Rational nul = new Rational(0, 1);
            for (int i = 0; i < s_row - 1; i++)
                if (table[i, s_column - 1] < nul) return true;
            return false;
        }
        //проверка Pi
        public bool check_Pi()
        {
            Rational nul = new Rational(0, 1);
            for (int j = 0; j < s_column - 1; j++)
                if (table[s_row - 1, j] < nul) return true;
            return false;
        }
        //проверка ограниченности снизу
        public bool check_limitation()
        {
            int k = 0;
            Rational nul = new Rational(0, 1);
            for (int j = 0; j < s_column - 1; j++)
                if (table[s_row - 1, j] < nul)
                {
                    for (int i = 0; i < s_row - 1; i++)
                        if ((table[i, j] < nul)) k++;
                    if (k == s_row - 1) return true;
                    k = 0;
                }
            return false;
        }
        //опорный элемент
        public void search_supporting()
        {
            Rational nul = new Rational(0, 1);
            bool flag = true;
            for (int j = 0; j < s_column - 1; j++)
                if (table[s_row - 1, j] < nul)
                    for (int i = 0; i < s_row - 1; i++)
                        if (!(flag) && (table[i, j] > nul) &&
                            (table[i, s_column - 1]) / (table[i, j]) < (table[i_min, s_column - 1]) / (table[i_min, j_min]))
                        {
                            i_min = i;
                            j_min = j;
                        }
                        else if ((flag) && (table[i, j] > nul))
                        {
                            i_min = i;
                            j_min = j;
                            flag = false;
                        }
        }
        //возможные опорные
        public void applicants_supporting()
        {
            Rational nul = new Rational(0, 1);
            for (int j = 0; j < s_column - 1; j++)
                if (table[s_row - 1, j] < nul)
                    for (int i = 0; i < s_row - 1; i++)
                    {
                        table[i, j].p = 0;
                        if ((table[i, j] > nul) && (table[i, s_column - 1] >= nul))
                            table[i, j].p = 1;
                    }
        }

        #endregion
        #region исскуственный базис

        public Simplecs artificial_base(Simplecs old, string[] function_or)
        {
            int j = 0;
            Simplecs new_simplecs = new Simplecs(old.row, old.column - old.row);
            new_simplecs.s_row = new_simplecs.row + 1;
            new_simplecs.s_column = new_simplecs.column - new_simplecs.row;
            //new_simplecs.row = new_simplecs.s_row - 1;
            //new_simplecs.column = new_simplecs.s_column + new_simplecs.row;
            new_simplecs.iteration = old.iteration + 1;
            new_simplecs.index_basic = new int[new_simplecs.row];
            for (int i = 0; i < old.s_row - 1; i++)
                new_simplecs.index_basic[i] = old.index_basic[i];
            new_simplecs.index_free = new int[new_simplecs.s_column];
            new_simplecs.table = new Rational[new_simplecs.s_row, new_simplecs.s_column];
            new_simplecs.function = new Rational[new_simplecs.s_column + new_simplecs.s_row - 1];
            for (int i = 0; i < new_simplecs.s_column + new_simplecs.s_row - 1; i++)
                new_simplecs.function[i] = new Rational(function_or[i]);

            for (int i = 0; i < old.s_column; i++)
            {
                if (old.index_free[i] - 1 <= new_simplecs.s_column)
                {
                    for (int k = 0; k < new_simplecs.s_row; k++)
                        new_simplecs.table[k, j] = new Rational(old.table[k, i]);
                    new_simplecs.index_free[j] = old.index_free[i];
                    j++;
                }
                if (old.index_free[i] - 1 == old.column - 1)
                {
                    for (int k = 0; k < new_simplecs.s_row; k++)
                        new_simplecs.table[k, j] = new Rational(old.table[k, i]);
                    new_simplecs.index_free[j] = old.index_free[i] - s_row + 1;
                    j++;
                }
            }
            new_simplecs.simplecs_function();
            new_simplecs.execution_code = 3;
            return new_simplecs;
        }

        #endregion
    }
}
