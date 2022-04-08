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
            List<Registration> registrationList = db.Registrations.ToList();
            return View(registrationList);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(reg);
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
                var obj = db.Registrations.Where(u => u.Id.Equals(login.UserId) &&
                u.password.Equals(login.Password)).FirstOrDefault();
                if (obj != null)
                {
                    TempData["username"] = obj.Id.ToString();
                    TempData["password"] = obj.password.ToString();
                    return RedirectToAction("Index", "Dashboard");
                    //HttpContext.Session.SetString("uid", obj.Id);
                }
				else
				{
                    ModelState.AddModelError("Failure", "Wrong UserId and Password combination !");
                    return RedirectToAction("Index");
				}
            }
            return View();
        }

        public IActionResult Dashboard()
		{
            return View();
		}
    }
}
