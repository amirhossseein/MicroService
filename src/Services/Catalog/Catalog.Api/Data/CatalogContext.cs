using Catalog.Api.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        private AppSettings appSettings;
        public CatalogContext(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
             var client = new MongoClient(appSettings.ConnectionString); 
             var database = client.GetDatabase(appSettings.DatabaseName);

            Products = database.GetCollection<Product>(appSettings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
