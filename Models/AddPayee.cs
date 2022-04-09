using BankingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSFBankingSystem.Models
{
    public partial class AddPayee
    {
        [Key]
        [Display(Name ="Beneficiary Account Number")]
        public decimal BeneficiaryAccountNumber { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Beneficiary Account Number")]
        [Required(ErrorMessage = "Please re-enter account number")]
        [Compare("BeneficiaryAccountNumber", ErrorMessage = "Account Number doesn't match, Type again !")]
        public decimal ReBenfAccNo { get; set; }

        [Display(Name ="Account Number")]
        public decimal? AccountNumber { get; set; }

        [Display(Name ="Beneficiary Name")]
        public string? BeneficiaryName { get; set; }

        [Display(Name ="Nick Name")]
        public string? NickName { get; set; }

        public virtual CustomerAcc? AccountNumberNavigation { get; set; }
    }
}
