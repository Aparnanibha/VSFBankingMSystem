using BankingManagementSystem.Data;
using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (ModelState.IsValid)
            {
                db.RegisterNetBankings.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error Occured");
            }
            return View(reg);
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
            return RedirectToAction("Index");
        }

    }
}
