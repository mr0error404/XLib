using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consoleXLib
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(60)]
        public string SubcategoryName { get; set; }

        public Role(int roleId, string subcategoryName)
        {
            RoleId = roleId;
            SubcategoryName = subcategoryName;
        }

        public void AssignRole(ApplicationDbContext context, int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.RoleId = RoleId;
                context.SaveChanges();
                Console.WriteLine("Role assigned successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void RevokeRole(ApplicationDbContext context, int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.RoleId = 0; // Assuming 0 or a specific RoleId means no role assigned
                context.SaveChanges();
                Console.WriteLine("Role revoked successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void EditRole(ApplicationDbContext context, string newSubcategoryName)
        {
            SubcategoryName = newSubcategoryName;
            context.Roles.Update(this);
            context.SaveChanges();
            Console.WriteLine("Role updated successfully.");
        }
    }
}
