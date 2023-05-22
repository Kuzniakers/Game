using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gra
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var start = true;
            while (start)
            {
                Console.Clear();
                GetAppInfo();
                string userName = GetUserName();
                GreetUser(userName);

                Random random = new Random();
                int correctNumber = random.Next(1, 11);
                bool correctAnswer = false;

                Console.WriteLine("Zgadnij wylosowaną liczbę z przedziału od 1 do 10.");

                while (!correctAnswer)
                {
                    string input = Console.ReadLine();

                    int guess;
                    bool isNumber = int.TryParse(input, out guess);

                    if (!isNumber)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę.");
                        continue;
                    }

                    if (guess < 1 || guess > 10)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę od 1 do 10.");
                        continue;
                    }
                    if (guess < correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "Błędna odpowiedz. Wylosowana liczba jest większa");
                    }
                    else if (guess > correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "Błędna odpowiedz. Wylosowana liczba jest mniejsza");
                    }
                    else
                    {
                        correctAnswer = true;
                        PrintColorMessage(ConsoleColor.Green, "Brawo prawidłowa odpowiedź!");
                    }
                }
                Again(ref start);
            }

        }
        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczby";
            int appVersion = 1;
            string appAuthor = "Konrad Kuźniak";

            string info = $"[{appName}] Wersja: {appVersion}.0, Autor: {appAuthor}";
            PrintColorMessage(ConsoleColor.DarkCyan, info);
        }

        static string GetUserName()
        {
            Console.WriteLine("Podaj imię");
            string userName = Console.ReadLine();
            return userName;
        }
        static void GreetUser(string userName)
        {

            string greet = "Powodzenia " + userName;
            PrintColorMessage(ConsoleColor.DarkMagenta, greet);

        }
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Again(ref bool end)
        {
            bool isNumeric = false;
            
            while (isNumeric == false)
            {                
                Console.WriteLine("Czy chcesz zagrać ponownie? Naciśnij '1' jeśli tak, '0' aby zakmnąć program");
                
                var answer = Console.ReadLine();
                isNumeric = int.TryParse(answer, out int decision);         
               
                if (isNumeric == true)
                {

                    if (decision == 1)
                    {
                        Console.Clear();
                        return;

                    }
                    else if (decision == 0)
                    {
                        end = false;
                        return;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "Proszę wciśnij '1' aby grać dalej lub '0' by zamknąć aplikację");
                        Console.ReadKey();
                    }
                }
                else
                {                  
                    PrintColorMessage(ConsoleColor.Yellow, "Twoja odpowiedź nie jest liczbą. Wpisz ponownie!");
                    
                }
                                      
                    
               
            }


        }


    }
}

