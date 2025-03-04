using System;

namespace TrainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 5;
            int columns = 8;
            Reservation reservation = new Reservation(rows, columns);
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
                        DisplaySeats(reservation);
                        break;

                    case 2:
                        HandleReservation(reservation);
                        break;

                    case 3:
                        HandleCancellation(reservation);
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

        static void DisplaySeats(Reservation reservation)
        {
            int[,] seats = reservation.GetSeats();
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

        static void HandleReservation(Reservation reservation)
        {
            Console.Write("Введіть номер ряду: ");
            if (!int.TryParse(Console.ReadLine(), out int row) || row < 1 || row > 5)
            {
                Console.WriteLine("Некоректний номер ряду.");
                return;
            }

            Console.Write("Введіть номер місця: ");
            if (!int.TryParse(Console.ReadLine(), out int seat) || seat < 1 || seat > 8)
            {
                Console.WriteLine("Некоректний номер місця.");
                return;
            }

            if (reservation.ReserveSeat(row - 1, seat - 1))
            {
                Console.WriteLine($"Місце {seat} у ряді {row} заброньовано.");
            }
            else
            {
                Console.WriteLine("Місце вже заброньоване. Виберіть інше.");
            }
        }

        static void HandleCancellation(Reservation reservation)
        {
            Console.Write("Введіть номер ряду: ");
            if (!int.TryParse(Console.ReadLine(), out int row) || row < 1 || row > 5)
            {
                Console.WriteLine("Некоректний номер ряду.");
                return;
            }

            Console.Write("Введіть номер місця: ");
            if (!int.TryParse(Console.ReadLine(), out int seat) || seat < 1 || seat > 8)
            {
                Console.WriteLine("Некоректний номер місця.");
                return;
            }

            if (reservation.CancelReservation(row - 1, seat - 1))
            {
                Console.WriteLine($"Бронювання місця {seat} у ряді {row} скасовано.");
            }
            else
            {
                Console.WriteLine("Це місце не було заброньоване.");
            }
        }
    }
}
