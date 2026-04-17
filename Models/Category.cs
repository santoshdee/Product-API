namespace ProductApi.Models
{
    public class Category
    {
        public int Id {get; set;}   // primary key
        public string Name {get; set;} = string.Empty;

        // Navigation property (1 Category -> Many Products)
        public List<Product> Products {get; set;} = [];
    }
}

// Category has many Products