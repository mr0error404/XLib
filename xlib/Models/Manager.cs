using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class Manager
    {
        // Properties
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string Username { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Constructor
        public Manager(int managerId, string username, int roleId, string password, string mobile, string email)
        {
            ManagerId = managerId;
            Username = username;
            RoleId = roleId;
            Password = password;
            Mobile = mobile;
            Email = email;
        }

        // Methods
        public static void AddUser(ApplicationDbContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public static void EditUser(ApplicationDbContext context, User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public static void DeleteUser(ApplicationDbContext context, int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public static User SearchUser(ApplicationDbContext context, int userId)
        {
            return context.Users.Find(userId);
        }

        public static Book SearchBook(ApplicationDbContext context, int bookId)
        {
            return context.Books.Find(bookId);
        }

        public static MainCategory SearchCategory(ApplicationDbContext context, int categoryId)
        {
            return context.MainCategorys.Find(categoryId);
        }

        public static void AddCategory(ApplicationDbContext context, MainCategory category)
        {
            context.MainCategorys.Add(category);
            context.SaveChanges();
        }

        public static void EditCategory(ApplicationDbContext context, MainCategory category)
        {
            context.MainCategorys.Update(category);
            context.SaveChanges();
        }

        public static void DeleteCategory(ApplicationDbContext context, int categoryId)
        {
            var category = context.MainCategorys.Find(categoryId);
            if (category != null)
            {
                context.MainCategorys.Remove(category);
                context.SaveChanges();
            }
        }

        public static SubCategory SearchSubCategory(ApplicationDbContext context, int subCategoryId)
        {
            return context.SubCategorys.Find(subCategoryId);
        }

        public static void AddSubCategory(ApplicationDbContext context, SubCategory subCategory)
        {
            context.SubCategorys.Add(subCategory);
            context.SaveChanges();
        }

        public static void EditSubCategory(ApplicationDbContext context, SubCategory subCategory)
        {
            context.SubCategorys.Update(subCategory);
            context.SaveChanges();
        }

        public static void DeleteSubCategory(ApplicationDbContext context, int subCategoryId)
        {
            var subCategory = context.SubCategorys.Find(subCategoryId);
            if (subCategory != null)
            {
                context.SubCategorys.Remove(subCategory);
                context.SaveChanges();
            }
        }

        public static void UpdateBookStatus(ApplicationDbContext context, int bookId, string status)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                book.BookState.StatusName = status;
                context.SaveChanges();
            }
        }
    }
}
