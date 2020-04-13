using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using testapp.Core;
using testapp.Database;

namespace testapp.Pages.XNAV
{
    public class ListModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IAttributeData attributeData;

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Core.Attribute> Attributes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchProductTerm { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchAttributeTerm { get; set; }

        public ListModel(IProductData productData, IAttributeData attributeData)
        {
            this.productData = productData;
            this.attributeData = attributeData;
        }

        public void OnGet()
        {
            Products = productData.GetProductsByName(SearchProductTerm);
            Attributes = attributeData.GetAttributesByName(SearchAttributeTerm);
        }
    }
}