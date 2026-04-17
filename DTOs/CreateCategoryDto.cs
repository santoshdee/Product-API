using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name {get; set;} = string.Empty;
    }
}