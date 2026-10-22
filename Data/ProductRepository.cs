using ProductsApi.Models;

namespace ProductsApi.Data;

// Shared by every API version: the data layer and domain logic stay the same.
public class ProductRepository
{
    private readonly List<Category> _categories = new()
    {
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Books" }
    };

    private readonly List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>
        {
            new() { Id = 1, Name = "Laptop", Price = 25000, CategoryId = 1 },
            new() { Id = 2, Name = "Phone", Price = 12000, CategoryId = 1 },
            new() { Id = 3, Name = "Clean Code", Price = 600, CategoryId = 2 }
        };

        foreach (var p in _products)
            p.Category = _categories.First(c => c.Id == p.CategoryId);
    }

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
}
