using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class SubCategory
    {
        // Properties
        [Key]
        public int SubcategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string? SubcategoryName { get; set; }

        // Foreign Key
        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }
        public MainCategory ?MainCategory { get; set; }

        // Constructor
        public SubCategory(string subcategoryName, int mainCategoryId)
        {
            SubcategoryName = subcategoryName;
            MainCategoryId = mainCategoryId;
        }

        // Methods
        public void AddSubCategory(ApplicationDbContext context, SubCategory subCategory)
        {
            context.SubCategories.Add(subCategory);
            context.SaveChanges();
            Console.WriteLine("Subcategory added successfully.");
        }

        public void EditSubCategory(ApplicationDbContext context, SubCategory subCategory)
        {
            var existingSubCategory = context.SubCategories.Find(subCategory.SubcategoryId);
            if (existingSubCategory != null)
            {
                existingSubCategory.SubcategoryName = subCategory.SubcategoryName;
                context.SaveChanges();
                Console.WriteLine("Subcategory updated successfully.");
            }
            else
            {
                Console.WriteLine("Subcategory not found.");
            }
        }

        public void DeleteSubCategory(ApplicationDbContext context, int subCategoryId)
        {
            var subCategory = context.SubCategories.Find(subCategoryId);
            if (subCategory != null)
            {
                context.SubCategories.Remove(subCategory);
                context.SaveChanges();
                Console.WriteLine("Subcategory deleted successfully.");
            }
            else
            {
                Console.WriteLine("Subcategory not found.");
            }
        }

        public void ViewSubCategories(SubCategory subCategory)
        {
            Console.WriteLine($"Subcategory ID: {subCategory.SubcategoryId}");
            Console.WriteLine($"Subcategory Name: {subCategory.SubcategoryName}");
        }
    }
}
