using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_2
{
    class Program
    {
        static double Check(ref string str, int n = 0)  //Проверка на десятичное число, замена точки на запятую
        {
            double num;
            str = str.Replace('.', ',');

            if (!double.TryParse(str, out num))
            {
                Console.WriteLine("Вводить надо число. Конец программы.");
                Console.ReadKey();
                Environment.Exit(37707);
            }

            if (n == 1 && num < 0)      //проверка на r > 0
            {
                Console.WriteLine("Радиус не может быть меньше 0. Конец программы.");
                Console.ReadKey();
                Environment.Exit(404);
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
            double y;
            if (R == 0 && x == 0)  //нулевой радиус = точка
                y = 0;
            else
                y = -Math.Sqrt(R * R - x * x);
            return y;
        }

        static double Fun_3(double x, double R)
        {
            double y;
            if (R == 0 && x == 6)          //нулевой радиус = точка
                y = 0;
            else
                y = Math.Sqrt(R * R - Math.Pow((x - 6), 2));
            return y;
        }

        static int Find_fun( double X, double R, ref bool k )
        {
            if (R < 3 && X > R && X < (6 - R))        //неопределенность X из-за радиуса
            {
                if (k)                  //условие чтобы не выводить одинаковые строки, когда выводятся все значения
                    return 5;
                Console.WriteLine("Функция не определена на отрезке {0:N3} < х < {1:N3} ", R, (6 - R));
                k = true;
            }
            else if (X >= -10 && X <= 0)               // прямая
            {
                Console.Write("Значение функции:   x =  {0:N3};  y = {1:N3}", X, Fun_1(X));
                if (R != 3 && X == 0)
                    Console.WriteLine(",  {0:N3}.", Fun_2(X, R));
                else
                    Console.WriteLine(". ");
            }
            else if (X >= 0 && X <= 3)           //первая дуга
            {
                Console.Write("Значение функции:   x =  {0:N3};  y = {1:N3}", X, Fun_2(X, R));
                if (R > 3 && X == 3)
                    Console.WriteLine(",  {0:N3}.", Fun_3(X, R));
                else
                    Console.WriteLine(". ");
            }
            else                          // вторая дуга
            {
                Console.WriteLine("Значение функции:   x =  {0:N3};  y = {1:N3}.", X, Fun_3(X, R));
            }

            return 37;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите радиус:    ");
            string str = Console.ReadLine();
            double R = Check(ref str, 1);
            
            double X;
            bool k = false;


            for (X = -10; X <= 6; X = Math.Round(X + 0.2, 3))   //Вывод всех значений
            {
                Find_fun(X, R, ref k);
            }
            Console.WriteLine("Функция определена на отрезке {0:N3} < х < {1:N3} ", -10, 6);

            Console.ReadKey();
        }
    }
}
