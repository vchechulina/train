using System;

namespace train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість рядів: ");
            int rows = GetValidIntInput();
            Console.Write("Введіть кількість місць у ряді: ");
            int columns = GetValidIntInput();
            int[,] seats = new int[rows, columns];

            bool isOpen = true;

            Console.WriteLine("Бронювання місця у потягу");

            while (isOpen)
            {
                Console.WriteLine("\nЩо ви хочете зробити?\n" +
                                  "1 - Переглянути стан місць\n" +
                                  "2 - Забронювати місце\n" +
                                  "3 - Відмінити бронювання\n" +
                                  "4 - Вийти з програми");
                Console.Write("\nОберіть команду: ");

                int command = GetValidIntInput();

                switch (command)
                {
                    case 1:
                        DisplaySeats(seats);
                        break;

                    case 2:
                        BookSeat(seats);
                        break;

                    case 3:
                        CancelBooking(seats);
                        break;

                    case 4:
                        Console.WriteLine("Ви впевнені, що хочете вийти? (Y/N)");
                        string answer = Console.ReadLine()?.Trim() ?? "";
                        if (answer.ToLower() == "y")
                        {
                            isOpen = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void DisplaySeats(int[,] seats)
        {
            Console.WriteLine("\nСтан місць:");
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
        }

        static void BookSeat(int[,] seats)
        {
            Console.Write("Введіть номер ряду: ");
            int row = GetValidIntInput() - 1;
            if (row < 0 || row >= seats.GetLength(0))
            {
                Console.WriteLine("Такого ряду немає.");
                return;
            }

            Console.Write("Введіть номер місця: ");
            int seat = GetValidIntInput() - 1;
            if (seat < 0 || seat >= seats.GetLength(1))
            {
                Console.WriteLine("Такого місця немає.");
                return;
            }

            if (seats[row, seat] == 0)
            {
                seats[row, seat] = 1;
                Console.WriteLine($"Місце в ряду {row + 1}, місце {seat + 1} заброньовано.");
            }
            else
            {
                Console.WriteLine("Місце вже заброньоване. Виберіть інше.");
            }
        }

        static void CancelBooking(int[,] seats)
        {
            Console.Write("Введіть номер ряду: ");
            int row = GetValidIntInput() - 1;
            if (row < 0 || row >= seats.GetLength(0))
            {
                Console.WriteLine("Такого ряду немає.");
                return;
            }

            Console.Write("Введіть номер місця: ");
            int seat = GetValidIntInput() - 1;
            if (seat < 0 || seat >= seats.GetLength(1))
            {
                Console.WriteLine("Такого місця немає.");
                return;
            }

            if (seats[row, seat] == 1)
            {
                seats[row, seat] = 0;
                Console.WriteLine($"Бронювання місця в ряду {row + 1}, місце {seat + 1} скасовано.");
            }
            else
            {
                Console.WriteLine("Місце не заброньоване. Скасування неможливе.");
            }
        }

        static int GetValidIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                {
                    return result;
                }
                Console.Write("Некоректне введення! Введіть число більше за 0: ");
            }
        }
    }
}
