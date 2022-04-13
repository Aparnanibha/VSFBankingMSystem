using BankingManagementSystem.Data;
using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Controllers
{
    [Route("User/[action]")]
    public class UserLoginController : Controller
    {
        private readonly BankingManagementContext db;

        public UserLoginController(BankingManagementContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            // List<Registration> registrationList = db.Registrations.ToList();
            List<RegisterNetBanking> registrationList = db.RegisterNetBankings.ToList();
            return View(registrationList);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterNetBanking reg)
        {
            RegisterNetBanking temp = new RegisterNetBanking();
            var accsList = (from acc in db.CustomerAccs
                            where acc.AccountNumber == reg.AccountNumber
                            where acc.CustomerId == reg.CustomerId.ToString()
                            select acc).FirstOrDefault();
            if (accsList.AccountNumber == reg.AccountNumber && accsList.CustomerId == reg.CustomerId.ToString())
            {
                temp.AccountNumber = reg.AccountNumber;
                temp.CustomerId = reg.CustomerId;
                temp.Passwordd = reg.Passwordd;
                temp.TransactionPassword = reg.TransactionPassword;

                db.RegisterNetBankings.Add(temp);
                db.SaveChanges();
                //Redirect to Login page
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var obj = db.RegisterNetBankings.Where(u => u.CustomerId.Equals(login.UserId) &&
                u.Passwordd.Equals(login.Password)).FirstOrDefault();
                if (obj != null)
                {
                    
                    TempData["username"] = obj.CustomerId.ToString();
                    TempData["password"] = obj.Passwordd.ToString();
                    return RedirectToAction("Index", "Dashboard");
                    HttpContext.Session.SetString("username", obj.CustomerId);
                }
				else
				{
                    ModelState.AddModelError("Login", "Wrong UserId and Password combination !");
                    return RedirectToAction("Index");
				}
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
           // return RedirectToAction("logout");
           return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(LoginVM loginVM)
        {
            try
            {
                var obj = db.RegisterNetBankings.Where(u => u.CustomerId == loginVM.UserId).FirstOrDefault();
                obj.Passwordd = loginVM.Password;
                db.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            catch (DbUpdateConcurrencyException)
            {
                return View();
            }
        }

    }
}
