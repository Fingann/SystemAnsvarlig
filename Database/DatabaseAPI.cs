using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using System.Linq.Expressions;
    using System.Net.Mime;

    


    
  

    public class DatabaseAPI
    {

        //protected static IMongoClient _client;

        //protected static IMongoDatabase _database;

        //protected static IMongoCollection<SystemApplication> _collection;

        //public DatabaseAPI()
        //{
        //    _client = new MongoClient("mongodb://10.110.3.157");
        //    _database = _client.GetDatabase("SystemAnsvarlig");
        //    _collection = _database.GetCollection<SystemApplication>("Applications");
        //}


        //public void Insert(IApplication application)
        //{
            
        //    _collection.InsertOne(application as SystemApplication);
          
        //}

        //public List<IApplication> Get()
        //{
        //    var g = _collection.AsQueryable().Select(x => x as IApplication).ToList();
        //    return g;
        //}

       
        //public List<IApplication> GetWhere(Func<SystemApplication,bool> predicat)
        //{
        //    var g = _collection.AsQueryable().Select(x => x).Where(predicat).ToList<IApplication>();
        //    return g;
        //}

        ////public bool Replace(IApplication application)
        ////{
        ////    var filter = Builders<SystemApplication>.Filter.Eq(x => x.ID, (application as SystemApplication).ID);
        ////    return  _collection.ReplaceOne(x =>x.ID == application.ID, application as SystemApplication).IsAcknowledged;
        ////}

        ////public bool Delete(IApplication application)
        ////{
        ////    var filter = Builders<SystemApplication>.Filter.Eq(x => x.ID, (application as SystemApplication).ID);
            
        ////    return _collection.DeleteOne(filter).IsAcknowledged;
        ////}
        











}
}
