using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingManagementSystem.Models
{
    public partial class TransactionDetail
    {
        public string TransactionId { get; set; } = null!;

        [Display(Name ="Transaction Type")]
        public string? TransactionType { get; set; }

        [Required]
        [Display(Name ="To Account")]
        public decimal? ToAccountNumber { get; set; }

        [Required,Display(Name ="From Account")]
        public decimal? AccountNumber { get; set; }

        [Required, Display(Name ="Maturity Instruction")]
        public string? Maturityinstruct { get; set; }

        [Required, Display(Name ="Transaction Date")]
        public DateTime? TransactionDate { get; set; }

        [Display(Name ="Debit/Credit")]
        public string? DebitCredit { get; set; }

        [Display(Name = "Amount (in INR)")]
        public decimal? Amount { get; set; }

        public virtual CustomerAcc? AccountNumberNavigation { get; set; }
    }
}
