using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class Laibrarian
    {
        // Properties
        [Key]
        public int LaibrarianId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        // Navigation property
        public virtual Role? Role { get; set; }

        // Constructor
        public Laibrarian(string userName, int laibrarianId, int roleId, string password, string email, string mobile)
        {
            UserName = userName;
            LaibrarianId = laibrarianId;
            RoleId = roleId;
            Password = password;
            Email = email;
            Mobile = mobile;
        }

        // Methods
        public void Login(ApplicationDbContext context, string username, string password)
        {
            var user = context.Laibrarians.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
            }
        }

        public void AddBook(ApplicationDbContext context, Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("Book added successfully.");
        }

        public void DeleteBook(ApplicationDbContext context, int bookId)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                // Check if the book is marked as not shown
                if (book.isShow == false)
                {
                    Console.WriteLine("Cannot delete a book that is not marked as shown.");
                    return;
                }

                context.Books.Remove(book);
                context.SaveChanges();
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void UpdateBook(ApplicationDbContext context, int bookId, Book updatedBook)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                // Update other properties as needed
                context.SaveChanges();
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void FindBook(ApplicationDbContext context, int bookId)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                Console.WriteLine($"Book Title: {book.Title}, Author: {book.Author}, Publisher: {book.Publisher}, Type: {book.Type}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}
