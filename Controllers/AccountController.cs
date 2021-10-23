using AppointmentSchduleMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchduleMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
    }
}