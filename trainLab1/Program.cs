
using System;

namespace train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 5;
            int columns = 8;

            int[,] seats = new int[rows, columns];
            bool isOpen = true;

            Console.WriteLine("Бронювання місця у потягу");

            while (isOpen)
            {
                Console.WriteLine("\nЩо ви хочете зробити?\n\n1 - Переглянути стан місць\n2 - Забронювати місце\n3 - Відмінити бронювання\n4 - Вийти з програми");
                Console.Write("\nОберіть команду: ");

                if (!int.TryParse(Console.ReadLine(), out int command))
                {
                    Console.WriteLine("Помилка! Введіть число.");
                    continue;
                }

                switch (command)
                {
                    case 1:
                        for (int i = 0; i < seats.GetLength(0); i++)
                        {
                            Console.Write($"Ряд {i + 1}: ");
                            for (int j = 0; j < seats.GetLength(1); j++)
                            {
                                Console.ForegroundColor = seats[i, j] == 0 ? ConsoleColor.Green : ConsoleColor.Red;
                                Console.Write(seats[i, j] == 0 ? "[ ] " : "[X] ");
                            }
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        Console.Write("Введіть номер ряду: ");
                        if (!int.TryParse(Console.ReadLine(), out int userSeries) || userSeries < 1 || userSeries > rows)
                        {
                            Console.WriteLine("Некоректний номер ряду.");
                            break;
                        }
                        userSeries--;

                        Console.Write("Введіть номер місця: ");
                        if (!int.TryParse(Console.ReadLine(), out int userSeat) || userSeat < 1 || userSeat > columns)
                        {
                            Console.WriteLine("Некоректний номер місця.");
                            break;
                        }
                        userSeat--;

                        if (seats[userSeries, userSeat] == 0)
                        {
                            seats[userSeries, userSeat] = 1;
                            Console.WriteLine($"Місце {userSeat + 1} у ряді {userSeries + 1} заброньовано.");
                        }
                        else
                        {
                            Console.WriteLine("Місце вже заброньоване. Виберіть інше.");
                        }
                        break;

                    case 3:
                        Console.Write("Введіть номер ряду: ");
                        if (!int.TryParse(Console.ReadLine(), out userSeries) || userSeries < 1 || userSeries > rows)
                        {
                            Console.WriteLine("Некоректний номер ряду.");
                            break;
                        }
                        userSeries--;

                        Console.Write("Введіть номер місця: ");
                        if (!int.TryParse(Console.ReadLine(), out userSeat) || userSeat < 1 || userSeat > columns)
                        {
                            Console.WriteLine("Некоректний номер місця.");
                            break;
                        }
                        userSeat--;

                        if (seats[userSeries, userSeat] == 1)
                        {
                            seats[userSeries, userSeat] = 0;
                            Console.WriteLine($"Бронювання місця {userSeat + 1} у ряді {userSeries + 1} скасовано.");
                        }
                        else
                        {
                            Console.WriteLine("Це місце не було заброньоване.");
                        }
                        break;

                    case 4:
                        Console.Write("Ви впевнені, що хочете вийти? (Y/N): ");
                        string answer = Console.ReadLine() ?? "";
                        if (answer.Trim().ToLower() == "y")
                        {
                            isOpen = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Невідома команда.");
                        break;
                }
            }
        }
    }
}
