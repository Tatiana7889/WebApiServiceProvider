using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static eCommerceEntities DbContext;
        static DAL()
        {
            DbContext = new eCommerceEntities();
           
        }
        public static List<Nop_Product> GetAllProducts()
        {
            return DbContext.Nop_Product.ToList();
        }
        public static Nop_Product GetProduct(int productId)
        {
            return DbContext.Nop_Product.Where(p => p.ProductId == productId).FirstOrDefault();
        }
        public static bool InsertProduct(Nop_Product productItem)
        {
            bool status;
            try
            {
                DbContext.Nop_Product.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            } 
            return status;
        }
        public static bool UpdateProduct(Nop_Product productItem)
        {
            bool status;
            try
            {
               var  prodItem = DbContext.Nop_Product.Where(p => p.ProductId == productItem.ProductId).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.Name = productItem.Name;
                    prodItem.ShortDescription = productItem.ShortDescription;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Nop_Product prodItem = DbContext.Nop_Product.Where(p => p.ProductId == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.Nop_Product.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
      
    }
}
