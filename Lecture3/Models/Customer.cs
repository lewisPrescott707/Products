using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
