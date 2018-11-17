namespace AppName.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}