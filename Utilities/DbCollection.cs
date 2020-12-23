using DishesTask.Models;
using MongoDB.Driver;

namespace DishesTask.Utilities
{
    public static class DbCollection
    {
        /// <summary>
        /// Ruft die Collection aus der Datenbank ab.
        /// </summary>
        /// <param name="dbClient">der Client.</param>
        /// <returns>die Datenbank-Collection.</returns>
        public static IMongoCollection<Dishes> GetCollection(MongoClient dbClient)
        {
            var db = dbClient.GetDatabase("dirs_task_db");
            var collection = db.GetCollection<Dishes>("task_dishes");
            return collection;
        }
    }
}