using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class MainCategory
    {
        // Properties
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        // Navigation property for subcategories
        public virtual ICollection<SubCategory> SubCategories { get; set; }

        // Constructor
        public MainCategory(int categoryId, string? categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            SubCategories = new List<SubCategory>();
        }

        // Methods
        public void AddMainCategory(ApplicationDbContext context, MainCategory mainCategory)
        {
            context.MainCategories.Add(mainCategory);
            context.SaveChanges();
            Console.WriteLine("Main category added successfully.");
        }

        public void EditMainCategory(ApplicationDbContext context, MainCategory mainCategory)
        {
            var existingMainCategory = context.MainCategories.Find(mainCategory.CategoryId);
            if (existingMainCategory != null)
            {
                existingMainCategory.CategoryName = mainCategory.CategoryName;
                context.SaveChanges();
                Console.WriteLine("Main category updated successfully.");
            }
            else
            {
                Console.WriteLine("Main category not found.");
            }
        }

        public void DeleteMainCategory(ApplicationDbContext context, int categoryId)
        {
            var mainCategory = context.MainCategories.Find(categoryId);
            if (mainCategory != null)
            {
                // Check if there are any subcategories before deletion
                if (mainCategory.SubCategories.Count > 0)
                {
                    Console.WriteLine("Cannot delete main category with subcategories. Delete the subcategories first.");
                    return;
                }

                context.MainCategories.Remove(mainCategory);
                context.SaveChanges();
                Console.WriteLine("Main category deleted successfully.");
            }
            else
            {
                Console.WriteLine("Main category not found.");
            }
        }

        public void ViewMainCategory(MainCategory mainCategory)
        {
            Console.WriteLine($"Main Category ID: {mainCategory.CategoryId}");
            Console.WriteLine($"Main Category Name: {mainCategory.CategoryName}");
        }
    }
}
