using System;
using System.ComponentModel.DataAnnotations;

namespace Contact_Manager.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string Organization { get; set; }


        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}
