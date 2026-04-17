// We will not return full Products list (to avoid cycles)

namespace ProductApi.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Optional: lightweight product info
        public List<string> ProductNames { get; set; } = new List<string>();
    }
}