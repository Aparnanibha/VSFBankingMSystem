using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSFBankingSystem.Models;

namespace BankingManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BankingManagementContext db;

        public DashboardController(BankingManagementContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statements()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Statements(DateTime From, DateTime To)
        {
            var res1 = (from t in db.TransactionDetails
                       join c in db.CustomerAccs
                       on t.AccountNumber equals c.AccountNumber
                       join cu in db.Customers
                       on c.CustomerId equals cu.CustomerId
                       where t.TransactionDate >= From && t.TransactionDate <= To
                        select new StatementVM{
                //AccountNumber = t.AccountNumber,
                //Name = c.Customer.FirstName,
                //AccountType = t.TransactionType,
                //Balance = c.TotalBalance
                transactionDetail = t,
                customerAcc = c,
                customer = cu
            }).ToList();

            return View(res1);
        }

        public IActionResult AccountSummary()
        {
            //List<CustomerAcc> customerAccs = _db.CustomerAccs.ToList();
            var result = (from details in db.CustomerAccs
                          where details.CustomerId == "1001"
                          select details).ToList();
            return View(result);
        }
        public IActionResult AccountDetails()
        {
            //List<TransactionDetail> transactionDetails = _db.TransactionDetails.ToList();
            var result = (from details in db.TransactionDetails
                          where details.AccountNumber == 200106300808
                          select details).ToList();
            return View(result);
        }

        public IActionResult Payee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payee(AddPayee addPayee)
        {
            if (ModelState.IsValid)
            {
                db.AddPayees.Add(new AddPayee
                {
                    BeneficiaryAccountNumber = addPayee.BeneficiaryAccountNumber,
                    AccountNumber = addPayee.AccountNumber,
                    BeneficiaryName = addPayee.BeneficiaryName,
                    NickName = addPayee.NickName,
                });
                // db.AddPayees.Add(addPayee);
                db.SaveChanges();
                return RedirectToAction("Index", "FundTransfer");
            }
            return View();
        }
    }
}
