using HealthJang.DAL;
using HealthJang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthJang.Controllers
{
    public class AccountController : Controller
    {

        //private HealthJangDbContext db = new HealthJangDbContext();

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new HealthJangDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserID.Equals(model.UserID) &&
                    u.UserPassword.Equals(model.UserPassword));

                    if(user != null)
                    {
                        // 로그인 성공
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "로그인 불가");
            }

            return View(model);
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new HealthJangDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}