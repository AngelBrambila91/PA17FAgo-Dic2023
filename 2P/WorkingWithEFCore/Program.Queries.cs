using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            Sectiontitle($"Categories and how many products they have");
            // Select all Categories -> SELECT * FROM Categories
            // Products that belong to each category JOIN
            // Products COUNT

            // All queries must be a IQueryable object
            IQueryable<Category> categories = db.Categories;
            //.Include(category => category.Products);
            db.ChangeTracker.LazyLoadingEnabled = false;
            if ((categories is null) || !categories.Any())
            {
                Fail("No categories found");
                return;
            }
            // Use the data
            foreach (var category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products");
            }
        }// close the db Connection
    }

    static void FilterIncludes()
    {
        using (Northwind db = new())
        {
            Sectiontitle($"Products with a minimun of stock.");
            // Select fro Products WHERE

            string input;
            int stock;

            do
            {
                Write("Enter a minimum for units in stock");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));

            // All queries must be a IQueryable object
            IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products.Where(p => p.Stock >= stock));

            if ((categories is null) || !categories.Any())
            {
                Fail("No categories found");
                return;
            }
            // Use the data
            foreach (var category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimun of {stock} units in stock");
                foreach (var product in category.Products)
                {
                    WriteLine($"{product.ProductName} has {product.Stock} units in stock");
                }
            }
        }
    }

    static void QueryingProducts()
    {
        using (Northwind db = new())
        {
            Sectiontitle($"Products that cost more than a price, highest at top.");
            // Select fro Products WHERE

            string input;
            decimal price;

            do
            {
                Write("Enter a product price : ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));

            // All queries must be a IQueryable object
            IQueryable<Product>? products = db.Products?
            .Where(p => p.Cost >= price)
            .OrderByDescending(product => product.Cost);

            Info($"ToQueryString : {products.ToQueryString()}");

            if ((products is null) || !products.Any())
            {
                Fail("No products found");
                return;
            }
            // Use the data
            foreach (var product in products)
            {
                WriteLine($"{product.ProductId}, {product.ProductName} cost {product.Cost: #,##0.00} and has {product.Stock} units in stock");
            }
        }
    }

    static void QueryingWithLike()
    {
        using (Northwind db = new())
        {
            Sectiontitle($"Pattern Matching with LIKE");
            // Select fro Products WHERE

            string input = ReadLine();
            if(string.IsNullOrWhiteSpace(input))
            {
                Fail("You did not enter a product name");
                return;
            }
            IQueryable<Product> products = db.Products?
            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

            Info($"ToQueryString : {products.ToQueryString()}");

            if ((products is null) || !products.Any())
            {
                Fail("No products found");
                return;
            }
            // Use the data
            foreach (var product in products)
            {
                WriteLine($"{product.ProductName} has {product.Stock} units in stock. Discontinued? {product.Discontinued}");
            }
        }
    }

    static void GetRandomProduct()
    {
        using (Northwind db = new())
        {
            Sectiontitle("Get a Random product");
            int? rowCount = db.Products.Count();
            if(rowCount is null)
            {
                Fail("Products table is empty");
                return; 
            }
            Product? p = db.Products?.
            FirstOrDefault(p => p.ProductId == (int)(EF.Functions.Random() * rowCount));
            if(p is null)
            {
                Fail("Product not found");
                return;
            }
            WriteLine($"Random product: {p.ProductId} {p.ProductName}");
        }
    }

    // Loads
    // Eager Loading: Load data early -> Load all entities at start. -> All loaded , memory excess
    // Lazy Loading: Load data automatically just before its needed. -> Memory efficient, if table is big enough it delays
    // Explicit Loading: Load data manually
}