namespace MongoRepository
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using System;

    /// <summary>
    /// IRepositoryManager definition.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository to manage.</typeparam>
    /// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
    public interface IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        /// <summary>
        /// Gets a value indicating whether the collection already exists.
        /// </summary>
        /// <value>Returns true when the collection already exists, false otherwise.</value>
        bool Exists { get; }

        /// <summary>
        /// Gets the name of the collection as Mongo uses.
        /// </summary>
        /// <value>The name of the collection as Mongo uses.</value>
        string Name { get; }

        /// <summary>
        /// Drops the repository.
        /// </summary>
        void Drop();


    }

    /// <summary>
    /// IRepositoryManager definition.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository to manage.</typeparam>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public interface IRepositoryManager<T> : IRepositoryManager<T, string>
        where T : IEntity<string> { }
}
