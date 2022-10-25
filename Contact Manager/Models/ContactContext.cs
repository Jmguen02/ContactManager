using Microsoft.EntityFrameworkCore;
using System;

namespace Contact_Manager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Manager> Managers { get; set; } 
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager {
                    ManagerId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "8591112234",
                    Email = "john.doe@gmail.com",
                    CategoryId = "1",
                    Organization = "Google",
                },
                new Manager
                {
                    ManagerId = 2,
                    FirstName = "Joe",
                    LastName = "Burrow",
                    PhoneNumber = "5131234567",
                    Email = "joe.burrow@gmail.com",
                    CategoryId = "2",
                    Organization = "Cincinnati Bengals",
                }
           );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "1", Name = "Friend" },
                new Category { CategoryId = "2", Name = "Work" },
                new Category { CategoryId = "3", Name = "Family" }
           );
        }
    }
}
