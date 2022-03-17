using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.EF;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Product> UpsertProductAsync(Product product)
        {
            var productFromDb = await this.GetProductAsync(product.Id).ConfigureAwait(false);

            if (productFromDb != null)
            {
                productFromDb.Name = product.Name;
                productFromDb.Price = product.Price;

                this.context.Products.Update(productFromDb);
            }
            else
            {
                await this.context.Products.AddAsync(product).ConfigureAwait(false);
            }

            await this.context.SaveChangesAsync().ConfigureAwait(false);

            if (productFromDb != null)
            {
                return productFromDb;
            }
            else
            {
                return product;
            }
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await this.context.FindAsync<Product>(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this.context.Products.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
    }
}