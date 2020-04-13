using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testapp.Database;
using testapp.Core;

namespace testapp.Pages.XNAV
{
    public class ProductDeleteModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IProductAttributesData productAttributesData;

        public Product Product { get; set; }
        public ProductAttributes ProductAttributes { get; set; }

        public ProductDeleteModel(IProductData productData, IProductAttributesData productAttributesData)
        {
            this.productData = productData;
            this.productAttributesData = productAttributesData;
        }
        public IActionResult OnGet(int productId)
        {
            Product = productData.GetById(productId);
            if(Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int productId)
        {
            var product = productData.Delete(productId);
            var productAttribute = productAttributesData.DeleteProduct(productId);
            productData.Commit();
            productAttributesData.Commit();

            if(product == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{product.Manufacturer} {product.Model} deleted";
            return RedirectToPage("./List");
        }
    }
}