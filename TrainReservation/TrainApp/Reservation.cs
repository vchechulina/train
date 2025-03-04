using System;

namespace TrainApp
{
    public class Reservation
    {
        private int[,] seats;

        public Reservation(int rows, int columns)
        {
            seats = new int[rows, columns];
        }

        public int[,] GetSeats() => seats;

        public bool ReserveSeat(int row, int column)
        {
            if (seats[row, column] == 0)
            {
                seats[row, column] = 1;
                return true;
            }
            return false;
        }

        public bool CancelReservation(int row, int column)
        {
            if (seats[row, column] == 1)
            {
                seats[row, column] = 0;
                return true;
            }
            return false;
        }
    }
}
