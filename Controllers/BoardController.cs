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
        public ActionResult Index(int page = 1)
        {
            if(Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            using(HealthJangDbContext db = new HealthJangDbContext())
            {
                // 페이징 처리 추가
                int perPost = 5;
                int perPage = 5;
                int totalPost = db.Boards.ToList().Count();
                int totalPage = totalPost % perPost == 0 ? totalPost / perPost : totalPost / perPost + 1;

                int startPage = ((page-1) / perPage) * perPage + 1;
                int endPage = (((page - 1) / perPage + 1) * perPage) > totalPage ? totalPage : (((page - 1) / perPage + 1) * perPage);

                ViewBag.startPage = startPage;
                ViewBag.endPage = endPage;
                ViewBag.prev = startPage == 1 ? false : true;
                ViewBag.next = endPage == totalPage ? false : true;

                List <Board> list = db.Boards
                    .Include(m => m.User)
                    .OrderByDescending(m => m.BoardNo)
                    .Skip((page-1)*perPage)
                    .Take(perPage)
                    .ToList();       
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

        [ValidateInput(false)] // HTML 내용 받기 위해 사용
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
                using (HealthJangDbContext db = new HealthJangDbContext())
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

            ViewBag.sessionUserNo = int.Parse(Session["USER_LOGIN_KEY"].ToString());

            using (HealthJangDbContext db = new HealthJangDbContext())
            {
                Board board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(id));
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

            int sessionUserNo = int.Parse(Session["USER_LOGIN_KEY"].ToString());

            using (HealthJangDbContext db = new HealthJangDbContext())
            {
                Board board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(id));
                if(sessionUserNo != board.UserNo)
                {
                    return Content("<script> alert('접근 오류!'); location.href = '/Board'; </script>");
                }
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
                using (HealthJangDbContext db = new HealthJangDbContext())
                {
                    Board board = db.Boards.FirstOrDefault(m => m.BoardNo.Equals(model.BoardNo));

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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (Session["USER_LOGIN_KEY"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using(HealthJangDbContext db = new HealthJangDbContext())
            {
                Board board = db.Boards.Find(id);
                db.Boards.Remove(board);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}