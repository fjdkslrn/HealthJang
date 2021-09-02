using HealthJang.DAL;
using HealthJang.Models;
using HealthJang.ViewModels;
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

        /// <summary>
        /// 실무에서는 쿠키로 주로 하기때문에 변경필요!?
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
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
                        HttpContext.Session.Add("USER_LOGIN_KEY", user.UserNo.ToString());
                        return RedirectToAction("Index", "Board");
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "로그인 불가");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
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