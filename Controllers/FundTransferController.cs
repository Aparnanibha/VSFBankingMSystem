using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //var accs = (from acc in db.CustomerAccs
            //            where acc.CustomerId == "1001"
            //            select acc).ToList();
            //var payeelist = (from payees in db.AddPayees
            //                 where payees.AccountNumber == 200106300808
            //                 select payees).ToList();
            var accs = new SelectList(db.CustomerAccs, "AccountNumber", "AccountNumber");
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
            db.SaveChanges();
            return View("Index");

        }
        public IActionResult Payment()
		{
            ViewData["AccountNumber"] = new SelectList(db.AddPayees, "AccountNumber", "AccountNumber");

            return View();
        }

      //  [HttpPost]
  //      public IActionResult Payment(TransactionDetail transaction, decimal amt)
		//{
  //          var data = db.CustomerAccs.Where(obj => obj.AccountNumber == transaction.AccountNumber).FirstOrDefault();
  //          if(amt <= data.TotalBalance)
  //          {
  //              data.TotalBalance -= amt;
  //              int mss = db.SaveChanges();
  //              if(mss > 0)
  //              {
  //                  ViewBag.data = "Withdrawl from account processed";
  //              }
  //              else
  //              {
  //                  ViewBag.data = "Not done";
  //              }
  //          }
  //          else
  //          {
  //              ViewBag.data = "Insufficient balance"; 
  //          }

  //          var data1 = db.CustomerAccs.Where(obj => obj.AccountNumber == transaction.ToAccountNumber).FirstOrDefault();
  //          data1.TotalBalance += amt;
  //          int ms = db.SaveChanges();
  //          if(ms > 0)
  //          {
  //              ViewBag.data1 = "Deposited";
  //          }
  //          else
  //          {
  //              ViewBag.data1 = "Not deposited";
  //          }

  //          db.TransactionDetails.Add(new TransactionDetail
  //          {
  //              TransactionId = "12345df",
  //              TransactionType = "IMPS",
  //              ToAccountNumber = transaction.ToAccountNumber,
  //              AccountNumber = transaction.AccountNumber,
  //              Maturityinstruct = transaction.Maturityinstruct,
  //              TransactionDate = transaction.TransactionDate,
  //              DebitCredit = "DebitCredit"
  //          });
  //          db.SaveChanges();
		//	return RedirectToAction("Index");
		//}

        
    }
}
