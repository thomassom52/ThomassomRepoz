using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите квадратное уравнение вида ax^2+bx+c=d, где a,b,c,d - целые числа. Любой из коэффициентов может быть равен нулю " +
                " Уравнение может содержать n элементов как в левой, так и в правой части уравнения");
            string Eq = Console.ReadLine();
            int coef = 1;
            double a = 0, b = 0, c = 0;
            int e = 0, d = 0, co = 0, a1 = 0, b1 = 0, a2 = 0, b2 = 0;
            string digit = "0";
            for (int i = 0; i < Eq.Length; i++)
            {

                if (Eq[i] == '+' && co != 1)
                {
                    if (digit != "0")
                    {
                        e = e + coef * Convert.ToInt32(digit);
                        digit = "0";
                    }
                    if (Eq[i + 1] == 'x')
                    {
                        digit = "1";
                    }

                    coef = 1;

                }
                if (Eq[i] == '-' && co != 1)
                {
                    if (digit != "0")
                    {
                        e = e + coef * Convert.ToInt32(digit);
                        digit = "0";
                    }
                    if (Eq[i + 1] == 'x')
                    {
                        digit = "1";
                    }

                    coef = -1;

                }

                if (Eq[i] >= '0' && Eq[i] <= '9')
                {
                    if (i == 0 && Eq[0] == '2')
                    {
                        digit = digit + Eq[i];
                    }
                    else
                    {
                        if (Eq[i] == '2' && Eq[i - 1] != '^')
                        {
                            digit = digit + Eq[i];
                        }
                    }

                    if (Eq[i] >= '0' && Eq[i] <= '9' && Eq[i] != '2')
                    {
                        digit = digit + Eq[i];
                    }
                }
                if (Eq[i] == 'x' && co != 1 && i != Eq.Length - 1)
                {
                    if (i == 0)
                    {
                        digit = "1";
                    }
                    if (Eq[i + 1] == '^' && Eq[i + 2] == '2')
                    {
                        a1 = a1 + coef * Convert.ToInt32(digit);
                        digit = "0";
                        coef = 1;
                    }
                    else
                    {
                        b1 = b1 + coef * Convert.ToInt32(digit);
                        digit = "0";
                        coef = 1;
                    }
                }
                if (Eq[i] == '=' && co != 1)
                {
                    if (digit != "0")
                    {
                        e = e + coef * Convert.ToInt32(digit);

                    }
                    digit = "0";
                    coef = 1;
                    co = 1;
                }
                if (co == 1)
                {
                    if (Eq[i] == 'x')
                    {
                        if (i == Eq.Length - 1)
                        {
                            b2 = b2 + coef * Convert.ToInt32(digit);
                            digit = "0";
                            coef = 1;
                        }
                        else
                        {
                            if (Eq[i + 1] == '^' && Eq[i + 2] == '2')
                            {
                                a2 = a2 + coef * Convert.ToInt32(digit);
                                digit = "0";
                                coef = 1;
                            }
                            else
                            {
                                b2 = b2 + coef * Convert.ToInt32(digit);
                                digit = "0";
                                coef = 1;
                            }
                        
                        }
                        
                    }
                }

                if (co == 1)
                {
                    if (Eq[i] == '=')
                    {
                        if (digit != "0")
                        {
                            d = d + coef * Convert.ToInt32(digit);

                        }
                        digit = "0";
                        coef = 1;
                        if (Eq[i + 1] == 'x')
                        {
                            digit = "1";
                        }
                    }
                    if (Eq[i] == '+')
                    {
                        if (digit != "0")
                        {
                            d = d + coef * Convert.ToInt32(digit);
                            digit = "0";
                        }
                        if (Eq[i + 1] == 'x')
                        {
                            digit = "1";
                        }
                        coef = 1;
                    }
                    if (Eq[i] == '-')
                    {
                        if (digit != "0")
                        {
                            d = d + coef * Convert.ToInt32(digit);
                            digit = "0";
                        }
                        if (Eq[i + 1] == 'x')
                        {
                            digit = "1";
                        }
                        coef = -1;
                    }
                    if (i == Eq.Length - 1)
                    {
                        if (digit != "0")
                        {
                            d = d + coef * Convert.ToInt32(digit);
                            digit = "0";
                            coef = 1;

                        }
                    }

                }

            }
            c = e - d;
            a = a1 - a2;
            b = b1 - b2;                       
            double D;
            double x = 0;
            double y = 0;
            if (a == 0 && b != 0)
            {
                x = -c / b;
                Console.WriteLine("Корень:" + x);
            }
            else
            {
                D = b * b - 4 * a * c;
                if (D > 0)
                {
                    x = ((-b + Math.Sqrt(D)) / (2 * a));
                    y = ((-b - Math.Sqrt(D)) / (2 * a));
                    Console.WriteLine("Первый корень: " + x);
                    Console.WriteLine("Второй корень: " + y);
                }
                if (D == 0 && a != 0)
                {
                    x = -b / (2 * a);
                    Console.WriteLine(x);
                }
                if (D < 0)
                {
                    Console.WriteLine("Нет корней");

                }

            }
            if (a == 0 && b == 0)
            {
                Console.WriteLine("Не уравнение");
            }
            Console.ReadLine();

        }
    }
}
