using HealthJang.DAL;
using HealthJang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthJang.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index()
        {
            using(HealthJangDbContext db = new HealthJangDbContext())
            {
                List<Product> products = db.Products.ToList();
                return View(products);
            }
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult Order(string orderNo)
        {
            return View();
        }

    }
}