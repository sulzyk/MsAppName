using System.Collections.Generic;

namespace AppName.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}