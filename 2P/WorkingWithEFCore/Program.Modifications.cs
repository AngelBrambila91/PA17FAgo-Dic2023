using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{
    // READ
    static void ListProducts(int[]? productsToHiglight = null)
    {
        using (Northwind db = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Cost", "Stock", "Disc");
            foreach (var product in db.Products)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((productsToHiglight is not null) && productsToHiglight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Red;
                }
                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4}",
                product.ProductId, product.ProductName, product.Cost, product.Stock, product.Discontinued);
                ForegroundColor = backgroundColor;
            }
        }
    }

    // Insert , Create
    static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };

            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State} ProductId: {p.ProductId}" );
            // SAVE THE CHANGES ON DB
            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State} ProductId: {p.ProductId}" );
            return (affected, p.ProductId);
        }
    }

    // UPDATE
    // If you do the Update First you got the delete because the delete is the simpler way to update
    static (int affected, int productId) UpdateProductPrice(string productNameStartWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            // Get the first product that start with productNameStartWith
            Product updateProdcut =
            db.Products.First(
                p => p.ProductName.StartsWith(productNameStartWith));
            updateProdcut.Cost = amount;
            int affected = db.SaveChanges();
            return (affected, updateProdcut.ProductId);
        }
    }


    static (int affected, int[]? productsId) UpdateProductPriceBetter(string productNameStartWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,null);
            // Get the first product that start with productNameStartWith
            IQueryable<Product>? products =
            db.Products.Where(
                p => p.ProductName.StartsWith(productNameStartWith));
            int affected = products.ExecuteUpdate(u => u.SetProperty(
                p => p.Cost, // Property Selctor
                p => p.Cost + amount // Value to edit
            ));
            int[] productIds = products.Select( p => p.ProductId).ToArray();
            return (affected, productIds);
        }
    }

    // DELETE
    static int DeleteProducts(string productNameStartWith)
    {
        using(Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName.StartsWith(productNameStartWith));
            if(products is null || !products.Any())
            {
                WriteLine("No products to delete");
                return 0;
            }
            else
            {
                if( db.Products is null) return 0;
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            return affected;
            
        }
    }
    
    // Better Delete
    static int DeleteProductsBetter(string productNameStartWith)
    {
        using(Northwind db = new())
        {
            int affected = 0;
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName.StartsWith(productNameStartWith));
            if(products is null || !products.Any())
            {
                WriteLine("No products to delete");
                return 0;
            }
            else
            {
                affected = products.ExecuteDelete();
            }
            return affected;
            
        }
    }
}