using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consoleXLib
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        public List<Book>? BorrowedBooks { get; set; }

        public int NumberOfBorrowedBooks { get; set; }

        [Required]
        public DateTime LastActivityDate { get; set; }

        public virtual Role? Role { get; set; }

        public User(int userId, string name, string username, string userEmail, string phone, int roleId, string password, int numberOfBorrowedBooks, DateTime lastActivityDate)
        {
            UserId = userId;
            Name = name;
            Username = username;
            UserEmail = userEmail;
            Phone = phone;
            RoleId = roleId;
            Password = password;
            NumberOfBorrowedBooks = numberOfBorrowedBooks;
            LastActivityDate = lastActivityDate;
        }

        public bool Login(ApplicationDbContext context, string username, string password)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.LastActivityDate = DateTime.Now;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditUser(ApplicationDbContext context, string name, string email, string phone)
        {
            this.Name = name;
            this.UserEmail = email;
            this.Phone = phone;
            context.Users.Update(this);
            context.SaveChanges();
        }

        public void DeleteUser(ApplicationDbContext context)
        {
            context.Users.Remove(this);
            context.SaveChanges();
        }

        public Book SearchBook(ApplicationDbContext context, int bookId)
        {
            return context.Books.Find(bookId);
        }

        public void ReserveBook(ApplicationDbContext context, int bookId)
        {
            var book = context.Books.Find(bookId);
            if (book != null && book.Availability && (book.isShow == null || book.isShow == true))
            {
                book.Availability = false;
                this.NumberOfBorrowedBooks += 1;
                this.LastActivityDate = DateTime.Now;
                if (this.BorrowedBooks == null)
                {
                    this.BorrowedBooks = new List<Book>();
                }
                this.BorrowedBooks.Add(book);
                context.SaveChanges();
            }
        }

        public int GetNumberOfBorrowedBooks()
        {
            return NumberOfBorrowedBooks;
        }

        public DateTime GetLastActivityDate()
        {
            return LastActivityDate;
        }
    }
}
