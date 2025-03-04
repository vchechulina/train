using Xunit;
using TrainApp;
using System;

namespace TrainApp.Tests
{
    public class ReservationTests
    {
        [Fact]
        public void ReserveSeat_ShouldReserve_WhenSeatIsAvailable()
        {
            var reservation = new Reservation(5, 8);
            bool result = reservation.ReserveSeat(2, 3);
            Assert.True(result);
        }

        [Fact]
        public void ReserveSeat_ShouldNotReserve_WhenSeatIsTaken()
        {
            var reservation = new Reservation(5, 8);
            reservation.ReserveSeat(2, 3);
            bool result = reservation.ReserveSeat(2, 3);
            Assert.False(result);
        }

        [Fact]
        public void CancelReservation_ShouldCancel_WhenSeatIsReserved()
        {
            var reservation = new Reservation(5, 8);
            reservation.ReserveSeat(2, 3);
            bool result = reservation.CancelReservation(2, 3);
            Assert.True(result);
        }

        [Fact]
        public void CancelReservation_ShouldNotCancel_WhenSeatIsNotReserved()
        {
            var reservation = new Reservation(5, 8);
            bool result = reservation.CancelReservation(2, 3);
            Assert.False(result);
        }

        [Fact]
        public void ReserveSeat_ShouldReserve_LastSeat()
        {
            var reservation = new Reservation(5, 8);
            bool result = reservation.ReserveSeat(4, 7);
            Assert.True(result);
        }

        [Fact]
        public void CancelReservation_ShouldCancel_LastSeat()
        {
            var reservation = new Reservation(5, 8);
            reservation.ReserveSeat(4, 7);
            bool result = reservation.CancelReservation(4, 7);
            Assert.True(result);
        }

        [Fact]
        public void ReserveSeat_ShouldThrowException_WhenIndexIsOutOfRange()
        {
            var reservation = new Reservation(5, 8);
            Assert.Throws<IndexOutOfRangeException>(() => reservation.ReserveSeat(5, 8));
            Assert.Throws<IndexOutOfRangeException>(() => reservation.ReserveSeat(-1, 0));
        }

        [Fact]
        public void CancelReservation_ShouldThrowException_WhenIndexIsOutOfRange()
        {
            var reservation = new Reservation(5, 8);
            Assert.Throws<IndexOutOfRangeException>(() => reservation.CancelReservation(5, 8));
            Assert.Throws<IndexOutOfRangeException>(() => reservation.CancelReservation(-1, 0));
        }

        [Fact]
        public void GetSeats_ShouldReflectReservations()
        {
            var reservation = new Reservation(3, 3);
            reservation.ReserveSeat(1, 1);
            reservation.ReserveSeat(2, 2);

            int[,] seats = reservation.GetSeats();

            Assert.Equal(1, seats[1, 1]);
            Assert.Equal(1, seats[2, 2]);
            Assert.Equal(0, seats[0, 0]);
        }

        [Fact]
        public void ShouldNotReserve_WhenAllSeatsAreTaken()
        {
            var reservation = new Reservation(2, 2);
            reservation.ReserveSeat(0, 0);
            reservation.ReserveSeat(0, 1);
            reservation.ReserveSeat(1, 0);
            reservation.ReserveSeat(1, 1);

            bool result = reservation.ReserveSeat(0, 0);
            Assert.False(result);
        }
    }
}
