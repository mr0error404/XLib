using System;
using System.ComponentModel.DataAnnotations;

namespace consoleXLib
{
    public class BookState
    {
        // Properties
        [Key]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        // Constructor
        public BookState(int statusId, string statusName, DateTime createDate)
        {
            StatusId = statusId;
            StatusName = statusName;
            CreateDate = createDate;
        }

        // Methods
        public void CreateStatus(ApplicationDbContext context, BookState bookState)
        {
            context.BookStates.Add(bookState);
            context.SaveChanges();
            Console.WriteLine("Book state created successfully.");
        }

        public void UpdateStatus(ApplicationDbContext context, int statusId, string newStatusName)
        {
            var bookState = context.BookStates.Find(statusId);
            if (bookState != null)
            {
                bookState.StatusName = newStatusName;
                context.SaveChanges();
                Console.WriteLine("Book state updated successfully.");
            }
            else
            {
                Console.WriteLine("Book state not found.");
            }
        }
    }
}
