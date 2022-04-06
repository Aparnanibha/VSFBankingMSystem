using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Models
{
    public partial class TransactionDetail
    {
        public string TransactionId { get; set; } = null!;
        public string? TransactionType { get; set; }
        public decimal? ToAccountNumber { get; set; }
        public decimal? AccountNumber { get; set; }
        public string? Maturityinstruct { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual CustomerAcc? AccountNumberNavigation { get; set; }
    }
}
