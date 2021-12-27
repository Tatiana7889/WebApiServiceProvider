using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using WebApiService.Repository;
using Newtonsoft.Json;
using System.Web.Http;

namespace WebApiService.Controllers
{
    
    public class ShowroomController : ApiController
    {
        
        // GET: Showroom  
        [HttpGet]
        public JsonResult<List<Models.Product>> GetAllProducts()
        {
            EntityMapper<DataAccessLayer.Nop_Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Nop_Product, Models.Product>();
            List<DataAccessLayer.Nop_Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Product>>(products);
        }
        [HttpGet]
        public JsonResult<Models.Product> GetProduct(int id)
        {
            EntityMapper<DataAccessLayer.Nop_Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Nop_Product, Models.Product>();
            DataAccessLayer.Nop_Product dalProduct = DAL.GetProduct(id);
            Models.Product products = new Models.Product();
            products = mapObj.Translate(dalProduct);
            return Json<Models.Product>(products);
        }
        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Nop_Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Nop_Product>();
                DataAccessLayer.Nop_Product productObj = new DataAccessLayer.Nop_Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;

        }
        [HttpPut]
       
        public bool UpdateProduct(Models.Product product)
        {
            EntityMapper<Models.Product, DataAccessLayer.Nop_Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Nop_Product>();
            DataAccessLayer.Nop_Product productObj = new DataAccessLayer.Nop_Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }
    }
}