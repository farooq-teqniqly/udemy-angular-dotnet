using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Entities;

namespace Api.Repositories
{
    public interface IProductRepository
    {
        Task<Product> UpsertProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string id);
    }
}