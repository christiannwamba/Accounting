using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Accounting.Models;

namespace Accounting.Controllers
{
    public class SalesController : Controller
    {
        private AccountingContext db = new AccountingContext();
        //
        // GET: /Sales/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomers()
        {
            var cust = from c in db.Customers select new { c.ContactName, c.CompanyName, c.CustomerID };
            return Json(cust, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerById(int id)
        {
            var cust = from c in db.Customers where c.CustomerID == id select new { c.ContactName, c.CompanyName, c.CustomerID };
            return Json(cust, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts()
        {
            var prod = from p in db.Products select new { p.ProductName, p.QuantityPerUnit, p.ReorderLevel, p.UnitInOrder, p.UnitPrice, p.UnitInStock, p.ProductID };
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(int id)
        {
            var prod = from p in db.Products where p.ProductID == id select new { p.ProductName, p.QuantityPerUnit, p.ReorderLevel, p.UnitInOrder, p.UnitPrice, p.UnitInStock, p.ProductID };
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        
        

        [HttpPost]
        public ActionResult SaveOrder(Order inputModel)
        {
            string message = string.Format("Created user '{0}' in the system.", inputModel.CustomerID);
            int orderId = 0;

            try
            {
                db.Orders.Add(inputModel);
                db.SaveChanges();
                orderId = inputModel.OrderID;
                
            }
            catch (Exception ex) {
                message = ex.ToString();
            }
            return Json(new OrderViewModel { Message = message, OrderID = orderId });
        }

        public JsonResult RemoveOrder(int id) {
            
            db.Orders.Remove(db.Orders.Find(id));
            db.SaveChanges();
            return Json("deleted", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveOrderDetail(OrderDetail inputModel)
        {
            string message = string.Format("Created user '{0}' in the system.", inputModel.OrderDetailID);
            int orderId = 0;

            try
            {
                db.OrderDetails.Add(inputModel);
                db.SaveChanges();
                orderId = inputModel.OrderDetailID;

            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            return Json(new OrderViewModel { Message = message, OrderID = orderId });
        }

        public JsonResult GetOrderDetails(int id) {

            var ord = from o in db.OrderDetails where o.OrderID == id select new { o.Product.ProductName, o.Quantity };
            return Json(ord, JsonRequestBehavior.AllowGet);
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
