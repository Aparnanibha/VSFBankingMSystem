using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingManagementSystem.Models
{
    public partial class RegisterNetBanking
    {
        [Required]
        [Display(Name = "Account Number")]
        public decimal AccountNumber { get; set; }

        [Display(Name = "UserId")]
        public string? CustomerId { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Passwordd { get; set; }

        [NotMapped]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Passwordd", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Transaction Password")]
        [DataType(DataType.Password)]
        public string? TransactionPassword { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Transaction password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("TransactionPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string? ConTransactionPassword { get; set; }

        public virtual CustomerAcc AccountNumberNavigation { get; set; } = null!;
    }
}
