using HealthJang.DAL;
using HealthJang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthJang.Controllers
{
    public class BoardController : Controller
    {
        /// <summary>
        /// 게시글 목록
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if(Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            using(var db = new HealthJangDbContext())
            {
                var list = db.Boards.ToList();       
                return View(list);
            }
            
        }


        /// <summary>
        /// 게시글 추가
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(Board model)
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(Session["USER_LOGIN_KEY"].ToString());

            if (ModelState.IsValid)
            {
                using (var db = new HealthJangDbContext())
                {
                    db.Boards.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// 게시글 상세보기
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = new HealthJangDbContext())
            {
                var board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(id));
                return View(board);
            }

        }

        /// <summary>
        /// 게시글 수정
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = new HealthJangDbContext())
            {
                var board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(id));
                return View(board);
            }

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Board model)
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                using (var db = new HealthJangDbContext())
                {
                    var board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(model.BoardNo));

                    board.BoardTitle = model.BoardTitle;
                    board.BoardContents = model.BoardContents;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(model);

        }

        /// <summary>
        /// 게시글 삭제
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}