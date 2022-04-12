using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingManagementSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAccs = new HashSet<CustomerAcc>();
        }

        public string CustomerId { get; set; } = null!;

       // [Required]
        [Range(1, 16, ErrorMessage = "First name is too short or too long! Please Enter Valid Details")]
        [Display(Name = "Enter Your First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Enter Your Middle Name")]
        public string? MiddleName { get; set; }

       // [Required]
        [Display(Name = "Enter Your Last Name")]
        [Range(1, 16, ErrorMessage = "Last name is too short or too long! Please enter valid details")]
        public string? LastName { get; set; }

        [Display(Name = "Enter Your Father's Full Name")]
        public string? FathersName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter valid Phone Number")]
        [Display(Name = "Enter your Phone number without Code")]
        public string? MobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter your Email Address")]
        public string? EmailId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enter your Date of Birth")]
      //  [Required]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Enter your Residential Address")]
       // [Required]
        public string? ResidentialAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Enter your Permanent Address")]
        //[Required]
        public string? PermanentAddress { get; set; }

       // [Required]
        [Display(Name = "Occupation Type")]
        public string? OccupationType { get; set; }

       // [Required]
        [Display(Name = "Source of Income")]
        public string? SourceOfIncome { get; set; }

       // [Required]
        [Display(Name = "Gross Annual Income")]
        public decimal? GrossAnnualIncome { get; set; }

        [Display(Name = "Do you want Debit Card?(Yes/No)")]
       // [Required]
        public string? IsDebitCardRequired { get; set; }

        [Display(Name = "Do you want to enable NetBanking?(Yes/No)")]
      //  [Required]
        public string? EnableNetBanking { get; set; }

       // [Required]
        [Display(Name = "Enter your Aadhar Card Number")]
        public string? AadharNumber { get; set; }

        public virtual ICollection<CustomerAcc> CustomerAccs { get; set; }
    }
}
