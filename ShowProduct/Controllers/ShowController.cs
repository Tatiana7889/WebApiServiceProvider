﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using ShowProduct.Repository;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ShowProduct.Controllers
{ 
    public class ShowController : Controller
    {
        // GET: Product  
        public ActionResult GetAllProducts()
        {
            try
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/showroom/getallproducts");
                    response.EnsureSuccessStatusCode();
                    List<Models.Product> products = response.Content.ReadAsAsync<List<Models.Product>>().Result;
                    ViewBag.Title = "All Products";
                    return View(products);
                }
                catch (Exception)
                {
                    throw;
                }
           
           
        }
        //[HttpGet]  
        public ActionResult EditProduct(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/showroom/GetProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            var products =  response.Content.ReadAsStringAsync().Result;
            ViewBag.Title = "All Products";
            return View(products);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/showroom/UpdateProduct", product);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/showroom/GetProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            var products = response.Content.ReadAsStringAsync().Result;
            ViewBag.Title = "All Products";
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/showroom/InsertProduct", product);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/showroom/DeleteProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
    }  
} 