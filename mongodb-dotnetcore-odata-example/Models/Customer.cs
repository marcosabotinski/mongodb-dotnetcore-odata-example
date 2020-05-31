using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_dotnetcore_odata_example.Models
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string EMail { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

    }
}
