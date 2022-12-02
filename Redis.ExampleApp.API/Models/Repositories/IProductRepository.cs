using System;
namespace Redis.ExampleApp.API.Models.Repositories
{
	public interface IProductRepository
	{
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int Id);

        Task<Product> CreateAsync(Product product);
    }
}

