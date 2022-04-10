using System;
using System.Collections.Generic;
using VSFBankingSystem.Models;

namespace BankingManagementSystem.Models
{
    public partial class CustomerAcc
    {
        public CustomerAcc()
        {
            AddPayees = new HashSet<AddPayee>();
            RegisterNetBankings = new HashSet<RegisterNetBanking>();
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public decimal AccountNumber { get; set; }
        public string? Status { get; set; }
        public string? CustomerId { get; set; }
        public decimal TotalBalance { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<AddPayee> AddPayees { get; set; }
        public virtual ICollection<RegisterNetBanking> RegisterNetBankings { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
