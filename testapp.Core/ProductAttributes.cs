using System.ComponentModel.DataAnnotations;

namespace testapp.Core
{
    public class ProductAttributes
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AttributeId { get; set; }
    }
}
