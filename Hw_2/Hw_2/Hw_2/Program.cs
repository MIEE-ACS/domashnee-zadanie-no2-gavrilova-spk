using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_2
{
    class Program
    {
        static double Check(ref string str)  //Проверка на десятичное число, замена точки на запятую
        {
            double num;
            //int i = str.IndexOf('.');/////////////
            str = str.Replace('.', ',');

            if (!double.TryParse(str, out num))
            {
                Console.WriteLine("Вводить надо число. Конец программы.");
                Environment.Exit(37707);
            }
            return num;
         }

        static double Fun_1(double x)
        {
            double y = -0.5 * x - 3;
            return y;
        }

        static double Fun_2(double x, double R)
        {
            double y = - Math.Sqrt(R * R - x * x);
            return y;
        }

        static double Fun_3(double x, double R)
        {
            double y = Math.Sqrt(R * R - Math.Pow((x - 6), 2));
            return y;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите радиус:    ");
            string str = Console.ReadLine();
            double R = Check(ref str);

            Console.Write("Введите значение аргумента :    ");
            str = Console.ReadLine();
            double X_0 = Check(ref str);
            double Y=999, X;

            for (X = -10; X <= 6; X += 1)
            {
                    if (R < 3 && X > R && X < (6 - R))
                    {
                        Console.WriteLine("Функция не определена на отрезке {0:N3} < х < {1:N3} ", R, (6 - R));
                    }
                    else if (X >= -10 && X <= 0)
                    {
                        Console.WriteLine("Значение функции:   {0:N3}  {1:N3}", X, Fun_1(X));
                        if (X_0 >= -10 && X_0 <= 0)
                            Y = Fun_1(X_0);
                    }
                    else if (X > 0 && X <= 3)
                    {
                        Console.WriteLine("Значение функции:   {0:N3}  {1:N3}", X, Fun_2(X, R));
                        if (X_0 > 0 && X_0 <= 3)
                            Y = Fun_2(X_0, R);
                    }
                    else
                    {
                        Console.WriteLine("Значение функции:   {0:N3}  {1:N3}", X, Fun_3(X, R));
                        if (X_0 >= 3 && X_0 <= 6)
                            Y = Fun_3(X_0, R);
                    }
            }


            Console.WriteLine("------------------------------------------------------");
            if (R < 3 && X_0 > R && X_0 < (6 - R))
                Console.WriteLine("Функция не определена на отрезке {0:N3} < х < {1:N3} ", R, (6 - R));
            else if (X_0 < -10 || X_0 > 6)
                Console.WriteLine("Функция определена на отрезке {0:N3} < х < {1:N3} ", -10, 6);
            else
                Console.WriteLine("Значение функции в точке {0:N3} :   {1:N3}", X_0, Y);

            Console.ReadKey();
        }
    }
}
