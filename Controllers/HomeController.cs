using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace BankingManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankingManagementContext db;
        private static Random RNG = new Random();

        public HomeController(ILogger<HomeController> logger, BankingManagementContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult CreateNewAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewAccount(Customer cust)
        {
            var customers = (from acc in db.Customers
                             where acc.AadharNumber == cust.AadharNumber
                             select acc).FirstOrDefault();
            Customer temp = new Customer();
            if (customers == null)
            {
                temp.FirstName = cust.FirstName;
                temp.MiddleName = cust.MiddleName;
                temp.LastName = cust.LastName;
                temp.MobileNumber = cust.MobileNumber;
                temp.EmailId = cust.EmailId;
                temp.DateOfBirth = cust.DateOfBirth;
                temp.ResidentialAddress = cust.ResidentialAddress;
                temp.PermanentAddress = cust.PermanentAddress;
                temp.OccupationType = cust.OccupationType;
                temp.SourceOfIncome = cust.SourceOfIncome;
                temp.GrossAnnualIncome = cust.GrossAnnualIncome;
                temp.IsDebitCardRequired = cust.IsDebitCardRequired;
                temp.EnableNetBanking = cust.EnableNetBanking;
                temp.AadharNumber = cust.AadharNumber;
                temp.CustomerId = Create16DigitString();
                CustomerAcc custacc = new CustomerAcc();
                custacc.AccountNumber = Decimal.Parse(Create16DigitString());
                custacc.TotalBalance = 0;
                custacc.CustomerId = temp.CustomerId;
                custacc.Status = "pending";

                db.Customers.Add(temp);
                db.CustomerAccs.Add(custacc);

                db.SaveChanges();
                if (cust.EnableNetBanking == "Yes")
                {
                    RedirectToAction("Register", "User");
                }

                return View("index");

            }
            else
            {
                ViewBag.Message = "Oops Could not create account Either u have already registered or entered invalid details please try again";
                return View();
            }

        }

        public string Create16DigitString()
        {

            var builder = new StringBuilder();
            while (builder.Length < 11)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}