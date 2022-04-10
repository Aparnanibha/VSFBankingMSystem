using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly BankingManagementContext db;

        public UserProfileController(BankingManagementContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            //var details = (from c in db.Customers
            //              where c.CustomerId == "1001"
            //              select c).FirstOrDefault();
            var d = from x in db.RegisterNetBankings
                    join y in db.CustomerAccs
                    on x.AccountNumber equals y.AccountNumber
                    join z in db.Customers
                    on y.CustomerId equals z.CustomerId
                    where x.CustomerId == "1001"
                    select new StatementVM
                    {
                        registerNetBanking = x,
                        customerAcc = y,
                        customer = z,
                    };

            return View(d);
        }

        [HttpGet]
        public IActionResult ChangePassword(string id)
        {
            var accs = (from acc in db.CustomerAccs
                        where acc.CustomerId == "1001"
                        where acc.Status.Contains("Approved")
                        select acc).ToList();
            var register = db.RegisterNetBankings.Where(model => model.CustomerId == id).FirstOrDefault();
            //var details = (from record in _db.RegisterNetBankings
            //               where record.AccountNumber == 500102300208
            //               select record).ToList();
            ViewBag.Accs = accs;
            //ViewBag.reg = register;
            //TempData["record"] = details;
            return View(register);
        }
        [HttpPost]
        public IActionResult ChangePassword(string id, [Bind(include: "AccountNumber,CustomerId,TransactionPassword,Passwordd")] RegisterNetBanking registerNetBanking)
        {
            //RegisterNetBanking temp = new RegisterNetBanking();
            //var reg = (from rcd in _db.RegisterNetBankings
            //           where rcd.AccountNumber == 500102300208
            //temp.AccountNumber = pwd.AccountNumber;
            //temp.Passwordd = pwd.Passwordd;
            //temp.TransactionPassword = reg.TransactionPassword;
            //temp.CustomerId = reg.CustomerId;
            //_db.Update(pwd);
            //_db.SaveChanges();       

            //return View("Dashboard");
            try
            {
                db.Entry(registerNetBanking).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                return View();
            }
        }
    }
}
