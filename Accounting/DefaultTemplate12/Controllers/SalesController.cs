using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using DefaultTemplate12.ViewModels;
using DefaultTemplate12.Models;
namespace DefaultTemplate12.Controllers
{
    public class SalesController : Controller
    {
        private AccountingContext db = new AccountingContext();
        //
        // GET: /Sales/
        public ActionResult Index(int? OrderID)
        {
            var viewmodel = new Sales();
            viewmodel.Orders = db.Orders.Include(o => o.OrderDetails);
            

            if (OrderID != null) {
                viewmodel.OrderDetails = db.OrderDetails.Include(p => p.Product).Where(p => p.OrderID == OrderID);
            }

            return View(viewmodel);
        }

        //
        // GET: /Sales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
