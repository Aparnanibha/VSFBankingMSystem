using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BankingManagementSystem.Controllers
{
    public class FundTransferController : Controller
    {
        private readonly BankingManagementContext db;

        public FundTransferController(BankingManagementContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentNEFT()
        {
            //var accs = (from acc in _db.CustomerAccs
            //            where acc.CustomerId == "1001"
            //            where acc.Status.Contains("Approved")
            //            select acc).ToList();
            //var payeelist = (from payees in db.AddPayees
            //                 where payees.AccountNumber == 200106300808
            //                 select payees).ToList();
            var accs = new SelectList(db.CustomerAccs.Where(s => s.Status == "Approved"), "AccountNumber", "AccountNumber");
            var payeelist = new SelectList(db.AddPayees, "AccountNumber", "AccountNumber");


            ViewBag.Payees = payeelist;
            ViewBag.Accs = accs;
            return View();
        }

        public static string GenerateRandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        [HttpPost]
        public IActionResult PaymentNEFT(TransactionDetail transaction)
        {
            TransactionDetail td = new TransactionDetail();
            td.AccountNumber = transaction.AccountNumber;
            td.DebitCredit = "Debit";
            td.ToAccountNumber = transaction.ToAccountNumber;
            td.TransactionDate = System.DateTime.Now;
            td.Maturityinstruct = transaction.Maturityinstruct;
            td.TransactionType = "NEFT";
            td.Amount = transaction.Amount;
            td.TransactionId = GenerateRandomString(12);
            db.TransactionDetails.Add(td);
            (from customer in db.CustomerAccs
             where customer.AccountNumber == transaction.ToAccountNumber
             select customer).ToList().ForEach(x => x.TotalBalance = x.TotalBalance + transaction.Amount ?? 0);

            (from customer in db.CustomerAccs
             where customer.AccountNumber == transaction.AccountNumber
             select customer).ToList().ForEach(x => x.TotalBalance = x.TotalBalance - transaction.Amount ?? 0);


            db.SaveChanges();
            return View("Index");

        }
        public IActionResult Payment()
		{
            ViewData["CAccs"] = new SelectList(db.CustomerAccs.Where(s => s.Status== "Approved"), "AccountNumber", "AccountNumber");
            ViewData["Payees"] = new SelectList(db.AddPayees, "AccountNumber", "AccountNumber");

            return View();
        }

  //          data1.TotalBalance += transaction.Amount??1;
  //          int ms = db.SaveChanges();
  //          if(ms > 0)
  //          {
  //              ViewBag.data1 = "Deposited";
  //          }
  //          else
  //          {
  //              ViewBag.data1 = "Not deposited";
  //          }

        [HttpPost]
        public IActionResult Payment(TransactionDetail transaction)
		{
            if (transaction.AccountNumber != transaction.ToAccountNumber)
            {
                //Transfer(transaction);
                var fromAccount = db.CustomerAccs.Include(x => x.TransactionDetails).First(x => x.AccountNumber == transaction.AccountNumber);
                decimal amount = transaction.Amount ?? 0;

                if (transaction.Amount <= fromAccount.TotalBalance)
                {
                    fromAccount.TotalBalance -= amount;
                    db.Update(fromAccount);
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Amount", "Insufficient Ammount to transfer");
                    return View();
                }

                var toAccount = db.CustomerAccs.Include(x => x.TransactionDetails).First(x => x.AccountNumber == transaction.ToAccountNumber);
                toAccount.TotalBalance += transaction.Amount ?? 0;
                db.Update(toAccount);
                db.SaveChanges();


                db.TransactionDetails.Add(new TransactionDetail
                {
                    TransactionId = GenerateRandomString(12),
                    TransactionType = "IMPS",
                    ToAccountNumber = transaction.ToAccountNumber,
                    AccountNumber = transaction.AccountNumber,
                    Maturityinstruct = transaction.Maturityinstruct,
                    TransactionDate = transaction.TransactionDate,
                    DebitCredit = "Credit",
                    Amount = transaction.Amount,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			else
			{
                ModelState.AddModelError("ToAccountNumber", "Source and destination account should be different");
                return View();
			}
        }

        [HttpGet]
        public IActionResult PaymentRTGS()
        {
            var accs = new SelectList(db.CustomerAccs.Where(s => s.Status == "Approved"), "AccountNumber", "AccountNumber");
            var payeelist = new SelectList(db.AddPayees, "AccountNumber", "AccountNumber");

            ViewBag.Payees = payeelist;
            ViewBag.Accs = accs;
            return View();
        }
        [HttpPost]
        public IActionResult PaymentRTGS(TransactionDetail transaction)
        {
            TransactionDetail td = new TransactionDetail();
            td.AccountNumber = transaction.AccountNumber;
            td.DebitCredit = "Debit";
            td.ToAccountNumber = transaction.ToAccountNumber;
            td.TransactionDate = System.DateTime.Now;
            td.Maturityinstruct = transaction.Maturityinstruct;
            td.TransactionType = "RTGS";
            td.Amount = transaction.Amount;
            td.TransactionId = GenerateRandomString(12);
            db.TransactionDetails.Add(td);
            (from customer in db.CustomerAccs
             where customer.AccountNumber == transaction.ToAccountNumber
             select customer).ToList().ForEach(x => x.TotalBalance = x.TotalBalance + transaction.Amount ?? 0);

            (from customer in db.CustomerAccs
             where customer.AccountNumber == transaction.AccountNumber
             select customer).ToList().ForEach(x => x.TotalBalance = x.TotalBalance - transaction.Amount ?? 0);


            db.SaveChanges();
            return View("Index");
        }
    }
}
