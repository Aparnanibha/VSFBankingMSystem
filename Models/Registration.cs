using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingManagementSystem.Models
{
    public partial class Registration
    {
        [Key]
        [Display(Name ="UserId")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="TransPass")]
        [DataType(DataType.Password)]
        public string TransactionPassword { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Transaction password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("TransactionPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConTransactionPassword { get; set; }

    }
}
