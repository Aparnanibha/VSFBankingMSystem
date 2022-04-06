using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Models
{
    public partial class AddPayee1
    {
        public decimal BeneficiaryAccountNumber { get; set; }
        public decimal AccountNumber { get; set; }
        public string? BeneficiaryName { get; set; }
        public string? NickName { get; set; }
    }
}
