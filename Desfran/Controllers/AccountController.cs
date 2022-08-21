using Desfran.Models.Entities;
using Desfran.Models.Helpers;
using Desfran.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desfran.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountInterface _account;
        private readonly RouteValueDictionary _url = new RouteValueDictionary();

        public AccountController(IAccountInterface account)
        {
            _account = account;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account account)
        {
            var obj = _account.ExistAccount(account.Email);
            if (obj == null)
            {
                if (ModelState.IsValid)
                {
                    var register = _account.Register(account);
                    HttpContext.Session.SetString("email", register.Email);
                    HttpContext.Session.SetString("username", register.Username);

                    _url.Add("icon", "success");
                    _url.Add("title", "Register And AutoLogin Successfully");

                    return RedirectToAction("Index", "Home", _url);
                }
                else
                {
                    ModelState.AddModelError("", "Error Occured! Try again!!");
                }
            }
            else
            {
                ModelState.AddModelError("", "User exists ,Please login with your password");
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account account)
        {
            var obj = _account.Login(account);
            if (obj != null)
            {
                _url.Add("icon", "success");
                _url.Add("title", "Login Successfully");

                HttpContext.Session.SetString("email", obj.Email);
                HttpContext.Session.SetString("username", obj.Username);

                return RedirectToAction("Index", "Home", _url);
            }
            else
            {
                ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(account);
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            _url.Add("icon", "success");
            _url.Add("title", "Logout Successfully");

            return RedirectToAction("Login", _url);
        }

    }
}