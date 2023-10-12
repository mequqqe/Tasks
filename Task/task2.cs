using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}

public class ProductCategory
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product A" },
            new Product { ProductId = 2, ProductName = "Product B" },
            new Product { ProductId = 3, ProductName = "Product C" }
        };

        List<Category> categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Category X" },
            new Category { CategoryId = 2, CategoryName = "Category Y" }
        };

        List<ProductCategory> productCategories = new List<ProductCategory>
        {
            new ProductCategory { ProductId = 1, CategoryId = 1 },
            new ProductCategory { ProductId = 2, CategoryId = 2 },
            new ProductCategory { ProductId = 3, CategoryId = 1 },
        };

        var query = from product in products
                    join pc in productCategories on product.ProductId equals pc.ProductId into gj
                    from subCategory in gj.DefaultIfEmpty()
                    join category in categories on subCategory?.CategoryId ?? -1 equals category.CategoryId into gj2
                    from subCategory2 in gj2.DefaultIfEmpty()
                    select new
                    {
                        ProductName = product.ProductName,
                        CategoryName = subCategory2?.CategoryName
                    };

        foreach (var result in query)
        {
            Console.WriteLine($"Product: {result.ProductName}, Category: {result.CategoryName ?? "No Category"}");
        }
    }
}

