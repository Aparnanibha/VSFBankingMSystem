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
    }
}
