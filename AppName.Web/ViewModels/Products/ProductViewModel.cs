using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppName.Web.Resources;

namespace AppName.Web.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name",
            ResourceType = typeof(ProductResources))]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Price",
            ResourceType = typeof(ProductResources))]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}