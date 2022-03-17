using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entities;

namespace Api.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public Task<Product> UpsertProductAsync(Product product)
        {
            if (this.products.ContainsKey(product.Id))
            {
                this.products[product.Id] = product;
            }
            else
            {
                this.products.Add(product.Id, product);
            }

            return Task.FromResult<Product>(product);
        }

        public Task<Product> GetProductAsync(string id)
        {
            if (this.products.ContainsKey(id))
            {
                return Task.FromResult<Product>(this.products[id]);
            }

            return Task.FromResult<Product>(null);
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(this.products.Select(kvp => kvp.Value));
        }
    }
}