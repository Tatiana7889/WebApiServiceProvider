using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowProduct.Models
{

        public class Product
        {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AdminComment { get; set; }
        public int ProductTypeID { get; set; }
        public int TemplateID { get; set; }
        public bool ShowOnHomePage { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool AllowCustomerRatings { get; set; }
        public int RatingSum { get; set; }
        public int TotalRatingVotes { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
 }
