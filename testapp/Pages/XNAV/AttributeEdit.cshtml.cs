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
    public class AttributeEditModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IProductAttributesData productAttributesData;
        private readonly IAttributeData attributeData;

        public Product Product { get; set; }
        [BindProperty]
        public Core.Attribute Attribute { get; set; }
        public ProductAttributes ProductAttributes { get; set; }

        public AttributeEditModel(IProductData productData, IProductAttributesData productAttributesData, IAttributeData attributeData)
        {
            this.productData = productData;
            this.productAttributesData = productAttributesData;
            this.attributeData = attributeData;
        }
        public IActionResult OnGet(int? productId, int? attributeId)
        {
            if(attributeId.HasValue)
            {
                Attribute = attributeData.GetById(attributeId.Value);
            }
            else
            {
                Attribute = new Core.Attribute();
            }
            if (Attribute == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int? productId)     // Make sure productId gets in here OK
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Attribute.Id > 0)
            {
                Attribute = attributeData.Update(Attribute);
            }
            else
            {
                attributeData.Add(Attribute);
            }

            attributeData.Commit();
            TempData["Message"] = "Attribute has been saved!";
            
            if(productId.HasValue)
            {
                ProductAttributes = new ProductAttributes();
                ProductAttributes.ProductId = productId.Value;
                ProductAttributes.AttributeId = Attribute.Id;
                productAttributesData.Add(ProductAttributes);
                productAttributesData.Commit();
            }



            return RedirectToPage("./AttributeDetails", new { attributeId = Attribute.Id });
        }
    }
}