using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public interface IMongoID 
    {
        [BsonId]
        string Id { get; set; } 
    }
    
}
