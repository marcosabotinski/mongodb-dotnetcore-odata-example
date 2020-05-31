using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using mongodb_dotnetcore_odata_example.Repositories;

namespace mongodb_dotnetcore_odata_example.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static void RegisterMongoClient(this Microsoft.Extensions.DependencyInjection.IServiceCollection servicesBuilder)
        {
            servicesBuilder.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var uri = s.GetRequiredService<IConfiguration>().GetValue<string>("MongoUri");
                var settings = MongoClientSettings.FromConnectionString(uri);
                return new MongoClient(settings);
            });
        }
        public static void RegisterMongoDbRepositories(this Microsoft.Extensions.DependencyInjection.IServiceCollection servicesBuilder)
        {
            servicesBuilder.AddSingleton<CustomerRepository>(s => 
            {
                var mongoClient = s.GetRequiredService<IMongoClient>();
                var databaseName = s.GetRequiredService<IConfiguration>().GetValue<string>("DatabaseName");
                return new CustomerRepository(mongoClient, databaseName);
            });
            //add additional repositories >>here<<
        }
    }
}