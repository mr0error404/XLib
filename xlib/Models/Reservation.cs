using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class Reservation
    {
        // Properties
        public int ReservationId { get; set; }

        // Foreign Key for User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        // Foreign Key for Book
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }

        public DateTime ReservedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StatusId { get; set; }

        // Constructor
        public Reservation(int reservationId, int userId, int bookId, DateTime reservedDate, DateTime returnDate, int statusId)
        {
            ReservationId = reservationId;
            UserId = userId;
            BookId = bookId;
            ReservedDate = reservedDate;
            ReturnDate = returnDate;
            StatusId = statusId;
        }

        // Methods
        public void MakeReservation(ApplicationDbContext context, Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            Console.WriteLine("Reservation made successfully.");
        }

        public void UpdateReturnDate(ApplicationDbContext context, int reservationId, DateTime newReturnDate)
        {
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                reservation.ReturnDate = newReturnDate;
                context.SaveChanges();
                Console.WriteLine("Return date updated successfully.");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
        }
    }
}
