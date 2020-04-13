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
    public class AttributeDetailsModel : PageModel
    {
        private readonly IAttributeData attributeData;
        private readonly IProductAttributesData productAttributesData;
        private readonly IProductData productData;

        public Core.Attribute Attribute { get; set; }
        public IEnumerable<Product> ProductsAttributes { get; set; }

        public AttributeDetailsModel(IAttributeData attributeData, IProductAttributesData productAttributesData, IProductData productData)
        {
            this.attributeData = attributeData;
            this.productAttributesData = productAttributesData;
            this.productData = productData;
        }

        public IActionResult OnGet(int attributeId)
        {
            Attribute = attributeData.GetById(attributeId);
            ProductsAttributes = productAttributesData.ProductsByAttribute(attributeId);
            if(Attribute == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }
    }
}