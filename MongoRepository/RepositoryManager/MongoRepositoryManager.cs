﻿namespace MongoRepository
{
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // TODO: Code coverage here is near-zero. A new RepoManagerTests.cs class needs to be created and we need to
    //      test these methods. Ofcourse we also need to update codeplex documentation on this entirely new object.
    //      This is a work-in-progress.

    // TODO: GetStats(), Validate(), GetIndexes and EnsureIndexes(IMongoIndexKeys, IMongoIndexOptions) "leak"
    //      MongoDb-specific details. These probably need to get wrapped in MongoRepository specific objects to hide
    //      MongoDb.

    /// <summary>
    /// Deals with the collections of entities in MongoDb. This class tries to hide as much MongoDb-specific details
    /// as possible but it's not 100% *yet*. It is a very thin wrapper around most methods on MongoDb's MongoCollection
    /// objects.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository to manage.</typeparam>
    /// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
    public class MongoRepositoryManager<T, TKey> : IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        /// <summary>
        /// MongoCollection field.
        /// </summary>
        private IMongoCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// Uses the Default App/Web.Config connectionstrings to fetch the connectionString and Database name.
        /// </summary>
        /// <remarks>Default constructor defaults to "MongoServerSettings" key for connectionstring.</remarks>
        public MongoRepositoryManager()
            : this(Util<TKey>.GetDefaultConnectionString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use for connecting to MongoDB.</param>
        public MongoRepositoryManager(string connectionString)
        {
            this.collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use for connecting to MongoDB.</param>
        /// <param name="collectionName">The name of the collection to use.</param>
        public MongoRepositoryManager(string connectionString, string collectionName)
        {
            this.collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
        }

        /// <summary>
        /// Gets a value indicating whether the collection already exists.
        /// </summary>
        /// <value>Returns true when the collection already exists, false otherwise.</value>
        public virtual bool Exists
        {
            get { return this.collection.Count(x => x.Id != null) > 0; }
        }

        /// <summary>
        /// Gets the name of the collection as Mongo uses.
        /// </summary>
        /// <value>The name of the collection as Mongo uses.</value>
        public virtual string Name
        {
            get { return this.collection.CollectionNamespace.FullName; }
        }

        /// <summary>
        /// Drops the collection.
        /// </summary>
        public virtual void Drop()
        {
            this.collection.Database.DropCollection(Name);
        }

      
     
    }

    /// <summary>
    /// Deals with the collections of entities in MongoDb. This class tries to hide as much MongoDb-specific details
    /// as possible but it's not 100% *yet*. It is a very thin wrapper around most methods on MongoDb's MongoCollection
    /// objects.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository to manage.</typeparam>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public class MongoRepositoryManager<T> : MongoRepositoryManager<T, string>, IRepositoryManager<T>
        where T : IEntity<string>
    {
        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// Uses the Default App/Web.Config connectionstrings to fetch the connectionString and Database name.
        /// </summary>
        /// <remarks>Default constructor defaults to "MongoServerSettings" key for connectionstring.</remarks>
        public MongoRepositoryManager()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use for connecting to MongoDB.</param>
        public MongoRepositoryManager(string connectionString)
            : base(connectionString) { }

        /// <summary>
        /// Initializes a new instance of the MongoRepositoryManager class.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use for connecting to MongoDB.</param>
        /// <param name="collectionName">The name of the collection to use.</param>
        public MongoRepositoryManager(string connectionString, string collectionName)
            : base(connectionString, collectionName) { }
    }
}
