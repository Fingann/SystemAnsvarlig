using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using MongoDB.Bson;

    public abstract class MongoClass : IMongoID
    {
        public string Id { get; set; }
    }
}
