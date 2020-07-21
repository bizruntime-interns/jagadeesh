using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testing_log_asp.net.Models;

namespace testing_log_asp.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly Iuser _iusr;
        private readonly ConnectionStringClass _cc;

        public HomeController(Iuser iuser, ConnectionStringClass cc)
        {
            _iusr = iuser;
            _cc = cc;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(login ll)
        {

          bool c=  _iusr.Get(ll.Name);
                if (c)
                {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append("user", ll.Name, cookie);
                    TempData["user"] = ll.Name;
                    return RedirectToAction("Index1");
                    // return RedirectToAction("HomeController", "Index1",new { id=1});

                }
                else
                {
                    return View();
                }


        }
        [HttpGet]
        public IActionResult Index1()
        {
            ViewBag.mess = Request.Cookies["user"];
          
            return View();
        }

        [HttpPost]
        public IActionResult Index1(login ll)
        {
            bool c = _iusr.Get1(ll.Password,Request.Cookies["user"]);
            if (c)
            {
                TempData["pass"] = ll.Password;

                return RedirectToAction("Index2");
            }
            else
            {
                ViewBag.mess = "incorrect";
                return View();
            }
        }
    }

}

