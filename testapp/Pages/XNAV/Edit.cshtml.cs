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
    public class EditModel : PageModel
    {
        private readonly IAttributeData attributeData;
        private readonly IProductAttributesData productAttributesData;
        private readonly IProductData productData;

        [BindProperty]
        public Product Product { get; set; }
        public Core.Attribute Attribute { get; set; }
        public ProductAttributes ProductAttributes { get; set; }


        public EditModel(IAttributeData attributeData, IProductAttributesData productAttributesData, IProductData productData)
        {
            this.attributeData = attributeData;
            this.productAttributesData = productAttributesData;
            this.productData = productData;
        }

        public IProductData ProductData { get; }

        public IActionResult OnGet(int? productId)
        {
            if(productId.HasValue)
            {
                Product = productData.GetById(productId.Value);
            }
            else
            {
                Product = new Product();
            }

            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Product.Id > 0)
            {
                Product = productData.Update(Product);
            }
            else
            {
                productData.Add(Product);
            }

            productData.Commit();
            TempData["Message"] = "Product saved!";
            return RedirectToPage("./Details", new { productId = Product.Id });
        }
    }
}