using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        [MinLength(2)]
        public string Name {get; set;} = string.Empty;
        [Range(1, 1000000)]
        public double Price {get; set;}
        public string? Description {get; set;}

        [Required]
        public int CategoryId {get; set;}
    }
}