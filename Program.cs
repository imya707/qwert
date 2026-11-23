using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorBattle
{
    class Program
    {
        static int ReadNumber(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int number)
                    && number >= min && number <= max)
                {
                    return number;
                }
            }
        }
        static void Main()
            {
                Console.Title = "Битва гладиаторов";
                try
                {
                    Console.SetWindowPosition(0, 0);
                    Console.SetWindowSize(100, 30);
                }
                catch 
                { 
                
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine("======================");
                Console.WriteLine("  БИТВА ГЛАДИАТОРОВ! ");
                Console.WriteLine("======================");

                Console.WriteLine("\nПервый гладиатор:");

                int health1 = ReadNumber("Введите здоровье: ", 1, 500);
                int armor1 = ReadNumber("Введите броню (0-100): ", 0, 100);

                Console.WriteLine("\nВторой гладиатор:");

                int health2 = ReadNumber("Введите здоровье: ", 1, 500);
                int armor2 = ReadNumber("Введите броню (0-100): ", 0, 100);

                Random random = new Random();

                int attack1 = random.Next(10, 51);
                int attack2 = random.Next(10, 51);

                Console.WriteLine("Удар первого: " + attack1);
                Console.WriteLine("Удар второго: " + attack2);

                int damage1 = attack2 * (100 - armor1) / 100;
                int damage2 = attack1 * (100 - armor2) / 100;

                health1 -= damage1;
                health2 -= damage2;

                if (health1 < 0) health1 = 0;
                if (health2 < 0) health2 = 0;

                Console.WriteLine("\n============ИТОГ============");
                Console.WriteLine("\nЗдоровье первого: " + health1);
                Console.WriteLine("\nЗдоровье второго: " + health2);


                if (health1 < health2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ПОбедил первый гладиатор! ");

                }
                else if (health2 < health1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Победил второй гладиатор! ");
                }
                else
                {
                    Console.WriteLine("Ничья! ");
                }
                Console.ResetColor();
                Console.WriteLine("\nНажмите любую клавишу: ");
                Console.ReadKey();
            }
        }
    }