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
    public class ConnectProductModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IProductAttributesData productAttributesData;
        private readonly IAttributeData attributeData;

        public Product Product { get; set; }
        public Core.Attribute Attribute { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public ProductAttributes ProductAttributes { get; set; }

        [BindProperty]
        public bool[] IsChecked { get; set; }

        public ConnectProductModel(IProductData productData, IProductAttributesData productAttributesData, IAttributeData attributeData)
        {
            this.productData = productData;
            this.productAttributesData = productAttributesData;
            this.attributeData = attributeData;
        }
        
        public IProductAttributesData ProductAttributesData { get; set; }


        public IActionResult OnGet(int attributeId)
        {

            Attribute = attributeData.GetById(attributeId);
            Products = productData.GetProductsByName("");
            ProductAttributesData = productAttributesData;
            return Page();
        }

        [HttpPost]
        public IActionResult OnPost(int attributeId)
        {
            var i = 0;
            ProductAttributesData = productAttributesData;
            foreach(var boolean in IsChecked)
            {
                if(boolean)
                {
                    var pa = new ProductAttributes();
                    pa.AttributeId = attributeId;
                    pa.ProductId = productData.GetProductsByName("").ToList()[i].Id;
                    ProductAttributesData.Add(pa);
                    productAttributesData.Commit();

                }
                i++;
            }
            return RedirectToPage("./List");
        }
    }
}