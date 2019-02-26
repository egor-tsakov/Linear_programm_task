using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linear_programm_task
{
    //класс дробей
    class Rational
    {
        public int a; //числитель
        public int b; //знаменатель
        public int p = 0; //может ли пользователь выбрать в качестве опрного
        public Rational(int x, int y)
        {
            int div = CMMDC(x, y);
            this.a = x / div;
            this.b = y / div;
            if (this.b < 0)
            {
                this.a = -this.a;
                this.b = -this.b;
            }
        }
        public Rational(Rational current)
        {
            this.a = current.a;
            this.b = current.b;
        }
        public Rational(string number)
        {
            switch (check_number(number))
            {
                case 1:
                    string[] x = number.Split('/');
                    int div = CMMDC(Int32.Parse(x[0]), Int32.Parse(x[1]));
                    this.a = Int32.Parse(x[0]) / div;
                    this.b = Int32.Parse(x[1]) / div;
                    if (this.b < 0)
                    {
                        this.a = -this.a;
                        this.b = -this.b;
                    }
                    break;
                case 2:
                    string[] x2 = number.Split('.');
                    int div2 = CMMDC(Int32.Parse(x2[0]+x2[1]), (int)Math.Pow(10, x2[1].Length));
                    this.a = Int32.Parse(x2[0] + x2[1]) / div2;
                    this.b = (int)Math.Pow(10, x2[1].Length) / div2;
                    if (this.b < 0)
                    {
                        this.a = -this.a;
                        this.b = -this.b;
                    }
                    break;
                case 3:
                    string[] x3 = number.Split(',');
                    int div3 = CMMDC(Int32.Parse(x3[0]+x3[1]), (int)Math.Pow(10, x3[1].Length));
                    this.a = Int32.Parse(x3[0] + x3[1]) / div3;
                    this.b = (int)Math.Pow(10, x3[1].Length) / div3;
                    if (this.b < 0)
                    {
                        this.a = -this.a;
                        this.b = -this.b;
                    }
                    break;
                case 4:
                    this.a = Int32.Parse(number);
                    this.b = 1;
                    break;
            }
            new Rational(0, 1);
        }

        //наименьший общее кратное
        public static int CMMDC(int x, int y)
        {
            int r;
            r = x % y;
            while (r != 0)
            {
                x = y;
                y = r;
                r = x % y;
            }
            return y;
        }

        //наименьшее общей делитель
        public static int CMMMC(int x, int y)
        {
            return (x * y / CMMDC(x, y)); ;
        }

        //определение типа дроби (обычная, десятичная)
        public static int check_number(string number)
        {
            try
            {
                if ((number.Split('/').Length == 2)) return 1;
                if ((number.Split('.').Length == 2)) return 2;
                if ((number.Split(',').Length == 2)) return 3;
                int i = Int32.Parse(number);
                return 4;
            }
            catch (NullReferenceException) { return 0; }
            catch (FormatException) { return 0; }
        }

        //операции с дробями, переопределение
        public static Rational operator+ (Rational x, Rational y)
        {
            int bottom = CMMMC(x.b, y.b);
            int top = (x.a * (bottom / x.b)) + (y.a * (bottom / y.b));
            return new Rational(top, bottom);
        }
        public static Rational operator -(Rational x, Rational y)
        {
            int bottom = CMMMC(x.b, y.b);
            int top = (x.a * (bottom / x.b)) - (y.a * (bottom / y.b));
            return new Rational(top, bottom);
        }
        public static Rational operator *(Rational x, Rational y)
        {
            int bottom = x.b * y.b;
            int top = x.a * y.a;
            return new Rational(top, bottom);
        }
        public static Rational operator /(Rational x, Rational y)
        {
            if (y.a == 0) return new Rational(0, 1);
            int bottom = x.b * y.a;
            int top = x.a * y.b;
            return new Rational(top, bottom);
        }
        public static bool operator <(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) < (y.a * (div / y.b))) return true;
            return false;
        }
        public static bool operator >(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) > (y.a * (div / y.b))) return true;
            return false;
        }
        public static bool operator ==(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) == (y.a * (div / y.b))) return true;
            return false;
        }
        public static bool operator !=(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) != (y.a * (div / y.b))) return true;
            return false;
        }
        public static bool operator <=(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) <= (y.a * (div / y.b))) return true;
            return false;
        }
        public static bool operator >=(Rational x, Rational y)
        {
            int div = CMMMC(x.b, y.b);
            if ((x.a * (div / x.b)) >= (y.a * (div / y.b))) return true;
            return false;
        }
        //модуль дроби
        public Rational Abs()
        {
            int x = this.a;
            int y = this.b;
            if (x < 0) x = -this.a;
            if (y < 0) y = -this.b;
            return new Rational(x, y);
        }

        //преобразование в строку
        override
        public string ToString()
        {
            if (this.b == 1) return a.ToString();
            if (this.a == 0) return "0";
            return a.ToString() + "\n——————————————————" + b.ToString();
        }
    }
}
