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
    public class AttributeDeleteModel : PageModel
    {
        private readonly IAttributeData attributeData;
        private readonly IProductAttributesData productAttributesData;

        public Core.Attribute Attribute { get; set; }
        public ProductAttributes ProductAttributes { get; set; }

        public AttributeDeleteModel(IAttributeData attributeData, IProductAttributesData productAttributesData)
        {
            this.attributeData = attributeData;
            this.productAttributesData = productAttributesData;
        }

        public IActionResult OnGet(int attributeId)
        {
            Attribute = attributeData.GetById(attributeId);
            if(Attribute == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPost(int attributeId)
        {
            var Attribute = attributeData.Delete(attributeId);
            var removedId = productAttributesData.DeleteAttribute(attributeId);

            attributeData.Commit();
            productAttributesData.Commit();

            if(Attribute == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = "Attribute Deleted!";
            return RedirectToPage("./List");
        }
    }
}