using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class Product : BaseEntity
    {
        public string name { get; set; }
        public double price { get; set; }
    }
}
