namespace AsyncDbUpdaterShared;

public class Product : BaseModel
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public Product(string title, decimal price, string description, string category)
    {
        Title = title;
        Price = price;
        Description = description; 
        Category = category;
    }
}

