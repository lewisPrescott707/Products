using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {

        public ProductsRepository(GenericRepoDBContext context) : base(context)
        {
        }

        public override Product Get(int productId)
        {
            var query = GetAll().FirstOrDefault(b => b.Id == productId);
            return query;
        }

        public async Task<Product> GetSingleAsyn(int blogId)
        {
            return await _context.Set<Product>().FindAsync(blogId);
        }

        public override Product Update(Product t, object key)
        {
            Product exist = _context.Set<Product>().Find(key);
            if (exist != null)
            {
                t.AddedDate = exist.AddedDate;
            }
            return base.Update(t, key);
        }

        public async override Task<Product> UpdateAsyn(Product t, object key)
        {
            Product exist = await _context.Set<Product>().FindAsync(key);
            if (exist != null)
            {
                t.AddedDate = exist.AddedDate;
            }
            return await base.UpdateAsyn(t, key);
        }

    }
}
