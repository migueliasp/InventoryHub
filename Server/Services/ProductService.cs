/*
 * Product Data Service - Centralized data management
 * REFACTORING: Eliminates hardcoded data and provides extensible data layer
 */

using Server.Models;

namespace Server.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
}

public class ProductService : IProductService
{
    // REFACTORING: Centralized sample data - easily replaceable with database calls
    private static readonly List<Product> SampleProducts = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50m,
            Stock = 25,
            Category = new Category { Id = 1, Name = "Electronics" }
        },
        new Product
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00m,
            Stock = 100,
            Category = new Category { Id = 1, Name = "Electronics" }
        },
        new Product
        {
            Id = 3,
            Name = "Wireless Mouse",
            Price = 25.99m,
            Stock = 75,
            Category = new Category { Id = 1, Name = "Electronics" }
        },
        new Product
        {
            Id = 4,
            Name = "Office Chair",
            Price = 199.99m,
            Stock = 15,
            Category = new Category { Id = 2, Name = "Furniture" }
        }
    };
    
    /// <summary>
    /// Gets all products - easily extensible to database access
    /// REFACTORING: Centralized data access pattern
    /// </summary>
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        // Simulate async database call
        await Task.Delay(10); // Small delay to simulate real async operation
        return SampleProducts;
    }
}