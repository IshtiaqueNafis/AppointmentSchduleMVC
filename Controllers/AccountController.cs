using System.Threading.Tasks;
using AppointmentSchduleMVC.Models;
using AppointmentSchduleMVC.Models.ViewModels;
using AppointmentSchduleMVC.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchduleMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db; // this gives connection to database 
        UserManager<ApplicationUser> _userManager; //manages user thus creates user 
        SignInManager<ApplicationUser> _signInManager; // signs in and signs out user 

        RoleManager<IdentityRole> _roleManager; //this for role such as admin,doctor and patient 
        // note that <ApplicationUser> is a custom user class is being used to register user and log in user 


        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Logs IN USER Get

        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region Logs IN USER Post

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                // model.RememberMe --> it will save cookie when the browser closes. 
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "invalid log in attempt");
            }

            return View(model);
        }

        #endregion


        #region Register USER GET

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())

                #region !_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult()) Explaniend

                /* !_roleManager.RoleExistsAsync(Helper.Admin) --> this checks whether or not admin role exisits or not. 
                 * GetAwaiter() --> means await for the data
                 * --> GetResult() get the result 
                 */

                #endregion

            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Patient));
            }

            return View();
        }

        #endregion


        #region Register User Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                };
                var result = await _userManager.CreateAsync(user, model.Password); // this creates a user  password is needed 

                if (result.Succeeded) // means nothing went wrong 
                {
                    await _userManager.AddToRoleAsync(user,
                        model.RoleName); // user needs to be passed to pass the user details, Model.RoleName is used for what role did the user choose. 
                    await _signInManager.SignInAsync(user, isPersistent: false); // this signs the user in. 

                    return RedirectToAction("Index", "Home"); // if its sucessful return there. 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",
                        error.Description); // adds error to check if there is any error at all. 
                }
            }

            return View(model);
        }

        #endregion


        #region Log OFF

        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}