using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        new Product Get(int productId);
    }
}
