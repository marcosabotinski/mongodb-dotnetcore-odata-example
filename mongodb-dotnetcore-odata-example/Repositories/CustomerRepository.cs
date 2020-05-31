using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;
using System.Linq;
using mongodb_dotnetcore_odata_example.Models;

namespace mongodb_dotnetcore_odata_example.Repositories 
{
    public class CustomerRepository 
    {
        private readonly IMongoCollection<Customer> _customersCollection;

        public CustomerRepository(IMongoClient mongoClient, string databaseName = "demo", string customerCollectionName = "customers")
        {
            var camelCaseConvention = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            _customersCollection = mongoClient.GetDatabase(databaseName).GetCollection<Customer>(customerCollectionName);

        }

        public IQueryable<Customer> GetQueryableCollection() 
        {
            return _customersCollection.AsQueryable<Customer>();
        }

    }

}