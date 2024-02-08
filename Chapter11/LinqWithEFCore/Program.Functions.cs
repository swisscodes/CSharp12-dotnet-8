using Northwind.EntityModels; // To use NorthwindDb, Category, Product.
using Microsoft.EntityFrameworkCore; // To use DbSet<T>.
partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");
        using NorthwindDb db = new();
        DbSet<Product> allProducts = db.Products;
        IQueryable<Product> filteredProducts = allProducts.Where(product => product.UnitPrice < 10M);
        IOrderedQueryable<Product> sortedAndFilteredProducts =
        filteredProducts.OrderByDescending(product => product.UnitPrice);

        var projectedProducts = sortedAndFilteredProducts
            .Select(product => new // Anonymous type.
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice
            });

        Console.WriteLine("Products that cost less than $10:");
        Console.WriteLine(projectedProducts.ToQueryString());
        foreach (var p in projectedProducts)
        {
            Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }
        Console.WriteLine();
    }


    private static void JoinCategoriesAndProducts()
    {
        SectionTitle("Join categories and products");
        using NorthwindDb db = new();
        // Join every product to its category to return 77 matches.
        var queryJoin = db.Categories.Join(
        inner: db.Products,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, p) =>
        new { c.CategoryName, p.ProductName, p.ProductId })
            .OrderBy(cp => cp.CategoryName);

        Console.WriteLine(queryJoin.ToQueryString());
        foreach (var p in queryJoin)
        {
            Console.WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}.");
        }
    }

    private static void GroupJoinCategoriesAndProducts()
    {
        SectionTitle("Group join categories and products");
        using NorthwindDb db = new();
        // Group all products by their category to return 8 matches.
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, matchingProducts) => new
            {
                c.CategoryName,
                Products = matchingProducts.OrderBy(p => p.ProductName)
            });
        foreach (var c in queryGroup)
        {
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");
            foreach (var product in c.Products)
            {
                Console.WriteLine($" {product.ProductName}");
            }
        }
    }


    private static void ProductsLookup()
    {
        SectionTitle("Products lookup");
        using NorthwindDb db = new();
        // Join all products to their category to return 77 matches.
        var productQuery = db.Categories.Join(
        inner: db.Products,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, p) => new { c.CategoryName, Product = p });
        ILookup<string, Product> productLookup = productQuery.ToLookup(
        keySelector: cp => cp.CategoryName,
        elementSelector: cp => cp.Product);
        Console.WriteLine(productQuery.ToQueryString());
        foreach (IGrouping<string, Product> group in productLookup)
        {
            // Key is Beverages, Condiments, and so on.
            Console.WriteLine($"{group.Key} has {group.Count()} products.");
            foreach (Product product in group)
            {
                Console.WriteLine($" {product.ProductName}");
            }
        }
        // We can look up the products by a category name.
        Console.Write("Enter a category name: ");
        string categoryName = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine($"Products in {categoryName}:");
        IEnumerable<Product> productsInCategory = productLookup[categoryName];
        foreach (Product product in productsInCategory)
        {
            Console.WriteLine($" {product.ProductName}");
        }
    }

}
