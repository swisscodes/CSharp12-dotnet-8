using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using NorthwindModel;

namespace NorthwindWebApi.Repositories;

public class CustomerRepository(NorthwindContext db, IMemoryCache memoryCache) : ICustomerRepository
{

    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };
    // Use an instance data context field because it should not be
    // cached due to the data context having internal caching.

    public async Task<Customer?> CreateAsync(Customer c)
    {
        c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

        // Add to database using EF Core.
        EntityEntry<Customer> added = await db.Customers.AddAsync(c);
        int affected = await db.SaveChangesAsync();
        if (affected == 1)
        {
            // If saved to database then store in cache.
            memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
            return c;
        }
        return null;
    }

    public Task<Customer[]> RetrieveAllAsync()
    {
        return db.Customers.ToArrayAsync();
    }


    public Task<Customer?> RetrieveAsync(string id)
    {
        id = id.ToUpper(); // Normalize to uppercase.
                           // Try to get from the cache first.
        if (memoryCache.TryGetValue(id, out Customer? fromCache))
            return Task.FromResult(fromCache);
        // If not in the cache, then try to get it from the database.
        Customer? fromDb = db.Customers.FirstOrDefault(c => c.CustomerId == id);
        // If not -in database then return null result.
        if (fromDb is null) return Task.FromResult(fromDb);
        // If in the database, then store in the cache and return customer.
        memoryCache.Set(fromDb.CustomerId, fromDb, _cacheEntryOptions);
        return Task.FromResult(fromDb)!;
    }


    public async Task<Customer?> UpdateAsync(Customer c)
    {
        c.CustomerId = c.CustomerId.ToUpper();
        db.Customers.Update(c);
        int affected = await db.SaveChangesAsync();
        if (affected == 1)
        {
            memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
            return c;
        }
        return null;
    }

    public async Task<bool?> DeleteAsync(string id)
    {
        id = id.ToUpper();
        Customer? c = await db.Customers.FindAsync(id);
        if (c is null) return null;
        db.Customers.Remove(c);
        int affected = await db.SaveChangesAsync();
        if (affected == 1)
        {
            memoryCache.Remove(c.CustomerId);
            return true;
        }
        return null;
    }

}
