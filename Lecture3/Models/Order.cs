using System.Collections.Generic;

namespace Lecture3.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new List<Product>();
        }

        public string Date { get; set; }
        public Product Module { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}