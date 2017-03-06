using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using System.Linq.Expressions;

    using MongoDB.Driver;

    public class MongoRepository  : IRepository<MongoClass>
    {
    
        protected static IMongoClient _client;

        protected static IMongoDatabase _database;

        protected static IMongoCollection<MongoClass> _collection;

        private string DatabaseName; 

        public MongoRepository(string databaseName, string CollectionName) {

            _client = new MongoClient("mongodb://10.110.3.157");
            DatabaseName = databaseName;
            _database = _client.GetDatabase(DatabaseName);
            _collection = _database.GetCollection<MongoClass>(CollectionName);
        }

        public void Delete(Expression<Func<MongoClass, bool>> expression)
        {
            _collection.DeleteMany(expression);
        }

        public void Delete(MongoClass item)
        {
            _collection.DeleteOne(x => x.Id == item.Id);
        }

        public void DropDatabase()
        {
            _database.DropCollection(DatabaseName);
           
        }


        public MongoClass Single(Expression<Func<MongoClass, bool>> expression)
        {
            //fjerne single 
            var collection = this.All().Where(expression).ToList();

            return collection.Single();
           
        }
        public IEnumerable<MongoClass> Find(Expression<Func<MongoClass, bool>> expression)
        {
            var collection = this.All().Where(expression);

            return collection;

        }

        public IQueryable<MongoClass> All()
        {
            return _collection.AsQueryable();
            
        }

        public void Add(MongoClass item)
        {
            _collection.InsertOne(item);
            
        }

        public void Add(IEnumerable<MongoClass> items)
        {
           _collection.InsertMany(items);
        }

        public void UpdateOrAdd(MongoClass item)
        {
            _collection.UpdateOne(x => x.Id == item.Id, );
        }
    }
}
