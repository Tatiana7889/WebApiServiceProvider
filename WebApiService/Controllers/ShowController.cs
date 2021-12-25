using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using DataAccessLayer;

namespace WebApiService.Controllers
{
    public class ShowController : Controller
    {
        DataAccessLayer.eCommerceEntities db = null;
        // GET: Blog
        public ShowController()
        {
            db = new DataAccessLayer.eCommerceEntities();
        }
        public ActionResult Index()
        {
            var categories = db.Nop_Product.ToList().Take(10);
            List<Models.Product> listProduct = new List<Models.Product>();
                       
            foreach (var c in categories)
            {
                var deliveryModel = new Models.Product();
                deliveryModel.ProductId = c.ProductId;
                deliveryModel.Name= c.Name;
                deliveryModel.ShortDescription= c.ShortDescription;
                listProduct.Add(deliveryModel);
               
            }
         
            return View(listProduct);
           
        }
    

        // GET: Show/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Show/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Show/Create
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

        // GET: Show/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Show/Edit/5
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

        // GET: Show/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Show/Delete/5
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
