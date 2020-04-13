using System.ComponentModel.DataAnnotations;

namespace testapp.Core
{
    public class Attribute
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //this value is optional
        public string Value { get; set; }
    }
}


//my line of thinking: add a 'tag' to a product (which might also have a value associated with it). This you can tag a product
//as 'DTP TRANSMITTER' or 'Input 6' with the value of 'HDMI'.