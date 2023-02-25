using Catalog.Api.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<AppSettings> options)
        {
             var client = new MongoClient(options.Value.ConnectionString); 
             var database = client.GetDatabase(options.Value.DatabaseName);

            Products = database.GetCollection<Product>(options.Value.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
