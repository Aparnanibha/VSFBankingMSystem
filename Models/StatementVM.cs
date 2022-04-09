namespace BankingManagementSystem.Models
{
    public class StatementVM
    {
        public CustomerAcc customerAcc { get; set; }
        public TransactionDetail transactionDetail { get; set; }
        public Customer customer { get; set; }
        public RegisterNetBanking registerNetBanking { get; set; }
    }
}
