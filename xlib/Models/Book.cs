using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class Book
    {
        // Properties
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string ?Title { get; set; }

        [Required]
        [StringLength(50)]
        public string? Author { get; set; }

        [Required]
        [StringLength(50)]
        public string ?Publisher { get; set; }

        [Required]
        [StringLength(50)]
        public string? Type { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfCopies { get; set; }

        public string? Description { get; set; }

        public bool? isShow { get; set; }

        // Foreign Key
        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }

        // Foreign Key
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        // Foreign Key
        [ForeignKey("BookState")]
        public int BookStateId { get; set; }
        public BookState BookState { get; set; }

        // Methods
        public void AddBook(ApplicationDbContext context, Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("Book added successfully.");
        }
        // Constructor
        public Book(int bookId, string title, string author, string publisher, string type, bool availability, int numberOfCopies, string description, bool? isShow, int mainCategoryId, int subCategoryId, int bookStateId)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Publisher = publisher;
            Type = type;
            Availability = availability;
            NumberOfCopies = numberOfCopies;
            Description = description;
            this.isShow = isShow;
            MainCategoryId = mainCategoryId;
            SubCategoryId = subCategoryId;
            BookStateId = bookStateId;
        }

        public void EditBook(ApplicationDbContext context, Book book)
        {
            var existingBook = context.Books.Find(book.BookId);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Publisher = book.Publisher;
                existingBook.Type = book.Type;
                existingBook.Availability = book.Availability;
                existingBook.NumberOfCopies = book.NumberOfCopies;
                existingBook.Description = book.Description;
                existingBook.isShow = book.isShow;
                existingBook.MainCategoryId = book.MainCategoryId;
                existingBook.SubCategoryId = book.SubCategoryId;
                existingBook.BookStateId = book.BookStateId;

                context.SaveChanges();
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DeleteBook(ApplicationDbContext context, int bookId)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                book.isShow = false;
                context.SaveChanges();
                Console.WriteLine("Book marked as not shown successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public Book SearchBook(ApplicationDbContext context, int bookId)
        {
            return context.Books.Find(bookId);
        }

        public void UpdateBook(ApplicationDbContext context, Book book)
        {
            EditBook(context, book);
        }

        public void GetBookDetails(Book book)
        {
            Console.WriteLine($"Book ID: {book.BookId}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Publisher: {book.Publisher}");
            Console.WriteLine($"Type: {book.Type}");
            Console.WriteLine($"Availability: {book.Availability}");
            Console.WriteLine($"Number Of Copies: {book.NumberOfCopies}");
            Console.WriteLine($"Description: {book.Description}");
            Console.WriteLine($"isShow: {book.isShow}");
            Console.WriteLine($"Main Category ID: {book.MainCategoryId}");
            Console.WriteLine($"Sub Category ID: {book.SubCategoryId}");
            Console.WriteLine($"Book State ID: {book.BookStateId}");
        }
    }
}
