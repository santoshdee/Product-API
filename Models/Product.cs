namespace ProductApi.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public double Price {get; set;}
        public string? Description {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        // Foreign Key
        public int CategoryId {get; set;}

        // Navigation property
        public Category? Category {get; set;}
    }
}

// Product belongs to Category