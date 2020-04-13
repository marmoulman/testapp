using System.ComponentModel.DataAnnotations;

namespace testapp.Core
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }

        public double Price { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
