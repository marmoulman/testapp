using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testapp.Core;
using testapp.Database;

namespace testapp.Pages.XNAV
{

    public class DetailsModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IProductAttributesData productAttributesData;

        public Product Product { get; set; }
        public IEnumerable<Core.Attribute> ProductsAttributes { get; set; }

        public DetailsModel(IProductData productData, IProductAttributesData productAttributesData)
        {
            this.productData = productData;
            this.productAttributesData = productAttributesData;
        }

        public IActionResult OnGet(int productId)
        {
            Product = productData.GetById(productId);
            ProductsAttributes = productAttributesData.AttributesByProduct(productId);
            if(Product == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}